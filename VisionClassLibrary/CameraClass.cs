using HalconDotNet;
using MvCameraControl;
using System.Diagnostics;

namespace VisionLibrary;


/// <summary>
/// 图像转换完成的委托声明
/// </summary>
/// <param name="image">实参图像Hobeject</param>
public delegate void ConvertImageEventHandler(ref HObject image);

/// <summary>
/// 这是一个机器视觉应用类，控制相机和图像处理
/// </summary>
public class CameraClass
{
    /// <summary>
    /// 对图像处理部分做隔离，halcon的处理都放到这个类里面，以便后续替换图像库
    /// </summary>
    public HalconClass halconClass = new HalconClass();

    /// <summary>
    /// 相机List类
    /// </summary>
    private List<IDeviceInfo> m_DeviceList = new();

    /// <summary>
    /// 设备类型
    /// </summary>
    readonly DeviceTLayerType enumTLayerType = DeviceTLayerType.MvGigEDevice | DeviceTLayerType.MvUsbDevice
       | DeviceTLayerType.MvGenTLGigEDevice | DeviceTLayerType.MvGenTLCXPDevice | DeviceTLayerType.MvGenTLCameraLinkDevice | DeviceTLayerType.MvGenTLXoFDevice;

    /// <summary>
    /// 相机类
    /// </summary>
    public IDevice? device = null;

    /// <summary>
    /// 图像默认参数
    /// </summary>
    UInt32 m_nCurWidth = 0;
    UInt32 m_nCurHeight = 0;
    /// <summary>
    /// 像素参数
    /// </summary>
    MvGvspPixelType m_emPixelType = MvGvspPixelType.PixelType_Gvsp_Mono8;

    // ch:用于从驱动获取图像的缓存 | en:Buffer for getting image from driver
    private static Object BufForDriverLock = new Object();

    /// <summary>
    /// 图像信息
    /// </summary>
    IImage? m_pcImgForDriver = null;
    //IImageDecoder? m_pcImgSpecInfo = null;
    //IImageSaver? m_pcSaveParam = null;

    /// <summary>
    /// 采集状态的flag
    /// </summary>
    bool m_bGrabbing = false;

    /// <summary>
    /// 自动处理的busy信号 ture：正忙  false：完成
    /// </summary>
    bool m_Busy = false;

    ///// <summary>
    ///// 照片回调事件
    ///// </summary>
    //public cbOutputExdelegate cbImage = new cbOutputExdelegate(ImageCallBack);

    /// <summary>
    /// 相机的序列号
    /// </summary>
    public string? DeviceID { get; set; }

    /// <summary>
    /// 图像线程，StatGrab时开启，StopGrab时结束
    /// </summary>
    Thread? m_hReceiveThread;

    /// <summary>
    /// 获取相机曝光时间
    /// </summary>
    /// <param name="ExposureTime"></param>
    /// <returns></returns>
    public int GetExposureTime(out float ExposureTime)
    {
        ExposureTime = 0;
        IFloatValue stParam;
        if (device == null) return 1;
        int nRet = device.Parameters.GetFloatValue("ExposureTime", out stParam);
        if (MvError.MV_OK == nRet)
        {
            ExposureTime = stParam.CurValue;
        }
        return nRet;
    }

    /// <summary>
    /// 设置曝光时间
    /// </summary>
    /// <param name="ExposureTime">曝光时间</param>
    /// <returns></returns>
    public int SetExposureTime(float ExposureTime)
    {
        if (device == null) return 1;
        device.Parameters.SetEnumValue("ExposureAuto", 0);
        int nRet = device.Parameters.SetFloatValue("ExposureTime", ExposureTime);
        if (nRet != MvError.MV_OK)
        {
            //  MessageBox.Show("Set Exposure Time Fail!");
        }
        return nRet;
    }

    /// <summary>
    /// 获取心跳时间
    /// </summary>
    /// <param name="Timeout">心跳时间</param>
    /// <returns></returns>
    public int GetGevHeartbeatTimeout(out long Timeout)
    {
        Timeout = 0;
        IIntValue stParam;
        if (device == null) return 1;
        int nRet = device.Parameters.GetIntValue("GevHeartbeatTimeout", out stParam);
        if (MvError.MV_OK == nRet)
        {
            Timeout = stParam.CurValue;
        }
        return nRet;
    }

