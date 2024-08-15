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
        public double DieOrg2RefPadX { get; set; }//encode
        public double DieOrg2RefPadY { get; set; }//encode
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
}
