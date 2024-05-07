using System.Text.Json;

namespace WaferMapLibrary
{
    /// <summary>
    /// 每一个Mapping点（Die）的信息，包括坐标和Bin状态
    /// </summary>
    public class MappingPoint
    {
        public double UserPosX { get; set; }
        public double UserPosY { get; set; }
        public double EncodeX { get; set; }
        public double EncodeY { get; set; }
        public int IndexX { get; set; }
        public int IndexY { get; set; }
        /// <summary>
        /// 0 = Not Exist;
        /// 1 = Test Die;
        /// 2 = Skip Die;
        /// 3 = Mark Die;
        /// 4 = Pass Die;
        /// 5 = Fail Die;
        /// 6 = Cur Die;
        /// 7 = Teach Die;
        /// 8 = Sample Die. 
        /// </summary>
        public int BIN { get; set; }
        public int Coordinates { get; set; }
    }
    /// <summary>
    /// 代表注册的WaferMap信息
    /// </summary>
    public class WaferMapClass
    {
        /// <summary>
        /// This is wafer size of current device. Value = 6/8/12
        /// </summary>
        private int waferSize = 12;
        public int WaferSize
        {
            get { return this.waferSize; }
            set
            {
                switch (value)
                {
                    case 6:
                        this.WaferDiameter = 150_0000;
                        break;
                    case 8:
                        this.WaferDiameter = 200_0000;
                        break;
                    case 12:
                        this.WaferDiameter = 300_0000;
                        break;
                    default:
                        throw new Exception("WaferSize must be 6/8/12");
                }
                this.waferSize = value;
            }
        }
        /// <summary>
        /// 直径
        /// </summary>
        public int WaferDiameter { get; set; } = 300_0000;
        public double DieSizeX { get; set; } = 150000;
        public double DieSizeY { get; set; } = 150000;
        public int DieNumX { get; set; } = 20;
        public int DieNumY { get; set; } = 20;
        public int RefDieX { get; set; } = 9;
        public int RefDieY { get; set; } = 9;
        public string DirectionX { get; set; } = "RIGHT";
        public string DirectionY { get; set; } = "DOWN";
        public double Center2RefDieCornerX { get; set; } = 0;//RefDie的Left Lower Crorner X - CenterX :转换到UserPos下
        public double Center2RefDieCornerY { get; set; } = 0;//RefDie的Left Lower Crorner Y - CenterY :转换到UserPos下
        public double Corner2OrgX { get; set; } = 0;//DieOrg - Lower Left Corner: 转换到UserPos下
        public double Corner2OrgY { get; set; } = 0;//DieOrg - Lower Left Corner: 转换到UserPos下
        public double Org2PatIIX { get; set; } = 0;//Die Pattern2 - DieOrg : 转换到UserPos下
        public double Org2PatIIY { get; set; } = 0;//Die Pattern2 - DieOrg : 转换到UserPos下
        public List<MappingPoint>? MappingPoints { get; set; }
    }
    /// <summary>
    /// 当前测试的这张Wafer信息
    /// </summary>
    public static class WaferMap
    {
        public static WaferMapClass Entity = new WaferMapClass();//定义WaferMap的实体
        public delegate void OnIndexChangeHander(int x, int y); //定义一个委托
        public static event OnIndexChangeHander? OnIndexChange;
        private static int currentIndexX = 0;
        public static int CurrentIndexX//当前index
        {
            get
            {
                return currentIndexX;
            }
            set
            {
                currentIndexX = value;
                if (OnIndexChange != null && !isBlockIndexChange) OnIndexChange(currentIndexX, currentIndexY);
            }
        }
        private static int currentIndexY = 0;
        public static int CurrentIndexY//当前index
        {
            get
            {
                return currentIndexY;
            }
            set
            {
                currentIndexY = value;
                if (OnIndexChange != null && !isBlockIndexChange) OnIndexChange(currentIndexX, currentIndexY);
            }
        }
        /// <summary>
        /// 是否屏蔽IndexChange事件
        /// </summary>
        private static Boolean isBlockIndexChange = false;
        /// <summary>
        /// 设置当前Index
        /// 一次性更新 x 和 y 时防止多次触发事件
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void setCurrentIndex(int x, int y)
        {
            isBlockIndexChange = true;
            CurrentIndexX = x;
            CurrentIndexY = y;
            isBlockIndexChange = false;
            if (OnIndexChange != null) OnIndexChange(currentIndexX, currentIndexY);
        }
        public delegate void OnAlignChangeHander(bool WaferCenter, bool LowAlign, bool HighAlign); //定义一个委托
        public static event OnAlignChangeHander? OnAlignChange;
        private static bool isWaferCenterCompleted = false;//晶圆圆心未寻找
        public static bool IsWaferCenterCompleted//WaferCenter未寻找
        {
            get
            {
                return isWaferCenterCompleted;
            }
            set
            {
                isWaferCenterCompleted = value;
                if (OnAlignChange != null) OnAlignChange(isWaferCenterCompleted, isLowAlignCompleted, isHighAlignCompleted);
            }
        }
        private static bool isLowAlignCompleted = false;//粗定位未完成
        public static bool IsLowAlignCompleted//精定位未完成
        {
            get
            {
                return isLowAlignCompleted;
            }
            set
            {
                isLowAlignCompleted = value;
                if (OnAlignChange != null) OnAlignChange(isWaferCenterCompleted, isLowAlignCompleted, isHighAlignCompleted);
            }
        }
        private static bool isHighAlignCompleted = false;//精定位未完成
        public static bool IsHighAlignCompleted//精定位未完成
        {
            get
            {
                return isHighAlignCompleted;
            }
            set
            {
                isHighAlignCompleted = value;
                if (OnAlignChange != null) OnAlignChange(isWaferCenterCompleted, isLowAlignCompleted, isHighAlignCompleted);
            }
        }

