using System.Text.Json;

namespace Inspection
{
    public class WaferInformation
    {

    }
    public class SetupInfomation
    {

    }
    public class Result
    {
        public int DieIndexX { get; set; } = 0;
        public int DieIndexY { get; set; } = 0;
        public int PadIndex { get; set; } = 0;
        public double Top { get; set; } = 0;
        public double Bottom { get; set; } = 0;
        public double Left { get; set; } = 0;
        public double Right { get; set; } = 0;
        public double DeltaX { get; set; } = 0;
        public double DeltaY { get; set; } = 0;
    }
    public static class PmiData
    {
        public static WaferInformation WaferInformation { get; set; } = new WaferInformation();
        public static SetupInfomation SetupInfomation { get; set; } = new SetupInfomation();
        public static List<Result> Results { get; set; } = new List<Result>();
        public static List<Result> PmiRef { get; set; } = new List<Result>();

        public static void Save(string filePath)
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
            };
            string jsonString = JsonSerializer.Serialize(PmiRef, options);
            File.WriteAllText(filePath, jsonString);
        }
        public static void Load(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            var item = JsonSerializer.Deserialize<List<Result>>(jsonString);
            if (item != null)
            {
                PmiRef = item;
            }
        }

        /// <summary>
        /// 已知 v1 = f(p1)，v2 = f(p2)为端点，求线性插值f(p0)?
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="v1"></param>
        /// <param name="p2"></param>
        /// <param name="v2"></param>
        /// <param name="p0"></param>
        /// <param name="inc"></param>
        /// <returns></returns>
        private static double LinerInterpolation(int p1,double v1, int p2,double v2, int p0,out double v0)
        {
            //线性插值
            v0 = (v2 - v1) / (p2 - p1) * (p0 - p1) + v1;
            return v0;
        }

        public static int Interpolation(int dieIndexX, int dieIndexY,  out double incX,out double incY)
        {
            incX = 0; incY = 0;
            //尝试看这个die是否属于Result的参考点
            var obj = PmiRef.Find(p => p.DieIndexY == dieIndexY && p.DieIndexX == dieIndexX);
            if (obj != null)
            {
                incX = obj.DeltaX;
                incY = obj.DeltaY;
                return 0;
            }
            InterpolationX(dieIndexX, dieIndexY, out incY);//横向的插值，两个插值互不影响
            InterpolationY(dieIndexX, dieIndexY, out incX);//纵向的插值
            return 0;
        }

        private static int InterpolationX(int dieIndexX,int dieIndexY,out double incY)
        {
            incY = 0;//如果错误就不插值
            //寻找该点左右侧参考点
            List<Result> refWithIndexY = PmiRef.Where(p => p.DieIndexY == dieIndexY).ToList();
            if (refWithIndexY.Count < 2) return 1;//找不到2个点以上就退出
            //按index降序排列
            List<Result> refSorted = refWithIndexY.OrderByDescending(p => p.DieIndexX).ToList();
            int p1 = refSorted[0].DieIndexX;
            double v1 = refSorted[0].DeltaY;
            int p2 = refSorted[refSorted.Count - 1].DieIndexX;
            double v2 = refSorted[refSorted.Count - 1].DeltaY;
            if ((dieIndexX - p1) * (dieIndexX - p2) > 0) return 2;//P不在P1、P2中间，无法做插值
            LinerInterpolation(p1, v1, p2, v2, dieIndexX, out incY);
            return 0;
        }
        private static int InterpolationY(int dieIndexX, int dieIndexY, out double incX)
        {
            incX = 0;//如果错误就不插值
            //寻找该点左右侧参考点
            List<Result> refWithIndexX = PmiRef.Where(p => p.DieIndexX == dieIndexX).ToList();
            if (refWithIndexX.Count < 2) return 1;//找不到2个点以上就退出
            //按index降序排列
            List<Result> refSorted = refWithIndexX.OrderByDescending(p => p.DieIndexY).ToList();
            int p1 = refSorted[0].DieIndexY;
            double v1 = refSorted[0].DeltaX;
            int p2 = refSorted[refSorted.Count - 1].DieIndexY;
            double v2 = refSorted[refSorted.Count - 1].DeltaX;
            if ((dieIndexY - p1) * (dieIndexY - p2) > 0) return 2;//P不在P1、P2中间，无法做插值
            LinerInterpolation(p1, v1, p2, v2, dieIndexY, out incX);
            return 0;
        }

    }
}
