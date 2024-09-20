using System.Text.Json;
namespace WaferMapLibrary
{
    public class Pin
    {
        public double PosX { get; set; }//angle=0时encode值
        public double PosY { get; set; }//angle=0时encode值
        public double PosZ { get; set; }//angle=0时encode值
        public double CurrentPosX { get; set; }//直接采集到的坐标，用以和pos计算并修正PinsAngle
        public double CurrentPosY { get; set; }
        public double CurrentPosZ { get; set; }
        public int AlignResult { get; set; } = 0;
        public int AlignMode { get; set; } = 0;//0 = All Pins; 1 = 4 pins
        public int DUTindex { get; set; } = 0;
    };
    public class PinClass
    {
        public double RefPinX { get; set; }//注册RefPinX encode值，为了下次快速定位refpin，理想条件下针卡为校平后的角度
        public double RefPinY { get; set; }//注册RefPinY encode值
        public double RefPinZ { get; set; }//注册RefPinZ encode值
        public double PinsAvgHeight { get; set; } = 0;//探针相机视角下当前针卡的高度，encode值，TODO：模式可以为refpin，也可以用平均值
        public double PinsAngle { get; set; } = 0;//当前针卡R偏移 encode值，距离理想条件下(与坐标轴平行)的旋转角度
                                                  //10000 = 1 degree，逆时针为正
        public List<Pin> Pins { get; set; } = new List<Pin>();//考虑pin卡不会很大，直接用encode值，好处是算法简单。
                                                              //且机台encode坐标系正好是笛卡尔坐标系。
    }
    public static class PinData
    {
        public static PinClass Entity = new();
        private static int currentIndex = 0;//所有DUT里的Pin合计序列
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

        public static void ClearCurrentPos()
        {
            foreach (var pin in Entity.Pins)
            {
                pin.CurrentPosX = 0;
                pin.CurrentPosY = 0;
                pin.CurrentPosZ = 0;
                pin.AlignResult = 0;
            }
        }
    }
}
