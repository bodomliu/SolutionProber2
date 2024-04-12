using MotionLibrary;
using VisionLibrary;
using WaferMapLibrary;

namespace UtityForm
{
    static internal class Alignment
    {
        /// <summary>
        /// X向校平
        /// </summary>
        /// <param name="Mag"></param>
        /// <param name="pattenModel"></param>
        /// <param name="L"></param>
        /// <param name="R"></param>
        /// <param name="dieSizeX"></param>
        /// <param name="dieSizeY"></param>
        /// <returns>0：匹配成功  1：没有图像  2：匹配失败  3：水平角度大于5度  </returns>
        public static int AlignX(CameraClass Mag, string pattenModel, int L, int R, double dieSizeX)
        {
            int res = 0;
            //运动到L点做精定位
            Motion.UserPosMoveRel(Compensation.Area.Align, -L * dieSizeX, 0);
            res = Match(pattenModel, Mag,out _,out _);
            if (res != 0) return res;//若匹配失败，直接返回findShapeModel错误结果
            Motion.GetUserPos(Compensation.Area.Align, out double startX1, out double startY1);
            //运动到R点做精定位
            Motion.UserPosMoveRel(Compensation.Area.Align, (L+R) * dieSizeX, 0);
            res = Match(pattenModel, Mag, out _, out _);
            if (res != 0) return res;//若匹配失败，直接返回findShapeModel错误结果
            Motion.GetUserPos(Compensation.Area.Align, out double startX2, out double startY2);

            //计算结果
            double[] feedbackX = new double[2] { startX1, startX2 };
            double[] feedbackY = new double[2] { startY1, startY2 };

            Mag.halconClass.GetWaferAngle2Points(feedbackX, feedbackY, out double Angle);
            //txtAngle.Text = Angle.ToString();

            if (Math.Abs(Angle) > 5)
            {
                MessageBox.Show("Error Angle");
                return 3;//角度错误
            }
            int feedbackR = -(int)Math.Round(Angle * 10000, 0);
            Motion.AxisMoveRel(1, 4, feedbackR, 600, 10, 10, 20);

            //移回中点处
            Motion.UserPosMoveRel(Compensation.Area.Align, -R * dieSizeX, 0);

            return 0;
        }



        /// <summary>
        /// TriggerExe 模板匹配 then 运动到位
        /// </summary>
        /// <param name="pattenModel">模板名称</param>
        /// <param name="Mag">相机Camera</param>
        /// <param name="DeltaX">X轴Match过程相对位移</param>
        /// <param name="DeltaY">Y轴Match过程相对位移</param>
        /// <returns>0：匹配成功  1：没有图像  2：匹配失败</returns>
        public static int Match(string pattenModel, CameraClass Mag,out double DeltaX,out double DeltaY)
        {
            Mag.TriggerMode();//单拍模式，对相机模式的切换写在这里合适吗？
            Mag.TriggerExec();//触发一帧
            //匹配pattenModel
            int res = Mag.halconClass.FindShapeModel(pattenModel, 0, out DeltaX, out DeltaY, out double[] X, out double[] Y,
                out double[] Angle, out double[] Score);
            if (res != 0) return res;//若匹配失败，直接返回findShapeModel错误结果
            //相对运动到匹配点
            Motion.XYZ_AxisMoveRel(1, Convert.ToInt32(DeltaX), Convert.ToInt32(DeltaY), 0, 600, 10, 10, 20);
            Mag.ContinuesMode();//连拍模式，匹配完，切回连拍模式
            return 0;
        }

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
        public static int AdjustWaferHeight(double waferThickness,CameraClass Mag)
        {
            double targetHigh = Motion.parameter.ZORIGIN - waferThickness;//46000 - 8000 = 38000
            double targetLow = targetHigh- Motion.parameter.ZWAFERLOW2HIGHT;//38000 - （-8000）= 46000
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
            else
            {
                slowStep = 1000;
                fastStep = 3000;
                endStep = 100000;
                slopThreshold = 1;
            }
        }
    }
}