    /// <summary>
    /// 设置心跳时间
    /// </summary>
    /// <param name="Timeout">心跳时间</param>
    /// <returns></returns>
    public int SetGevHeartbeatTimeout(long Timeout)
    {
        if (Timeout < 500) return -1;
        //CIntValue stParam = new CIntValue();
        if (device == null) return 1;
        int nRet = device.Parameters.SetIntValue("GevHeartbeatTimeout", Timeout);
        if (MvError.MV_OK == nRet)
        {
            //  MessageBox.Show("Set Gev Heartbeat Timeout Fail!");
        }
        return nRet;
    }
    /// <summary>
    /// 获取设备列表
    /// </summary>
    /// <returns>序列号设备列表</returns>
    public List<string>? DeviceListAcq()
    {
        // ch:创建设备列表 || en: Create device list
        System.GC.Collect();
        List<string> DeviceList = new();
        m_DeviceList.Clear();

        int nRet = DeviceEnumerator.EnumDevices(enumTLayerType, out m_DeviceList);
        if (nRet != MvError.MV_OK)
        {
            return null;
        }

        for (int i = 0; i < m_DeviceList.Count; i++)
        {
            if (m_DeviceList[i].TLayerType == DeviceTLayerType.MvGigEDevice)
            {
                IGigEDeviceInfo gigeInfo = (IGigEDeviceInfo)m_DeviceList[i];
                DeviceList.Add(gigeInfo.SerialNumber);
            }
        }
        return DeviceList;
    }

    /// <summary>
    /// 重载打开相机
    /// </summary>
    /// <param name="serial">相机序列号</param>
    public int OpenCamera(string serial)
    {
        DeviceID = serial;
        return OpenCamera();
    }

    /// <summary>
    /// 打开相机
    /// </summary>
    /// <returns>成功回1；其他回0</returns>
    public int OpenCamera()
    {
        DeviceListAcq();
        int nRet = -1;
        if (m_bGrabbing)
        {
            CloseCamera();
            Thread.Sleep(200);
        }
        IDeviceInfo? deviceToOpen = null;
        for (int i = 0; i < m_DeviceList.Count; i++)
        {
            deviceToOpen = m_DeviceList[i];
            IGigEDeviceInfo cGigECameraInfo = (IGigEDeviceInfo)deviceToOpen;
            //存在指定序列号的gige相机
            if (cGigECameraInfo.SerialNumber == DeviceID)
            {
                if (device != null)
                    device.Close();
                // ch:打开设备 | en:Open device
                device = DeviceFactory.CreateDevice(deviceToOpen);

                nRet = device.Open();
                if (nRet != MvError.MV_OK)
                {
                    //device.Close();
                    return 0;//打开失败
                }
                device.Parameters.SetEnumValueByString("AcquisitionMode", "Continuous");
                device.Parameters.SetEnumValueByString("TriggerMode", "On");
                device.Parameters.SetEnumValueByString("TriggerSource", "Software");
                device.Parameters.SetIntValue("GevHeartbeatTimeout", 3000);
                return 1;
            }
        }
        //打开成功
        return 0;
    }

    /// <summary>
    /// 关闭相机
    /// </summary>
    public void CloseCamera()
    {
        if (device == null) return ;
        if (m_bGrabbing)
        {
            m_bGrabbing = false;
            // ch:停止抓图 || en:Stop grab image
            device.StreamGrabber.StopGrabbing();
            m_hReceiveThread?.Join();
        }
        device.Parameters.SetEnumValueByString("TriggerMode", "Off");
        device.Close();
        device.Dispose();
        m_bGrabbing = false;
    }

