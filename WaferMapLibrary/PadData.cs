using System.Text.Json;
namespace WaferMapLibrary
{
    public class Pad
    {
        public double PosX { get; set; }
        public double PosY { get; set; }
    };
    public class PadClass
    {
        public double DieOrg2RefPadX { get; set; }
        public double DieOrg2RefPadY { get; set; }
        public int PadWidth { get; set; } = 106;
        public int PadHeight { get; set; } = 106;
        public int PadAngle { get; set; }
        public List<Pad> Pads { get; set; } = new List<Pad>();
    }
    public static class PadData
    {
        public static PadClass Entity = new();
        private static int currentIndex = 0;
        public static int CurrentIndex
        {
            get
            {
                return currentIndex;
            }
            set
            {
                currentIndex = value;
                if (OnIndexChange != null) OnIndexChange(currentIndex);
            }
        }
        public delegate void OnIndexChangeHander(int index); //定义一个委托
        public static event OnIndexChangeHander? OnIndexChange;
        public static void Load(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            var item = JsonSerializer.Deserialize<PadClass>(jsonString);
            if (item != null) Entity = item;
            //Vision.WaferHighMag.halconClass.m_Pad.Resize2(512, 640, Entity.PadWidth, Entity.PadHeight);
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
    }
    public class Pin
    {
        public double PosX { get; set; }//用户坐标系下的值Area=Probing,PinsAngle变化后，计算刷新posX
        public double PosY { get; set; }//用户坐标系下的值Area=Probing,PinsAngle变化后，计算刷新posX
        public double PosZ { get; set; }//用户坐标系下的值Area=Probing,PinsAngle变化后，计算刷新posX
        public double PresentPosX { get; set; }//直接采集到的坐标，用以和padData计算并修正PinsAngle
        public double PresentPosY { get; set; }
        public double PresentPosZ { get; set; }
        public int Result { get; set; } = 0;
        public bool Pin4Enable { get; set; }
        public bool AllpinEnable { get; set; }
    };
    public class PinClass
    {
        public double RefPinX { get; set; }//注册RefPinX encode值，为了下次快速定位refpin，理想条件下针卡为校平后的角度
        public double RefPinY { get; set; }//注册RefPinY encode值
        public double RefPinZ { get; set; }//注册RefPinZ encode值
        public double PinsAvgHeight { get; set; } = 0;//探针相机视角下当前针卡的高度，encode值，TODO：模式可以为refpin，也可以用平均值
        public double PinsAngle { get; set; } = 0;//当前针卡R偏移 encode值，距离理想条件下(与坐标轴平行)的旋转角度
                                                        //10000 = 1 degree，逆时针为正
        public List<Pin> Pins { get; set; } = new List<Pin>();//均为用户系下的坐标系下的值，Area = Probing，
                                                              //这样的好处是pin的坐标系方向和pad相同
    }
    public static class PinData
    {
        public static PinClass Entity = new();
        private static int currentIndex = 0;
        public static int CurrentIndex
        {
            get
            {
                return currentIndex;
            }
            set
            {
                currentIndex = value;
                if (OnIndexChange != null) OnIndexChange(currentIndex);
            }
        }
        public delegate void OnIndexChangeHander(int index); //定义一个委托
        public static event OnIndexChangeHander? OnIndexChange;

        public delegate void OnAlignChangeHander(bool align); //定义一个委托
        public static event OnAlignChangeHander? OnAlignChange;
        private static bool isPinAlignCompleted = false;//pinAlign
        public static bool IsPinAlignCompleted//WaferCenter未寻找
        {
            get
            {
                return isPinAlignCompleted;
            }
            set
            {
                isPinAlignCompleted = value;
                if (OnAlignChange != null) OnAlignChange(isPinAlignCompleted);
            }
        }
        public static void Load(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            var item = JsonSerializer.Deserialize<PinClass>(jsonString);
            if (item != null) Entity = item;
            //Vision.WaferHighMag.halconClass.m_Pad.Resize2(512, 640, Entity.PadWidth, Entity.PadHeight);
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
    }
}
