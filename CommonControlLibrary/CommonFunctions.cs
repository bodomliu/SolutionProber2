﻿using WaferMapLibrary;
using VisionLibrary;
using MotionLibrary;
using log4net;
namespace CommonComponentLibrary
{
    public static class CommonFunctions
    {

        /// <summary>
        /// 对焦函数
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="Mag"></param>
        /// <returns></returns>
        public static int AdjustWaferHeight(double start, double end, CameraClass Mag)
        {
            Mag.TriggerMode();

            List<double> def = new();
            List<double> pos = new();
            bool SlowFlag = false;


            for (double z = start; z < end;)
            {
                Motion.AxisMoveAbs(1, 3, z, 600, 20, 20, 10);
                Mag.TriggerExec();
                Mag.halconClass.EvaluateDefinition(out double Definition);//计算清晰度
                pos.Add(z);
                def.Add(Definition);

                //判断斜率，然后看i是否要增加
                z += NextStep(pos, def, Mag, ref SlowFlag);

                Console.WriteLine("pos= " + z + "  def= " + Definition + " Slowflag= " + SlowFlag);
            }
            int maxIndex = def.IndexOf(def.Max());//找Def最大处的index值
            double Target = pos[maxIndex];
            Motion.AxisMoveAbs(1, 3, Target, 600, 20, 20, 10);
            //Console.WriteLine(Target);

            Mag.ContinuesMode();
            int res = (maxIndex == 0 || maxIndex == pos.Count - 1) ? 1 : 0;//如果最大值在两端，则报1
            return res;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="range"></param>
        /// <param name="Mag"></param>
        /// <returns></returns>
        public static int AdjustWaferHeight(double waferThickness, CameraClass Mag)
        {
            double targetHigh = Motion.parameter.ZORIGIN - waferThickness;//46000 - 8000 = 38000
            double targetLow = targetHigh - Motion.parameter.ZWAFERLOW2HIGHT;//38000 - （-8000）= 46000
            double targetJig = targetHigh + Motion.parameter.ZALIGN2PROBE;//38000 + 45823 = 83823
            double rangeHigh = 1000;
            double rangeLow = 15000;

            if (Mag == Vision.WaferLowMag)
            {
                return AdjustWaferHeight(targetLow - rangeLow, targetLow + rangeLow, Mag);
            }
            else if (Mag == Vision.WaferHighMag)
            {
                return AdjustWaferHeight(targetHigh - rangeHigh, targetHigh + rangeHigh, Mag);
            }
            else if (Mag == Vision.JigCamera)
            {
                return AdjustWaferHeight(targetJig - rangeHigh, targetJig + rangeHigh, Mag);
            }
            else return -1;
        }
        /// <summary>
        /// 计算下次Step值
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="def"></param>
        /// <param name="Mag"></param>
        /// <param name="SlowDownFlag"></param>
        /// <returns></returns>
        private static double NextStep(List<double> pos, List<double> def, CameraClass Mag, ref bool SlowDownFlag)
        {
            GetNextStepPara(Mag, out double slowStep, out double fastStep, out double endStep, out double slopThreshold);

            int cnt = def.Count;

            if (cnt == 1) return slowStep;//次数不够,算不出斜率

            double slop = (def[cnt - 1] - def[cnt - 2]) / (pos[cnt - 1] - pos[cnt - 2]);

            if (slop > slopThreshold)
            {
                SlowDownFlag = true;
                return slowStep;//斜率在上升，step改小
            }
            else if (slop >= -slopThreshold && slop <= slopThreshold && !SlowDownFlag)
            {
                return fastStep;//斜率平稳，没有降过速step改大
            }
            //else if (slop < -slopThreshold)
            //{
            //    return endStep;//斜率在下降，焦点已经没了，直接step到最大退出
            //}
            else if (def[cnt - 1] < def.Max() * 0.7)
            {
                return endStep;//当前的def已经小于最大值的70%，直接step到最大退出
            }
            else { return slowStep; }
        }
        private static void GetNextStepPara(CameraClass Mag, out double slowStep, out double fastStep, out double endStep, out double slopThreshold)
        {
            //是否时高分辨率相机
            if (Mag == Vision.WaferHighMag || Mag == Vision.JigCamera)
            {
                slowStep = 10;
                fastStep = 100;
                endStep = 10000;
                slopThreshold = 10;
            }
            else if (Mag == Vision.WaferLowMag)
            {
                slowStep = 1000;
                fastStep = 3000;
                endStep = 100000;
                slopThreshold = 1;
            }
            else if (Mag == Vision.PinHighMag)
            {
                slowStep = 20;
                fastStep = 200;
                endStep = 10000;
                slopThreshold = 1;
            }
            else if (Mag == Vision.PinLowMag)
            {
                slowStep = 1000;
                fastStep = 3000;
                endStep = 100000;
                slopThreshold = 1;
            }
            else
            {
                slowStep = 1000;
                fastStep = 3000;
                endStep = 100000;
                slopThreshold = 1;
            }
        }

        #region WaferAlignment
        /// <summary>
        /// TriggerExe 模板匹配 then 运动到位
        /// </summary>
        /// <param name="pattenModel">模板名称</param>
        /// <param name="Mag">相机Camera</param>
        /// <param name="DeltaX">X轴Match过程相对位移</param>
        /// <param name="DeltaY">Y轴Match过程相对位移</param>
        /// <returns>0：匹配成功  1：没有图像  2：匹配失败</returns>
        public static int Match(string pattenModel, CameraClass Mag, out double DeltaX, out double DeltaY)
        {
            Mag.TriggerMode();//单拍模式，对相机模式的切换写在这里合适吗？
            Mag.TriggerExec();//触发一帧
            //匹配pattenModel
            int res = Mag.halconClass.FindShapeModel(pattenModel, 0, out DeltaX, out DeltaY, out double[] X, out double[] Y,
                out double[] Angle, out double[] Score);
            if (res != 0)
            {
                Mag.ContinuesMode();//连拍模式，匹配完，切回连拍模式
                return res;//若匹配失败，直接返回findShapeModel错误结果
            }
            //相对运动到匹配点
            Motion.XY_AxisMoveRel(1, Convert.ToInt32(DeltaX), Convert.ToInt32(DeltaY), 600, 10, 10, 20);

            Mag.TriggerExec();//触发一帧
            Thread.Sleep(500);//显示补偿效果

            Mag.ContinuesMode();//连拍模式，匹配完，切回连拍模式
            return 0;
        }

        /// <summary>
        /// 只拍照看要补偿多少，却不去做移动匹配的动作了，用于errorMap
        /// </summary>
        /// <param name="pattenModel"></param>
        /// <param name="Mag"></param>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        /// <param name="encodeX"></param>
        /// <param name="encodeY"></param>
        /// <returns></returns>
        public static int FastMatch(string pattenModel, CameraClass Mag, out double deltaX, out double deltaY, out double encodeX, out double encodeY)
        {
            Mag.TriggerExec();//触发一帧
            //匹配pattenModel
            int res = Mag.halconClass.FindShapeModel(pattenModel, 0, out deltaX, out deltaY, out _, out _, out _, out _);

            Motion.XY_GetEncPos(out encodeX, out encodeY);
            encodeX += deltaX;
            encodeY += deltaY;
            if (res != 0)
            {
                return res;//若匹配失败，直接返回findShapeModel错误结果
            }
            return 0;
        }

        /// <summary>
        /// X向校平
        /// </summary>
        /// <param name="Mag"></param>
        /// <param name="pattenModel"></param>
        /// <param name="L"></param>
        /// <param name="R"></param>
        /// <param name="dieSizeX"></param>
        /// <param name="RotateX">旋转中心X</param>
        /// <returns>0：匹配成功  1：没有图像  2：匹配失败  3：水平角度大于5度 </returns>
        public static int AlignX(CameraClass Mag, string pattenModel, int L, int R, double dieSizeX, out double RotateX)
        {
            int res = 0; RotateX = double.NaN;
            //记录初始位置
            Motion.GetUserPos(Compensation.Area.Align, out double X0, out double Y0);

            //运动到L点做精定位
            Motion.UserPosMoveAbs(Compensation.Area.Align, X0 - L * dieSizeX, Y0);
            res = CommonFunctions.Match(pattenModel, Mag, out _, out _);
            if (res != 0) return res;//若匹配失败，直接返回findShapeModel错误结果
            Motion.GetUserPos(Compensation.Area.Align, out double X1, out double Y1);

            //运动到R点做精定位
            Motion.UserPosMoveAbs(Compensation.Area.Align, X0 + R * dieSizeX, Y0);
            res = CommonFunctions.Match(pattenModel, Mag, out _, out _);
            if (res != 0) return res;//若匹配失败，直接返回findShapeModel错误结果
            Motion.GetUserPos(Compensation.Area.Align, out double X2, out double Y2);

            //计算结果
            double[] feedbackX = new double[2] { X1, X2 };
            double[] feedbackY = new double[2] { Y1, Y2 };

            Mag.halconClass.GetWaferAngle2Points(feedbackX, feedbackY, out double Angle);
            //txtAngle.Text = Angle.ToString();

            if (Math.Abs(Angle) > 5)
            {
                MessageBox.Show("Error Angle");
                return 3;//角度错误
            }
            int feedbackR = (int)Math.Round(Angle * 10000, 0);//TODO:如果用轴运动坐标系，符号相反，待兼容
            Motion.AxisMoveRel(1, 4, feedbackR, 600, 10, 10, 20);

            //移回中点处
            Motion.UserPosMoveAbs(Compensation.Area.Align, X0, Y0);
            RotateX = (X1 * (Y0 - Y1) - X2 * (Y0 - Y2)) / (Y1 - Y2);
            return 0;
        }

        /// <summary>
        /// Y向校平
        /// </summary>
        /// <param name="Mag"></param>
        /// <param name="pattenModel"></param>
        /// <param name="U"></param>
        /// <param name="D"></param>
        /// <param name="dieSizeY"></param>
        /// <param name="RotateY">旋转中心X</param>
        /// <returns>0：匹配成功  1：没有图像  2：匹配失败  3：水平角度大于5度 </returns>
        public static int AlignY(CameraClass Mag, string pattenModel, int U, int D, double dieSizeY, out double RotateY)
        {
            int res = 0; RotateY = double.NaN;
            //记录初始位置
            Motion.GetUserPos(Compensation.Area.Align, out double X0, out double Y0);

            //运动到L点做精定位
            Motion.UserPosMoveAbs(Compensation.Area.Align, X0, Y0 - U * dieSizeY);
            res = CommonFunctions.Match(pattenModel, Mag, out _, out _);
            if (res != 0) return res;//若匹配失败，直接返回findShapeModel错误结果
            Motion.GetUserPos(Compensation.Area.Align, out double X1, out double Y1);

            //运动到R点做精定位
            Motion.UserPosMoveAbs(Compensation.Area.Align, X0, Y0 + D * dieSizeY);
            res = CommonFunctions.Match(pattenModel, Mag, out _, out _);
            if (res != 0) return res;//若匹配失败，直接返回findShapeModel错误结果
            Motion.GetUserPos(Compensation.Area.Align, out double X2, out double Y2);

            //计算结果
            double[] feedbackX = new double[2] { X1, X2 };
            double[] feedbackY = new double[2] { Y1, Y2 };

            Mag.halconClass.GetWaferAngle2Points(feedbackX, feedbackY, out double Angle);
            //txtAngle.Text = Angle.ToString();

            if ((90 - Math.Abs(Angle)) > 5)
            {
                MessageBox.Show("Error Angle");
                return 3;//角度错误
            }
            double ToRotate = (Angle > 0) ? (90 - Angle) : (90 + Angle);
            int feedbackR = (int)Math.Round(ToRotate * 10000, 0);//TODO:如果用轴运动坐标系，符号相反，待兼容
            Motion.AxisMoveRel(1, 4, feedbackR, 600, 10, 10, 20);

            //移回中点处
            Motion.UserPosMoveAbs(Compensation.Area.Align, X0, Y0);
            RotateY = (Y1 * (X0 - X2) - Y2 * (X0 - X1)) / (X1 - X2);
            return 0;
        }

        /// <summary>
        /// 根据index值，获得用户坐标系坐标
        /// </summary>
        /// <param name="indexX"></param>
        /// <param name="intexY"></param>
        /// <param name="userPosX"></param>
        /// <param name="userPosY"></param>
        /// <returns></returns>
        public static int GetMapUserPos(int indexX, int intexY, out double userPosX, out double userPosY)
        {
            userPosX = double.NaN; userPosY = double.NaN;
            if (WaferMap.Entity.MappingPoints == null) return 1;

            var point = WaferMap.Entity.MappingPoints.Find(p => p.IndexX == indexX && p.IndexY == intexY);
            if (point == null) return 2;

            userPosX = point.UserPosX;
            userPosY = point.UserPosY;
            return 0;
        }

        /// <summary>
        /// 指定区域，和index，进行补偿运动
        /// </summary>
        /// <param name="area"></param>
        /// <param name="indexX"></param>
        /// <param name="indexY"></param>
        public static void IndexMove(Compensation.Area area, int indexX, int indexY)
        {
            //TODO：需要知道是粗定位还是精定位下的坐标
            IndexUserPosAfterAlign(indexX, indexY, out double UserPosX, out double UserPosY);
            Motion.UserPosMoveAbs(area, UserPosX, UserPosY);
            //刷新当前位置
            WaferMap.CurrentIndexX = indexX; WaferMap.CurrentIndexY = indexY;
            CommonPanel.IndexX = indexX; CommonPanel.IndexY = indexY;
        }

        /// <summary>
        /// 带了Offset的精确定位
        /// </summary>
        /// <param name="indexX"></param>
        /// <param name="indexY"></param>
        /// <param name="userPosX"></param>
        /// <param name="userPosY"></param>
        public static void IndexUserPosAfterAlign(int indexX, int indexY, out double userPosX, out double userPosY)
        {
            //TODO：需要知道是粗定位还是精定位下的坐标
            //求refDieOrg的坐标
            double refDieOrgX = 0 + WaferMap.Entity.Center2RefDieCornerX + WaferMap.Entity.Corner2OrgX;
            double refDieOrgY = 0 + WaferMap.Entity.Center2RefDieCornerY + WaferMap.Entity.Corner2OrgY;
            //求DieOrg的坐标
            userPosX = (indexX - WaferMap.Entity.RefDieX) * WaferMap.Entity.DieSizeX + refDieOrgX;
            userPosY = (indexY - WaferMap.Entity.RefDieY) * WaferMap.Entity.DieSizeY + refDieOrgY;
            //加offset
            userPosX += WaferMap.WaferOffsetX; userPosY += WaferMap.WaferOffsetY;
        }
        #endregion

        /// <summary>
        /// 根据index值，获得轴坐标系坐标
        /// </summary>
        /// <param name="indexX"></param>
        /// <param name="indexY"></param>
        /// <param name="encodeX"></param>
        /// <param name="encodeY"></param>
        /// <returns></returns>
        public static int GetMapEncode(int indexX, int indexY, out double encodeX, out double encodeY)
        {
            encodeX = double.NaN; encodeY = double.NaN;
            if (WaferMap.Entity.MappingPoints == null) return 1;

            var point = WaferMap.Entity.MappingPoints.Find(p => p.IndexX == indexX && p.IndexY == indexY);
            if (point == null) return 2;

            encodeX = point.EncodeX;
            encodeY = point.EncodeY;
            return 0;
        }

        /// <summary>
        /// 返回当前wafer的9点
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public static void Generate9Pionts(out double[] X, out double[] Y)
        {
            X = new double[9];
            Y = new double[9];
            double R = 1300000;

            int dltX = (int)(R / WaferMap.Entity.DieSizeX);
            int dltY = (int)(R / WaferMap.Entity.DieSizeY);
            int dltX2 = (int)(R / 1.414 / WaferMap.Entity.DieSizeX);
            int dltY2 = (int)(R / 1.414 / WaferMap.Entity.DieSizeY);

            int refX = WaferMap.Entity.RefDieX;
            int refY = WaferMap.Entity.RefDieY;

            GetMapUserPos(refX, refY - dltY, out X[0], out Y[0]);//点0
            GetMapUserPos(refX + dltX2, refY - dltY2, out X[1], out Y[1]);//点1
            GetMapUserPos(refX + dltX, refY, out X[2], out Y[2]);//点2
            GetMapUserPos(refX + dltX2, refY + dltY2, out X[3], out Y[3]);//点3
            GetMapUserPos(refX, refY + dltY, out X[4], out Y[4]);//点4
            GetMapUserPos(refX - dltX2, refY + dltY2, out X[5], out Y[5]);//点5
            GetMapUserPos(refX - dltX, refY, out X[6], out Y[6]);//点6
            GetMapUserPos(refX - dltX2, refY - dltY2, out X[7], out Y[7]);//点7
            GetMapUserPos(refX, refY, out X[8], out Y[8]);//点8

            for (int i = 0; i < 9; i++)
            {
                X[i] += WaferMap.WaferOffsetX;
                Y[i] += WaferMap.WaferOffsetY;
            }
        }

        /// <summary>
        /// 根据已知参数生产mappingpoints
        /// </summary>
        public static void InitialMappingPoints()
        {
            if (WaferMap.Entity.MappingPoints != null) WaferMap.Entity.MappingPoints.Clear();

            //求refDieOrg的坐标
            double refDieOrgX = 0 + WaferMap.Entity.Center2RefDieCornerX + WaferMap.Entity.Corner2OrgX;
            double refDieOrgY = 0 + WaferMap.Entity.Center2RefDieCornerY + WaferMap.Entity.Corner2OrgY;

            for (int i = 0; i < WaferMap.Entity.DieNumX; i++)
            {
                for (int j = 0; j < WaferMap.Entity.DieNumY; j++)
                {
                    //新增一个点
                    MappingPoint point = new MappingPoint();
                    point.UserPosX = (i - WaferMap.Entity.RefDieX) * WaferMap.Entity.DieSizeX + refDieOrgX;
                    point.UserPosY = (j - WaferMap.Entity.RefDieY) * WaferMap.Entity.DieSizeY + refDieOrgY;

                    point.IndexX = i;
                    point.IndexY = j;

                    if (WaferMap.Entity.MappingPoints != null) WaferMap.Entity.MappingPoints.Add(point);
                }
            }
        }

        #region PinAlignment
        public static void MovePinToCenter()
        {
            Vision.PinHighMag.TriggerMode();
            Vision.PinHighMag.TriggerExec();

            int res = Vision.PinHighMag.halconClass.GetPin(out double DeltaX, out double DeltaY);
            if (res != 0) { MessageBox.Show("Move To Pin Error."); return; }

            Motion.XYZ_AxisMoveRel(1, Convert.ToInt32(DeltaX), Convert.ToInt32(DeltaY), 0, 600, 10, 10, 20);
            Vision.PinHighMag.ContinuesMode();
        }
        public static void GoToPin(int index)
        {
            if (index > PinData.Entity.Pins.Count) return;
            //TODO 根据粗精模式走点

            double X = PinData.Entity.RefPinX + PinData.Entity.Pins[index].PosX;
            double Y = PinData.Entity.RefPinY + PinData.Entity.Pins[index].PosY;
            Motion.XY_AxisMoveAbs(1, X, Y, 600, 10, 10, 20);
            PinData.CurrentIndex = index;
        }
        public static void UpdateProbePosition()
        {
            double waferOffset = WaferMap.WaferHeight - Motion.parameter.PROBING.ZOrgWaferHeight;//wafer比注册高了waferOffset
            double pinOffset = PinData.Entity.RefPinZ - Motion.parameter.PROBING.ZOrgPin;//pin比注册高了pinOffset
            double upPos = Motion.parameter.PROBING.ZOrgWaferHeight + Motion.parameter.PROBING.ZPad2Pin;//注册时候upPos

            DeviceData.Entity.Probing.ZUpPosition = upPos - waferOffset + pinOffset;//当前的upPos理论值
            DeviceData.Entity.Probing.ZDownPosition = DeviceData.Entity.Probing.ZUpPosition + DeviceData.Entity.Probing.ZClearance;
        }
        #endregion
        public static void Delay(int mm)
        {
            while (DateTime.Now.AddMilliseconds((double)mm) > DateTime.Now)
            {
              Thread.Sleep(1);
              Application.DoEvents();
            }
        }
    }
}
