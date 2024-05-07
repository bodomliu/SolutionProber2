using MainForm;
using System.Diagnostics;
using static GTN.mc;

namespace MainForm
{
    public partial class MotionControl : UserControl
    {
        public short core;
        public short axis;
        short Z;
        public MotionControl()
        {
            Stopwatch sw = Stopwatch.StartNew();
            InitializeComponent();
            //开卡
            //Motion.Initial();
            timer1.Enabled = true;
            sw.Stop();
            Console.WriteLine("Motion Control " + sw.ElapsedMilliseconds + " ms");
        }

        private void MotionControl_Load(object sender, EventArgs e)
        {

        }


        private void HomeIII_Click(object sender, EventArgs e)
        {
            Motion.XYZR_AxisHome();
        }
        public void UpdateUI()
        {
            Xposition.Text = m_AxisSts[0].EncPos.ToString();
            Yposition.Text = m_AxisSts[1].EncPos.ToString();
            Zposition.Text = m_AxisSts[2].EncPos.ToString();
            Rposition.Text = m_AxisSts[3].EncPos.ToString();

            XEncVel.Text = m_AxisSts[0].EncVel.ToString();
            YEncVel.Text = m_AxisSts[1].EncVel.ToString();
            ZEncVel.Text = m_AxisSts[2].EncVel.ToString();
            REncVel.Text = m_AxisSts[3].EncVel.ToString();

            XpicAxisOn.BackColor = (m_AxisSts[0].AxisOn) ? Color.Red : Color.Green;
            YpicAxisOn.BackColor = (m_AxisSts[1].AxisOn) ? Color.Red : Color.Green;
            ZpicAxisOn.BackColor = (m_AxisSts[2].AxisOn) ? Color.Red : Color.Green;
            RpicAxisOn.BackColor = (m_AxisSts[3].AxisOn) ? Color.Red : Color.Green;

            XpicAxisAlarm.BackColor = (m_AxisSts[0].AxisAlarm) ? Color.Red : Color.Green;
            YpicAxisAlarm.BackColor = (m_AxisSts[1].AxisAlarm) ? Color.Red : Color.Green;
            ZpicAxisAlarm.BackColor = (m_AxisSts[2].AxisAlarm) ? Color.Red : Color.Green;
            RpicAxisAlarm.BackColor = (m_AxisSts[3].AxisAlarm) ? Color.Red : Color.Green;

            XpicP_Lmt.BackColor = (m_AxisSts[0].P_Lmt) ? Color.Red : Color.Green;
            YpicP_Lmt.BackColor = (m_AxisSts[1].P_Lmt) ? Color.Red : Color.Green;
            ZpicP_Lmt.BackColor = (m_AxisSts[2].P_Lmt) ? Color.Red : Color.Green;
            RpicP_Lmt.BackColor = (m_AxisSts[3].P_Lmt) ? Color.Red : Color.Green;

            XpicN_Lmt.BackColor = (m_AxisSts[0].N_Lmt) ? Color.Red : Color.Green;
            YpicN_Lmt.BackColor = (m_AxisSts[1].N_Lmt) ? Color.Red : Color.Green;
            ZpicN_Lmt.BackColor = (m_AxisSts[2].N_Lmt) ? Color.Red : Color.Green;
            RpicN_Lmt.BackColor = (m_AxisSts[3].N_Lmt) ? Color.Red : Color.Green;

            XpicArrive.BackColor = (m_AxisSts[0].Arrive) ? Color.Red : Color.Green;
            YpicArrive.BackColor = (m_AxisSts[1].Arrive) ? Color.Red : Color.Green;
            ZpicArrive.BackColor = (m_AxisSts[2].Arrive) ? Color.Red : Color.Green;
            RpicArrive.BackColor = (m_AxisSts[3].Arrive) ? Color.Red : Color.Green;
        }

        private Motion.AxisStatus[] m_AxisSts = new Motion.AxisStatus[4]; //新建4根主轴状态

