﻿using System;
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
        public double Thickness { get; set; } = 10000;//this is wafer thickness of current device
    }

    public class DeviceDataClass
    {
        public  PhysicalInformation PhysicalInformation = new PhysicalInformation();
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
