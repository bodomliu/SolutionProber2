namespace CommonComponentLibrary
{
    partial class MotionControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            BtnXforward = new Button();
            stagejog = new GroupBox();
            textBox5 = new TextBox();
            button7 = new Button();
            button8 = new Button();
            textBox4 = new TextBox();
            button5 = new Button();
            button6 = new Button();
            textBox3 = new TextBox();
            BtnZbackward = new Button();
            BtnZforward = new Button();
            textBox2 = new TextBox();
            BtnYbackward = new Button();
            BtnYforward = new Button();
            textBox1 = new TextBox();
            BtnXbackward = new Button();
            NCposition = new TextBox();
            NClabelposition = new Label();
            Cposition = new TextBox();
            Clabelposition = new Label();
            Zposition1 = new TextBox();
            Zlabelposition = new Label();
            Yposition1 = new TextBox();
            Ylabelposition = new Label();
            Xposition1 = new TextBox();
            Xlabelposition = new Label();
            Loaderhome = new GroupBox();
            HomeII = new Button();
            HomeIII = new Button();
            Whome = new Button();
            U2Home = new Button();
            U1Home = new Button();
            Ahome = new Button();
            groupBox1 = new GroupBox();
            RMoveRel = new TextBox();
            btnRMoveRel2 = new Button();
            btnRMoveRel1 = new Button();
            btnStop = new Button();
            ZMoveRel = new TextBox();
            btnZMoveRel2 = new Button();
            btnZMoveRel1 = new Button();
            YMoveRel = new TextBox();
            btnYMoveRel2 = new Button();
            btnYMoveRel1 = new Button();
            XMoveRel = new TextBox();
            btnXMoveRel2 = new Button();
            btnXMoveRel1 = new Button();
            label12 = new Label();
            ToYposition = new TextBox();
            ToZposition = new TextBox();
            ToXposition = new TextBox();
            MoveAbs = new Button();
            btnAxisOff = new Button();
            button2 = new Button();
            btnAxisOn = new Button();
            RpicArrive = new PictureBox();
            RpicN_Lmt = new PictureBox();
            ZpicArrive = new PictureBox();
            ZpicN_Lmt = new PictureBox();
            RpicP_Lmt = new PictureBox();
            ZpicP_Lmt = new PictureBox();
            RpicAxisAlarm = new PictureBox();
            YpicArrive = new PictureBox();
            YpicN_Lmt = new PictureBox();
            ZpicAxisAlarm = new PictureBox();
            YpicP_Lmt = new PictureBox();
            XpicArrive = new PictureBox();
            RpicAxisOn = new PictureBox();
            XpicN_Lmt = new PictureBox();
            YpicAxisAlarm = new PictureBox();
            XpicP_Lmt = new PictureBox();
            label11 = new Label();
            ZpicAxisOn = new PictureBox();
            label10 = new Label();
            XpicAxisAlarm = new PictureBox();
            label9 = new Label();
            YpicAxisOn = new PictureBox();
            label8 = new Label();
            XpicAxisOn = new PictureBox();
            label7 = new Label();
            REncVel = new TextBox();
            ZEncVel = new TextBox();
            YEncVel = new TextBox();
            XEncVel = new TextBox();
            label6 = new Label();
            Rposition = new TextBox();
            Zposition = new TextBox();
            Yposition = new TextBox();
            label5 = new Label();
            Xposition = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            stagejog.SuspendLayout();
            Loaderhome.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RpicArrive).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RpicN_Lmt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ZpicArrive).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ZpicN_Lmt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RpicP_Lmt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ZpicP_Lmt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RpicAxisAlarm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)YpicArrive).BeginInit();
            ((System.ComponentModel.ISupportInitialize)YpicN_Lmt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ZpicAxisAlarm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)YpicP_Lmt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XpicArrive).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RpicAxisOn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XpicN_Lmt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)YpicAxisAlarm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XpicP_Lmt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ZpicAxisOn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XpicAxisAlarm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)YpicAxisOn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XpicAxisOn).BeginInit();
            SuspendLayout();
            // 
            // BtnXforward
            // 
            BtnXforward.Location = new Point(139, 30);
            BtnXforward.Name = "BtnXforward";
            BtnXforward.Size = new Size(66, 52);
            BtnXforward.TabIndex = 0;
            BtnXforward.Tag = "1";
            BtnXforward.Text = "X+";
            BtnXforward.UseVisualStyleBackColor = true;
            BtnXforward.MouseDown += BtnXforward_MouseDown;
            BtnXforward.MouseUp += BtnXforward_MouseUp;
            // 
            // stagejog
            // 
            stagejog.Controls.Add(textBox5);
            stagejog.Controls.Add(button7);
            stagejog.Controls.Add(button8);
            stagejog.Controls.Add(textBox4);
            stagejog.Controls.Add(button5);
            stagejog.Controls.Add(button6);
            stagejog.Controls.Add(textBox3);
            stagejog.Controls.Add(BtnZbackward);
            stagejog.Controls.Add(BtnZforward);
            stagejog.Controls.Add(textBox2);
            stagejog.Controls.Add(BtnYbackward);
            stagejog.Controls.Add(BtnYforward);
            stagejog.Controls.Add(textBox1);
            stagejog.Controls.Add(BtnXbackward);
            stagejog.Controls.Add(NCposition);
            stagejog.Controls.Add(NClabelposition);
            stagejog.Controls.Add(Cposition);
            stagejog.Controls.Add(Clabelposition);
            stagejog.Controls.Add(Zposition1);
            stagejog.Controls.Add(Zlabelposition);
            stagejog.Controls.Add(Yposition1);
            stagejog.Controls.Add(Ylabelposition);
            stagejog.Controls.Add(Xposition1);
            stagejog.Controls.Add(Xlabelposition);
            stagejog.Controls.Add(BtnXforward);
            stagejog.Location = new Point(16, 16);
            stagejog.Name = "stagejog";
            stagejog.Size = new Size(515, 189);
            stagejog.TabIndex = 1;
            stagejog.TabStop = false;
            stagejog.Text = "JOG状态";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(426, 89);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(66, 23);
            textBox5.TabIndex = 24;
            textBox5.Text = "1000";
            // 
            // button7
            // 
            button7.Location = new Point(426, 121);
            button7.Name = "button7";
            button7.Size = new Size(66, 49);
            button7.TabIndex = 23;
            button7.Text = "NC-";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(426, 31);
            button8.Name = "button8";
            button8.Size = new Size(66, 52);
            button8.TabIndex = 22;
            button8.Text = "NC+";
            button8.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(354, 89);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(66, 23);
            textBox4.TabIndex = 21;
            textBox4.Text = "1000";
            // 
            // button5
            // 
            button5.Location = new Point(354, 121);
            button5.Name = "button5";
            button5.Size = new Size(66, 49);
            button5.TabIndex = 20;
            button5.Text = "C-";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(354, 31);
            button6.Name = "button6";
            button6.Size = new Size(66, 52);
            button6.TabIndex = 19;
            button6.Text = "C+";
            button6.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(282, 88);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(66, 23);
            textBox3.TabIndex = 18;
            textBox3.Text = "1000";
            // 
            // BtnZbackward
            // 
            BtnZbackward.Location = new Point(282, 120);
            BtnZbackward.Name = "BtnZbackward";
            BtnZbackward.Size = new Size(66, 49);
            BtnZbackward.TabIndex = 17;
            BtnZbackward.Tag = "6";
            BtnZbackward.Text = "Z-";
            BtnZbackward.UseVisualStyleBackColor = true;
            BtnZbackward.MouseDown += BtnZbackward_MouseDown;
            BtnZbackward.MouseUp += BtnZbackward_MouseUp;
            // 
            // BtnZforward
            // 
            BtnZforward.Location = new Point(282, 30);
            BtnZforward.Name = "BtnZforward";
            BtnZforward.Size = new Size(66, 52);
            BtnZforward.TabIndex = 16;
            BtnZforward.Tag = "3";
            BtnZforward.Text = "Z+";
            BtnZforward.UseVisualStyleBackColor = true;
            BtnZforward.MouseDown += BtnZforward_MouseDown;
            BtnZforward.MouseUp += BtnZforward_MouseUp;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(210, 88);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(66, 23);
            textBox2.TabIndex = 15;
            textBox2.Text = "10000";
            // 
            // BtnYbackward
            // 
            BtnYbackward.Location = new Point(210, 120);
            BtnYbackward.Name = "BtnYbackward";
            BtnYbackward.Size = new Size(66, 49);
            BtnYbackward.TabIndex = 14;
            BtnYbackward.Tag = "5";
            BtnYbackward.Text = "Y-";
            BtnYbackward.UseVisualStyleBackColor = true;
            BtnYbackward.MouseDown += BtnYbackward_MouseDown;
            BtnYbackward.MouseUp += BtnYbackward_MouseUp;
            // 
            // BtnYforward
            // 
            BtnYforward.Location = new Point(210, 30);
            BtnYforward.Name = "BtnYforward";
            BtnYforward.Size = new Size(66, 52);
            BtnYforward.TabIndex = 13;
            BtnYforward.Tag = "2";
            BtnYforward.Text = "Y+";
            BtnYforward.UseVisualStyleBackColor = true;
            BtnYforward.MouseDown += BtnYforward_MouseDown;
            BtnYforward.MouseUp += BtnYforward_MouseUp;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(138, 88);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(66, 23);
            textBox1.TabIndex = 12;
            textBox1.Text = "10000";
            // 
            // BtnXbackward
            // 
            BtnXbackward.Location = new Point(138, 120);
            BtnXbackward.Name = "BtnXbackward";
            BtnXbackward.Size = new Size(66, 49);
            BtnXbackward.TabIndex = 11;
            BtnXbackward.Tag = "4";
            BtnXbackward.Text = "X-";
            BtnXbackward.UseVisualStyleBackColor = true;
            BtnXbackward.MouseDown += BtnXbackward_MouseDown;
            BtnXbackward.MouseUp += BtnXbackward_MouseUp;
            // 
            // NCposition
            // 
            NCposition.Location = new Point(29, 146);
            NCposition.Name = "NCposition";
            NCposition.Size = new Size(104, 23);
            NCposition.TabIndex = 10;
            // 
            // NClabelposition
            // 
            NClabelposition.AutoSize = true;
            NClabelposition.Location = new Point(4, 149);
            NClabelposition.Name = "NClabelposition";
            NClabelposition.Size = new Size(29, 17);
            NClabelposition.TabIndex = 9;
            NClabelposition.Text = "NC:";
            // 
            // Cposition
            // 
            Cposition.Location = new Point(29, 117);
            Cposition.Name = "Cposition";
            Cposition.Size = new Size(104, 23);
            Cposition.TabIndex = 8;
            // 
            // Clabelposition
            // 
            Clabelposition.AutoSize = true;
            Clabelposition.Location = new Point(4, 120);
            Clabelposition.Name = "Clabelposition";
            Clabelposition.Size = new Size(19, 17);
            Clabelposition.TabIndex = 7;
            Clabelposition.Text = "C:";
            // 
            // Zposition1
            // 
            Zposition1.Location = new Point(29, 88);
            Zposition1.Name = "Zposition1";
            Zposition1.Size = new Size(104, 23);
            Zposition1.TabIndex = 6;
            // 
            // Zlabelposition
            // 
            Zlabelposition.AutoSize = true;
            Zlabelposition.Location = new Point(4, 91);
            Zlabelposition.Name = "Zlabelposition";
            Zlabelposition.Size = new Size(18, 17);
            Zlabelposition.TabIndex = 5;
            Zlabelposition.Text = "Z:";
            // 
            // Yposition1
            // 
            Yposition1.Location = new Point(29, 59);
            Yposition1.Name = "Yposition1";
            Yposition1.Size = new Size(104, 23);
            Yposition1.TabIndex = 4;
            // 
            // Ylabelposition
            // 
            Ylabelposition.AutoSize = true;
            Ylabelposition.Location = new Point(4, 62);
            Ylabelposition.Name = "Ylabelposition";
            Ylabelposition.Size = new Size(18, 17);
            Ylabelposition.TabIndex = 3;
            Ylabelposition.Text = "Y:";
            // 
            // Xposition1
            // 
            Xposition1.Location = new Point(29, 30);
            Xposition1.Name = "Xposition1";
            Xposition1.Size = new Size(104, 23);
            Xposition1.TabIndex = 2;
            // 
            // Xlabelposition
            // 
            Xlabelposition.AutoSize = true;
            Xlabelposition.Location = new Point(4, 33);
            Xlabelposition.Name = "Xlabelposition";
            Xlabelposition.Size = new Size(19, 17);
            Xlabelposition.TabIndex = 1;
            Xlabelposition.Text = "X:";
            // 
            // Loaderhome
            // 
            Loaderhome.Controls.Add(HomeII);
            Loaderhome.Controls.Add(HomeIII);
            Loaderhome.Controls.Add(Whome);
            Loaderhome.Controls.Add(U2Home);
            Loaderhome.Controls.Add(U1Home);
            Loaderhome.Controls.Add(Ahome);
            Loaderhome.Location = new Point(16, 211);
            Loaderhome.Name = "Loaderhome";
            Loaderhome.Size = new Size(609, 152);
            Loaderhome.TabIndex = 2;
            Loaderhome.TabStop = false;
            Loaderhome.Text = "回原加载";
            // 
            // HomeII
            // 
            HomeII.Location = new Point(387, 46);
            HomeII.Name = "HomeII";
            HomeII.Size = new Size(105, 62);
            HomeII.TabIndex = 5;
            HomeII.Text = "Home II";
            HomeII.UseVisualStyleBackColor = true;
            // 
            // HomeIII
            // 
            HomeIII.Location = new Point(498, 46);
            HomeIII.Name = "HomeIII";
            HomeIII.Size = new Size(102, 62);
            HomeIII.TabIndex = 4;
            HomeIII.Text = "Home III";
            HomeIII.UseVisualStyleBackColor = true;
            HomeIII.Click += HomeIII_Click;
            // 
            // Whome
            // 
            Whome.Location = new Point(294, 46);
            Whome.Name = "Whome";
            Whome.Size = new Size(92, 62);
            Whome.TabIndex = 3;
            Whome.Text = "W Home";
            Whome.UseVisualStyleBackColor = true;
            Whome.Click += Whome_Click;
            // 
            // U2Home
            // 
            U2Home.Location = new Point(198, 46);
            U2Home.Name = "U2Home";
            U2Home.Size = new Size(90, 62);
            U2Home.TabIndex = 2;
            U2Home.Text = "U2 Home";
            U2Home.UseVisualStyleBackColor = true;
            U2Home.Click += U2Home_Click;
            // 
            // U1Home
            // 
            U1Home.Location = new Point(104, 46);
            U1Home.Name = "U1Home";
            U1Home.Size = new Size(88, 62);
            U1Home.TabIndex = 1;
            U1Home.Text = "U1 Home";
            U1Home.UseVisualStyleBackColor = true;
            U1Home.Click += U1Home_Click;
            // 
            // Ahome
            // 
            Ahome.Location = new Point(12, 46);
            Ahome.Name = "Ahome";
            Ahome.Size = new Size(86, 62);
            Ahome.TabIndex = 0;
            Ahome.Text = "A Home";
            Ahome.UseVisualStyleBackColor = true;
            Ahome.Click += Ahome_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(RMoveRel);
            groupBox1.Controls.Add(btnRMoveRel2);
            groupBox1.Controls.Add(btnRMoveRel1);
            groupBox1.Controls.Add(btnStop);
            groupBox1.Controls.Add(ZMoveRel);
            groupBox1.Controls.Add(btnZMoveRel2);
            groupBox1.Controls.Add(btnZMoveRel1);
            groupBox1.Controls.Add(YMoveRel);
            groupBox1.Controls.Add(btnYMoveRel2);
            groupBox1.Controls.Add(btnYMoveRel1);
            groupBox1.Controls.Add(XMoveRel);
            groupBox1.Controls.Add(btnXMoveRel2);
            groupBox1.Controls.Add(btnXMoveRel1);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(ToYposition);
            groupBox1.Controls.Add(ToZposition);
            groupBox1.Controls.Add(ToXposition);
            groupBox1.Controls.Add(MoveAbs);
            groupBox1.Controls.Add(btnAxisOff);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(btnAxisOn);
            groupBox1.Controls.Add(RpicArrive);
            groupBox1.Controls.Add(RpicN_Lmt);
            groupBox1.Controls.Add(ZpicArrive);
            groupBox1.Controls.Add(ZpicN_Lmt);
            groupBox1.Controls.Add(RpicP_Lmt);
            groupBox1.Controls.Add(ZpicP_Lmt);
            groupBox1.Controls.Add(RpicAxisAlarm);
            groupBox1.Controls.Add(YpicArrive);
            groupBox1.Controls.Add(YpicN_Lmt);
            groupBox1.Controls.Add(ZpicAxisAlarm);
            groupBox1.Controls.Add(YpicP_Lmt);
            groupBox1.Controls.Add(XpicArrive);
            groupBox1.Controls.Add(RpicAxisOn);
            groupBox1.Controls.Add(XpicN_Lmt);
            groupBox1.Controls.Add(YpicAxisAlarm);
            groupBox1.Controls.Add(XpicP_Lmt);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(ZpicAxisOn);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(XpicAxisAlarm);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(YpicAxisOn);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(XpicAxisOn);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(REncVel);
            groupBox1.Controls.Add(ZEncVel);
            groupBox1.Controls.Add(YEncVel);
            groupBox1.Controls.Add(XEncVel);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(Rposition);
            groupBox1.Controls.Add(Zposition);
            groupBox1.Controls.Add(Yposition);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(Xposition);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(16, 369);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1077, 277);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "状态信息";
            // 
            // RMoveRel
            // 
            RMoveRel.Location = new Point(650, 203);
            RMoveRel.Name = "RMoveRel";
            RMoveRel.Size = new Size(100, 23);
            RMoveRel.TabIndex = 32;
            // 
            // btnRMoveRel2
            // 
            btnRMoveRel2.Location = new Point(756, 197);
            btnRMoveRel2.Name = "btnRMoveRel2";
            btnRMoveRel2.Size = new Size(95, 43);
            btnRMoveRel2.TabIndex = 31;
            btnRMoveRel2.Text = "相对运动-";
            btnRMoveRel2.UseVisualStyleBackColor = true;
            btnRMoveRel2.Click += btnRMoveRel2_Click;
            // 
            // btnRMoveRel1
            // 
            btnRMoveRel1.Location = new Point(534, 197);
            btnRMoveRel1.Name = "btnRMoveRel1";
            btnRMoveRel1.Size = new Size(110, 43);
            btnRMoveRel1.TabIndex = 30;
            btnRMoveRel1.Text = "相对运动+";
            btnRMoveRel1.UseVisualStyleBackColor = true;
            btnRMoveRel1.Click += btnRMoveRel1_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(967, 94);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(104, 43);
            btnStop.TabIndex = 29;
            btnStop.Text = "停止运动";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // ZMoveRel
            // 
            ZMoveRel.Location = new Point(650, 155);
            ZMoveRel.Name = "ZMoveRel";
            ZMoveRel.Size = new Size(100, 23);
            ZMoveRel.TabIndex = 28;
            // 
            // btnZMoveRel2
            // 
            btnZMoveRel2.Location = new Point(756, 149);
            btnZMoveRel2.Name = "btnZMoveRel2";
            btnZMoveRel2.Size = new Size(95, 43);
            btnZMoveRel2.TabIndex = 27;
            btnZMoveRel2.Text = "相对运动-";
            btnZMoveRel2.UseVisualStyleBackColor = true;
            btnZMoveRel2.Click += btnZMoveRel2_Click;
            // 
            // btnZMoveRel1
            // 
            btnZMoveRel1.Location = new Point(534, 149);
            btnZMoveRel1.Name = "btnZMoveRel1";
            btnZMoveRel1.Size = new Size(110, 43);
            btnZMoveRel1.TabIndex = 26;
            btnZMoveRel1.Text = "相对运动+";
            btnZMoveRel1.UseVisualStyleBackColor = true;
            btnZMoveRel1.Click += btnZMoveRel1_Click;
            // 
            // YMoveRel
            // 
            YMoveRel.Location = new Point(650, 103);
            YMoveRel.Name = "YMoveRel";
            YMoveRel.Size = new Size(100, 23);
            YMoveRel.TabIndex = 25;
            // 
            // btnYMoveRel2
            // 
            btnYMoveRel2.Location = new Point(756, 94);
            btnYMoveRel2.Name = "btnYMoveRel2";
            btnYMoveRel2.Size = new Size(95, 43);
            btnYMoveRel2.TabIndex = 24;
            btnYMoveRel2.Text = "相对运动-";
            btnYMoveRel2.UseVisualStyleBackColor = true;
            btnYMoveRel2.Click += btnYMoveRel2_Click;
            // 
            // btnYMoveRel1
            // 
            btnYMoveRel1.Location = new Point(534, 94);
            btnYMoveRel1.Name = "btnYMoveRel1";
            btnYMoveRel1.Size = new Size(110, 43);
            btnYMoveRel1.TabIndex = 23;
            btnYMoveRel1.Text = "相对运动+";
            btnYMoveRel1.UseVisualStyleBackColor = true;
            btnYMoveRel1.Click += btnYMoveRel1_Click;
            // 
            // XMoveRel
            // 
            XMoveRel.Location = new Point(650, 39);
            XMoveRel.Name = "XMoveRel";
            XMoveRel.Size = new Size(100, 23);
            XMoveRel.TabIndex = 22;
            // 
            // btnXMoveRel2
            // 
            btnXMoveRel2.Location = new Point(756, 30);
            btnXMoveRel2.Name = "btnXMoveRel2";
            btnXMoveRel2.Size = new Size(95, 49);
            btnXMoveRel2.TabIndex = 21;
            btnXMoveRel2.Text = "相对运动-";
            btnXMoveRel2.UseVisualStyleBackColor = true;
            btnXMoveRel2.Click += btnXMoveRel2_Click;
            // 
            // btnXMoveRel1
            // 
            btnXMoveRel1.Location = new Point(534, 30);
            btnXMoveRel1.Name = "btnXMoveRel1";
            btnXMoveRel1.Size = new Size(110, 49);
            btnXMoveRel1.TabIndex = 20;
            btnXMoveRel1.Text = "相对运动+";
            btnXMoveRel1.UseVisualStyleBackColor = true;
            btnXMoveRel1.Click += btnMoveRel_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(448, 22);
            label12.Name = "label12";
            label12.Size = new Size(56, 17);
            label12.TabIndex = 19;
            label12.Text = "规划位置";
            // 
            // ToYposition
            // 
            ToYposition.Location = new Point(426, 104);
            ToYposition.Name = "ToYposition";
            ToYposition.Size = new Size(100, 23);
            ToYposition.TabIndex = 18;
            // 
            // ToZposition
            // 
            ToZposition.Location = new Point(426, 153);
            ToZposition.Name = "ToZposition";
            ToZposition.Size = new Size(100, 23);
            ToZposition.TabIndex = 17;
            // 
            // ToXposition
            // 
            ToXposition.Location = new Point(428, 42);
            ToXposition.Name = "ToXposition";
            ToXposition.Size = new Size(100, 23);
            ToXposition.TabIndex = 16;
            // 
            // MoveAbs
            // 
            MoveAbs.Location = new Point(426, 191);
            MoveAbs.Name = "MoveAbs";
            MoveAbs.Size = new Size(100, 53);
            MoveAbs.TabIndex = 14;
            MoveAbs.Text = "绝对运动";
            MoveAbs.UseVisualStyleBackColor = true;
            MoveAbs.Click += MoveAbs_Click;
            // 
            // btnAxisOff
            // 
            btnAxisOff.Location = new Point(857, 94);
            btnAxisOff.Name = "btnAxisOff";
            btnAxisOff.Size = new Size(104, 43);
            btnAxisOff.TabIndex = 13;
            btnAxisOff.Text = "下使能";
            btnAxisOff.UseVisualStyleBackColor = true;
            btnAxisOff.Click += btnAxisOff_Click;
            // 
            // button2
            // 
            button2.Location = new Point(967, 30);
            button2.Name = "button2";
            button2.Size = new Size(104, 49);
            button2.TabIndex = 13;
            button2.Text = "清报警";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ClrSts_Click;
            // 
            // btnAxisOn
            // 
            btnAxisOn.Location = new Point(857, 30);
            btnAxisOn.Name = "btnAxisOn";
            btnAxisOn.Size = new Size(104, 49);
            btnAxisOn.TabIndex = 13;
            btnAxisOn.Text = "上使能";
            btnAxisOn.UseVisualStyleBackColor = true;
            btnAxisOn.Click += btnAxisOn_Click;
            // 
            // RpicArrive
            // 
            RpicArrive.BackColor = Color.Red;
            RpicArrive.Location = new Point(387, 207);
            RpicArrive.Name = "RpicArrive";
            RpicArrive.Size = new Size(27, 21);
            RpicArrive.TabIndex = 12;
            RpicArrive.TabStop = false;
            // 
            // RpicN_Lmt
            // 
            RpicN_Lmt.BackColor = Color.Red;
            RpicN_Lmt.Location = new Point(354, 207);
            RpicN_Lmt.Name = "RpicN_Lmt";
            RpicN_Lmt.Size = new Size(27, 21);
            RpicN_Lmt.TabIndex = 12;
            RpicN_Lmt.TabStop = false;
            // 
            // ZpicArrive
            // 
            ZpicArrive.BackColor = Color.Red;
            ZpicArrive.Location = new Point(387, 155);
            ZpicArrive.Name = "ZpicArrive";
            ZpicArrive.Size = new Size(27, 21);
            ZpicArrive.TabIndex = 12;
            ZpicArrive.TabStop = false;
            // 
            // ZpicN_Lmt
            // 
            ZpicN_Lmt.BackColor = Color.Red;
            ZpicN_Lmt.Location = new Point(354, 155);
            ZpicN_Lmt.Name = "ZpicN_Lmt";
            ZpicN_Lmt.Size = new Size(27, 21);
            ZpicN_Lmt.TabIndex = 12;
            ZpicN_Lmt.TabStop = false;
            // 
            // RpicP_Lmt
            // 
            RpicP_Lmt.BackColor = Color.Red;
            RpicP_Lmt.Location = new Point(322, 207);
            RpicP_Lmt.Name = "RpicP_Lmt";
            RpicP_Lmt.Size = new Size(27, 21);
            RpicP_Lmt.TabIndex = 12;
            RpicP_Lmt.TabStop = false;
            // 
            // ZpicP_Lmt
            // 
            ZpicP_Lmt.BackColor = Color.Red;
            ZpicP_Lmt.Location = new Point(322, 155);
            ZpicP_Lmt.Name = "ZpicP_Lmt";
            ZpicP_Lmt.Size = new Size(27, 21);
            ZpicP_Lmt.TabIndex = 12;
            ZpicP_Lmt.TabStop = false;
            // 
            // RpicAxisAlarm
            // 
            RpicAxisAlarm.BackColor = Color.Red;
            RpicAxisAlarm.Location = new Point(289, 207);
            RpicAxisAlarm.Name = "RpicAxisAlarm";
            RpicAxisAlarm.Size = new Size(27, 21);
            RpicAxisAlarm.TabIndex = 12;
            RpicAxisAlarm.TabStop = false;
            // 
            // YpicArrive
            // 
            YpicArrive.BackColor = Color.Red;
            YpicArrive.Location = new Point(387, 103);
            YpicArrive.Name = "YpicArrive";
            YpicArrive.Size = new Size(27, 21);
            YpicArrive.TabIndex = 12;
            YpicArrive.TabStop = false;
            // 
            // YpicN_Lmt
            // 
            YpicN_Lmt.BackColor = Color.Red;
            YpicN_Lmt.Location = new Point(354, 103);
            YpicN_Lmt.Name = "YpicN_Lmt";
            YpicN_Lmt.Size = new Size(27, 21);
            YpicN_Lmt.TabIndex = 12;
            YpicN_Lmt.TabStop = false;
            // 
            // ZpicAxisAlarm
            // 
            ZpicAxisAlarm.BackColor = Color.Red;
            ZpicAxisAlarm.Location = new Point(289, 155);
            ZpicAxisAlarm.Name = "ZpicAxisAlarm";
            ZpicAxisAlarm.Size = new Size(27, 21);
            ZpicAxisAlarm.TabIndex = 12;
            ZpicAxisAlarm.TabStop = false;
            // 
            // YpicP_Lmt
            // 
            YpicP_Lmt.BackColor = Color.Red;
            YpicP_Lmt.Location = new Point(322, 103);
            YpicP_Lmt.Name = "YpicP_Lmt";
            YpicP_Lmt.Size = new Size(27, 21);
            YpicP_Lmt.TabIndex = 12;
            YpicP_Lmt.TabStop = false;
            // 
            // XpicArrive
            // 
            XpicArrive.BackColor = Color.Red;
            XpicArrive.Location = new Point(387, 42);
            XpicArrive.Name = "XpicArrive";
            XpicArrive.Size = new Size(27, 21);
            XpicArrive.TabIndex = 12;
            XpicArrive.TabStop = false;
            // 
            // RpicAxisOn
            // 
            RpicAxisOn.BackColor = Color.Red;
            RpicAxisOn.Location = new Point(256, 207);
            RpicAxisOn.Name = "RpicAxisOn";
            RpicAxisOn.Size = new Size(27, 21);
            RpicAxisOn.TabIndex = 12;
            RpicAxisOn.TabStop = false;
            // 
            // XpicN_Lmt
            // 
            XpicN_Lmt.BackColor = Color.Red;
            XpicN_Lmt.Location = new Point(354, 42);
            XpicN_Lmt.Name = "XpicN_Lmt";
            XpicN_Lmt.Size = new Size(27, 21);
            XpicN_Lmt.TabIndex = 12;
            XpicN_Lmt.TabStop = false;
            // 
            // YpicAxisAlarm
            // 
            YpicAxisAlarm.BackColor = Color.Red;
            YpicAxisAlarm.Location = new Point(289, 103);
            YpicAxisAlarm.Name = "YpicAxisAlarm";
            YpicAxisAlarm.Size = new Size(27, 21);
            YpicAxisAlarm.TabIndex = 12;
            YpicAxisAlarm.TabStop = false;
            // 
            // XpicP_Lmt
            // 
            XpicP_Lmt.BackColor = Color.Red;
            XpicP_Lmt.Location = new Point(322, 42);
            XpicP_Lmt.Name = "XpicP_Lmt";
            XpicP_Lmt.Size = new Size(27, 21);
            XpicP_Lmt.TabIndex = 12;
            XpicP_Lmt.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(387, 22);
            label11.Name = "label11";
            label11.Size = new Size(32, 17);
            label11.TabIndex = 11;
            label11.Text = "到位";
            // 
            // ZpicAxisOn
            // 
            ZpicAxisOn.BackColor = Color.Red;
            ZpicAxisOn.Location = new Point(256, 155);
            ZpicAxisOn.Name = "ZpicAxisOn";
            ZpicAxisOn.Size = new Size(27, 21);
            ZpicAxisOn.TabIndex = 12;
            ZpicAxisOn.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(354, 22);
            label10.Name = "label10";
            label10.Size = new Size(32, 17);
            label10.TabIndex = 11;
            label10.Text = "负限";
            // 
            // XpicAxisAlarm
            // 
            XpicAxisAlarm.BackColor = Color.Red;
            XpicAxisAlarm.Location = new Point(289, 42);
            XpicAxisAlarm.Name = "XpicAxisAlarm";
            XpicAxisAlarm.Size = new Size(27, 21);
            XpicAxisAlarm.TabIndex = 12;
            XpicAxisAlarm.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(322, 22);
            label9.Name = "label9";
            label9.Size = new Size(32, 17);
            label9.TabIndex = 11;
            label9.Text = "正限";
            // 
            // YpicAxisOn
            // 
            YpicAxisOn.BackColor = Color.Red;
            YpicAxisOn.Location = new Point(256, 103);
            YpicAxisOn.Name = "YpicAxisOn";
            YpicAxisOn.Size = new Size(27, 21);
            YpicAxisOn.TabIndex = 12;
            YpicAxisOn.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(289, 22);
            label8.Name = "label8";
            label8.Size = new Size(32, 17);
            label8.TabIndex = 11;
            label8.Text = "报警";
            // 
            // XpicAxisOn
            // 
            XpicAxisOn.BackColor = Color.Red;
            XpicAxisOn.Location = new Point(256, 42);
            XpicAxisOn.Name = "XpicAxisOn";
            XpicAxisOn.Size = new Size(27, 21);
            XpicAxisOn.TabIndex = 12;
            XpicAxisOn.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(256, 22);
            label7.Name = "label7";
            label7.Size = new Size(32, 17);
            label7.TabIndex = 11;
            label7.Text = "使能";
            // 
            // REncVel
            // 
            REncVel.Location = new Point(146, 207);
            REncVel.Name = "REncVel";
            REncVel.Size = new Size(100, 23);
            REncVel.TabIndex = 10;
            // 
            // ZEncVel
            // 
            ZEncVel.Location = new Point(146, 152);
            ZEncVel.Name = "ZEncVel";
            ZEncVel.Size = new Size(100, 23);
            ZEncVel.TabIndex = 10;
            // 
            // YEncVel
            // 
            YEncVel.Location = new Point(150, 100);
            YEncVel.Name = "YEncVel";
            YEncVel.Size = new Size(100, 23);
            YEncVel.TabIndex = 10;
            // 
            // XEncVel
            // 
            XEncVel.Location = new Point(146, 42);
            XEncVel.Name = "XEncVel";
            XEncVel.Size = new Size(100, 23);
            XEncVel.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(163, 22);
            label6.Name = "label6";
            label6.Size = new Size(56, 17);
            label6.TabIndex = 9;
            label6.Text = "实际速度";
            // 
            // Rposition
            // 
            Rposition.Location = new Point(40, 206);
            Rposition.Name = "Rposition";
            Rposition.Size = new Size(100, 23);
            Rposition.TabIndex = 8;
            // 
            // Zposition
            // 
            Zposition.Location = new Point(40, 152);
            Zposition.Name = "Zposition";
            Zposition.Size = new Size(100, 23);
            Zposition.TabIndex = 7;
            // 
            // Yposition
            // 
            Yposition.Location = new Point(40, 100);
            Yposition.Name = "Yposition";
            Yposition.Size = new Size(100, 23);
            Yposition.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(66, 22);
            label5.Name = "label5";
            label5.Size = new Size(56, 17);
            label5.TabIndex = 5;
            label5.Text = "实际位置";
            // 
            // Xposition
            // 
            Xposition.Location = new Point(40, 42);
            Xposition.Name = "Xposition";
            Xposition.Size = new Size(100, 23);
            Xposition.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 209);
            label4.Name = "label4";
            label4.Size = new Size(28, 17);
            label4.TabIndex = 3;
            label4.Text = "R轴";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 155);
            label3.Name = "label3";
            label3.Size = new Size(27, 17);
            label3.TabIndex = 2;
            label3.Text = "Z轴";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 103);
            label2.Name = "label2";
            label2.Size = new Size(27, 17);
            label2.TabIndex = 1;
            label2.Text = "Y轴";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 45);
            label1.Name = "label1";
            label1.Size = new Size(28, 17);
            label1.TabIndex = 0;
            label1.Text = "X轴";
            // 
            // timer1
            // 
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            // 
            // MotionControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Controls.Add(Loaderhome);
            Controls.Add(stagejog);
            Name = "MotionControl";
            Size = new Size(1096, 646);
            Load += MotionControl_Load;
            stagejog.ResumeLayout(false);
            stagejog.PerformLayout();
            Loaderhome.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)RpicArrive).EndInit();
            ((System.ComponentModel.ISupportInitialize)RpicN_Lmt).EndInit();
            ((System.ComponentModel.ISupportInitialize)ZpicArrive).EndInit();
            ((System.ComponentModel.ISupportInitialize)ZpicN_Lmt).EndInit();
            ((System.ComponentModel.ISupportInitialize)RpicP_Lmt).EndInit();
            ((System.ComponentModel.ISupportInitialize)ZpicP_Lmt).EndInit();
            ((System.ComponentModel.ISupportInitialize)RpicAxisAlarm).EndInit();
            ((System.ComponentModel.ISupportInitialize)YpicArrive).EndInit();
            ((System.ComponentModel.ISupportInitialize)YpicN_Lmt).EndInit();
            ((System.ComponentModel.ISupportInitialize)ZpicAxisAlarm).EndInit();
            ((System.ComponentModel.ISupportInitialize)YpicP_Lmt).EndInit();
            ((System.ComponentModel.ISupportInitialize)XpicArrive).EndInit();
            ((System.ComponentModel.ISupportInitialize)RpicAxisOn).EndInit();
            ((System.ComponentModel.ISupportInitialize)XpicN_Lmt).EndInit();
            ((System.ComponentModel.ISupportInitialize)YpicAxisAlarm).EndInit();
            ((System.ComponentModel.ISupportInitialize)XpicP_Lmt).EndInit();
            ((System.ComponentModel.ISupportInitialize)ZpicAxisOn).EndInit();
            ((System.ComponentModel.ISupportInitialize)XpicAxisAlarm).EndInit();
            ((System.ComponentModel.ISupportInitialize)YpicAxisOn).EndInit();
            ((System.ComponentModel.ISupportInitialize)XpicAxisOn).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button BtnXforward;
        private GroupBox stagejog;
        private Label Xlabelposition;
        private TextBox NCposition;
        private Label NClabelposition;
        private TextBox Cposition;
        private Label Clabelposition;
        private TextBox Zposition1;
        private Label Zlabelposition;
        private TextBox Yposition1;
        private Label Ylabelposition;
        private TextBox Xposition1;
        private Button BtnXbackward;
        private TextBox textBox5;
        private Button button7;
        private Button button8;
        private TextBox textBox4;
        private Button button5;
        private Button button6;
        private TextBox textBox3;
        private Button BtnZbackward;
        private Button BtnZforward;
        private TextBox textBox2;
        private Button BtnYbackward;
        private Button BtnYforward;
        private TextBox textBox1;
        private GroupBox Loaderhome;
        private Button Whome;
        private Button U2Home;
        private Button U1Home;
        private Button Ahome;
        private Button HomeII;
        private Button HomeIII;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox Rposition;
        private TextBox Zposition;
        private TextBox Yposition;
        private Label label5;
        private TextBox Xposition;
        private TextBox XEncVel;
        private Label label6;
        private PictureBox XpicAxisOn;
        private Label label7;
        private PictureBox ZpicAxisOn;
        private PictureBox YpicAxisOn;
        private TextBox ZEncVel;
        private TextBox YEncVel;
        private PictureBox RpicArrive;
        private PictureBox RpicN_Lmt;
        private PictureBox ZpicArrive;
        private PictureBox ZpicN_Lmt;
        private PictureBox RpicP_Lmt;
        private PictureBox ZpicP_Lmt;
        private PictureBox RpicAxisAlarm;
        private PictureBox YpicArrive;
        private PictureBox YpicN_Lmt;
        private PictureBox ZpicAxisAlarm;
        private PictureBox YpicP_Lmt;
        private PictureBox XpicArrive;
        private PictureBox RpicAxisOn;
        private PictureBox XpicN_Lmt;
        private PictureBox YpicAxisAlarm;
        private PictureBox XpicP_Lmt;
        private Label label11;
        private Label label10;
        private PictureBox XpicAxisAlarm;
        private Label label9;
        private Label label8;
        private TextBox REncVel;
        private System.Windows.Forms.Timer timer1;
        private Button MoveAbs;
        private Button btnXMoveRel1;
        private TextBox ToXposition;
        private TextBox ToYposition;
        private TextBox ToZposition;
        private Label label12;
        private Button btnXMoveRel2;
        private TextBox ZMoveRel;
        private Button btnZMoveRel2;
        private Button btnZMoveRel1;
        private TextBox YMoveRel;
        private Button btnYMoveRel2;
        private Button btnYMoveRel1;
        private TextBox XMoveRel;
        private Button btnStop;
        private Button btnAxisOff;
        private Button button2;
        private Button btnAxisOn;
        private TextBox RMoveRel;
        private Button btnRMoveRel2;
        private Button btnRMoveRel1;
    }
}
