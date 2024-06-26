using HalconDotNet;
using log4net;
using log4net.Config;
using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VisionLibrary
{
    public class VisionROI
    {
        /// <summary>
        /// ROI左上角的列坐标
        /// </summary>
        public int Row1 { get; set; }
        /// <summary>
        /// ROI左上角的行坐标
        /// </summary>
        public int Column1 { get; set; }
        /// <summary>
        /// ROI右下角的列坐标
        /// </summary>
        public int Row2 { get; set; }
        /// <summary>
        /// ROI右下角的行坐标
        /// </summary>
        public int Column2 { get; set; }
        /// <summary>
        /// ROI的宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// ROI的高度
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Roi的颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Row1">ROI左上角的列坐标</param>
        /// <param name="Column1">ROI左上角的行坐标</param>
        /// <param name="Row2">ROI右下角的列坐标</param>
        /// <param name="Column2">ROI右下角的行坐标</param>
        public VisionROI(int row1 = 0, int column1 = 0, int row2 = 0, int column2 = 0)
        {
            Row1 = row1;
            Column1 = column1;
            Row2 = row2;
            Column2 = column2;
            Width = column2 - column1;
            Height = row2 - row1;
            Color = "red";
        }
        /// <summary>
        /// 重新裁剪ROI图像，并显示图像
        /// </summary>
        /// <param name="Row1">裁剪后，ROI左上角的列坐标</param>
        /// <param name="Column1">裁剪后，ROI左上角的行坐标</param>
        /// <param name="Row2">裁剪后，ROI右下角的列坐标</param>
        /// <param name="Column2">裁剪后，ROI右下角的行坐标</param>
        
        public void Resize1(int row1, int column1, int row2, int column2)
        {
            Row1 = row1;
            Column1 = column1;
            Row2 = row2;
            Column2 = column2;
            Width = column2 - column1;
            Height = row2 - row1;
        }

        /// <summary>
        /// 从中心ResizeROI
        /// </summary>
        /// <param name="rowCenter"></param>
        /// <param name="columnCenter"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Resize2(int rowCenter, int columnCenter, int width, int height)
        {
            Row1 = rowCenter - height/2;
            Column1 = columnCenter-width/2;
            Row2 = rowCenter + height / 2; ;
            Column2 = columnCenter + width / 2; ;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// 默认设置长宽512，640
        /// </summary>
        public void DefaultStyle()
        {
            Resize2(512,640,400,400);
            Color = "red";
        }
    }

    /// <summary>
    /// 2D标定用的类
    /// </summary>
    public class Calibratioin2D
    {
        public HTuple m_HomMat2d = null!;
        
        /// <summary>
        /// 图像坐标与世界坐标系的转换
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="FeedbackX"></param>
        /// <param name="FeedbackY"></param>
        /// <returns></returns>
        public int GenHomMat2d(double[] row, double[] column, double[] FeedbackX, double[] FeedbackY,
            out double RatioX, out double RatioY, out double Rotation, out double Slant, out double TranslationX, out double TranslationY)
        {
            //根据3个以上点计算仿射变换矩阵
            HOperatorSet.VectorToHomMat2d(row, column, FeedbackX, FeedbackY, out HTuple homMat2D);
            //已知仿射变换矩阵，计算仿射变换参数
            HOperatorSet.HomMat2dToAffinePar(homMat2D, out HTuple sx, out HTuple sy, out HTuple phi,
                out HTuple theta, out HTuple tx, out HTuple ty);
            //弧度转角度
            HOperatorSet.TupleDeg(phi, out HTuple DegPhi);
            //弧度转角度
            HOperatorSet.TupleDeg(theta, out HTuple DegTheta);
            //Sx:x方向的缩放因子
            RatioX = sx;
            //Sy:y方向的缩放因子
            RatioY = sy;
            //Phi:旋转角度
            Rotation = DegPhi;
            //Theta:斜切角度
            Slant = DegTheta;
            //Tx:沿x方向平移的距离
            TranslationX = tx;
            //Ty:沿y方向平移的距离
            TranslationY = ty;
            //仿射变换赋值
            m_HomMat2d = homMat2D;

            return 0;
        }

        /// <summary>
        /// 重载，简化输入
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="FeedbackX"></param>
        /// <param name="FeedbackY"></param>
        /// <returns></returns>
        public int GenHomMat2d(double[] row, double[] column, double[] FeedbackX, double[] FeedbackY)
        {
            return GenHomMat2d(row, column, FeedbackX, FeedbackY,
                out _, out _, out _, out _, out _, out _);
        }

        /// <summary>
        /// 根据像素坐标，已定义的hotMat2d参数，求物理坐标
        /// </summary>
        /// <param name="Row"></param>
        /// <param name="Column"></param>
        /// <param name="FeedbackX"></param>
        /// <param name="FeedbackY"></param>
        /// <returns></returns>
        public int AffineTransPoint2d(double Row, double Column, out double FeedbackX, out double FeedbackY)
        {
            FeedbackX = 0;
            FeedbackY = 0;
            if (m_HomMat2d == null) return 1;

            HOperatorSet.AffineTransPoint2d(m_HomMat2d, Row, Column, out HTuple qx, out HTuple qy);

            //规范的HTuple转double的用法，当HTuple为数组，则使用HTuple.DArr
            FeedbackX = qx.D;
            FeedbackY = qy.D;

            return 0;
        }

        public int AffineTransPoint2dInvert(double FeedbackX, double FeedbackY, out double Row, out double Column)
        {
            Row = 0;
            Column = 0;
            if (m_HomMat2d == null) return 1;
            HOperatorSet.HomMat2dInvert(m_HomMat2d, out HTuple homMat2DInvert);//获得逆矩阵
            HOperatorSet.AffineTransPoint2d(homMat2DInvert, FeedbackX, FeedbackY, out HTuple qx, out HTuple qy);

            //规范的HTuple转double的用法，当HTuple为数组，则使用HTuple.DArr
            Row = qx.D;
            Column = qy.D;

            return 0;
        }

        /// <summary>
        /// 保存HomMat2d
        /// </summary>
        /// <param name="FileName">文件路径</param>
        /// <returns></returns>
        public int SaveHomMat2d(string FileName)
        {
            //将指定的二维变换矩阵进行序列化操作(输入二维变换矩阵，输出序列化句柄)
            HOperatorSet.SerializeHomMat2d(m_HomMat2d, out HTuple SirializedItemHandle);
            //以ASCII码或是二进制格式打开文件
            HOperatorSet.OpenFile(FileName, "output_binary", out HTuple FileHandle);
            //保存
            HOperatorSet.FwriteSerializedItem(FileHandle, SirializedItemHandle);
            //关闭
            HOperatorSet.CloseFile(FileHandle);
            return 0;
        }

        /// <summary>
        /// 读取HomMat2d
        /// </summary>
        /// <param name="FileName">文件路径</param>
        /// <returns></returns>
        public int LoadHomMat2d(string FileName)
        {
            //读取
            HOperatorSet.OpenFile(FileName, "input_binary", out HTuple FileHandle);

            HOperatorSet.FreadSerializedItem(FileHandle, out HTuple SirializedItemHandle);

            HOperatorSet.DeserializeHomMat2d(SirializedItemHandle, out m_HomMat2d);
            //关闭
            HOperatorSet.CloseFile(FileHandle);
            return 0;
        }
    }

    /// <summary>
    /// 隔离出来的Halcon相关图像处理类
    /// </summary>
    public class HalconClass
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HalconClass));

        /// <summary>
        /// 图像显示的窗口句柄
        /// </summary>
        public HWindow? m_Window = new HWindow();

        /// <summary>
        /// 定义图像临时变量
        /// </summary>
        public HObject m_Image = new HObject();

        /// <summary>
        /// 标志位：是否显示绿十字
        /// </summary>
        public bool bDisplayCross { get; set; } = true;

        /// <summary>
        /// 标志位：是否显示红色ROI
        /// </summary>
        public bool bDisplayROI { get; set; } = true;

        private readonly object DisplayLock = new object();

        //public bool bDisplayPad { get; set; } = false;

        /// <summary>
        /// ROI类
        /// </summary>
        public VisionROI m_Roi = new VisionROI();

        //public VisionROI m_Pad = new VisionROI();

        /// <summary>
        /// 实例化一个标定类，用于标定操作
        /// </summary>
        public Calibratioin2D m_Calibration = new Calibratioin2D();

        /// <summary>
        /// 构造函数
        /// </summary>
        public HalconClass()
        {
            GlobalContext.Properties["name"] = this.GetType().Name;//存log时，自定义文件名
            XmlConfigurator.Configure(new FileInfo("log4net.config"));//读取配置

            bDisplayCross = true;
            bDisplayROI = true;
            m_Roi.Resize1(512 - 200, 640 - 200, 512 + 200, 640 + 200);

           /* 
           * 初始化Halcon参数
           * The parameter defaultChannels returns the most frequent number of channels of an image object. 
           * This value can be set to 0 if for the most part regions are used. 
           * If more channels than those having been set at the initialization are necessary for one image, the number will be enlarged dynamically for this image. 
           * If less channels than those having been set at the initialization are necessary for the image, the superfluous channels will be set as undefined. 
           * For the user this will seem as if they were non existent, however, memory is allocated unnecessarily.
           * 如果设为3，后续的Region_To_Mean会出错
           * 详见 https://www.mvtec.com/doc/halcon/13/en/reset_obj_db.html
           */
            HOperatorSet.ResetObjDb(2448, 2048, 0);
        }

        /// <summary>
        /// 获得m_Image的Width和Height
        /// </summary>
        public void GetImageSize(out int Width, out int Height)
        {
            if (m_Image == null)
            {
                Width = 0;
                Height = 0;
                return;
            }

            HOperatorSet.GetImageSize(m_Image, out HTuple hv_Width, out HTuple hv_Height);

            Width = hv_Width.I;
            Height = hv_Height.I;
        }

        /// <summary>
        /// 绘制图像
        /// </summary>
        /// <param name="hWindow">绑定的窗口m_Window</param>
        /// <param name="hObj">绘制的图像Hobject</param>
        /// <param name="hHeight">窗口的高</param>
        /// <param name="hWidth">窗口的宽</param>
        /// <returns></returns>
        public int HalconDisplay(HObject hObj, HTuple hHeight, HTuple hWidth)
        {
            lock (DisplayLock)
            {
                if (m_Window == null) return 2;
                //写在这里会出现异常
                //HOperatorSet.SetPart(m_Window, 0, 0, 1024 - 1, 1280 - 1);// ch: 使图像显示适应窗口大小 || en: Make the image adapt the window size

                // ch: 显示 || display
                m_Window.DispObj(hObj);
                //HOperatorSet.DispObj(hObj, hWindow);// ch 显示 || en: display

                if (bDisplayCross)
                {
                    if (m_Window == null) return 3;
                    m_Window.SetColor("green");
                    m_Window.DispCross(hHeight / 2, hWidth / 2, hWidth, 0);
                }
                if (OnPaintEvent!=null)
                {
                    OnPaintEvent();
                }
                if (bDisplayROI)
                {
                    if (m_Window == null) return 3;
                    m_Window.SetColor(m_Roi.Color);
                    HOperatorSet.GenRectangle2ContourXld(out HObject rectangle, (m_Roi.Row1 + m_Roi.Row2) / 2, (m_Roi.Column1 + m_Roi.Column2) / 2, 0, m_Roi.Width / 2, m_Roi.Height / 2);
                    HXLD m_hxld = new(rectangle);
                    m_Window.DispXld(m_hxld);
                }

                //返回白色
                m_Window.SetColor("white");
            }
            return 0;
        }

        /// <summary>
        /// 重载，方便直接绘制原图
        /// </summary>
        public int HalconDisplay()
        {
            //非常想注释掉下面这句，但是一旦注释，重载的display会出警告
            //if (m_Image == null) return 2;
            GetImageSize(out int Width, out int Height);
            // ch: 显示 || display
            return HalconDisplay(m_Image, Height, Width);
        }

        public delegate void OnPaintEventHander(); //定义一个委托用于自定义绘画
        public event OnPaintEventHander? OnPaintEvent;

        /// <summary>
        /// 提供SmartControl应用开发的绑定方式
        /// </summary>
        /// <param name="WindowControl"></param>
        public void DisplayWindowsBind(HSmartWindowControl WindowControl)
        {
            m_Window = WindowControl.HalconWindow;            
        }

        /// <summary>
        /// 用作zoomFit
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        public void SetPart(int Width, int Height)
        {
            HOperatorSet.SetPart(m_Window, 0, 0, Height - 1, Width - 1);
            //m_Window.SetPart(0, 0, 1024 - 1, 1280 - 1);
        }

        /// <summary>
        /// 解绑window
        /// </summary>
        public void DisplayWindowsUnbind()
        {
            lock (DisplayLock)
            {
                m_Window = null;
            }
        }

        /// <summary>
        /// 获得当前窗口的图像，并将尺寸还原，传递给DstImage
        /// </summary>
        public int SaveResultImage(string ImgPath)
        {
            HOperatorSet.GetImageSize(m_Image, out HTuple hWidth, out HTuple hHeight);
            //Width = hWidth.I;
            //Height = hHeight.I;
            //Channel = 3;
            HOperatorSet.DumpWindowImage(out HObject Himage, m_Window);
            HOperatorSet.WriteImage(Himage, "bmp", 0, ImgPath);
            return 0;
        }

        /// <summary>
        /// 保存m_Image
        /// </summary>
        /// <param name="path"></param>
        public void SaveImage(string FileName)
        {
            HOperatorSet.WriteImage(m_Image, "bmp", 0, FileName);
        }

        /// <summary>
        /// 载入图像
        /// </summary>
        /// <param name="path">图像的地址</param>
        public void LoadImage(string path)
        {
            HObject Hobj = new HObject();
            HOperatorSet.ReadImage(out Hobj, path);

            m_Image = Hobj;//将读取的图像赋值给m_image

            HTuple hv_Width = new HTuple(), hv_Height = new HTuple();
            HOperatorSet.GetImageSize(Hobj, out hv_Width, out hv_Height);

            //显示原图
            HalconDisplay(Hobj, hv_Height, hv_Width);

            hv_Width.Dispose();
            hv_Height.Dispose();
        }

        #region Focus对焦相关
        /// <summary>
        /// 清晰度评价方式
        /// </summary>
        public enum EvaluateMethod
        {
            Deviation = 0,/**< 方差（默认） */
            Laplace = 1,/**< 拉普拉斯能量函数 */
            Energy = 2, /**< 能量梯度函数 */
            Brenner = 3,/**< Brenner函数法 */
            Tenegrad = 4/**< Tenegrad函数法 */
        }

        /// <summary>
        /// 清晰度评价
        /// https://blog.csdn.net/Dangkie/article/details/77726792?spm=1001.2014.3001.5501
        /// </summary>
        /// <param name="m_Method">评价方法</param>
        /// <param name="ho_Image">传入图片，要求channels = 1</param>
        /// <returns>返回方差</returns>
        private double EvaluateDefinition(EvaluateMethod m_Method, HObject ho_Image)
        {
            //获取传递进来的图像长宽
            HOperatorSet.GetImageSize(ho_Image, out HTuple Width, out HTuple Height);

            //初始化均值
            HTuple hv_Value = 0;

            //初始化方差
            HTuple hv_Deviation = 0;

            if (m_Method == EvaluateMethod.Deviation)
            {
                //方差法
                //先对图像取均值，尺寸等于ROI后的ImagePart尺寸
                HOperatorSet.RegionToMean(ho_Image, ho_Image, out HObject ho_ImageMean);
                //为何要进行转换才能做差？
                //不确定我们的图像是否需要该函数，如果可以进行优化。
                HOperatorSet.ConvertImageType(ho_ImageMean, out ho_ImageMean, "real");
                HOperatorSet.ConvertImageType(ho_Image, out ho_Image, "real");
                //原图与均值图像做差
                HOperatorSet.SubImage(ho_Image, ho_ImageMean, out HObject ho_ImageSub, 1, 0);
                //差值图像矩阵平方  g' := g1 * g2 * Mult + Add
                HOperatorSet.MultImage(ho_ImageSub, ho_ImageSub, out HObject ho_ImageResult, 1, 0);
                //求结果矩阵的均值hv_Value，和方差hv_Deviation
                HOperatorSet.Intensity(ho_ImageResult, ho_ImageResult, out hv_Value, out hv_Deviation);
            }
            else if (m_Method == EvaluateMethod.Laplace)
            {
                //拉普拉斯能量函数
                HOperatorSet.Laplace(ho_Image, out HObject ho_ImageLaplace4, "signed", 3, "n_4");
                HOperatorSet.Laplace(ho_Image, out HObject ho_ImageLaplace8, "signed", 3, "n_8");
                HOperatorSet.AddImage(ho_ImageLaplace4, ho_ImageLaplace4, out HObject ho_ImageResult1, 1, 0);
                HOperatorSet.AddImage(ho_ImageLaplace4, ho_ImageResult1, out ho_ImageResult1, 1, 0);
                HOperatorSet.AddImage(ho_ImageLaplace8, ho_ImageResult1, out ho_ImageResult1, 1, 0);
                HOperatorSet.MultImage(ho_ImageResult1, ho_ImageResult1, out HObject ho_ImageResult, 1, 0);
                HOperatorSet.Intensity(ho_ImageResult, ho_ImageResult, out hv_Value, out hv_Deviation);
            }
            else if (m_Method == EvaluateMethod.Energy)
            {
                //能量梯度函数
                HOperatorSet.CropPart(ho_Image, out HObject ho_ImagePart00, 0, 0, Width - 1, Height - 1);
                HOperatorSet.CropPart(ho_Image, out HObject ho_ImagePart01, 0, 1, Width - 1, Height - 1);
                HOperatorSet.CropPart(ho_Image, out HObject ho_ImagePart10, 1, 0, Width - 1, Height - 1);
                HOperatorSet.ConvertImageType(ho_ImagePart00, out ho_ImagePart00, "real");
                HOperatorSet.ConvertImageType(ho_ImagePart10, out ho_ImagePart10, "real");
                HOperatorSet.ConvertImageType(ho_ImagePart01, out ho_ImagePart01, "real");
                HOperatorSet.SubImage(ho_ImagePart10, ho_ImagePart00, out HObject ho_ImageSub1, 1, 0);
                HOperatorSet.MultImage(ho_ImageSub1, ho_ImageSub1, out HObject ho_ImageResult1, 1, 0);
                HOperatorSet.SubImage(ho_ImagePart01, ho_ImagePart00, out HObject ho_ImageSub2, 1, 0);
                HOperatorSet.MultImage(ho_ImageSub2, ho_ImageSub2, out HObject ho_ImageResult2, 1, 0);
                HOperatorSet.AddImage(ho_ImageResult1, ho_ImageResult2, out HObject ho_ImageResult, 1, 0);
                HOperatorSet.Intensity(ho_ImageResult, ho_ImageResult, out hv_Value, out hv_Deviation);
            }
            else if (m_Method == EvaluateMethod.Brenner)
            {
                //Brenner函数法
                HOperatorSet.CropPart(ho_Image, out HObject ho_ImagePart00, 0, 0, Width, Height - 2);
                HOperatorSet.ConvertImageType(ho_ImagePart00, out ho_ImagePart00, "real");
                HOperatorSet.CropPart(ho_Image, out HObject ho_ImagePart20, 2, 0, Width, Height - 2);
                HOperatorSet.ConvertImageType(ho_ImagePart20, out ho_ImagePart20, "real");
                HOperatorSet.SubImage(ho_ImagePart20, ho_ImagePart00, out HObject ho_ImageSub, 1, 0);
                HOperatorSet.MultImage(ho_ImageSub, ho_ImageSub, out HObject ho_ImageResult, 1, 0);
                HOperatorSet.Intensity(ho_ImageResult, ho_ImageResult, out hv_Value, out hv_Deviation);
            }
            else if (m_Method == EvaluateMethod.Tenegrad)
            {
                //Tenegrad函数法
                HOperatorSet.SobelAmp(ho_Image, out HObject ho_EdgeAmplitude, "sum_sqrt", 3);
                HOperatorSet.MinMaxGray(ho_EdgeAmplitude, ho_EdgeAmplitude, 0, out HTuple hv_Min,
                    out HTuple hv_Max, out HTuple hv_Range);
                HOperatorSet.Threshold(ho_EdgeAmplitude, out HObject ho_Region1, 12, 255);
                HOperatorSet.RegionToBin(ho_Region1, out HObject ho_BinImage, 1, 0, Width, Height);
                HOperatorSet.MultImage(ho_EdgeAmplitude, ho_BinImage, out HObject ho_ImageResult4, 1, 0);
                HOperatorSet.MultImage(ho_ImageResult4, ho_ImageResult4, out HObject ho_ImageResult, 1, 0);
                HOperatorSet.Intensity(ho_ImageResult, ho_ImageResult, out hv_Value, out hv_Deviation);
            }

            return hv_Deviation;
        }

        /// <summary>
        /// 清晰度评价
        /// </summary>
        /// <returns>0：计算成功，结果保存到Definition  1：图像不存在  2：ROI未指定</returns>
        public int EvaluateDefinition(out double Definition)
        {
            Definition = 0;

            //若图片不存在，返回1
            if (m_Image == null) return 1;
            //若ROI不存在，返回2
            if (m_Roi.Width == 0 || m_Roi.Height == 0) return 2;

            //若图像为3通道直接进行合并到单通道
            HOperatorSet.CountChannels(m_Image, out HTuple channels);
            if (channels == 3) HOperatorSet.Rgb1ToGray(m_Image, out m_Image);

            //直接获取ROI
            HOperatorSet.GenRectangle1(out HObject m_Rect, m_Roi.Row1, m_Roi.Column1, m_Roi.Row2, m_Roi.Column2);
            //Reduce图像,得到m_ImageReduced(原始图像尺寸大小)
            HOperatorSet.ReduceDomain(m_Image, m_Rect, out HObject m_ImageReduced);
            //crop_domain图像，使ROI后的图像尺寸缩小 ,ho_ImagePart成为后续计算清晰度的对象
            HOperatorSet.CropDomain(m_ImageReduced, out HObject ho_ImagePart);
            //当未指定ROI，以m_ROI的值输入
            Definition = EvaluateDefinition(EvaluateMethod.Laplace, ho_ImagePart);

            return 0;
        }

        /// <summary>
        /// 找出最大清晰度的所在位置功能
        /// </summary>
        /// <param name="FeedbackZ">位置</param>
        /// <param name="Definition">清晰度值</param>
        /// <param name="Target">目标位置</param>
        /// <param name="MaxTargetDefinition">最大清晰度值</param>
        /// <returns>结果0:正确  1:错误的入参  2:index of Max = FirstPoint  3:index of Max = LastPoint</returns>
        public int FindMaxDefinition(double[] FeedbackZ, double[] Definition,
           out double Target, out double MaxTargetDefinition)
        {
            Target = FeedbackZ[0];
            MaxTargetDefinition = Definition[0];
            //M = 数据长度，数据长度不符合要求时
            int M = FeedbackZ.Length;
            if (M != Definition.Length) return 1;

            //直接求最大值
            MaxTargetDefinition = Definition.Max();
            //获得Index
            List<double> arrayToList = Definition.ToList();
            int TargetIndex = arrayToList.IndexOf(MaxTargetDefinition);

            //获得target
            Target = FeedbackZ[TargetIndex];

            //当目标在端点处，返回不正常结果
            if (TargetIndex == 0) return 2;
            if (TargetIndex == M - 1) return 3;

            return 0;
        }

        public bool OverMaxDefinition(double[] FeedbackZ, double[] Definition,int Length)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            double[] pos = new double[Length];
            double[] def = new double[Length];
            Array.Copy(FeedbackZ, pos, Length);
            Array.Copy(Definition, def, Length);
            int res = FindMaxDefinition(pos, def, out double Target, out double MaxTargetDefinition);
            if (res != 0) return false;//如果没找到最高点，直接返回非零

            bool res2 = (def.Last() / MaxTargetDefinition < 0.7) ? true : false;//0.7 = 经验参数

            //结束计时  
            sw.Stop();
            //获取运行时间[毫秒]  
            long times = sw.ElapsedMilliseconds;
            Debug.WriteLine(DateTime.Now.ToString() + " OverMaxDefinition time = " + times + " ms");

            return res2;
        }

        #endregion

        #region ShapeModel相关
        /// <summary>
        /// 以m_ROI创建模板，供外部调用
        /// </summary>
        /// <param name="fileName">保存路径</param>
        /// <returns>0：创建成功  1：图像不存在  2：ROI未指定</returns>
        public int CreateShapeModel(string fileName)
        {
            //若图片不存在，返回1
            if (m_Image == null) return 1;

            //若ROI不存在，返回2
            if (m_Roi.Width == 0 || m_Roi.Height == 0) return 2;

            //根据ROI生成一个矩形
            HOperatorSet.GenRectangle1(out HObject ho_Rectangle, m_Roi.Row1, m_Roi.Column1, m_Roi.Row2, m_Roi.Column2);

            //提取ROI矩形中的像素
            HOperatorSet.ReduceDomain(m_Image, ho_Rectangle, out HObject ho_ImageReduced);

            //生成匹配模板
            //HOperatorSet.CreateScaledShapeModel(ho_ImageReduced, "auto", -1.57,1.57 ,
            //    "auto", 0.9, 1.1, "auto", "auto", "use_polarity", "auto", "auto", out HTuple hv_ModelID);
            HOperatorSet.CreateShapeModel(ho_ImageReduced, "auto", -3.14, 6.28, "auto", "auto",
                "use_polarity", "auto", "auto", out HTuple hv_ModelID);

            //写入文件
            HOperatorSet.WriteShapeModel(hv_ModelID, fileName);

            //打印日志
            Debug.WriteLine(DateTime.Now.ToString() + " Write Shape Model Successfully! " + fileName);

            //成功返回0
            return 0;
        }
        /// <summary>
        /// 根据模板名称在指定的图片上查找模板对象，返回结果
        /// </summary>
        /// <param name="ModelName">模板路径</param>
        /// <param name="ResultX">返回的X坐标</param>
        /// <param name="ResultY">返回的Y坐标</param>
        /// <param name="ResultA">返回的角度坐标</param>
        /// <param name="ResultScore">返回的匹配分值</param>
        /// <returns>0：匹配成功  1：没有图像  2：匹配失败</returns>
        private int FindShapeModel(string ModelName, int NumLevels, out double[] Row, out double[] Column, out double[] Angle, out double[] Score)
        {
            int res = 0;
            Row = new double[10];
            Row[0] = 512;
            Column = new double[10];
            Column[0] = 640;
            Angle = new double[10];
            Angle[0] = 65535;
            Score = new double[10];
            Score[0] = 0;

            if (m_Image == null) return 1;//当前图片未加载

            //读取模板
            HOperatorSet.ReadShapeModel(ModelName, out HTuple hv_ModelID);

            //匹配模板，找到一个最合适的模板
            HOperatorSet.FindShapeModel(m_Image, hv_ModelID, -0.1, 0.2, 0.4, 1, 0.5, "least_squares", NumLevels, 0,
                    out HTuple hv_Row, out HTuple hv_Column, out HTuple hv_Angle, out HTuple hv_Score);

            if (hv_Score.Length == 0) return 2;//匹配失败，返回2
            for (int i = 0; i < hv_Score.Length; i++)
            {
                Row[i] = hv_Row[i];
                Column[i] = hv_Column[i];
                Angle[i] = hv_Angle[i];
                Score[i] = hv_Score[i];
            }

            //赋值
            Row = hv_Row;
            Column = hv_Column;
            Angle = hv_Angle;
            Score = hv_Score;
            //绘制必要的图形
            for (int i = 0; i < Score.Length; i++)
            {
                PaintShapeModel(hv_ModelID, Column[i], Row[i], Angle[i]);
            }

            //释放modelID
            HOperatorSet.ClearShapeModel(hv_ModelID);

            return res;
        }

        /// <summary>
        /// 重载，简化参数
        /// </summary>
        /// <param name="ModelName"></param>
        /// <param name="DeltaX"></param>
        /// <param name="DeltaY"></param>
        /// <param name="Row"></param>
        /// <param name="Column"></param>
        /// <param name="Angle"></param>
        /// <param name="Score"></param>
        /// <returns>0：匹配成功  1：没有图像  2：匹配失败</returns>
        public int FindShapeModel(string ModelName, int NumLevels, out double DeltaX, out double DeltaY, out double[] Row, out double[] Column, out double[] Angle, out double[] Score)
        {
            int res = FindShapeModel(ModelName, NumLevels, out Row, out Column, out Angle, out Score);
            if (res != 0)
            {
                DeltaX = 0.0; DeltaY = 0.0;
                return res;
            }
            //获得整张图像的中心点，即视野中心
            HOperatorSet.AreaCenter(m_Image, out _, out HTuple Row_imageCenter, out HTuple Column_imageCenter);

            m_Calibration.AffineTransPoint2d(Row_imageCenter, Column_imageCenter, out double CenterX, out double CenterY);
            m_Calibration.AffineTransPoint2d(Row[0], Column[0], out double PresentX, out double PresentY);

            DeltaX = CenterX - PresentX;
            DeltaY = CenterY - PresentY;

            return res;
        }
        /// <summary>
        /// 重载，用于查找pad
        /// </summary>
        /// <param name="ModelName"></param>
        /// <param name="NumLevels"></param>
        /// <param name="HalfWidth"></param>
        /// <param name="HalfHeight"></param>
        /// <param name="DeltaX"></param>
        /// <param name="DeltaY"></param>
        /// <returns></returns>
        public int FindShapeModel(string ModelName, int NumLevels, double HalfWidth,double HalfHeight,out double DeltaX, out double DeltaY)
        {
            //因为Pad很小，容易出现一个视野里出现多个pad，故先剪切图片
            HOperatorSet.GenRectangle2(out HObject m_Rect, 512, 640, 0, HalfWidth, HalfHeight);
            //Reduce图像,得到m_ImageReduced(原始图像尺寸大小)
            HOperatorSet.ReduceDomain(m_Image, m_Rect, out HObject m_ImageReduced);
            m_Image = m_ImageReduced;

            int res = FindShapeModel(ModelName, NumLevels, out double[] Row, out double[] Column, out double[] Angle, out double[] Score);
            if (res != 0)
            {
                DeltaX = 0.0; DeltaY = 0.0;
                return res;
            }
            //获得整张图像的中心点，即视野中心
            HOperatorSet.AreaCenter(m_Image, out _, out HTuple Row_imageCenter, out HTuple Column_imageCenter);

            m_Calibration.AffineTransPoint2d(Row_imageCenter, Column_imageCenter, out double CenterX, out double CenterY);
            m_Calibration.AffineTransPoint2d(Row[0], Column[0], out double PresentX, out double PresentY);

            DeltaX = CenterX - PresentX;
            DeltaY = CenterY - PresentY;

            return res;
        }

        /// <summary>
        /// 绘制图形
        /// </summary>
        /// <param name="hv_ModleID">返回形状模型的轮廓表示</param>
        /// <param name="hv_Row">列坐标</param>
        /// <param name="hv_Column">行坐标</param>
        /// <param name="hv_Angle">角度</param>
        private void PaintShapeModel(HTuple hv_ModleID, HTuple hv_Row, HTuple hv_Column, HTuple hv_Angle)
        {
            // Local iconic variables 
            // HOperatorSet.GenCrossContourXld(out HObject ho_Cross, hv_Row, hv_Column, 50, hv_Angle);

            // 画十字箭头
            HOperatorSet.SetColor(m_Window, "blue");
            // HOperatorSet.DispObj(ho_Cross, m_Window);

            // 定义一个仿射变换器
            HOperatorSet.HomMat2dIdentity(out HTuple HomMat2D);
            // Scale之，在我们的应用里，尺寸不变=1
            // HOperatorSet.HomMat2dScale(HomMat2D, ScaleX, ScaleY, 0, 0, HomMat2D);
            // 旋转之
            HOperatorSet.HomMat2dRotate(HomMat2D, hv_Angle, 0, 0, out HomMat2D);
            // 平移之
            HOperatorSet.HomMat2dTranslate(HomMat2D, hv_Column, hv_Row, out HomMat2D);

            // 获得model的轮廓
            HOperatorSet.GetShapeModelContours(out HObject ModelContours, hv_ModleID, 1);
            // 对轮廓进行仿射变换
            HOperatorSet.AffineTransContourXld(ModelContours, out HObject TransContours, HomMat2D);

            // 将变换后的轮廓画出
            HOperatorSet.DispXld(TransContours, m_Window);

            //绘制完以后，将颜色改回默认白色
            HOperatorSet.SetColor(m_Window, "white");
        }

        #endregion

        #region Blob相关
        /// <summary>
        /// 获取Wafer在Roi内的Blob，并计算Blob质心到画面中心的位移XY
        /// </summary>
        /// <param name="DeltaX">Blob质心到画面中心的位移X</param>
        /// <param name="DeltaY">Blob质心到画面中心的位移Y</param>
        /// <returns>0:计算成功 1：obj数量不唯一</returns>
        public int GetWaferEdge(out double DeltaX, out double DeltaY)
        {
            return Blob(0, 20, 15000, 100000, true,out DeltaX, out DeltaY, out _, out _);           
        }

        /// <summary>
        /// 对针尖部分做Threshold，亮的部分返回面积
        /// 面积中心其与视野中心的DeltaX，和DeltaY，
        /// 面积中心在视野中心右方，DeltaX > 0, DeltaColumn > 0,
        /// 面积中心在视野中心上方，DeltaY < 0, DeltaRow < 0
        /// </summary>
        /// <returns>0：计算成功，结果保存到Definition  1：图像不存在  2：ROI未指定</returns>
        public int GetPin(out double DeltaX, out double DeltaY)
        {
            return Blob(200, 255, 800, 20000, true, out DeltaX, out DeltaY, out _, out _);
        }

        //针痕检测
        public int GetProbeMark(int Threshold, int AreaPad, int AreaMark,
            out double Top, out double Bottom, out double Left, out double Right, out double DeltaX, out double DeltaY)
        {           
            int res = 0;
            Top = 0; Bottom = 0; Left = 0; Right = 0; DeltaX = 0; DeltaY = 0;

            //缩放ROI
            m_Roi.Resize2(512, 640, 200, 200);
            //找Pad,0-Threshold
            res = NearestRectangle(Threshold, 255, AreaPad * 0.5, AreaPad * 2, "blue", 
                out HTuple Row1, out HTuple Column1, out HTuple Row2, out HTuple Column2,out HTuple RowCenter1,out HTuple columnCenter1);
            if (res != 0) return res;
            log.Debug("Pad Found.");
            //找Mark,Threshold - 255
            res = NearestRectangle(0, Threshold, AreaMark * 0.5, AreaMark * 2, "red", 
                out HTuple Row3, out HTuple Column3, out HTuple Row4, out HTuple Column4, out HTuple RowCenter2, out HTuple columnCenter2);
            if (res != 0) return res;
            log.Debug("Mark Found.");
            m_Calibration.AffineTransPoint2d(Row1, Column1, out double encodeX1, out double encodeY1);//pad左上
            m_Calibration.AffineTransPoint2d(Row2, Column2, out double encodeX2, out double encodeY2);//pad右下
            m_Calibration.AffineTransPoint2d(Row3, Column3, out double encodeX3, out double encodeY3);//Mark左上
            m_Calibration.AffineTransPoint2d(Row4, Column4, out double encodeX4, out double encodeY4);//Mark右下
            m_Calibration.AffineTransPoint2d(RowCenter1, columnCenter1, out double encodeCenterX1, out double encodeCenterY1);//Pad中心
            m_Calibration.AffineTransPoint2d(RowCenter2, columnCenter2, out double encodeCenterX2, out double encodeCenterY2);//Pad中心

            Top = Math.Abs(encodeY1 - encodeY3);
            Bottom = Math.Abs(encodeY2 - encodeY4);
            Left = Math.Abs(encodeX1 - encodeX3);
            Right = Math.Abs(encodeX2 - encodeX4);
            DeltaX = encodeCenterX2 - encodeCenterX1;
            DeltaY = encodeCenterY2 - encodeCenterY1;

            return 0;
        }

        private int NearestRectangle(int tresholdMin, int tresholdMax, double areaMin, double areaMax, string paintColor,
             out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2,out HTuple RowCenter,out HTuple ColumnCenter)
        {
            row1 = new HTuple();column1 = new HTuple(); row2 = new HTuple(); column2 = new HTuple(); RowCenter = new HTuple(); ColumnCenter = new HTuple();
            int res = Blob(tresholdMin, tresholdMax, areaMin, areaMax, out HObject SelectedRegions);
            if (res != 0) { return res; }
            //获得最小外接矩形
            HOperatorSet.SmallestRectangle1(SelectedRegions, out row1, out column1, out row2, out column2);
            //其他数据
            RowCenter = row1 * 0.5 + row2 * 0.5;
            ColumnCenter = column1 * 0.5 + column2 * 0.5;
            HTuple WidthRectHalf = column2 * 0.5 - column1 * 0.5;
            HTuple HeightRectHalf = row2 * 0.5 - row1 * 0.5;
            //GetDeltaFromCenter(RowCenter, ColumnCenter, out double DeltaX, out double DeltaY);
            //Row1 = row1.D; Column1 = column1.D; Row2 = row2.D; Column2 = column2.D;

            //画图
            if (paintColor != "")
            {
                HOperatorSet.GenRectangle2ContourXld(out HObject rectangle ,RowCenter,ColumnCenter,0, WidthRectHalf, HeightRectHalf);
                HOperatorSet.SetColor(m_Window, paintColor);
                HOperatorSet.DispObj(rectangle, m_Window);// ch 显示 || en: display
                HOperatorSet.SetColor(m_Window, "white");
            }

            return 0;
        }

        private int Blob(int tresholdMin, int tresholdMax, double areaMin, double areaMax, out HObject obj)
        {
            //剪切图片ROI
            HOperatorSet.GenRectangle1(out HObject m_Rect, m_Roi.Row1, m_Roi.Column1, m_Roi.Row2, m_Roi.Column2);
            //Reduce图像,得到m_ImageReduced(原始图像尺寸大小)
            HOperatorSet.ReduceDomain(m_Image, m_Rect, out HObject m_ImageReduced);
            //crop_domain图像，使ROI后的图像尺寸缩小 ,ho_ImagePart成为后续计算清晰度的对象
            //HOperatorSet.CropDomain(m_ImageReduced, out HObject ho_ImagePart);

            //阈值提取
            HOperatorSet.Threshold(m_ImageReduced, out HObject Regions, tresholdMin, tresholdMax);
            //选取特征区域
            HOperatorSet.Connection(Regions, out HObject ConnectedRegions);
            //更具特征筛选
            HOperatorSet.SelectShape(ConnectedRegions, out HObject SelectedRegions, "area", "and", areaMin, areaMax);
            //如果number != 1 错误跳出
            HOperatorSet.CountObj(SelectedRegions, out HTuple number);

            obj = SelectedRegions;
            if (number == 1)
            { 
                return 0; 
            }
            else 
            {
                return 1;
            }
        }

        /// <summary>
        /// Blob 给外界调用
        /// </summary>
        /// <param name="tresholdMin"></param>
        /// <param name="tresholdMax"></param>
        /// <param name="areaMin"></param>
        /// <param name="areaMax"></param>
        /// <param name="DeltaX"></param>
        /// <param name="DeltaY"></param>
        /// <param name="Row"></param>
        /// <param name="Column"></param>
        /// <returns>0: 计算成功 1：Object数量不唯一</returns>
        public int Blob(int tresholdMin, int tresholdMax, double areaMin, double areaMax,bool paintObj,
            out double DeltaX, out double DeltaY, out double Row, out double Column)
        {
            DeltaX = 0;DeltaY = 0;Row = 512;Column = 640;

            int res = Blob(tresholdMin, tresholdMax, areaMin, areaMax, out HObject SelectedRegions);
            if (res != 0) { return res; }
            //计算形心
            HOperatorSet.AreaCenter(SelectedRegions, out _, out HTuple Row_Obj, out HTuple Column_Obj);

            //计算中心偏移
            GetDeltaFromCenter(Row_Obj, Column_Obj, out DeltaX, out DeltaY);

            Row = Row_Obj.D;
            Column = Column_Obj.D;

            if (paintObj)
            {
                HOperatorSet.SetColor(m_Window, "red");
                HOperatorSet.DispObj(SelectedRegions, m_Window);// ch 显示 || en: display
                HOperatorSet.SetColor(m_Window, "white");
            }
           
            return 0;
        }

        /// <summary>
        /// 计算目标点到中心的偏移，经过比例系数换算
        /// </summary>
        /// <param name="Row_Obj"></param>
        /// <param name="Column_Obj"></param>
        /// <param name="DeltaX"></param>
        /// <param name="DeltaY"></param>
        private void GetDeltaFromCenter(HTuple Row_Obj, HTuple Column_Obj, out double DeltaX, out double DeltaY)
        {
            DeltaX = 0; DeltaY = 0;
            //获得整张图像的中心点，即视野中心
            HOperatorSet.AreaCenter(m_Image, out HTuple Area, out HTuple Row_imageCenter, out HTuple Column_imageCenter);
            m_Calibration.AffineTransPoint2d(Row_imageCenter, Column_imageCenter, out double CenterX, out double CenterY);
            m_Calibration.AffineTransPoint2d(Row_Obj, Column_Obj, out double PresentX, out double PresentY);

            DeltaX = CenterX - PresentX;
            DeltaY = CenterY - PresentY;
        }

        /// <summary>
        /// 拟合圆心X，Y by Bodom
        /// </summary>
        /// <param name="EdgeXs">M组圆边界点X</param>
        /// <param name="EdgeYs">M组圆边界点Y</param>
        /// <param name="CircleCenterX">计算得到的圆心X</param>
        /// <param name="CircleCenterY">计算得到的圆心Y</param>
        /// <param name="Radius">计算得到圆心的像素直径</param>
        /// <returns>0：计算成功  1：数组长度出错</returns>
        public int FitCircle(double[] EdgeXs, double[] EdgeYs, out double CircleCenterX, out double CircleCenterY, out double Radius)
        {
            CircleCenterX = 65535;
            CircleCenterY = 65535;
            Radius = 65535;

            //M = 数据长度，数据长度不符合要求时
            int M = EdgeXs.Length;
            if (M < 4 || M != EdgeXs.Length || M != EdgeYs.Length) return 1;

            //根据离散点生成圆轮廓
            HOperatorSet.GenContourPolygonXld(out HObject Contour, EdgeYs, EdgeXs);
            //根据轮廓拟合圆心
            HOperatorSet.FitCircleContourXld(Contour, "geotukey", -1, 0.0, 0, 3, 2.0, out HTuple CenterRow, out HTuple CenterColumn,
                out HTuple radius, out HTuple startPhi, out HTuple endPhi, out HTuple pointOrder);

            //平台中心赋值
            CircleCenterX = CenterColumn;
            CircleCenterY = CenterRow;
            Radius = radius;

            return 0;
        }

        #endregion

        #region Align角度相关
        /// <summary>
        /// 计算N组晶圆格的角度
        /// </summary>
        /// <param name="FeedbackX">X坐标</param>
        /// <param name="FeedbackY">Y坐标</param>
        /// <param name="Angle">计算的角度值</param>
        public void GetWaferAngle(double[] FeedbackX, double[] FeedbackY, out double Angle)
        {
            FitLine(FeedbackX, FeedbackY, out double intercept, out double Slop);

            Angle = Math.Atan(Slop) * 180 / Math.PI;
        }

        /// <summary>
        /// 两点求角度，FitLine在某些情况下得出显而易见错误的解
        /// </summary>
        /// <param name="FeedbackX"></param>
        /// <param name="FeedbackY"></param>
        /// <param name="Slope"></param>
        /// <returns></returns>
        public int GetWaferAngle2Points(double[] FeedbackX, double[] FeedbackY, out double Angle)
        {
            int count = FeedbackX.Count();
            if (FeedbackX[0] == FeedbackX[count - 1])
            {
                Angle = 90;
                return 0;
            }
            else
            {
                double Slop = (FeedbackY[0] - FeedbackY[count - 1]) / (FeedbackX[0] - FeedbackX[count - 1]);
                Angle = Math.Atan(Slop) * 180 / Math.PI;
                return 0;
            }
        }

        /// <summary>
        /// 直线拟合
        /// </summary>
        /// <param name="FeedbackX"></param>
        /// <param name="FeedbackY"></param>
        /// <param name="Angle"></param>
        /// <param name="b"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FitLine(double[] FeedbackX, double[] FeedbackY, out double Intercept, out double Slope)
        {
            (double, double) res = Fit.Line(FeedbackX, FeedbackY);
            Intercept = res.Item1;
            Slope = res.Item2;

            return 0;
        }
        #endregion

        #region 未归类
        /// <summary>
        /// MathNet.Numerics提供的多项式拟合
        /// Least-Squares fitting the points (x,y) to a k-order polynomial y : x -> p0 + p1*x + p2*x^2 +... + pk*x^k,
        /// returning its best fitting parameters as [p0, p1, p2,..., pk] array, compatible with Polynomial.Evaluate.
        /// A polynomial with order/degree k has (k+1) coefficients and thus requires at least (k+1) samples.
        /// </summary>
        /// <param name="Position">位置</param>
        /// <param name="Definition">评价值</param>
        /// <param name="Target">目标位置</param>
        /// <param name="TargetDefinition">清晰度评价值最高的位置</param>
        /// <param name="res">二次函数拟合输出</param>
        /// <param name="Tag">标志位，如果为-1表示极值在所有点的左侧，+1表示极值在所有点的右侧</param>
        /// <param name="DeltaTarget">这个数值表示的是最大的数值和求出来的极值点之间的差</param>
        /// <returns></returns>
        public int FitPolynomial(double[] Position, double[] Definition,
            out double Target, out double TargetDefinition, out double[] res, out int Tag, out double DeltaTarget)
        {
            res = null!;
            Target = 65535;
            TargetDefinition = 65535;

            Tag = 0; DeltaTarget = 0;
            //M = 数据长度，数据长度不符合要求时
            int M = Position.Length;
            if (M < 9 || M != Position.Length || M != Definition.Length) return 1;

            //截取最高点和旁边的两个点
            double MaxTargetDefinition = Definition.Max();
            List<double> arrayToList = Definition.ToList();
            int MaxTarget = arrayToList.IndexOf(MaxTargetDefinition);
            //判断start是否包含在0-M以内
            int start = MaxTarget - 1;
            if (start < 1) start = 0;
            if (start > M - 2) start = M - 2;
            //挑中间3个
            double[] PositionSelected = Position.Skip(start).Take(3).ToArray();
            double[] DefinitionSelected = Definition.Skip(start).Take(3).ToArray();
            //二次拟合 返回res
            res = Fit.Polynomial(PositionSelected, DefinitionSelected, 2);
            //极值点 : k = -b /2a
            //返回值为2，表示二次函数的开口方向向上
            if (res[2] >= 0) return 2;
            Target = -res[1] / 2 / res[2];
            TargetDefinition = res[0] + res[1] * Target + res[2] * Target * Target;
            //Tag标志位，如果为-1表示极值在所有点的左侧，+1表示极值在所有点的右侧
            if (Target < Position[0]) Tag = -1;
            if (Target > Position[2]) Tag = 1;
            //DeltaTarget这个数值表示的是最大的数值和求出来的极值点之间的差
            DeltaTarget = System.Math.Abs(MaxTarget - Target);
            return 0;
        }

        public int GetChuckEdge(out double DeltaX, out double DeltaY, out double Row_edge, out double Column_edge)
        {
            HOperatorSet.Threshold(m_Image, out HObject region, 20, 255);
            HOperatorSet.ClosingCircle(region, out HObject regionclosing, 20);
            HOperatorSet.Connection(regionclosing, out HObject connectedregions);
            HOperatorSet.GenContourRegionXld(connectedregions, out HObject Contours, "border");
            //获得ImageSize
            HOperatorSet.GetImageSize(m_Image, out HTuple Width, out HTuple Height);
            //分割边缘
            HOperatorSet.ClipContoursXld(Contours, out HObject ClippedContours, 2, 2, Height - 2, Width - 2);
            //拟合边缘
            HOperatorSet.FitLineContourXld(ClippedContours, "regression", -1, 0, 5, 2,
                out HTuple RowBegin, out HTuple ColBegin, out HTuple RowEnd, out HTuple ColEnd, out HTuple Nr,
                out HTuple Nc, out HTuple Dist);
            //求直线的中点
            Row_edge = (RowBegin + RowEnd) / 2;
            Column_edge = (ColBegin + ColEnd) / 2;
            //获得整张图像的中心点，即视野中心
            HOperatorSet.AreaCenter(m_Image, out HTuple Area, out HTuple Row_imageCenter, out HTuple Column_imageCenter);

            m_Calibration.AffineTransPoint2d(Row_imageCenter, Column_imageCenter, out double CenterX, out double CenterY);
            m_Calibration.AffineTransPoint2d(Row_edge, Column_edge, out double PresentX, out double PresentY);

            DeltaX = CenterX - PresentX;
            DeltaY = CenterY - PresentY;

            return 0;
        }

        /// <summary>
        /// 角点检测，用于进行标定，返回Harris角点数组里索引为0的行列值。
        /// 建议将ROI调整为仅获得一个角点
        /// </summary>
        /// <param name="NumOfPoints">Harris角点数组个数</param>
        /// <param name="Row">索引为0的行值，若计算失败返回-1</param>
        /// <param name="Column">索引为0的列值，若计算失败返回-1</param>
        /// <returns>0：计算成功  1：图像不存在  2：ROI未指定  3：角点个数为零</returns>
        public int PointsHarris(out int NumOfPoints, out double Row, out double Column)
        {
            //初始化
            NumOfPoints = 0;
            Row = 65535;
            Column = 65535;

            //若图片不存在，返回1
            if (m_Image == null) return 1;
            //若ROI不存在，返回2
            if (m_Roi.Width == 0 || m_Roi.Height == 0) return 2;

            //生成一个矩形rect
            HOperatorSet.GenRectangle1(out HObject m_Rect, m_Roi.Row1, m_Roi.Column1, m_Roi.Row2, m_Roi.Column2);
            //Reduce图像,得到m_ImageReduced(原始图像尺寸大小)
            HOperatorSet.ReduceDomain(m_Image, m_Rect, out HObject m_ImageReduced);

            //Harris角点检测
            HOperatorSet.PointsHarris(m_ImageReduced, 0.7, 2, 0.04, 0, out HTuple RowHarris, out HTuple ColHarris);

            //获得角点数量
            NumOfPoints = RowHarris.TupleLength();
            //如果数量为零，则跳出
            if (NumOfPoints == 0) return 3;

            //赋值结果
            Row = RowHarris[0];
            Column = ColHarris[0];

            //绘制角点
            HOperatorSet.TupleRad(45, out HTuple rad);
            HOperatorSet.GenCrossContourXld(out HObject CrossHarris, RowHarris, ColHarris, 10, rad);
            HOperatorSet.SetColor(m_Window, "green");
            HOperatorSet.DispObj(CrossHarris, m_Window);
            HOperatorSet.SetColor(m_Window, "white");

            return 0;
        }

        /// <summary>
        /// 四点坐标求四边形面积
        /// </summary>
        /// <param name="qx"></param>
        /// <param name="qy"></param>
        /// <param name="area"></param>
        public void CalQuadrilateralArea(double[] qx, double[] qy, out double area)
        {
            area = (qx[0] * qy[1] - qy[0] * qx[1] + qx[1] * qy[2] - qy[1] * qx[2]
                 + qx[2] * qy[3] - qy[2] * qx[3] + qx[3] * qy[0] - qy[3] * qx[0]) / 2;
        }
        #endregion

        #region 用户自定义绘图
        /// <summary>
        /// 传入Pin的坐标，并指定Index在视野正中间
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="CurrentIndex"></param>
        /// <param name="Angle"></param>
        public void PaintPins(double[]? X, double[]? Y, int CurrentIndex)
        {
            if (X == null || Y == null) return;            
            //获得整张图像的中心点，即视野中心
            HOperatorSet.AreaCenter(m_Image, out _, out HTuple Row_imageCenter, out HTuple Column_imageCenter);
            //中心点对应的encodeX和encodeY
            m_Calibration.AffineTransPoint2d(Row_imageCenter, Column_imageCenter, out double EncodeCenterX, out double EncodeCenterY);
            //CurrentIndex运动至原点（0，0）时，其余各点坐标
            int cnt = X.Length;
            double[] Xout = new double[cnt];
            double[] Yout = new double[cnt];
            //所有点跟随currentIndex再平移到 EncodeCenterX，EncodeCenterY，并开始绘图
            HOperatorSet.SetColor(m_Window, "blue");
            for (int i = 0; i < X.Length; i++)
            {
                Xout[i] = EncodeCenterX - X[i] + X[CurrentIndex];//标定时，目标点在(dX,dY)位置时的encode1，与目标从中点运动到(dX,dY)位置的encode符号相反
                Yout[i] = EncodeCenterY - Y[i] + Y[CurrentIndex];
                m_Calibration.AffineTransPoint2dInvert(Xout[i], Yout[i], out double Row, out double Column);
                if (Row > 1024 || Row < 0) continue;
                if (Column > 1280 || Column < 0) continue;
                HOperatorSet.GenCircleContourXld(out HObject conCircle, Row, Column, 6, 0, 2 * Math.PI, "positive", 1.0);
                HTuple str = (i == 0) ? "#REF" : "#" + i.ToString();
                HOperatorSet.DispXld(conCircle, m_Window);
                HOperatorSet.SetTposition(m_Window, Row + 6, Column - 3);
                HOperatorSet.WriteString(m_Window, str);
            }

            //绘制完以后，将颜色改回默认白色
            HOperatorSet.SetColor(m_Window, "white");
        }
        #endregion
    }
}