    /// <summary>
    /// 取图前的必要步骤
    /// </summary>
    /// <returns></returns>
    private int NecessaryOperBeforeGrab()
    {
        if (device == null) return 1;
        // ch:获取图像宽 | en:Get Image Width
        IIntValue? pcWidth = null;
        int nRet = device.Parameters.GetIntValue("Width", out pcWidth);
        if (MvError.MV_OK != nRet)
        {
            //ShowErrorMsg("Get Width Info Fail!", nRet);
            return nRet;
        }
        m_nCurWidth = (UInt32)pcWidth.CurValue;

        // ch:获取图像高 | en:Get Image Height
        IIntValue? pcHeight = null;
        nRet = device.Parameters.GetIntValue("Height", out pcHeight);
        if (MvError.MV_OK != nRet)
        {
            //ShowErrorMsg("Get Height Info Fail!", nRet);
            return nRet;
        }
        m_nCurHeight = (UInt32)pcHeight.CurValue;

        // ch:取像素格式 | en:Get Pixel Format
        IEnumValue? pcPixelFormat = null;
        nRet = device.Parameters.GetEnumValue("PixelFormat", out pcPixelFormat);
        if (MvError.MV_OK != nRet)
        {
            //ShowErrorMsg("Get Pixel Format Fail!", nRet);
            return nRet;
        }
        m_emPixelType = (MvGvspPixelType)pcPixelFormat.CurEnumEntry.Value;

        return MvError.MV_OK;
    }

    /// <summary>
    /// 开始采集
    /// </summary>
    public void StartGrab()
    {
        int nRet = NecessaryOperBeforeGrab();
        if (nRet != MvError.MV_OK)
        {
            return;
        }
        m_bGrabbing = true;

        m_hReceiveThread = new Thread(ReceiveImageWorkThread)
        {
            IsBackground = true//当进程释放时不会被阻塞
        };
        m_hReceiveThread.Start();

        int ret = device!.StreamGrabber.StopGrabbing();

        Thread.Sleep(100);
        // ch:开启抓图 | en:start grab
        nRet = device.StreamGrabber.StartGrabbing();
        if (nRet != MvError.MV_OK)
        {
            m_bGrabbing = false;
            m_hReceiveThread.Join();
            return;
        }
    }

    /// <summary>
    /// 停止采集
    /// </summary>
    public void StopGrab()
    {
        // ch:停止抓图 || en:Stop grab image
        int nRet = device!.StreamGrabber.StopGrabbing();
        if (nRet != MvError.MV_OK)
        {
            // MessageBox.Show("Stop Grabbing Fail");
        }
        m_bGrabbing = false;
    }

    /// <summary>
    /// 触发一次
    /// </summary>
    public void TriggerExec()
    {
        if (device == null) return;
        //采像开始，进程忙碌状态
        m_Busy = true;

        Debug.WriteLine(DateTime.Now.ToString() + " Trigger Execute!");
        // ch: 触发命令 || en: Trigger command
        int nRet = device.Parameters.SetCommandValue("TriggerSoftware");
        if (MvError.MV_OK != nRet)
        {
            // MessageBox.Show("Trigger Fail");
            return;
        }

        //从简处理，当单次触发时，直接阻塞线程，直到图像处理完成
        while (m_Busy)
        {
            Thread.Sleep(1);
        }
    }

    /// <summary>
    /// 连续模式
    /// </summary>
    public void ContinuesMode()
    {
        if (device == null) return;
        int nRet = MvError.MV_OK;
        nRet = device.Parameters.SetEnumValueByString("TriggerMode", "Off");
        if (nRet != MvError.MV_OK)
        {
            // MessageBox.Show("Set TriggerMode Fail");
            return;
        }
    }

    /// <summary>
    /// 单次触发模式
    /// </summary>
    public void TriggerMode()
    {
        if (device == null) return;
        int nRet = MvError.MV_OK;

        nRet = device.Parameters.SetEnumValueByString("TriggerMode", "On");
        if (nRet != MvError.MV_OK)
        {
            // MessageBox.Show("Set TriggerMode Fail");
            return;
        }
        //变更模式后加延时
        Thread.Sleep(500);
    }

