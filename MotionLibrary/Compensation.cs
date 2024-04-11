using System.Text.Json;
using WaferMapLibrary;
namespace MotionLibrary
{
    public static class Compensation
    {
        public static WaferMapClass ErrorMapAlign = new();
        public static WaferMapClass ErrorMapProbing = new();
        public static List<Grid>? CalibrationGrids = new();//为了给测试用来可视化Grids，所以pulbic
        public static List<Grid>? WorkingGrids = new();//为了给测试用来可视化Grids，所以pulbic

        public class Grid
        {
            //分别为00左下，01右下，11右上，10左上 四个点
            public MappingPoint[] Pt = new MappingPoint[4];
            public double UserPosCentroidX;
            public double UserPosCentroidY;
            public double EncodeCentroidX;
            public double EncodeCentroidY;
        }

        /// <summary>
        /// 0 = 标定区；1 = 工作区
        /// </summary>
        public enum Area
        {
            Align = 0,
            Probing = 1,
        }

        /// <summary>
        /// 0:输入用户坐标，求Encode;1,输入Encode，求用户坐标
        /// </summary>
        public enum Dir
        {
            User2Encode = 0, //Dir = 0:输入用户坐标，求Encode
            Encode2User = 1, //int Dir = 1,输入Encode，求用户坐标
        }

