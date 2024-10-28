using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UtilityForm
{
    public partial class GT2Control : UserControl
    {
        public GT2Control()
        {
            InitializeComponent();
            // 订阅 Disposed 事件，在控件销毁时释放资源
            this.Disposed += GT2Control_Disposed;

            //添加Invar36控件

            flowLayoutPanel1.Controls.Add(new Invar36Control());
            flowLayoutPanel1.Controls.Add(new Invar36Control());

        }

        private void GT2Control_Disposed(object? sender, EventArgs e)
        {
            if (client != null)
            {
                try
                {
                    client.Shutdown(SocketShutdown.Both); // 关闭套接字
                }
                catch (SocketException ex)
                {
                    Console.WriteLine($"Socket exception during shutdown: {ex.Message}");
                }
                finally
                {
                    client.Close();  // 确保关闭套接字
                    client = null;   // 防止重复释放
                }
            }
        }

        private static Socket? client;

        private void GT2Control_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true) { timer1.Stop(); }
            lblStatus.Text = "Recording...";
            timer1.Interval = int.Parse(txtInterval.Text);
            timer1.Enabled = true;
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            string response = await SendMessage();
            string msg = System.DateTime.Now.ToString("yyyy-MM-dd HH: mm: ss: ") + response;
            lblStatus.Text = msg;
        }

        public async Task<string> SendMessage()
        {
            // Send message.
            var message = "M0\r\n";
            var messageBytes = Encoding.ASCII.GetBytes(message);
            if (client == null) return "no client.";
             _ = await client.SendAsync(messageBytes, SocketFlags.None);
            Console.WriteLine($"Socket client sent message: \"{message}\"");

            // Receive ack.
            var buffer = new byte[1024];
            var received = await client.ReceiveAsync(buffer, SocketFlags.None);
            var response = Encoding.ASCII.GetString(buffer, 0, received);

            Console.WriteLine($"Socket client received acknowledgment: \"{response}\"");
            txtValue.Text = response;
            WriteToTXT(response);
            return response;
        }

        public void WriteToTXT(string str)
        {
            // 也可以指定编码方式, true 是 Appendtext, false 为覆盖原文件 
            StreamWriter sW2 = new StreamWriter(@"GT2_Recording.txt", true, Encoding.UTF8);
            string str2write = System.DateTime.Now.ToString("yyyy-MM-dd HH: mm: ss: ") + str;
            sW2.Write(str2write);
            sW2.Close();

        }
        private async void btnTrigger_Click(object sender, EventArgs e)
        {
            Task<string> task = SendMessage();
            await task;//等待完成
            //WriteToTXT(task.Result);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse(txtIP.Text);
            IPEndPoint ipEndPoint = new(ipAddress, 64000);
            client = new(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ipEndPoint);
            lblStatus.Text = "Ready...";
            btnConnect.Enabled = false;
            btnTrigger.Enabled = true;
        }
    }
}
