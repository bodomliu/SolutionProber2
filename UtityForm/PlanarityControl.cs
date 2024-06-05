using CommonComponentLibrary;
using VisionLibrary;
using MotionLibrary;
using WaferMapLibrary;
namespace MainForm
{
    public partial class PlanarityControl : UserControl
    {
        //List<PlanarityPoint> Points6inch = new List<PlanarityPoint>();
        //List<PlanarityPoint> Points8inch = new List<PlanarityPoint>();
        //List<PlanarityPoint> Points12inch = new List<PlanarityPoint>();

        //int[] Points6inch_X = new int[9];
        //int[] Points6inch_Y = new int[9];
        //int[] Points6inch_Z = new int[9];

        //int[] Points8inch_X = new int[9];
        //int[] Points8inch_Y = new int[9];
        //int[] Points8inch_Z = new int[9];

        //int[] Points12inch_X = new int[9];
        //int[] Points12inch_Y = new int[9];
        //int[] Points12inch_Z = new int[9];

        //Label[] labels = new Label[9];
        public PlanarityControl()
        {
            InitializeComponent();
        }
        private void PlanarityControl_Load(object sender, EventArgs e)
        {
            //默认是With Wafer模式
            RbtnWithWafer.Checked = true;

            //默认是WaferHighMag
            RbtnWaferCamera.Checked = true;
            Vision.ChangeCamera(Vision.WaferHighMag);
        }
        private void UpdateZ(double[] Z)
        {
            lblAvgZ.Text = Z.Average().ToString();
            lblDiffZ.Text = (Z.Max() - Z.Min()).ToString();

            btn1.Text = Z[0].ToString();
            btn2.Text = Z[1].ToString();
            btn3.Text = Z[2].ToString();
            btn4.Text = Z[3].ToString();
            btn5.Text = Z[4].ToString();
            btn6.Text = Z[5].ToString();
            btn7.Text = Z[6].ToString();
            btn8.Text = Z[7].ToString();
            btn9.Text = Z[8].ToString();

            Diff1.Text = (Z[0] - Z[8]).ToString();
            Diff2.Text = (Z[1] - Z[8]).ToString();
            Diff3.Text = (Z[2] - Z[8]).ToString();
            Diff4.Text = (Z[3] - Z[8]).ToString();
            Diff5.Text = (Z[4] - Z[8]).ToString();
            Diff6.Text = (Z[5] - Z[8]).ToString();
            Diff7.Text = (Z[6] - Z[8]).ToString();
            Diff8.Text = (Z[7] - Z[8]).ToString();
            Diff9.Text = (Z[8] - Z[8]).ToString();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //JsonArray Pointsinch12 = new JsonArray();

            //for (int i = 0; i < 9; i++)
            //{
            //    JsonArray item = new JsonArray();
            //    item.Add(Points12inch_X[i]);
            //    item.Add(Points12inch_Y[i]);
            //    item.Add(Points12inch_Z[i]);

            //    Pointsinch12.Add(item);
            //}


            //var jasonString = new JsonObject
            //{
            //    ["12inch"] = Pointsinch12,
            //};
            //var options = new JsonSerializerOptions { WriteIndented = true };
            //Console.WriteLine(jasonString.ToJsonString(options));
            //File.WriteAllText("PlanarityPoints.json", jasonString.ToJsonString(options));
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            //string json = File.ReadAllText("PlanarityPoints.json");
            //var jsonNode = JsonNode.Parse(json);

            //var DataList = jsonNode["12inch"];

            //JsonArray listArray = DataList.AsArray();

            //for (int i = 0; i < 9; i++)
            //{
            //    JsonArray point = listArray[i].AsArray();

            //    Points12inch_X[i] = point[0].GetValue<int>();
            //    Points12inch_Y[i] = point[1].GetValue<int>();
            //    Points12inch_Z[i] = point[2].GetValue<int>();
            //}
            //UpdatePos();
        }
        private void btnMove_Click(object sender, EventArgs e)
        {
            int index = 0;

            Button btnMove = (Button)sender;
            var item = btnMove.Tag.ToString();

            if (item != null)
            {
                index = int.Parse(item) - 1;
            }

            CommonFunctions.Generate9Pionts(out double[] userX, out double[] userY);

            Motion.UserPosMoveAbs(Compensation.Area.Align, userX[index], userY[index]);
        }
        private void btnCheckAllPos_Click(object sender, EventArgs e)
        {
            double[] Z = new double[9];

            CommonFunctions.Generate9Pionts(out double[] userX, out double[] userY);

            for (int i = 0; i < 9; i++)
            {
                //Application.DoEvents();
                if (RbtnWaferCamera.Checked) Motion.UserPosMoveAbs(Compensation.Area.Align, userX[i], userY[i]);
                double thickness = (RbtnWithWafer.Checked) ? DeviceData.Entity.PhysicalInformation.Thickness : 0;
                int res = CommonFunctions.AdjustWaferHeight(thickness, Vision.WaferHighMag);
                if (res != 0) { MessageBox.Show("Adjust Wafer Height wrong "); return; }
                Z[i] = Motion.GetEncPos(1, 3);
            }

            UpdateZ(Z);
        }
        private void btnUpdatePos_Click(object sender, EventArgs e)
        {
            CommonFunctions.Generate9Pionts(out double[] userX, out double[] userY);

            X1.Text = userX[0].ToString();
            Y1.Text = userY[0].ToString();
            X2.Text = userX[1].ToString();
            Y2.Text = userY[1].ToString();
            X3.Text = userX[2].ToString();
            Y3.Text = userY[2].ToString();
            X4.Text = userX[3].ToString();
            Y4.Text = userY[3].ToString();
            X5.Text = userX[4].ToString();
            Y5.Text = userY[4].ToString();
            X6.Text = userX[5].ToString();
            Y6.Text = userY[5].ToString();
            X7.Text = userX[6].ToString();
            Y7.Text = userY[6].ToString();
            X8.Text = userX[7].ToString();
            Y8.Text = userY[7].ToString();
            X9.Text = userX[8].ToString();
            Y9.Text = userY[8].ToString();
        }
        private void BtnAdjustWaferHeight_Click(object sender, EventArgs e)
        {
            WaitingControl wf = new WaitingControl();
            this.Controls.Add(wf);
            wf.Show();

            if (Vision.activeCamera == Camera.WaferLowMag)
            {
                CommonFunctions.AdjustWaferHeight(DeviceData.Entity.PhysicalInformation.Thickness, Vision.WaferLowMag);
            }
            else if (Vision.activeCamera == Camera.WaferHighMag)
            {
                CommonFunctions.AdjustWaferHeight(DeviceData.Entity.PhysicalInformation.Thickness, Vision.WaferHighMag);
            }

            wf.Dispose();
        }
        private void RbtnWaferCamera_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtnWaferCamera.Checked) Vision.ChangeCamera(Vision.WaferHighMag);
            else if (RbtnJigCamera.Checked) Vision.ChangeCamera(Vision.JigCamera);
        }
    }
}