        private void timer1_Tick(object sender, EventArgs e)
        {

            //刷新轴状态
            uint pClock; //时钟信号
            double[] pEncPos = new double[4];
            double[] pEncVel = new double[4];
            Z = GTN.mc.GTN_GetEncPos(1, 1, out pEncPos[0], 4, out pClock);
            Z = GTN.mc.GTN_GetEncVel(1, 1, out pEncVel[0], 4, out pClock);

            //轴状态指示灯，只能读取状态为0或1
            int[] AxisStatus = new int[4];
            Z = GTN.mc.GTN_GetSts(1, 1, out AxisStatus[0], 4, out pClock);//读取1-4轴状态
            //commandHandler("GTN_GetSts", Z);

            //赋值并在label显示
            for (int i = 0; i < 4; i++)
            {
                m_AxisSts[i] = new Motion.AxisStatus();
                m_AxisSts[i].EncPos = pEncPos[i];
                m_AxisSts[i].EncVel = pEncVel[i];

                m_AxisSts[i].AxisOn = ((AxisStatus[i] & 0x200) == 0) ? false : true;
                m_AxisSts[i].AxisAlarm = ((AxisStatus[i] & 0x002) == 0) ? false : true;
                m_AxisSts[i].P_Lmt = ((AxisStatus[i] & 0x020) == 0) ? false : true;
                m_AxisSts[i].N_Lmt = ((AxisStatus[i] & 0x040) == 0) ? false : true;
                m_AxisSts[i].Arrive = ((AxisStatus[i] & 0x800) == 0) ? false : true;
            }

            UpdateUI();
        }
        private void BtnXforward_MouseDown(object sender, MouseEventArgs e)
        {
            double velJ = 10;//Jog正向运动的速度
            double accJ = 10;//Jog正向运动的加速度
            double decJ = 10;//Jog正向运动的减速度
            double SmoothtimeJ = 0;//Jog正向运动的平滑时间[0,1)
            Motion.AxisJog(1, 1, velJ, accJ, decJ, SmoothtimeJ);
        }
        private void BtnXforward_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(1, 1, 0);
        }

        private void BtnYforward_MouseDown(object sender, MouseEventArgs e)
        {
            double velJ = 10;//Jog正向运动的速度
            double accJ = 10;//Jog正向运动的加速度
            double decJ = 10;//Jog正向运动的减速度
            double SmoothtimeJ = 0;//Jog正向运动的平滑时间[0,1)
            Motion.AxisJog(1, 2, velJ, accJ, decJ, SmoothtimeJ);
        }

