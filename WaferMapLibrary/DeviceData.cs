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
        public int PadWidth { get; set; } = 106;//像素
        public int PadHeight { get; set; } = 106;//像素
        public string PinDataPath { get; set; } = "DeviceData/0411PinData.json";
        public double NeddleTipFocusOffset { get; set; } = 60000;//neddle tip to probe card upper plate base is 6mm
        public int TipFocusXArea { get; set; } = 100;
        public int TipFocusYArea { get; set; } = 100;
        public float TipFocusExposureTime { get; set; } = 200;
        public int GetPinXArea { get; set; } = 800;
        public int GetPinYArea { get; set; } = 800;
        public float GetPinExposureTime { get; set; } = 500;
        public int PinAlingmentMode { get; set; } = 0;//0: Disable, 1:4 Pins, 2:All Pins, 3:Specific Pins
    }
    public class Probing
    {
        public double Overdrive { get; set; } = -2000;//默认负值，需要再增加
        public double ZClearance { get; set; } = -50000;//先放-5mm，默认-0.5mm
        public double ZUpPosition { get; set; } = 0;//根据Wafer和Pin的校准数据，计算两个postion，相差ZClearance
        public double ZDownPosition { get; set; } = 0;//根据Wafer和Pin的校准数据，计算两个postion，相差ZClearance
        public double FirstContactHeight { get; set; } = 0;//FistContactHeight - RefPinZ 通常小于等于0
        public double AllContactHeight { get; set; } = 0;//AllContactHeight - RefPinZ 通常大于等于0
        public double ProbingShiftX { get; set; } = 0;
        public double ProbingShiftY { get; set; } = 0;
    }
    public class ProbeMarkInspection
    {
        public int Threshold { get; set; } = 150;//Pad : 0 - 150 ; Mark = 150 - 255
        public int AreaPad { get; set; } = 8000;//pixel
        public int AreaMark { get; set; } = 1000;//pixel
        public int RoiWidth { get; set; } = 200;
        public int RoiHeight { get; set; } = 200;
    }
    public class DeviceDataClass
    {
        public PhysicalInformation PhysicalInformation { get; set; } = new PhysicalInformation();
        public WaferAlignment WaferAlignment { get; set; } = new WaferAlignment();
        public PinAlignment PinAlignment { get; set; } = new PinAlignment();
        public Probing Probing { get; set;} = new Probing();
        public ProbeMarkInspection ProbeMarkInspection { get; set; } = new ProbeMarkInspection();
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
