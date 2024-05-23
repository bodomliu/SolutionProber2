using System.Text.Json;

namespace WaferMapLibrary
{
    public class PhysicalInformation
    {
        public string DeviceName { get; set; } = "0411";//This is name of current device
        public int WaferSize { get; set; } = 12;//This is wafer size of current device. Value = 6/8/12
        //public double FlatAngle { get; set; } = 0;//this angle that wafer is loaded
        public double Thickness { get; set; } = 8000;//this is wafer thickness of current device
    }

    public class WaferAlignment
    {
        public string WaferMapPath { get; set; } = "DeviceData/0411WaferMap.json";
        public string DutPath { get; set; } = "DeviceData/0411Dut.json";//
        public string LowPattern1 { get; set; } = "VisionConfig/0411LowPattern1.shm";//
        public string LowPattern2 { get; set; } = "VisionConfig/0411LowPattern2.shm";//
        public string HighPattern1 { get; set; } = "VisionConfig/0411HighPattern1.shm";//
        public string HighPattern2 { get; set; } = "VisionConfig/0411HighPattern2.shm";//
    }
    public class PinAlignment
    {
        public string PadDataPath { get; set; } = "DeviceData/0411PadData.json";
        public string PadPatten { get; set; } = "VisionConfig/pad.shm";//for pad model
        public int TipFocusXArea { get; set; } = 100;
        public int TipFocusYArea { get; set; } = 100;
        public double NeddleTipFocusOffset { get; set; } = 60000;//neddle tip to probe card upper plate base is 6mm
    }
    public class DeviceDataClass
    {
        public PhysicalInformation PhysicalInformation { get; set; } = new PhysicalInformation();
        public WaferAlignment WaferAlignment { get; set; } = new WaferAlignment();
        public PinAlignment PinAlignment { get; set; } = new PinAlignment();
    }

    //静态类方便操作
    public static class DeviceData
    {
        public static DeviceDataClass Entity = new DeviceDataClass();//定义DeviceData的实体

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
            var item = JsonSerializer.Deserialize<DeviceDataClass>(jsonString);
            if (item != null) Entity = item;
        }
    }
}
