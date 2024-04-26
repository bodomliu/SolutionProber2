using CommonComponentLibrary;
using MainForm;
using VisionLibrary;

namespace MainForm
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
            //记录初始位置
            Motion.GetUserPos(Compensation.Area.Align, out double startX0, out double startY0);

            //运动到L点做精定位
            Motion.UserPosMoveAbs(Compensation.Area.Align, startX0 - L * dieSizeX, startY0);
            res = CommonFunctions.Match(pattenModel, Mag, out _, out _);
            if (res != 0) return res;//若匹配失败，直接返回findShapeModel错误结果
            Motion.GetUserPos(Compensation.Area.Align, out double startX1, out double startY1);

            //运动到R点做精定位
            Motion.UserPosMoveAbs(Compensation.Area.Align, startX0 + R * dieSizeX, startY0);
            res = CommonFunctions.Match(pattenModel, Mag, out _, out _);
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
            int feedbackR = (int)Math.Round(Angle * 10000, 0);//TODO:如果用轴运动坐标系，符号相反，待兼容
            Motion.AxisMoveRel(1, 4, feedbackR, 600, 10, 10, 20);

            //移回中点处
            Motion.UserPosMoveAbs(Compensation.Area.Align, startX0, startY0);

            return 0;
        }
    }
}
