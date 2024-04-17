using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using HalconDotNet;
using MathNet.Numerics.Distributions;
using MvCamCtrl.NET;
//using Yolov7net;

namespace VisionLibrary
{
    /// <summary>
    /// 相机枚举
    /// </summary>
    public enum Camera
    {
        WaferLowMag = 0,
        WaferHighMag = 1,
        PinLowMag = 2,
        PinHighMag = 3,

        CassetteCamera = 4,
        PreAlignCamera6 = 5,
        PreAlignCamera12 = 6,
        OCRCamera = 7,

        JigCamera = 8
    }

    public class CameraInfo
    {
        public string DeviceID { get; set; } = "";
    }


    public class VisionSettings
    {

    }

    public class CameraSettings
    {
        public CameraInfo WaferLowMag { get; set; } = new();
        public CameraInfo WaferHighMag { get; set; } = new();
        public CameraInfo PinLowMag { get; set; } = new();
        public CameraInfo PinHighMag { get; set; } = new();
        public CameraInfo CassetteCamera { get; set; } = new();
        public CameraInfo PreAlignCamera6 { get; set; } = new();
        public CameraInfo PreAlignCamera12 { get; set; } = new();
        public CameraInfo OCRCamera { get; set; } = new();
        public CameraInfo JigCamera { get; set; } = new();

    }

    public class VisionConfig
    {
        public VisionSettings visionSettings { get; set; } = new();

        public CameraSettings cameraSettings { get; set; } = new();
    }

    /// <summary>
    /// 静态类，处理所有的相机和图像函数
    /// </summary>
    public static class Vision
    {
        private static VisionConfig config = new();//定义一个config
        public static List<CameraClass> CameraList = new();//定义一个相机List，方便操作相机

        public static CameraClass WaferLowMag = new();
        public static CameraClass WaferHighMag = new();
        public static CameraClass PinLowMag = new();
        public static CameraClass PinHighMag = new();

        public static CameraClass CassetteCamera = new();//晶舟相机
        public static CameraClass PreAlignCamera6 = new();//预对位相机6寸
        public static CameraClass PreAlignCamera12 = new();//预对位相机12寸
        public static CameraClass OCRCamera = new();//OCR相机

        public static CameraClass JigCamera = new();//Probe区域的标定相机

        public static HSmartWindowControl m_HSmartWindowControl = new();

        public static Camera activeCamera;//当前绑定halconwindow的相机

        /// <summary>
        /// 配置文件错误时，恢复出厂设置
        /// </summary>
        public static void ResetConfig()
        {
            config = new VisionConfig()
            {
                visionSettings = new VisionSettings(),
                cameraSettings = new CameraSettings()
                {
                    WaferLowMag = new CameraInfo() { DeviceID = "J12552370", },
                    WaferHighMag = new CameraInfo() { DeviceID = "J12552356", },
                    PinLowMag = new CameraInfo() { DeviceID = "J12552071", },
                    PinHighMag = new CameraInfo() { DeviceID = "J12552478", },
                    CassetteCamera = new CameraInfo() { DeviceID = "00J19317121", },
                    PreAlignCamera6 = new CameraInfo() { DeviceID = "00J23884366", },
                    PreAlignCamera12 = new CameraInfo() { DeviceID = "00J23884297", },
                    OCRCamera = new CameraInfo() { DeviceID = "00J23884317", },
                    JigCamera = new CameraInfo() { DeviceID = "J97114305", },
                },
            };
        }