        public static void SaveMap(WaferMapClass entity, string path)
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
            };
            string jsonString = JsonSerializer.Serialize(entity, options);
            File.WriteAllText(path, jsonString);
        }

        public static void LoadMap(out WaferMapClass entity, string Path)
        {
            entity = new WaferMapClass();
            string jsonString = File.ReadAllText(Path);
            var item = JsonSerializer.Deserialize<WaferMapClass>(jsonString);
            if (item != null) entity = item;
        }

        /// <summary>
        /// 初始化补偿地图参数
        /// </summary>
        /// <returns>0 = 完整；1 = 标定区点位缺失；2 = 工作区点位缺失</returns>
        public static int Initial()
        {
            try
            {
                LoadMap(out ErrorMapAlign, "Config/ErrorMapAlign.json");
                //筛选可用的标定点，组成网格Grids
                CalibrationGrids = GridsAvailable(ErrorMapAlign);
                if (CalibrationGrids == null) return 1;
                if (CalibrationGrids.Count == 0) { return 1; }
            }
            catch (Exception)
            {
                return 1;
            }

            try
            {
                LoadMap(out ErrorMapProbing, "Config/ErrorMapProbing.json");
                //筛选可用的标定点，组成网格Grids
                WorkingGrids = GridsAvailable(ErrorMapProbing);
                if (WorkingGrids == null) return 2;
                if (WorkingGrids.Count == 0) { return 2; }
            }
            catch (Exception)
            {
                return 2;
            }
            return 0;
        }

        /// <summary>
        /// 筛选可用的标定点，组成网格Grids
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        private static List<Grid>? GridsAvailable(WaferMapClass map)
        {
            if (map.MappingPoints == null) { return null; }
            //遍历ErrorMap，选取所有Coordinates = 1
            List<MappingPoint> CoordinatesPoints = map.MappingPoints.Where(p => p.Coordinates == 1).ToList();
            if (CoordinatesPoints.Count == 0) { return null; }

            //遍历CoordinatesPoints，选取所有能形成Grid（该点为左下角）的点            
            List<Grid> grids = new();
            foreach (var point in CoordinatesPoints)
            {
                var NextX = CoordinatesPoints.Find(p => p.IndexX == point.IndexX + 1 && p.IndexY == point.IndexY);
                var NextY = CoordinatesPoints.Find(p => p.IndexX == point.IndexX && p.IndexY == point.IndexY - 1);
                var NextXY = CoordinatesPoints.Find(p => p.IndexX == point.IndexX + 1 && p.IndexY == point.IndexY - 1);
                if (NextX != null && NextY != null && NextXY != null)
                {
                    Grid grid = new();
                    grid.Pt[0] = point;
                    grid.Pt[1] = NextX;
                    grid.Pt[2] = NextXY;
                    grid.Pt[3] = NextY;
                    grid.UserPosCentroidX = grid.Pt.Average(t => t.UserPosX);
                    grid.UserPosCentroidY = grid.Pt.Average(t => t.UserPosY);
                    grid.EncodeCentroidX = grid.Pt.Average(t => t.EncodeX);
                    grid.EncodeCentroidY = grid.Pt.Average(t => t.EncodeY);
                    grids.Add(grid);
                }
            }

            //若没有符合要求的点，则空
            if (grids.Count == 0) { return null; }
            return grids;
        }

        /// <summary>
        /// 双线性插值
        /// https://zh.wikipedia.org/wiki/%E5%8F%8C%E7%BA%BF%E6%80%A7%E6%8F%92%E5%80%BC
        /// </summary>
        /// <param name="px">用户参考点X</param>
        /// <param name="py">用户参考点Y</param>
        /// <param name="qx">原始参考点X</param>
        /// <param name="qy">原始参考点Y</param>
        /// <param name="UserX">用户坐标X</param>
        /// <param name="UserY">用户坐标Y</param>
        /// <param name="FeedbackX"></param>
        /// <param name="FeedbackY"></param>
        public static void BilinearInterpolation(double[] px, double[] py, double[] qx, double[] qy, double UserX, double UserY, out double FeedbackX, out double FeedbackY)
        {
            double p1x = (px[1] - UserX) / (px[1] - px[0]) * qx[0] + (UserX - px[0]) / (px[1] - px[0]) * qx[1];

            double p1y = (px[1] - UserX) / (px[1] - px[0]) * qy[0] + (UserX - px[0]) / (px[1] - px[0]) * qy[1];

            double p2x = (px[2] - UserX) / (px[2] - px[3]) * qx[3] + (UserX - px[3]) / (px[2] - px[3]) * qx[2];

            double p2y = (px[2] - UserX) / (px[2] - px[3]) * qy[3] + (UserX - px[3]) / (px[2] - px[3]) * qy[2];

            FeedbackX = (py[2] - UserY) / (py[2] - py[1]) * p1x + (UserY - py[1]) / (py[2] - py[1]) * p2x;

            FeedbackY = (py[2] - UserY) / (py[2] - py[1]) * p1y + (UserY - py[1]) / (py[2] - py[1]) * p2y;
        }

        /// <summary>
        /// 逆双线性插值
        /// https://www.cnblogs.com/lipoicyclic/p/16338901.html
        /// 最后一个公式错误
        /// https://gwb.tencent.com/community/detail/121581
        /// </summary>
        /// <param name="px">原始参考点X</param>
        /// <param name="py">原始参考点Y</param>
        /// <param name="qx">用户参考点X</param>
        /// <param name="qy">用户参考点Y</param>
        /// <param name="FeedbackX">原始坐标X</param>
        /// <param name="FeedbackY">原始坐标Y</param>
        /// <param name="UserX"></param>
        /// <param name="UserY"></param>
        /// <returns>0：计算成功  1：计算错误</returns>
        public static int InverseBilinearInterpolation(double[] px, double[] py, double[] qx, double[] qy, double FeedbackX, double FeedbackY, out double UserX, out double UserY)
        {
            double ex = px[2] - px[3];
            double ey = py[2] - py[3];

            double fx = px[0] - px[3];
            double fy = py[0] - py[3];

            double gx = px[3] - px[2] + px[1] - px[0];
            double gy = py[3] - py[2] + py[1] - py[0];

            double hx = FeedbackX - px[3];
            double hy = FeedbackY - py[3];

            //求Ax^2 + Bx + C = 0 的解
            double A = gx * fy - gy * fx;
            double B = ex * fy - ey * fx + hx * gy - hy * gx;
            double C = hx * ey - hy * ex;

            double v1 = (-B + Math.Sqrt(B * B - 4 * A * C)) / 2 / A;
            double v2 = (-B - Math.Sqrt(B * B - 4 * A * C)) / 2 / A;

            double threshold = 100;//标定格的边长约为3w，实际需要逆差补的点不至于超过NearestGrid，300w个单位，故阈值设为100
            double v0 = (Math.Abs(v1) < Math.Abs(v2)) ? v1 : v2;//取一个绝对值更小的
            double v;
            if (A == 0)
            {
                v = -C / B;//Grid为平行四边形
            }
            else if (v0 < threshold)
            {
                v = v0;//点在距离NearestGrid的100倍范围内，当0<v<1，代表点在grid内部
            }
            else
            {
                UserX = double.NaN;
                UserY = double.NaN;
                return 1;
            }

            double u = (hx - fx * v) / (ex + gx * v);

            UserX = qx[3] + u * (qx[2] - qx[3]) + v * (qx[0] - qx[3] + u * v * (qx[3] - qx[2] + qx[1] - qx[0]));
            UserY = qy[3] + u * (qy[2] - qy[3]) + v * (qy[0] - qy[3] + u * v * (qy[3] - qy[2] + qy[1] - qy[0]));
            return 0;
        }

        /// <summary>
        /// 进行坐标系变化加插值
        /// </summary>
        /// <param name="area"></param>
        /// <param name="dir"></param>
        /// <param name="Xin"></param>
        /// <param name="Yin"></param>
        /// <param name="Xout"></param>
        /// <param name="Yout"></param>
        /// <returns>0 = 正确；1 = 标定点错误; 2 = 标定点数量为0</returns>
        public static int Transform(Area area, Dir dir, double Xin, double Yin, out double Xout, out double Yout)
        {
            //初始化XY输出
            Xout = double.NaN; Yout = double.NaN;

            //判断标定点是否存在，不存在返回1
            List<Grid>? grids = (area == Area.Align) ? CalibrationGrids : WorkingGrids;
            if (grids == null) { return 1; }

            //判断in的点距离哪个grids的中心最近，点可能出现在grids外，所以不能用是否在grids内部来做判断
            Grid grid = NearestGrid(dir, grids, Xin, Yin);

            //根据mode进行双线性插值，或逆插值 
            double[] EncodeX = grid.Pt.Select(t => t.EncodeX).ToArray();
            double[] EncodeY = grid.Pt.Select(t => t.EncodeY).ToArray();
            double[] UserPosX = grid.Pt.Select(t => t.UserPosX).ToArray();
            double[] UserPosY = grid.Pt.Select(t => t.UserPosY).ToArray();

            if (dir == Dir.User2Encode)
            {
                BilinearInterpolation(UserPosX, UserPosY, EncodeX, EncodeY, Xin, Yin, out Xout, out Yout);
            }
            else if (dir == Dir.Encode2User)
            {
                InverseBilinearInterpolation(EncodeX, EncodeY, UserPosX, UserPosY, Xin, Yin, out Xout, out Yout);
            }

            return 0;
        }

        /// <summary>
        /// 获取最近的标定格子
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="grids"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static Grid NearestGrid(Dir dir, List<Grid> grids, double X, double Y)
        {
            //遍历所有能形成Grid的格子，User点到格子形心最短，则该格子选用
            List<double> Distance = new();

            foreach (var grid in grids)
            {
                double dist = double.PositiveInfinity;
                //根据mode判断用哪个坐标做中心去比较
                if (dir == Dir.User2Encode)
                {
                    dist = Math.Sqrt(Math.Pow(X - grid.UserPosCentroidX, 2) + Math.Pow(Y - grid.UserPosCentroidY, 2));
                }
                else if (dir == Dir.Encode2User)
                {
                    dist = Math.Sqrt(Math.Pow(X - grid.EncodeCentroidX, 2) + Math.Pow(Y - grid.EncodeCentroidY, 2));
                }

                Distance.Add(dist);
            }
            //距离最短的点
            int MinIndex = Distance.IndexOf(Distance.Min());

            return grids[MinIndex];
        }
    }
}