        public static double WaferCenterX;//LowMag下的值:转用户坐标系  只能用来做粗定位
        public static double WaferCenterY;//LowMag下的值:转用户坐标系  只能用来做粗定位
        public static double WaferOffsetX;//HighMag下的值：实际RefDie - 注册RefDie :转用户坐标系
        public static double WaferOffsetY;//HighMag下的值：实际RefDie - 注册RefDie :转用户坐标系
        /// <summary>
        /// 初始化WaferMap的DieNum和OriginNum
        /// </summary>
        /// <param name="waferSize"></param>
        /// <param name="DieSizeX"></param>
        /// <param name="DieSizeY"></param>
        public static void Initial(int waferSize, double DieSizeX, double DieSizeY)
        {
            Entity.WaferSize = waferSize;
            Entity.DieSizeX = DieSizeX;
            Entity.DieSizeY = DieSizeY;
            Entity.DieNumX = (int)Math.Ceiling(Entity.WaferDiameter / DieSizeX);
            Entity.DieNumY = (int)Math.Ceiling(Entity.WaferDiameter / DieSizeY);
            Entity.RefDieX = Entity.DieNumX / 2;
            Entity.RefDieY = Entity.DieNumY / 2;
        }
        public static void Save(string filePath)
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
            };
            string jsonString = JsonSerializer.Serialize(Entity, options);
            File.WriteAllText(filePath, jsonString);
        }

        public delegate void OnWaferMapChangeHander(); //定义一个委托
        public static event OnWaferMapChangeHander? OnWaferMapChange;
        public static void Load(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            var item = JsonSerializer.Deserialize<WaferMapClass>(jsonString);
            if (item != null)
            {
                Entity = item;
                OnWaferMapChange?.Invoke();
            }
        }
        public static int GetBIN(int indexX, int indexY)
        {
            if (Entity.MappingPoints == null) return int.MaxValue;

            var point = Entity.MappingPoints.Find(p => p.IndexX == indexX && p.IndexY == indexY);
            if (point == null) return int.MaxValue;

            return point.BIN;
        }
        public static int SetBIN(int indexX, int indexY, int bin)
        {
            if (Entity.MappingPoints == null) return 1;

            var point = Entity.MappingPoints.Find(p => p.IndexX == indexX && p.IndexY == indexY);
            if (point == null) return 2;

            //point.UserPosX = userPosX; point.UserPosY = userPosY;
            //point.EncodeX = encodeX; point.EncodeY = encodeY;
            point.BIN = bin;
            //point.Coordinates = 1;

            return 0;
        }
    }
}