        private void BtnYforward_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(1, 2, 0);
        }

        private void BtnXbackward_MouseDown(object sender, MouseEventArgs e)
        {
            double velJ = 10;//Jog正向运动的速度
            double accJ = 10;//Jog正向运动的加速度
            double decJ = 10;//Jog正向运动的减速度
            double SmoothtimeJ = 0;//Jog正向运动的平滑时间[0,1)
            Motion.AxisJog(1, 1, -velJ, accJ, decJ, SmoothtimeJ);
        }

        private void BtnXbackward_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(1, 1, 0);
        }

        private void BtnYbackward_MouseDown(object sender, MouseEventArgs e)
        {
            double velJ = 10;//Jog正向运动的速度
            double accJ = 10;//Jog正向运动的加速度
            double decJ = 10;//Jog正向运动的减速度
            double SmoothtimeJ = 0;//Jog正向运动的平滑时间[0,1)
            Motion.AxisJog(1, 2, -velJ, accJ, decJ, SmoothtimeJ);
        }

        private void BtnYbackward_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(1, 2, 0);
        }

        private void ClrSts_Click(object sender, EventArgs e)
        {
            GTN.mc.GTN_ClrSts(1, 1, 1);
            GTN.mc.GTN_ClrSts(1, 2, 1);
            GTN.mc.GTN_ClrSts(1, 3, 1);
            GTN.mc.GTN_ClrSts(1, 4, 1);
            GTN.mc.GTN_ClrSts(2, 1, 1);
            GTN.mc.GTN_ClrSts(2, 2, 1);
            GTN.mc.GTN_ClrSts(2, 3, 1);
            GTN.mc.GTN_ClrSts(2, 4, 1);
            GTN.mc.GTN_ClrSts(2, 5, 1);
            GTN.mc.GTN_ClrSts(2, 6, 1);

        }

        private void BtnZforward_MouseDown(object sender, MouseEventArgs e)
        {
            double velJ = 10;//Jog正向运动的速度
            double accJ = 10;//Jog正向运动的加速度
            double decJ = 10;//Jog正向运动的减速度
            double SmoothtimeJ = 0;//Jog正向运动的平滑时间[0,1)
            Motion.AxisJog(1, 3, velJ, accJ, decJ, SmoothtimeJ);
        }

        private void BtnZforward_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(1, 3, 0);
        }

        private void BtnZbackward_MouseDown(object sender, MouseEventArgs e)
        {
            double velJ = 10;//Jog正向运动的速度
            double accJ = 10;//Jog正向运动的加速度
            double decJ = 10;//Jog正向运动的减速度
            double SmoothtimeJ = 0;//Jog正向运动的平滑时间[0,1)
            Motion.AxisJog(1, 3, -velJ, accJ, decJ, SmoothtimeJ);
        }
        private void BtnZbackward_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(1, 3, 0);
        }

        /// <summary>
        /// 运动轴绝对运动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveAbs_Click(object sender, EventArgs e)
        {
            try
            {
                double vel = 600;//增量运动的速度
                double acc = 10;//增量运动的加速度
                double dec = 10;//增量运动的减速度
                short smoothtime = 0;//增量运动的平滑时间[0,50]

                Motion.AxisMoveAbs(1, 1, Convert.ToInt32(ToXposition.Text), vel, acc, dec, smoothtime);
                Motion.AxisMoveAbs(1, 2, Convert.ToInt32(ToYposition.Text), vel, acc, dec, smoothtime);
                Motion.AxisMoveAbs(1, 3, Convert.ToInt32(ToZposition.Text), vel, acc, dec, smoothtime);
            }
            catch
            {
                MessageBox.Show("wrong input");
                return;

            }
        }

        /// <summary>
        /// 运动轴相对运动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnMoveRel_Click(object sender, EventArgs e)
        {
            try
            {
                double vel = 600;//增量运动的速度
                double acc = 10;//增量运动的加速度
                double dec = 10;//增量运动的减速度
                short smoothtime = 0;//增量运动的平滑时间[0,50]


                Motion.AxisMoveRel(1, 1, Convert.ToInt32(XMoveRel.Text), vel, acc, dec, smoothtime);
            }
            catch
            {
                MessageBox.Show("wrong input");
                return;

            }

        }

        private void btnXMoveRel2_Click(object sender, EventArgs e)
        {
            try
            {
                double vel = 600;//增量运动的速度
                double acc = 10;//增量运动的加速度
                double dec = 10;//增量运动的减速度
                short smoothtime = 0;//增量运动的平滑时间[0,50]


                Motion.AxisMoveRel(1, 1, -Convert.ToInt32(XMoveRel.Text), vel, acc, dec, smoothtime);
            }
            catch
            {
                MessageBox.Show("wrong input");
                return;

            }
        }

        private void btnYMoveRel1_Click(object sender, EventArgs e)
        {
            try
            {
                double vel = 600;//增量运动的速度
                double acc = 10;//增量运动的加速度
                double dec = 10;//增量运动的减速度
                short smoothtime = 0;//增量运动的平滑时间[0,50]


                Motion.AxisMoveRel(1, 2, Convert.ToInt32(YMoveRel.Text), vel, acc, dec, smoothtime);
            }
            catch
            {
                MessageBox.Show("wrong input");
                return;

            }
        }

        private void btnYMoveRel2_Click(object sender, EventArgs e)
        {
            try
            {
                double vel = 600;//增量运动的速度
                double acc = 10;//增量运动的加速度
                double dec = 10;//增量运动的减速度
                short smoothtime = 0;//增量运动的平滑时间[0,50]


                Motion.AxisMoveRel(1, 2, -Convert.ToInt32(YMoveRel.Text), vel, acc, dec, smoothtime);
            }
            catch
            {
                MessageBox.Show("wrong input");
                return;

            }
        }

        private void btnZMoveRel1_Click(object sender, EventArgs e)
        {
            try
            {
                double vel = 600;//增量运动的速度
                double acc = 10;//增量运动的加速度
                double dec = 10;//增量运动的减速度
                short smoothtime = 0;//增量运动的平滑时间[0,50]


                Motion.AxisMoveRel(1, 3, Convert.ToInt32(ZMoveRel.Text), vel, acc, dec, smoothtime);
            }
            catch
            {
                MessageBox.Show("wrong input");
                return;

            }
        }

        private void btnZMoveRel2_Click(object sender, EventArgs e)
        {
            try
            {
                double vel = 600;//增量运动的速度
                double acc = 10;//增量运动的加速度
                double dec = 10;//增量运动的减速度
                short smoothtime = 0;//增量运动的平滑时间[0,50]


                Motion.AxisMoveRel(1, 3, -Convert.ToInt32(ZMoveRel.Text), vel, acc, dec, smoothtime);
            }
            catch
            {
                MessageBox.Show("wrong input");
                return;

            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Motion.AxisStop(1, 1, 0);
            Motion.AxisStop(1, 2, 0);
            Motion.AxisStop(1, 3, 0);
            Motion.AxisStop(1, 4, 0);
            Motion.AxisStop(2, 1, 0);
            Motion.AxisStop(2, 2, 0);
            Motion.AxisStop(2, 3, 0);
            Motion.AxisStop(2, 4, 0);
            Motion.AxisStop(2, 5, 0);
            Motion.AxisStop(2, 6, 0);
            Motion.homeToken.Cancel();
        }

        private void Ahome_Click(object sender, EventArgs e)
        {
            Motion.EcatGoHome(1, 100000, 10000, 100000);

        }
        private void U1Home_Click(object sender, EventArgs e)
        {
            Motion.EcatGoHome(4, 100000, 10000, 100000);
        }

        private void U2Home_Click(object sender, EventArgs e)
        {
            Motion.EcatGoHome(5, 100000, 10000, 100000);
        }
        private void VHome_Click(object sender, EventArgs e)
        {
            Motion.EcatGoHome(2, 100000, 10000, 100000);
        }
        private void Whome_Click(object sender, EventArgs e)
        {
            Motion.EcatGoHome(3, 100000, 10000, 100000);
        }

        private void HomeII_Click(object sender, EventArgs e)
        {
            Motion.LoaderAxisHome();
        }
        private void btnAxisOn_Click(object sender, EventArgs e)
        {
            Motion.AxisOn(1, 1);
            Motion.AxisOn(1, 2);
            Motion.AxisOn(1, 3);
            Motion.AxisOn(1, 4);
            Motion.AxisOn(2, 1);
            Motion.AxisOn(2, 2);
            Motion.AxisOn(2, 3);
            Motion.AxisOn(2, 4);
            Motion.AxisOn(2, 5);
            Motion.AxisOn(2, 6);

        }

        private void btnAxisOff_Click(object sender, EventArgs e)
        {
            Motion.AxisOff(1, 1);
            Motion.AxisOff(1, 2);
            Motion.AxisOff(1, 3);
            Motion.AxisOff(1, 4);
            Motion.AxisOff(2, 1);
            Motion.AxisOff(2, 2);
            Motion.AxisOff(2, 3);
            Motion.AxisOff(2, 4);
            Motion.AxisOff(2, 5);
            Motion.AxisOff(2, 6);
        }

        private void btnRMoveRel1_Click(object sender, EventArgs e)
        {
            try
            {
                double vel = 600;//增量运动的速度
                double acc = 10;//增量运动的加速度
                double dec = 10;//增量运动的减速度
                short smoothtime = 0;//增量运动的平滑时间[0,50]


                Motion.AxisMoveRel(1, 4, Convert.ToInt32(RMoveRel.Text), vel, acc, dec, smoothtime);
            }
            catch
            {
                MessageBox.Show("wrong input");
                return;

            }
        }

        private void btnRMoveRel2_Click(object sender, EventArgs e)
        {
            try
            {
                double vel = 600;//增量运动的速度
                double acc = 10;//增量运动的加速度
                double dec = 10;//增量运动的减速度
                short smoothtime = 0;//增量运动的平滑时间[0,50]


                Motion.AxisMoveRel(1, 4, -Convert.ToInt32(RMoveRel.Text), vel, acc, dec, smoothtime);
            }
            catch
            {
                MessageBox.Show("wrong input");
                return;

            }
        }



        private void btnAxis1Forward_MouseDown(object sender, MouseEventArgs e)
        {
            double velJ = 100;//Jog正向运动的速度
            double accJ = 10;//Jog正向运动的加速度
            double decJ = 10;//Jog正向运动的减速度
            double SmoothtimeJ = 0;//Jog正向运动的平滑时间[0,1)
            Motion.AxisJog(2, 1, velJ, accJ, decJ, SmoothtimeJ);

        }

        private void btnAxis1Forward_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(2, 1, 0);
        }

        private void btnAxis1Backward_MouseDown(object sender, MouseEventArgs e)
        {
            double velJ = 100;//Jog正向运动的速度
            double accJ = 10;//Jog正向运动的加速度
            double decJ = 10;//Jog正向运动的减速度
            double SmoothtimeJ = 0;//Jog正向运动的平滑时间[0,1)
            Motion.AxisJog(2, 1, -velJ, accJ, decJ, SmoothtimeJ);

        }

        private void btnAxis1Backward_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(2, 1, 0);
        }

        private void btnAxis2Forward_MouseDown(object sender, MouseEventArgs e)
        {
            double velJ = 100;//Jog正向运动的速度
            double accJ = 10;//Jog正向运动的加速度
            double decJ = 10;//Jog正向运动的减速度
            double SmoothtimeJ = 0;//Jog正向运动的平滑时间[0,1)
            Motion.AxisJog(2, 2, velJ, accJ, decJ, SmoothtimeJ);
        }

        private void btnAxis2Forward_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(2, 2, 0);

        }

        private void btnAxis2Backward_MouseDown(object sender, MouseEventArgs e)
        {
            double velJ = 100;//Jog正向运动的速度
            double accJ = 10;//Jog正向运动的加速度
            double decJ = 10;//Jog正向运动的减速度
            double SmoothtimeJ = 0;//Jog正向运动的平滑时间[0,1)
            Motion.AxisJog(2, 2, -velJ, accJ, decJ, SmoothtimeJ);
        }

        private void btnAxis2Backward_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(2, 2, 0);
        }

        private void btnAxis3Forward_MouseDown(object sender, MouseEventArgs e)
        {
            double velJ = 50;//Jog正向运动的速度
            double accJ = 5;//Jog正向运动的加速度
            double decJ = 5;//Jog正向运动的减速度
            double SmoothtimeJ = 0;//Jog正向运动的平滑时间[0,1)
            Motion.AxisJog(2, 3, velJ, accJ, decJ, SmoothtimeJ);

        }

        private void btnAxis3Forward_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(2, 3, 0);
        }

        private void btnAxis3Backward_MouseDown(object sender, MouseEventArgs e)
        {
            double velJ = 50;//Jog正向运动的速度
            double accJ = 5;//Jog正向运动的加速度
            double decJ = 5;//Jog正向运动的减速度
            double SmoothtimeJ = 0;//Jog正向运动的平滑时间[0,1)
            Motion.AxisJog(2, 3, -velJ, accJ, decJ, SmoothtimeJ);

        }

        private void btnAxis3Backward_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(2, 3, 0);
        }

        private void btnAxis4Forward_MouseDown(object sender, MouseEventArgs e)
        {
            double velJ = 100;//Jog正向运动的速度
            double accJ = 10;//Jog正向运动的加速度
            double decJ = 10;//Jog正向运动的减速度
            double SmoothtimeJ = 0;//Jog正向运动的平滑时间[0,1)
            Motion.AxisJog(2, 4, velJ, accJ, decJ, SmoothtimeJ);
        }

        private void btnAxis4Forward_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(2, 4, 0);
        }
        private void btnAxis4Backward_MouseDown(object sender, MouseEventArgs e)
        {
            double velJ = 100;//Jog正向运动的速度
            double accJ = 10;//Jog正向运动的加速度
            double decJ = 10;//Jog正向运动的减速度
            double SmoothtimeJ = 0;//Jog正向运动的平滑时间[0,1)
            Motion.AxisJog(2, 4, -velJ, accJ, decJ, SmoothtimeJ);
        }

        private void btnAxis4Backward_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(2, 4, 0);
        }

        private void btnAxis5Forward_MouseDown(object sender, MouseEventArgs e)
        {
            double velJ = 100;//Jog正向运动的速度
            double accJ = 10;//Jog正向运动的加速度
            double decJ = 10;//Jog正向运动的减速度
            double SmoothtimeJ = 0;//Jog正向运动的平滑时间[0,1)
            Motion.AxisJog(2, 5, velJ, accJ, decJ, SmoothtimeJ);
        }

        private void btnAxis5Forward_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(2, 5, 0);
        }
        private void btnAxis5Backward_MouseDown(object sender, MouseEventArgs e)
        {

            double velJ = 100;//Jog正向运动的速度
            double accJ = 10;//Jog正向运动的加速度
            double decJ = 10;//Jog正向运动的减速度
            double SmoothtimeJ = 0;//Jog正向运动的平滑时间[0,1)
            Motion.AxisJog(2, 5, -velJ, accJ, decJ, SmoothtimeJ);
        }

        private void btnAxis5Backward_MouseUp(object sender, MouseEventArgs e)
        {
            Motion.AxisStop(2, 5, 0);
        }

        private void ZHome_Click(object sender, EventArgs e)
        {
            Motion.AxisHome(1, 3, -1, 1, 1, 100, 10, 0);
        }
        private void BtnLoadParameter_Click(object sender, EventArgs e)
        {
            Motion.Load("Config/MotionParameter.json");
        }
    }
}
