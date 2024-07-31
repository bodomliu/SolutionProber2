using MotionLibrary;
using System.Text.Json;
namespace UtilityForm
{
    public class Point3D
    {
        public double x { get; set; } = 0;
        public double y { get; set; } = 0;
        public double z { get; set; } = 0;
    }
    public class PlanarityClass
    {
        public List<Point3D> Inch12 { get; set; } = new List<Point3D>();
        public List<Point3D> Inch8 { get; set; } = new List<Point3D>();
        public List<Point3D> Inch6 { get; set; } = new List<Point3D>();
    }
    public static class Planarity
    {
        public static PlanarityClass Entity = new PlanarityClass();//定义WaferMap的实体
        public static List<Point3D> PointsToSet { get; set; } = new List<Point3D>();//画图用这个变量即可
        private static int waferSize { get; set; } = 12;//默认12寸
        public static int WaferSize
        {
            get { return waferSize; }
            set
            {
                switch (value)
                {
                    case 6:
                        PointsToSet = Entity.Inch6;
                        break;
                    case 8:
                        PointsToSet = Entity.Inch8;
                        break;
                    case 12:
                        PointsToSet = Entity.Inch12;
                        break;
                    default:
                        throw new Exception("WaferSize must be 6/8/12");
                }
                waferSize = value;
            }
        }
        public static int Index { get; set; } = 0;//位置
        public static double AverageHeight { get; set; } = 0;//当前Wafer的平均高度
        public static double Difference { get; set; } = 0;//当前Wafer的高度差
        public static void Save(string filePath, int waferSize)
        {
            //保存的时候先将PointsToSet存入Entity,再写入文件
            switch (waferSize)
            {
                case 6:
                    Entity.Inch6 = PointsToSet;
                    break;
                case 8:
                    Entity.Inch8 = PointsToSet;
                    break;
                case 12:
                    Entity.Inch12 = PointsToSet;
                    break;
                default:
                    throw new Exception("WaferSize must be 6/8/12");
            }

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
            var item = JsonSerializer.Deserialize<PlanarityClass>(jsonString);
            if (item != null)
            {
                Entity = item;
                //OnWaferMapChange?.Invoke();
            }
        }
        //重置CPI
        private static void Reset(string filePath, int waferSize)
        {
            Gen9Points(waferSize, out double[] x, out double[] y);
            PointsToSet = new List<Point3D>();
            for (int i = 0; i < 9; i++)
            {
                PointsToSet.Add(new Point3D { x = x[i], y = y[i], z = 0});
            }
            Save(filePath, waferSize);
        }
        public static void ResetAll(string filePath)
        {
            Reset(filePath, 6);
            Reset(filePath, 8);
            Reset(filePath, 12);
        }
        public static void UpdateHeightAndDiff()
        {
            //do with PointsToSet
            List<double> doubles = PointsToSet.Select(point => point.z).ToList();
            AverageHeight = doubles.Average();
            Difference = doubles.Max() - doubles.Min();
        }
        public static void RegHeight(int index, double height)
        {
            //reg height of current Point
            PointsToSet[index].z = height;
        }

        public static void RegPosition(int index, double x, double y)
        {
            PointsToSet[index].x = x;
            PointsToSet[index].y = y;
        }
        public static void Gen9Points(int waferSize, out double[] x, out double[] y)
        {
            x = new double[9];
            y = new double[9];

            double r;//radium
            switch (waferSize)
            {
                case 6:
                    r = 1350000;
                    break;
                case 8:
                    r = 1350000;
                    break;
                case 12:
                    r = 1350000;
                    break;
                default:
                    throw new Exception("WaferSize must be 6/8/12");
            }
            //原点
            x[0] = Motion.parameter.XORIGIN;
            y[0] = Motion.parameter.YORIGIN;
            x[0] = Math.Round(x[0] / 10000) * 10000;//取整
            y[0] = Math.Round(y[0] / 10000) * 10000;//取整

            //45度换算成弧度
            double deltaAng = 45 * Math.PI / 180;
            //x1 = x0 + r * cos(a)
            //y1 = y0 + r * sin(a)
            //极坐标，换算角度方向后
            for (int i = 1; i < 9; i++)
            {
                x[i] = x[0] + r * Math.Sin((i-1) * deltaAng - Math.PI);
                y[i] = y[0] + r * Math.Cos((i-1) * deltaAng - Math.PI);
                x[i] = Math.Round(x[i] / 10000) * 10000;//取整
                y[i] = Math.Round(y[i] / 10000) * 10000;//取整
            }
        }
    }
}
