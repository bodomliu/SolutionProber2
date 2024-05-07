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
        public int PadWidth { get; set; } = 53;
        public int PadHeight { get; set; } = 53;
        public int PadAngle { get; set; }
        public List<Pad> Pads { get; set; } = new List<Pad>();
    }
    public static class PadData
    {
        public static PadClass Entity = new();
        public static int CurrentIndex { set; get; } = 0;
        //public static double RefDieAfterAlignX;//???
        //public static double RefDieAfterAlignY;//???

        public static void LoadPads(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            var item = JsonSerializer.Deserialize<PadClass>(jsonString);
            if (item != null) Entity = item;
            //Vision.WaferHighMag.halconClass.m_Pad.Resize2(512, 640, Entity.PadWidth, Entity.PadHeight);
        }

        public static void SavePads(string filePath)
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
