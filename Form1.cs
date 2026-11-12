using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
namespace My_串口调试助手
{
    public partial class Form1 : Form
    {
        SerialPort serialPort = new SerialPort(); //全局串口对象
        long rxCount = 0; // 接收字节计数
        long txCount = 0; // 发送字节计数
        System.Windows.Forms.Timer sendTime = new System.Windows.Forms.Timer(); //发送定时器
        public Form1()
        {
            InitializeComponent();
            serialPort.DataReceived += SerialPort_DataReceived;  //订阅串口接收事件
            sendTime.Tick += SendTimer_Tick;      // 绑定发送方法
            comboBox_停止位.SelectedIndex = 0;
            comboBox_数据位.SelectedIndex = 0;
            comboBox_校验位.SelectedIndex = 0;
            comboBox_编码.SelectedIndex = 0;
            comboBox_波特率.SelectedIndex = 0;
            numericUpDown1.Maximum = 60000;   // 默认上限只有 100，不改的话设 500 会直接抛异常
            numericUpDown1.Minimum = 10;      // 原来默认 0，Interval=0 会导致定时发送疯狂刷
            numericUpDown1.Value = 500;
            // DTR / RTS 两个复选框以前没有事件，勾了没反应，这里补上
            checkBox1.CheckedChanged += (s, e) => { if (serialPort.IsOpen) serialPort.DtrEnable = checkBox1.Checked; };
            checkBox2.CheckedChanged += (s, e) => { if (serialPort.IsOpen) serialPort.RtsEnable = checkBox2.Checked; };
            RefreshPortList();             // 启动即枚举串口，不用再手动点"刷新"
        }

        // 按下拉框选择返回编码；GB2312 依赖 Program.Main 里注册的 CodePagesEncodingProvider
        private Encoding GetEncoding()
        {
            switch (comboBox_编码.Text)
            {
                case "GB2312": return Encoding.GetEncoding("GB2312");
                case "ASCII": return Encoding.ASCII;
                default: return Encoding.UTF8;
            }
        }
        private void RefreshPortList()
        {
            // 清空现有的端口列表
            comboBox_端口号.Items.Clear();
            // 获取当前可用的串口列表
            string[] ports = SerialPort.GetPortNames();

            // 将可用的串口添加到下拉列表中
            foreach (string port in ports)
            {
                comboBox_端口号.Items.Add(port);
            }
            // 如果有可用的串口，选择第一个作为默认值
            if (comboBox_端口号.Items.Count > 0)
            {
                comboBox_端口号.SelectedIndex = 0;
            }

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button_发送清空_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();   //加上这行，光标会自动闪烁在输入框里
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_定时发送.Checked)
            {
                if(!serialPort.IsOpen)
                {
                    MessageBox.Show("请先打开串口！", "提示");
                    checkBox_定时发送.Checked = false;
                    return;
                }
                if(string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("发送数据不能为空！", "提示");
                    checkBox_定时发送.Checked = false;
                    return;
                }
                sendTime.Interval = (int)numericUpDown1.Value; //设置定时器间隔
                sendTime.Start();
            }
            
            else
            {
                sendTime.Stop();
            }
        }
        // 【新增】定时器触发事件
        private void SendTimer_Tick(object? sender, EventArgs e)
        {
            // 防呆：如果串口意外断开，停止定时器
            if (!serialPort.IsOpen)
            {
                sendTime.Stop();
                checkBox_定时发送.Checked = false;
                return;
            }

            // 直接触发发送按钮的点击事件，复用发送逻辑
            // 注意：这里不能再把 button_发送.Enabled 设成 false，禁用后 PerformClick 不会执行，定时发送就发不出去了
            button_发送.PerformClick();
        }


        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button_刷新_Click(object sender, EventArgs e)
        {
            RefreshPortList();
        }

        private void button_打开串口_Click(object sender, EventArgs e)
        {
            if (comboBox_端口号.SelectedIndex == -1)
            {
                MessageBox.Show("请选择一个有效的串口！");
                return;
            }
            // 在这里添加打开串口的逻辑
            try // 防止串口被占用等突发情况导致程序死机
            {
                if (!serialPort.IsOpen)
                {
                    // 1.配置参数
                    serialPort.PortName = comboBox_端口号.Text; // 获取端口号
                    serialPort.BaudRate = int.Parse(comboBox_波特率.Text); // 获取波特率
                    serialPort.DataBits = int.Parse(comboBox_数据位.Text);//获取数据位
                                                                       //获取校验位
                    switch (comboBox_停止位.Text)
                    {
                        case "1": serialPort.StopBits = StopBits.One; break;
                        case "1.5": serialPort.StopBits = StopBits.OnePointFive; break;
                        case "2": serialPort.StopBits = StopBits.Two; break;
                    }
                    switch (comboBox_校验位.Text)
                    {
                        case "None": serialPort.Parity = Parity.None; break;
                        case "Odd": serialPort.Parity = Parity.Odd; break;
                        case "Even": serialPort.Parity = Parity.Even; break;
                        case "Mark": serialPort.Parity = Parity.Mark; break;
                        case "Space": serialPort.Parity = Parity.Space; break;
                    }
                    //打开串口
                    serialPort.Open();
                    //更新UI状态
                    button_打开串口.Text = "关闭串口";
                    toolStripStatusLabel1.Text = "串口已打开";
                    comboBox_端口号.Enabled = false;
                    comboBox_波特率.Enabled = false;
                    comboBox_数据位.Enabled = false;
                    comboBox_停止位.Enabled = false;
                    comboBox_校验位.Enabled = false;
                    button_刷新.Enabled = false; // 禁用刷新
                }

                else if (serialPort.IsOpen)
                {
                    serialPort.Close();
                    button_打开串口.Text = "打开串口";
                    toolStripStatusLabel1.Text = "串口已关闭";
                    comboBox_端口号.Enabled = true;
                    comboBox_波特率.Enabled = true;
                    comboBox_数据位.Enabled = true;
                    comboBox_停止位.Enabled = true;
                    comboBox_校验位.Enabled = true;
                    button_刷新.Enabled = true; // 禁用刷新
                }
            }
            catch (Exception ex)
            {
                // 如果报错，强制恢复状态，并弹窗提示用户
                if (serialPort.IsOpen) serialPort.Close();
                button_打开串口.Text = "打开串口";
                toolStripStatusLabel1.Text = "串口已关闭";
                MessageBox.Show("打开串口时发生错误：" + ex.Message, "错误");

            }
        }

