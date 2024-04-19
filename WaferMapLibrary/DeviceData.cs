using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WaferMapLibrary
{
    public class PhysicalInformation
    {
        public string DeviceName { get; set; } = "12INCH";//This is name of current device
        public int WaferSize { get; set; } = 12;//This is wafer size of current device. Value = 6/8/12
        //public double FlatAngle { get; set; } = 0;//this angle that wafer is loaded
        public double Thickness { get; set; } = 8000;//this is wafer thickness of current device
    }

    public class WaferAlignment
    {
        public string LowPattern1 { get; set; } = "VisionConfig/0411LowPattern1.shm";//
        public string LowPattern2 { get; set; } = "VisionConfig/0411LowPattern2.shm";//
        public string HighPattern1 { get; set; } = "VisionConfig/0411HighPattern1.shm";//
        public string HighPattern2 { get; set; } = "VisionConfig/0411HighPattern2.shm";//
    }
    public class DeviceDataClass
    {
        public  PhysicalInformation PhysicalInformation { get; set; } = new PhysicalInformation();
        public WaferAlignment WaferAlignment { get; set; } = new WaferAlignment();
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
