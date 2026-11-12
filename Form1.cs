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
                if(textBox1.Text != "")
                {
                    MessageBox.Show("发送数据不能为空！", "提示");
                    checkBox_定时发送.Checked = false;
                    return;
                }
                sendTime.Interval = (int)numericUpDown1.Value; //设置定时器间隔
                sendTime.Start();
                button_发送.Enabled = false;//禁用发送按钮,防止冲突
            }
            
            else
            {
                sendTime.Stop();
                button_发送.Enabled = true;
            }
        }
        // 【新增】定时器触发事件
        private void SendTimer_Tick(object sender, EventArgs e)
        {
            // 防呆：如果串口意外断开，停止定时器
            if (!serialPort.IsOpen)
            {
                sendTime.Stop();
                checkBox_定时发送.Checked = false;
                button_发送.Enabled = true;
                return;
            }

            // 直接触发发送按钮的点击事件，复用发送逻辑
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
                    Encoding encoding = Encoding.UTF8;
                    switch (comboBox_编码.Text)
                    {
                        case "UTF-8":
                            {
                                encoding = Encoding.UTF8;
                                break;
                            }
                        case "GB2312":
                            {
                                encoding = Encoding.GetEncoding("GB2312");
                                break;
                            }
                        case "ASCII":
                            {
                                encoding = Encoding.ASCII;
                                break;
                            }
                    }
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
                // 1. 获取接收缓冲区有多少字节
                int bytesToRead = serialPort.BytesToRead;
                if (bytesToRead == 0)
                {
                    return; // 没有数据就直接返回
                }
                // 2. 创建一个字节数组来存储接收到的数据
                byte[] receivedBytes = new byte[bytesToRead];
                serialPort.Read(receivedBytes, 0, bytesToRead);//读数据
                // 3. // 3. 根据下拉框选择的编码，把字节翻译成文字
                Encoding encoding = Encoding.UTF8;
                rxCount += receivedBytes.Length;
                toolStripStatusLabel2.Text = $"RX:{rxCount}位";
                this.Invoke(new Action(() =>
                {
                    if (checkBox5.Checked)
                    {
                        return;
                    }
                    if (checkBox3.Checked)
                    {
                        // ================= HEX 显示模式 =================

                        // 把字节数组直接转成十六进制字符串，并把 "-" 替换成空格
                        string hexString = BitConverter.ToString(receivedBytes).Replace("-", " ");

                        // 处理时间戳
                        if (checkBox4.Checked)
                        {
                            richTextBox1.SelectionColor = Color.Red;
                            richTextBox1.AppendText("[" + DateTime.Now.ToString("HH:mm:ss.fff") + "] ");
                            richTextBox1.SelectionColor = Color.Black;
                        }

                        // 打印 HEX 数据并换行
                        richTextBox1.AppendText(hexString + "\r\n");
                    }
                    else
                    {
                        switch (comboBox_编码.Text)
                        {
                            case "UTF-8":
                                {
                                    encoding = Encoding.UTF8;
                                    break;
                                }
                            case "GB2312":
                                {
                                    encoding = Encoding.GetEncoding("GB2312");
                                    break;
                                }
                            case "ASCII":
                                {
                                    encoding = Encoding.ASCII;
                                    break;
                                }
                        }
                        string receivedText = encoding.GetString(receivedBytes);
                        //清洗数据
                        // receivedText = receivedText.Replace("\r", "").Replace("\n", "").Replace("\0", "");
                        //把接收到的字符进行以"\r\n"拆分
                        string[] lines = receivedText.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                        if (lines.Length > 0)
                        {
                            foreach (string line in lines)
                            {
                                if (checkBox4.Checked)
                                {
                                    // 1. 把光标颜色设为灰色，打印时间戳
                                    richTextBox1.SelectionColor = Color.Red;
                                    richTextBox1.AppendText("[" + DateTime.Now.ToString("HH:mm:ss.fff") + "] ");

                                    // 2. 把光标颜色改回黑色，打印数据
                                    richTextBox1.SelectionColor = Color.Black;
                                    richTextBox1.AppendText(line.Trim() + "\r\n");
                                }
                                else
                                {
                                    // 没勾选，直接黑色打印
                                    richTextBox1.SelectionColor = Color.Black;
                                    richTextBox1.AppendText(line.Trim() + "\r\n");
                                }


                            }
                            richTextBox1.ScrollToCaret();
                        }
                    }

     
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("接收数据时发生错误：" + ex.Message, "错误");
            }
        }

        private void checkBox_追加换行_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