        /// <summary>
        /// Vision初始化，载入ID，相机Open等
        /// </summary>
        public static void Initial()
        {
            LoadConfig("VisionConfig/VisionConfig.json");
            if (config == null) return;

            //将对象“按顺序”添加进CameraList
            CameraList.Add(WaferLowMag);
            CameraList.Add(WaferHighMag);
            CameraList.Add(PinLowMag);
            CameraList.Add(PinHighMag);
            CameraList.Add(CassetteCamera);
            CameraList.Add(PreAlignCamera6);
            CameraList.Add(PreAlignCamera12);
            CameraList.Add(OCRCamera);
            CameraList.Add(JigCamera);

            //对所有相机DeviceID赋值
            WaferLowMag.DeviceID = config.cameraSettings.WaferLowMag.DeviceID;
            WaferHighMag.DeviceID = config.cameraSettings.WaferHighMag.DeviceID;
            PinLowMag.DeviceID = config.cameraSettings.PinLowMag.DeviceID;
            PinHighMag.DeviceID = config.cameraSettings.PinHighMag.DeviceID;

            CassetteCamera.DeviceID = config.cameraSettings.CassetteCamera.DeviceID;
            PreAlignCamera6.DeviceID = config.cameraSettings.PreAlignCamera6.DeviceID;
            PreAlignCamera12.DeviceID = config.cameraSettings.PreAlignCamera12.DeviceID;
            OCRCamera.DeviceID = config.cameraSettings.OCRCamera.DeviceID;
            JigCamera.DeviceID = config.cameraSettings.JigCamera.DeviceID;

            //载入标定文件
            WaferLowMag.halconClass.m_Calibration.LoadHomMat2d("VisionConfig/WaferLowMag.bin");            
            WaferHighMag.halconClass.m_Calibration.LoadHomMat2d("VisionConfig/WaferHighMag.bin");
            PinLowMag.halconClass.m_Calibration.LoadHomMat2d("VisionConfig/PinLowMag.bin");
            PinHighMag.halconClass.m_Calibration.LoadHomMat2d("VisionConfig/PinHighMag.bin");
            //JigCamera.halconClass.m_Calibration.LoadHomMat2d("HighCalibration.bin");

            OpenAllCamera();
        }

        public static void OpenAllCamera()
        {
            foreach (var camera in CameraList) camera.OpenCamera();
        }

        public static void CloseAllCamera()
        {
            foreach(var camera in CameraList) camera.CloseCamera();
        }

        //public static List<string> GetCameraList()
        //{
        //    List<string> strings = new List<string>();

        //    List<CCameraInfo> m_ltDeviceList = new List<CCameraInfo>();

        //    //获取相机列表
        //    int nRet = CSystem.EnumDevices(CSystem.MV_GIGE_DEVICE, ref m_ltDeviceList);
        //    //if (m_ltDeviceList.Count == 0) return strings;

        //    for (int i = 0; i < m_ltDeviceList.Count; i++)
        //    {
        //        CGigECameraInfo gigeInfo = (CGigECameraInfo)m_ltDeviceList[i];
        //        strings.Add(gigeInfo.chSerialNumber);
        //    }
        //    return strings;
        //}

        /// <summary>
        /// 变更绑定halconWindow的相机
        /// </summary>
        /// <param name="camera"></param>
        public static void ChangeCamera(CameraClass camera)
        {
            //获取当前激活的相机
            int index = (int)activeCamera;//index初始值=-1
            CameraList[index].halconClass.DisplayWindowsUnbind();

            //绑定halconwindow
            camera.halconClass.DisplayWindowsBind(m_HSmartWindowControl);

            //相机打到连拍模式
            camera.ContinuesMode();

            //获得camera在CamraList下的编号
            activeCamera = (Camera)CameraList.IndexOf(camera);
        }

        public static void ChangeCamera(Camera camera)
        {
            int Index = (int)camera;
            ChangeCamera(CameraList[Index]);
        }

        public static void ChangeCamera(int camera)
        {
            ChangeCamera(CameraList[camera]);
        }

        public static void printInfo()
        {
            Console.WriteLine("Version 0.1");
        }

        public static void LoadConfig(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            var item = JsonSerializer.Deserialize<VisionConfig>(jsonString);
            if (item != null) config = item;
        }

        public static void SaveConfig(string filePath)
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
            };
            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