        private void button_清空接收_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear(); // 清空接收区
        }

        private void button_发送_Click(object sender, EventArgs e)
        {
            //1.串口未打开防呆
            if (!serialPort.IsOpen)
            {
                MessageBox.Show("请先打开串口！", "提示");
                return;
            }
            try
            {
                // 2. 获取发送框里的文本
                string sendText = textBox1.Text;

                // 如果文本框是空的，直接结束，不用发送
                if (string.IsNullOrEmpty(sendText))
                {
                    return;
                }
                // HEX发送模式
                if (checkBox8.Checked)
                {
                    // 如果是 HEX 发送模式，先把字符串转换成字节数组
                    sendText = sendText.Replace(" ", ""); // 去掉空格
                    if (sendText.Length % 2 != 0)
                    {
                        MessageBox.Show("HEX 数据长度必须为偶数！", "错误");
                        return;
                    }
                    byte[] hexBytes = new byte[sendText.Length / 2];
                    for (int i = 0; i < hexBytes.Length; i++)
                    {
                        hexBytes[i] = Convert.ToByte(sendText.Substring(i * 2, 2), 16);
                    }
                    txCount += hexBytes.Length;
                    toolStripStatusLabel3.Text = $"TX:{txCount}位";
                    serialPort.Write(hexBytes, 0, hexBytes.Length);
                    return;
                }
                else
                {
                    // 处理追加换行
                    if (checkBox_追加换行.Checked)
                    {
                        sendText += "\r\n";
                    }
                    // 4. 决定用哪种编码发送数据
                    Encoding encoding = GetEncoding();
                    // 5. 把字符串转换成字节数组（串口只能发字节）
                    byte[] sendBytes = encoding.GetBytes(sendText);
                    // 发送数据
                    serialPort.Write(sendBytes, 0, sendBytes.Length);
                    txCount += sendBytes.Length;
                    toolStripStatusLabel3.Text = $"TX:{txCount}位";
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("HEX格式错误！请确保输入的内容只包含 0-9 和 A-F（例如：01 0A FF）", "错误");
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送失败：" + ex.Message, "错误");
            }
        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // 1. 取接收缓冲区里的字节（ReadExisting 用的是 SerialPort.Encoding，不是下拉框选的，所以自己读字节）
                int bytesToRead = serialPort.BytesToRead;
                if (bytesToRead == 0)
                {
                    return;
                }
                byte[] receivedBytes = new byte[bytesToRead];
                serialPort.Read(receivedBytes, 0, bytesToRead);

                if (!IsHandleCreated || IsDisposed)   // 窗口正在关闭，别再往 UI 线程扔东西
                {
                    return;
                }

                // 2. 所有 UI 操作（包括计数标签）统一回到 UI 线程，否则 VS 里调试会报"线程间操作无效"
                this.BeginInvoke(new Action(() =>
                {
                    rxCount += receivedBytes.Length;
                    toolStripStatusLabel2.Text = $"RX:{rxCount}字节";

                    if (checkBox5.Checked)   // 暂停
                    {
                        return;
                    }

                    if (checkBox4.Checked)   // 时间戳：每收到一批打一个
                    {
                        richTextBox1.SelectionColor = Color.Red;
                        richTextBox1.AppendText("[" + DateTime.Now.ToString("HH:mm:ss.fff") + "] ");
                    }
                    richTextBox1.SelectionColor = Color.Black;

                    if (checkBox3.Checked)   // HEX 显示
                    {
                        richTextBox1.AppendText(BitConverter.ToString(receivedBytes).Replace("-", " ") + "\r\n");
                    }
                    else                     // 文本原样显示：不拆行、不 Trim，收到的什么就看到什么
                    {
                        richTextBox1.AppendText(GetEncoding().GetString(receivedBytes));
                    }
                    richTextBox1.ScrollToCaret();
                }));
            }
            catch (Exception ex)
            {
                // 不要在串口线程上弹模态框，否则异常一来接收就卡死
                if (IsHandleCreated && !IsDisposed)
                {
                    BeginInvoke(new Action(() => richTextBox1.AppendText("[接收异常] " + ex.Message + "\r\n")));
                }
            }
        }

        // 关窗时把串口和定时器一起收掉，否则端口要等进程退出才释放
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            sendTime.Stop();
            serialPort.DataReceived -= SerialPort_DataReceived;
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            serialPort.Dispose();
            base.OnFormClosing(e);
        }

        private void checkBox_追加换行_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
