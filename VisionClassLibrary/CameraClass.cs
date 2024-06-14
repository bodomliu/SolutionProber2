using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvCamCtrl.NET;
using HalconDotNet;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using MvCamCtrl.NET.CameraParams;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace VisionLibrary
{
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
        /// 相机List类，为了方便外面调用，直接用deviceID组成List
        /// </summary>
        private List<CCameraInfo> m_ltDeviceList = new List<CCameraInfo>();

        /// <summary>
        /// 相机类
        /// </summary>
        public CCamera m_MyCamera = new CCamera();

        /// <summary>
        /// 图像默认参数
        /// </summary>
        UInt32 m_nCurWidth = 0;
        UInt32 m_nCurHeight = 0;
        MvGvspPixelType m_emPixelType = MvGvspPixelType.PixelType_Gvsp_Mono8;

        // ch:用于从驱动获取图像的缓存 | en:Buffer for getting image from driver
        private static Object BufForDriverLock = new Object();
        CImage? m_pcImgForDriver = new CImage();        // 图像信息
        CFrameSpecInfo m_pcImgSpecInfo =new CFrameSpecInfo(); // 图像的水印信息
        CSaveImageParam m_pcSaveParam = new CSaveImageParam(); // 保存到缓存的参数信息

        /// <summary>
        /// 采集状态的flag
        /// </summary>
        bool m_bGrabbing = false;

        /// <summary>
        /// 自动处理的busy信号 ture：正忙  false：完成
        /// </summary>
        bool m_Busy =false;

        /// <summary>
        /// 照片回调事件
        /// </summary>
        public cbOutputExdelegate cbImage = new cbOutputExdelegate(ImageCallBack);
        /// <summary>
        /// 相机的序列号
        /// </summary>
        public string? DeviceID { get; set; }

        /// <summary>
        /// 图像线程，StatGrab时开启，StopGrab时结束
        /// </summary>
        Thread? m_hReceiveThread;

        //MyCamera.cbOutputExdelegate ImageCallback;
        /// <summary>
        /// 获取相机曝光时间
        /// </summary>
        public int GetExposureTime(out float ExposureTime)
        {
            ExposureTime = 0;
            CFloatValue stParam = new CFloatValue();
            int nRet = m_MyCamera.GetFloatValue("ExposureTime", ref stParam);
            if (CErrorDefine.MV_OK == nRet)
            {
                ExposureTime = stParam.CurValue;
            }
            return nRet;
        }
        public int SetExposureTime(float ExposureTime)
        {
            m_MyCamera.SetEnumValue("ExposureAuto", 0);
            int nRet = m_MyCamera.SetFloatValue("ExposureTime", ExposureTime);
            if (nRet != CErrorDefine.MV_OK)
            {
              //  MessageBox.Show("Set Exposure Time Fail!");
            }
            return nRet;
        }
        public int GetGevHeartbeatTimeout(out long Timeout)
        {
            Timeout = 0;
            CIntValue stParam = new CIntValue();
            int nRet = m_MyCamera.GetIntValue("GevHeartbeatTimeout", ref stParam);
            if (CErrorDefine.MV_OK == nRet)
            {
                Timeout = stParam.CurValue;
            }
            return nRet;
        }
        public int SetGevHeartbeatTimeout(long Timeout)
        {
            if (Timeout < 500) return -1;
            //CIntValue stParam = new CIntValue();
            int nRet = m_MyCamera.SetIntValue("GevHeartbeatTimeout", Timeout);
            if (CErrorDefine.MV_OK == nRet)
            {
                //  MessageBox.Show("Set Gev Heartbeat Timeout Fail!");
            }
            return nRet;
        }

        /// <summary>
        /// 设备列表获取
        /// </summary>
        public List<string>? DeviceListAcq()
        {
            // ch:创建设备列表 || en: Create device list
            System.GC.Collect();

            // 相机数量置零
            List<string> DeviceList = new List<string>();
            m_ltDeviceList.Clear();

            int nRet = CSystem.EnumDevices(CSystem.MV_GIGE_DEVICE | CSystem.MV_USB_DEVICE, ref m_ltDeviceList);
            if (CErrorDefine.MV_OK != nRet)
            {
              //  MessageBox.Show("Enum Devices Fail");
              return null;
            }

            // ch:枚举相机名 | en:Display device name in the form list
            for (int i = 0; i < m_ltDeviceList.Count; i++)
            {
                if (m_ltDeviceList[i].nTLayerType == CSystem.MV_GIGE_DEVICE)
                {
                    CGigECameraInfo gigeInfo = (CGigECameraInfo)m_ltDeviceList[i];
                    DeviceList.Add(gigeInfo.chSerialNumber);
                }
            }
            return DeviceList;
        }

        /// <summary>
        /// 打开相机重载
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
        public int OpenCamera()
        {
            //连接相机前，刷一遍List
            DeviceListAcq();

            int nRet = -1;
            //如果有线程正在运行，则先关闭再打开
            if (m_bGrabbing)
            {
                CloseCamera();
                Thread.Sleep(200);
            }

            CCameraInfo deviceToOpen;
            //ch:遍历设备信息 | en:Get selected device information
            for (int i = 0; i < m_ltDeviceList.Count; i++)
            {
                // ch:获取选择的设备信息 | en:Get selected device information
                deviceToOpen = m_ltDeviceList[i];
                CGigECameraInfo cGigECameraInfo = (CGigECameraInfo)deviceToOpen;//强制转换成GIGEinfo
                
                //存在指定序列号的gige相机
                if (cGigECameraInfo.chSerialNumber == DeviceID)
                {

                    // ch:打开设备 | en:Open device
                    nRet = m_MyCamera.CreateHandle(ref deviceToOpen);
                    if (CErrorDefine.MV_OK != nRet)
                    {
                        return 0;//打开失败
                    }

                    nRet = m_MyCamera.OpenDevice();
                    if (CErrorDefine.MV_OK != nRet)
                    {
                        nRet = m_MyCamera.DestroyHandle();
                        //   MessageBox.Show("Open Device Fail");
                        return 0;
                    }

                    // ch:设置采集模式为联系采集 || en:set acquisition mode as continues
                    //m_MyCamera.MV_CC_SetEnumValue_NET("AcquisitionMode", 2);
                    m_MyCamera.SetEnumValue("AcquisitionMode", (uint)MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS);

                    // en: Trigger Mode :Controls whether or not the selected trigger is active.
                    // ch: 触发模式选择:0 - Off 不按触发源模式，表现为重新连接相机后，相机自动进行采像
                    //           1 - On 按照设定的触发源，表现为相机重新连接后，不会启动启动采像，因为触发源设定成了software;
                    //m_MyCamera.MV_CC_SetEnumValue_NET("TriggerMode", 1);
                    m_MyCamera.SetEnumValue("TriggerMode", (uint)MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);

                    // ch: 触发源设为软触发 || en: set trigger mode as Software
                    // ch: 触发源选择:0 - Line0 || en :TriggerMode select;
                    //           1 - Line1;
                    //           2 - Line2;
                    //           3 - Line3;
                    //           4 - Counter;
                    //           7 - Software;
                    //m_MyCamera.MV_CC_SetEnumValue_NET("TriggerSource", 7);
                    m_MyCamera.SetEnumValue("TriggerSource", (uint)MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);

                    //设置心跳超时3秒：调试程序异常跳出后，3秒后相机释放handle，该值在相机Close后会自动还原为60000.
                    m_MyCamera.SetIntValue("GevHeartbeatTimeout", 3000);
                    // ch: 控件操作 || en: Control operation
                    //SetCtrlWhenOpen();

                    //ch: 设置合适的缓存节点数量 | en: Setting the appropriate number of image nodes
                    //m_MyCamera.SetImageNodeNum(5);

                    // ch:注册回调函数 | en:Register image callback
                    //m_MyCamera.RegisterImageCallBackEx(cbImage, (IntPtr)i);

                    //打开相机后开始采集，手动采集
                    //StartGrab();

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
            if (m_bGrabbing)
            {
                m_bGrabbing = false;
                // ch:停止抓图 || en:Stop grab image
                m_MyCamera.StopGrabbing();
                m_hReceiveThread?.Join();
            }
            //将采集模式恢复到初始
            m_MyCamera.SetEnumValue("TriggerMode", (uint)MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
            // ch:关闭设备 || en: Close device
            m_MyCamera.CloseDevice();
            // ch: 控件操作 || en: Control operation
            //SetCtrlWhenClose();

            m_bGrabbing = false;

        }

        // ch:取图前的必要操作步骤 | en:Necessary operation before grab
        private Int32 NecessaryOperBeforeGrab()
        {
            // ch:取图像宽 | en:Get Iamge Width
            CIntValue pcWidth = new CIntValue();
            int nRet = m_MyCamera.GetIntValue("Width", ref pcWidth);
            if (CErrorDefine.MV_OK != nRet)
            {
                //ShowErrorMsg("Get Width Info Fail!", nRet);
                return nRet;
            }
            m_nCurWidth = (UInt32)pcWidth.CurValue;


            // ch:取图像高 | en:Get Iamge Height
            CIntValue pcHeight = new CIntValue();
            nRet = m_MyCamera.GetIntValue("Height", ref pcHeight);
            if (CErrorDefine.MV_OK != nRet)
            {
                //ShowErrorMsg("Get Height Info Fail!", nRet);
                return nRet;
            }
            m_nCurHeight = (UInt32)pcHeight.CurValue;

            // ch:取像素格式 | en:Get Pixel Format
            CEnumValue pcPixelFormat = new CEnumValue();
            nRet = m_MyCamera.GetEnumValue("PixelFormat", ref pcPixelFormat);
            if (CErrorDefine.MV_OK != nRet)
            {
                //ShowErrorMsg("Get Pixel Format Fail!", nRet);
                return nRet;
            }
            m_emPixelType = (MvGvspPixelType)pcPixelFormat.CurValue;

            return CErrorDefine.MV_OK;
        }

        /// <summary>
        /// 开始采集
        /// </summary>
        public void StartGrab()
        {
            // ch:前置配置 | en:pre-operation
            int nRet = NecessaryOperBeforeGrab();
            if (CErrorDefine.MV_OK != nRet)
            {
              //  MessageBox.Show("Start Grabbing Fail");
                return;
            }
            m_bGrabbing = true;

            m_hReceiveThread = new Thread(ReceiveImageWorkThread);
            m_hReceiveThread.IsBackground = true;//当进程释放时不会被阻塞
            m_hReceiveThread.Start();

            // ch:开启抓图 | en:start grab
            nRet = m_MyCamera.StartGrabbing();
            if (CErrorDefine.MV_OK != nRet)
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
            int nRet = m_MyCamera.StopGrabbing();
            if (nRet != CErrorDefine.MV_OK)
            {
               // MessageBox.Show("Stop Grabbing Fail");
            }
            m_bGrabbing = false;
        }

        /// <summary>
        /// 触发一次取像
        /// </summary>
        public void TriggerExec()
        {
            //采像开始，进程忙碌状态
            m_Busy = true;

            Debug.WriteLine(DateTime.Now.ToString() + " Trigger Execute!");
            // ch: 触发命令 || en: Trigger command
            int nRet = m_MyCamera.SetCommandValue("TriggerSoftware");
            if (CErrorDefine.MV_OK != nRet)
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
            int nRet = CErrorDefine.MV_OK;
            nRet = m_MyCamera.SetEnumValue("TriggerMode", (uint)MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
            if (nRet != CErrorDefine.MV_OK)
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
            int nRet = CErrorDefine.MV_OK;

            nRet = m_MyCamera.SetEnumValue("TriggerMode", (uint)MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
            if (nRet != CErrorDefine.MV_OK)
            {
               // MessageBox.Show("Set TriggerMode Fail");
                return;
            }
            //变更模式后加延时
            Thread.Sleep(500);
        }

        public void ReceiveImageWorkThread()
        {
            int nRet = CErrorDefine.MV_OK;

            while (m_bGrabbing)
            {
                CFrameout pcFrameInfo = new CFrameout();
                CDisplayFrameInfo pcDisplayInfo = new CDisplayFrameInfo();
                CPixelConvertParam pcConvertParam = new CPixelConvertParam();

                nRet = m_MyCamera.GetImageBuffer(ref pcFrameInfo, 1000);               
                if (nRet == CErrorDefine.MV_OK)
                {
                    lock (BufForDriverLock)
                    {
                        m_pcImgForDriver = pcFrameInfo.Image.Clone() as CImage;
                        m_pcImgSpecInfo = pcFrameInfo.FrameSpec;
                    }
                    //如果位获得imgForDriver直接放弃此次处理
                    if (m_pcImgForDriver == null) break;

                    try
                    {
                        HOperatorSet.GenImage1Extern(out HObject Hobj, "byte", m_pcImgForDriver.Width, m_pcImgForDriver.Height, m_pcImgForDriver.ImageAddr, IntPtr.Zero);
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

                    m_MyCamera.FreeImageBuffer(ref pcFrameInfo);
                }
                else
                {
                    Thread.Sleep(5);
                }
            }
        }

        //ImageCallBack的定义
        private static void ImageCallBack(IntPtr pData, ref MV_FRAME_OUT_INFO_EX pFrameInfo, IntPtr pUser)
        {
            int nIndex = (int)pUser;
            string time = System.DateTime.Now.ToString("yyMMdd")+ System.DateTime.Now.ToString("HHmmss");
            Console.WriteLine("one frame captured at " + time);

            // ch:抓取的帧数 | en:Aquired Frame Number
            //++m_nFrames[nIndex];

            //ch:判断是否需要保存图片 | en:Determine whether to save image
            //if (m_bSaveImg[nIndex])
            //{
            //    SaveImage(pData, pFrameInfo, nIndex);
            //    m_bSaveImg[nIndex] = false;
            //}

            //MV_DISPLAY_FRAME_INFO stDisplayInfo = new MV_DISPLAY_FRAME_INFO();
            //stDisplayInfo.hWnd = m_hDisplayHandle[nIndex];
            //stDisplayInfo.pData = pData;
            //stDisplayInfo.nDataLen = pFrameInfo.nFrameLen;
            //stDisplayInfo.nWidth = pFrameInfo.nWidth;
            //stDisplayInfo.nHeight = pFrameInfo.nHeight;
            //stDisplayInfo.enPixelType = pFrameInfo.enPixelType;

            //m_pMyCamera[nIndex].MV_CC_DisplayOneFrame_NET(ref stDisplayInfo);
        }

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
}
