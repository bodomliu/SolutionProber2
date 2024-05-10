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
        public double PosX { get; set; }
        public double PosY { get; set; }
    };
    public class PinClass
    {
        public double RefPinX { get; set; }//注册RefPinX encode值，为了下次快速定位refpin
        public double RefPinY { get; set; }//注册RefPinY encode值
        public double RefPinZ { get; set; }//注册RefPinZ encode值
        public List<Pin> Pins { get; set; } = new List<Pin>();
    }
    public static class PinData
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
        public static double RefPinOffsetX { get; set; } = 0;//当前针卡X偏移 encode值
        public static double RefPinOffsetY { get; set; } = 0;//当前针卡Y偏移 encode值
        public static double RefPinOffsetZ { get; set; } = 0;//当前针卡Z偏移 encode值
        public static double OffsetR { get; set; } = 0;
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
}
