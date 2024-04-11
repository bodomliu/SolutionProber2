using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Reflection;
using System.Text.Json.Serialization;

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
        public int Coordinates { get; set; }//0 = 不是坐标点，1 = 有效坐标点，2 = 需要进行标定的点
    }

    /// <summary>
    /// 代表注册的WaferMap信息
    /// </summary>
    public class WaferMapClass
    {

        public WaferMapClass()
        {
            this.WaferSize = 12;
            this.DieSizeX = 102400;
            this.DieSizeY = 102400;
        }

        private int waferSize;

        /// <summary>
        /// This is wafer size of current device. Value = 6/8/12
        /// </summary>
        [JsonPropertyOrder(1)]
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
        [JsonIgnore]
        public int WaferDiameter { get; private set; }

        private double dieSizeX = 102400;

        /// <summary>
        /// this is die size of current device; Also named Index size
        /// </summary>
        [JsonPropertyOrder(2)]
        public double DieSizeX
        {
            get { return this.dieSizeX; }
            set
            {
                this.dieSizeX = value;
                // 向上取整
                this.DieNumX = (int)Math.Ceiling((double)this.WaferDiameter / this.DieSizeX);
            }
        }
        private double dieSizeY = 102400;

        /// <summary>
        /// this is die size of current device; Also named Index size
        /// </summary>
        [JsonPropertyOrder(2)]
        public double DieSizeY
        {
            get { return this.dieSizeY; }

            set
            {
                this.dieSizeY = value;
                // 向上取整
                this.DieNumY = (int)Math.Ceiling((double)this.WaferDiameter / this.DieSizeY);
            }
        }

        private int dieNumX = 0;
        [JsonIgnore]
        public int DieNumX
        {
            get { return this.dieNumX; }
            private set
            {
                this.dieNumX = value;
                this.OriginDieX = value / 2;
            }
        }

        private int dieNumY = 0;

        [JsonIgnore]
        public int DieNumY
        {
            get { return this.dieNumY; }
            private set
            {
                this.dieNumY = value;
                this.OriginDieY = value / 2;
            }
        }
        [JsonPropertyOrder(3)]
        public int OriginDieX { get; set; } = 10;
        [JsonPropertyOrder(3)]
        public int OriginDieY { get; set; } = 10;
        public string DirectionX { get; set; } = "RIGHT";
        public string DirectionY { get; set; } = "DOWN";
        public double Center2OriginDieCornerX { get; set; } = 0;//OriginDie的Left Lower Crorner X - CenterX
        public double Center2OriginDieCornerY { get; set; } = 0;//OriginDie的Left Lower Crorner Y - CenterY
        public double Corner2PatternX { get; set; } = 0;//DiePattern - Lower Left Corner
        public double Corner2PatternY { get; set; } = 0;//DiePattern - Lower Left Corner
        public List<MappingPoint>? MappingPoints { get; set; }
    }

    /// <summary>
    /// 当前测试的这张Wafer信息
    /// </summary>
    public static class WaferMap
    {
        public static WaferMapClass Entity = new WaferMapClass();//定义WaferMap的实体
        public delegate void OnIndexChangeHander(int x,int y); //定义一个委托
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
                if (value < 0)
                    value = 0;
                else if (value >= WaferMap.Entity.DieNumX)
                    value = WaferMap.Entity.DieNumX - 1;

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
                if (value < 0)
                    value = 0;
                else if (value >= WaferMap.Entity.DieNumY)
                    value = WaferMap.Entity.DieNumY - 1;
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

        public delegate void OnAlignChangeHander(bool WaferCenter,bool LowAlign,bool HighAlign); //定义一个委托
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

        public static double WaferCenterX;//LowMag下的值 + XWAFERLOW2HIGHT：转UserPos
        public static double WaferCenterY;//LowMag下的值 + YWAFERLOW2HIGHT：转UserPos
        public static double WaferOffsetX;//HighMag下的值：实际RefDie - 注册RefDie：转UserPos
        public static double WaferOffsetY;//HighMag下的值：实际RefDie - 注册RefDie：转UserPos
        public static void Save(string filePath)
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
            };
            string jsonString = JsonSerializer.Serialize(Entity, options);
            File.WriteAllText(filePath, jsonString);
        }
        public static void Load(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            var item = JsonSerializer.Deserialize<WaferMapClass>(jsonString);
            if (item != null) Entity = item;
        }
    }
}