    /// <summary>
    /// 后台图片线程
    /// </summary>
    public void ReceiveImageWorkThread()
    {
        int nRet = MvError.MV_OK;

        while (m_bGrabbing)
        {
            IFrameOut? pcFrameInfo = null;
            nRet = device!.StreamGrabber.GetImageBuffer(1000, out pcFrameInfo);

            if (nRet == MvError.MV_OK)
            {
                lock (BufForDriverLock)
                {
                    m_pcImgForDriver = pcFrameInfo.Image.Clone() as IImage;
                }
                //如果位获得imgForDriver直接放弃此次处理
                if (m_pcImgForDriver == null) break;

                try
                {
                    HOperatorSet.GenImage1Extern(out HObject Hobj, "byte", m_pcImgForDriver.Width, m_pcImgForDriver.Height, m_pcImgForDriver.PixelDataPtr, IntPtr.Zero);
                    //HOperatorSet.GenImage1Extern(out HObject Hobj, "byte", pcDisplayInfo.Image.Width, pcDisplayInfo.Image.Height, pcDisplayInfo.Image.ImageAddr, IntPtr.Zero);

                    //转换完成后赋值给图像
                    halconClass.m_Image = Hobj;

                    //先显示原图像
                    halconClass.HalconDisplay(Hobj, m_pcImgForDriver.Height, m_pcImgForDriver.Width);

                    m_Busy = false;
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    break;
                }

                device.StreamGrabber.FreeImageBuffer(pcFrameInfo);
            }
            else
            {
                Thread.Sleep(5);
            }
        }
    }

    //private static void ImageCallBack(IntPtr pData, ref MV_FRAME_OUT_INFO_EX pFrameInfo, IntPtr pUser)
    //{
    //    int nIndex = (int)pUser;
    //    string time = System.DateTime.Now.ToString("yyMMdd") + System.DateTime.Now.ToString("HHmmss");
    //    Console.WriteLine("one frame captured at " + time);
    //}

    /// <summary>
    /// mono格式图像的处理
    /// </summary>
    /// <param name="enType">图像色彩格式</param>
    /// <returns></returns>
    private bool IsMonoPixelFormat(MvGvspPixelType enType)
    {
        switch (enType)
        {
            case MvGvspPixelType.PixelType_Gvsp_Mono8:
            case MvGvspPixelType.PixelType_Gvsp_Mono10:
            case MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
            case MvGvspPixelType.PixelType_Gvsp_Mono12:
            case MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
                return true;
            default:
                return false;
        }
    }

    /// <summary>
    /// 彩色格式图像的处理
    /// </summary>
    /// <param name="enType">图像色彩格式</param>
    /// <returns></returns>
    private bool IsColorPixelFormat(MvGvspPixelType enType)
    {
        switch (enType)
        {
            case MvGvspPixelType.PixelType_Gvsp_RGB8_Packed:
            case MvGvspPixelType.PixelType_Gvsp_BGR8_Packed:
            case MvGvspPixelType.PixelType_Gvsp_RGBA8_Packed:
            case MvGvspPixelType.PixelType_Gvsp_BGRA8_Packed:
            case MvGvspPixelType.PixelType_Gvsp_YUV422_Packed:
            case MvGvspPixelType.PixelType_Gvsp_YUV422_YUYV_Packed:
            case MvGvspPixelType.PixelType_Gvsp_BayerGR8:
            case MvGvspPixelType.PixelType_Gvsp_BayerRG8:
            case MvGvspPixelType.PixelType_Gvsp_BayerGB8:
            case MvGvspPixelType.PixelType_Gvsp_BayerBG8:
            case MvGvspPixelType.PixelType_Gvsp_BayerGB10:
            case MvGvspPixelType.PixelType_Gvsp_BayerGB10_Packed:
            case MvGvspPixelType.PixelType_Gvsp_BayerBG10:
            case MvGvspPixelType.PixelType_Gvsp_BayerBG10_Packed:
            case MvGvspPixelType.PixelType_Gvsp_BayerRG10:
            case MvGvspPixelType.PixelType_Gvsp_BayerRG10_Packed:
            case MvGvspPixelType.PixelType_Gvsp_BayerGR10:
            case MvGvspPixelType.PixelType_Gvsp_BayerGR10_Packed:
            case MvGvspPixelType.PixelType_Gvsp_BayerGB12:
            case MvGvspPixelType.PixelType_Gvsp_BayerGB12_Packed:
            case MvGvspPixelType.PixelType_Gvsp_BayerBG12:
            case MvGvspPixelType.PixelType_Gvsp_BayerBG12_Packed:
            case MvGvspPixelType.PixelType_Gvsp_BayerRG12:
            case MvGvspPixelType.PixelType_Gvsp_BayerRG12_Packed:
            case MvGvspPixelType.PixelType_Gvsp_BayerGR12:
            case MvGvspPixelType.PixelType_Gvsp_BayerGR12_Packed:
                return true;
            default:
                return false;
        }
    }
}
