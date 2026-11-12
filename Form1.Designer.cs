

namespace My_串口调试助手
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button_刷新 = new Button();
            button_打开串口 = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            comboBox_端口号 = new ComboBox();
            comboBox_波特率 = new ComboBox();
            comboBox_数据位 = new ComboBox();
            comboBox_停止位 = new ComboBox();
            comboBox_校验位 = new ComboBox();
            comboBox_编码 = new ComboBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            richTextBox1 = new RichTextBox();
            checkBox5 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox3 = new CheckBox();
            button_清空接收 = new Button();
            groupBox3 = new GroupBox();
            checkBox8 = new CheckBox();
            checkBox_追加换行 = new CheckBox();
            numericUpDown1 = new NumericUpDown();
            button_发送清空 = new Button();
            button_发送 = new Button();
            textBox1 = new TextBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            checkBox_定时发送 = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // checkBox_定时发送
            // 
            checkBox_定时发送.AutoSize = true;
            checkBox_定时发送.BackgroundImageLayout = ImageLayout.Center;
            checkBox_定时发送.Location = new Point(253, 160);
            checkBox_定时发送.Name = "checkBox_定时发送";
            checkBox_定时发送.Size = new Size(106, 22);
            checkBox_定时发送.TabIndex = 12;
            checkBox_定时发送.Text = "定时发送";
            checkBox_定时发送.UseVisualStyleBackColor = true;
            checkBox_定时发送.CheckedChanged += checkBox6_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 62);
            label2.Name = "label2";
            label2.Size = new Size(65, 18);
            label2.TabIndex = 1;
            label2.Text = "端口号";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 102);
            label1.Name = "label1";
            label1.Size = new Size(65, 18);
            label1.TabIndex = 2;
            label1.Text = "波特率";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 145);
            label3.Name = "label3";
            label3.Size = new Size(65, 18);
            label3.TabIndex = 3;
            label3.Text = "数据位";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 196);
            label4.Name = "label4";
            label4.Size = new Size(65, 18);
            label4.TabIndex = 4;
            label4.Text = "停止位";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 249);
            label5.Name = "label5";
            label5.Size = new Size(65, 18);
            label5.TabIndex = 5;
            label5.Text = "校验位";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 303);
            label6.Name = "label6";
            label6.Size = new Size(46, 18);
            label6.TabIndex = 6;
            label6.Text = "编码";
            // 
            // button_刷新
            // 
            button_刷新.Location = new Point(95, 24);
            button_刷新.Name = "button_刷新";
            button_刷新.Size = new Size(72, 29);
            button_刷新.TabIndex = 7;
            button_刷新.Text = "刷新";
            button_刷新.UseVisualStyleBackColor = true;
            button_刷新.Click += button_刷新_Click;
            // 
            // button_打开串口
            // 
            button_打开串口.AutoSize = true;
            button_打开串口.Location = new Point(17, 372);
            button_打开串口.Name = "button_打开串口";
            button_打开串口.Size = new Size(102, 38);
            button_打开串口.TabIndex = 8;
            button_打开串口.Text = "打开串口";
            button_打开串口.UseVisualStyleBackColor = true;
            button_打开串口.Click += button_打开串口_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(17, 333);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(60, 22);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "DTR";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(158, 333);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(60, 22);
            checkBox2.TabIndex = 10;
            checkBox2.Text = "RTS";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // comboBox_端口号
            // 
            comboBox_端口号.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_端口号.FormattingEnabled = true;
            comboBox_端口号.Location = new Point(66, 59);
            comboBox_端口号.Name = "comboBox_端口号";
            comboBox_端口号.Size = new Size(151, 26);
            comboBox_端口号.TabIndex = 11;
            // 
            // comboBox_波特率
            // 
            comboBox_波特率.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_波特率.FormattingEnabled = true;
            comboBox_波特率.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "115200" });
            comboBox_波特率.Location = new Point(66, 99);
            comboBox_波特率.Name = "comboBox_波特率";
            comboBox_波特率.Size = new Size(151, 26);
            comboBox_波特率.TabIndex = 12;
            // 
            // comboBox_数据位
            // 
            comboBox_数据位.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_数据位.FormattingEnabled = true;
            comboBox_数据位.Items.AddRange(new object[] { "8", "7", "6", "5" });
            comboBox_数据位.Location = new Point(66, 142);
            comboBox_数据位.Name = "comboBox_数据位";
            comboBox_数据位.Size = new Size(151, 26);
            comboBox_数据位.TabIndex = 13;
            // 
            // comboBox_停止位
            // 
            comboBox_停止位.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_停止位.FormattingEnabled = true;
            comboBox_停止位.Items.AddRange(new object[] { "1", "1.5", "2" });
            comboBox_停止位.Location = new Point(66, 188);
            comboBox_停止位.Name = "comboBox_停止位";
            comboBox_停止位.Size = new Size(151, 26);
            comboBox_停止位.TabIndex = 14;
            // 
            // comboBox_校验位
            // 
            comboBox_校验位.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_校验位.FormattingEnabled = true;
            comboBox_校验位.Items.AddRange(new object[] { "None", "Odd", "Even", "Mark", "Space" });
            comboBox_校验位.Location = new Point(66, 249);
            comboBox_校验位.Name = "comboBox_校验位";
            comboBox_校验位.Size = new Size(151, 26);
            comboBox_校验位.TabIndex = 15;
            // 
            // comboBox_编码
            // 
            comboBox_编码.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_编码.FormattingEnabled = true;
            comboBox_编码.Items.AddRange(new object[] { "UTF-8", "GB2312", "ASCII" });
            comboBox_编码.Location = new Point(66, 299);
            comboBox_编码.Name = "comboBox_编码";
            comboBox_编码.Size = new Size(151, 26);
            comboBox_编码.TabIndex = 16;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button_刷新);
            groupBox1.Controls.Add(button_打开串口);
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(comboBox_编码);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(comboBox_校验位);
            groupBox1.Controls.Add(comboBox_端口号);
            groupBox1.Controls.Add(comboBox_停止位);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(comboBox_数据位);
            groupBox1.Controls.Add(comboBox_波特率);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Font = new Font("宋体", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            groupBox1.Location = new Point(22, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 426);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "串口配置";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(richTextBox1);
            groupBox2.Controls.Add(checkBox5);
            groupBox2.Controls.Add(checkBox4);
            groupBox2.Controls.Add(checkBox3);
            groupBox2.Controls.Add(button_清空接收);
            groupBox2.Font = new Font("宋体", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            groupBox2.Location = new Point(298, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(474, 426);
            groupBox2.TabIndex = 18;
            groupBox2.TabStop = false;
            groupBox2.Text = "接收区";
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("宋体", 10.8F, FontStyle.Bold);
            richTextBox1.Location = new Point(6, 24);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(462, 331);
            richTextBox1.TabIndex = 13;
            richTextBox1.Text = "";
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Font = new Font("宋体", 10.8F, FontStyle.Bold);
            checkBox5.Location = new Point(319, 363);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(68, 22);
            checkBox5.TabIndex = 12;
            checkBox5.Text = "暂停";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Font = new Font("宋体", 10.8F, FontStyle.Bold);
            checkBox4.Location = new Point(174, 363);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(87, 22);
            checkBox4.TabIndex = 11;
            checkBox4.Text = "时间戳";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Font = new Font("宋体", 10.8F, FontStyle.Bold);
            checkBox3.Location = new Point(29, 363);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(98, 22);
            checkBox3.TabIndex = 10;
            checkBox3.Text = "HEX显示";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // button_清空接收
            // 
            button_清空接收.Font = new Font("宋体", 10.8F, FontStyle.Bold);
            button_清空接收.Location = new Point(155, 391);
            button_清空接收.Name = "button_清空接收";
            button_清空接收.Size = new Size(97, 29);
            button_清空接收.TabIndex = 8;
            button_清空接收.Text = "清空接收";
            button_清空接收.UseVisualStyleBackColor = true;
            button_清空接收.Click += button_清空接收_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkBox8);
            groupBox3.Controls.Add(checkBox_追加换行);
            groupBox3.Controls.Add(checkBox_定时发送);
            groupBox3.Controls.Add(numericUpDown1);
            groupBox3.Controls.Add(button_发送清空);
            groupBox3.Controls.Add(button_发送);
            groupBox3.Controls.Add(textBox1);
            groupBox3.Font = new Font("宋体", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            groupBox3.Location = new Point(12, 444);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(760, 200);
            groupBox3.TabIndex = 19;
            groupBox3.TabStop = false;
            groupBox3.Text = "发送区";
            // 
            // checkBox8
            // 
            checkBox8.AutoSize = true;
            checkBox8.Font = new Font("宋体", 10.8F, FontStyle.Bold);
            checkBox8.Location = new Point(16, 160);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(98, 22);
            checkBox8.TabIndex = 17;
            checkBox8.Text = "HEX发送";
            checkBox8.UseVisualStyleBackColor = true;
            checkBox8.CheckedChanged += checkBox8_CheckedChanged;
            // 
            // checkBox_追加换行
            // 
            checkBox_追加换行.AutoSize = true;
            checkBox_追加换行.Location = new Point(122, 160);
            checkBox_追加换行.Name = "checkBox_追加换行";
            checkBox_追加换行.Size = new Size(106, 22);
            checkBox_追加换行.TabIndex = 13;
            checkBox_追加换行.Text = "追加换行";
            checkBox_追加换行.UseVisualStyleBackColor = true;
            checkBox_追加换行.CheckedChanged += checkBox_追加换行_CheckedChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(365, 154);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(79, 28);
            numericUpDown1.TabIndex = 11;
            // 
            // button_发送清空
            // 
            button_发送清空.Location = new Point(634, 137);
            button_发送清空.Name = "button_发送清空";
            button_发送清空.Size = new Size(117, 57);
            button_发送清空.TabIndex = 10;
            button_发送清空.Text = "发送清空";
            button_发送清空.UseVisualStyleBackColor = true;
            button_发送清空.Click += button_发送清空_Click;
            // 
            // button_发送
            // 
            button_发送.Location = new Point(679, 17);
            button_发送.Name = "button_发送";
            button_发送.Size = new Size(72, 114);
            button_发送.TabIndex = 9;
            button_发送.Text = "发送";
            button_发送.UseVisualStyleBackColor = true;
            button_发送.Click += button_发送_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 17);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(667, 114);
            textBox1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, toolStripStatusLabel3 });
            statusStrip1.Location = new Point(0, 648);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 26);
            statusStrip1.TabIndex = 20;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(84, 20);
            toolStripStatusLabel1.Text = "串口已关闭";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(57, 20);
            toolStripStatusLabel2.Text = "RX:0位";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(56, 20);
            toolStripStatusLabel3.Text = "TX:0位";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 674);
            Controls.Add(statusStrip1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button_刷新;
        private Button button_打开串口;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private ComboBox comboBox_端口号;
        private ComboBox comboBox_波特率;
        private ComboBox comboBox_数据位;
        private ComboBox comboBox_停止位;
        private ComboBox comboBox_校验位;
        private ComboBox comboBox_编码;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private Button button_清空接收;
        private RichTextBox richTextBox1;
        private Button button_发送;
        private TextBox textBox1;
        private Button button_发送清空;
        private CheckBox checkBox_定时发送;
        private NumericUpDown numericUpDown1;
        private CheckBox checkBox8;
        private CheckBox checkBox_追加换行;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
    }
}
