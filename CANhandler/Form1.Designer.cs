namespace CANhandler
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
            button1 = new Button();
            txt_Status = new TextBox();
            groupBox1 = new GroupBox();
            lst_History = new ListBox();
            txt_cmd = new TextBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            label7 = new Label();
            pb_connect = new PictureBox();
            cbo_Baudrate = new ComboBox();
            cbo_port = new ComboBox();
            btn_Disconnect = new Button();
            btn_Connect = new Button();
            label2 = new Label();
            label1 = new Label();
            groupBox4 = new GroupBox();
            button4 = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            comboBox3 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            label6 = new Label();
            groupBox5 = new GroupBox();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_connect).BeginInit();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(41, 176);
            button1.Name = "button1";
            button1.Size = new Size(238, 45);
            button1.TabIndex = 1;
            button1.Text = "btnSend";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txt_Status
            // 
            txt_Status.Location = new Point(1378, 903);
            txt_Status.Name = "txt_Status";
            txt_Status.Size = new Size(467, 27);
            txt_Status.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Black;
            groupBox1.Controls.Add(lst_History);
            groupBox1.ForeColor = Color.Cyan;
            groupBox1.Location = new Point(1104, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(766, 791);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "History";
            // 
            // lst_History
            // 
            lst_History.FormattingEnabled = true;
            lst_History.Location = new Point(20, 34);
            lst_History.Name = "lst_History";
            lst_History.Size = new Size(721, 724);
            lst_History.TabIndex = 0;
            // 
            // txt_cmd
            // 
            txt_cmd.BackColor = Color.Black;
            txt_cmd.ForeColor = Color.White;
            txt_cmd.Location = new Point(15, 33);
            txt_cmd.Name = "txt_cmd";
            txt_cmd.Size = new Size(435, 27);
            txt_cmd.TabIndex = 4;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txt_cmd);
            groupBox2.Location = new Point(12, 824);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(469, 106);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Command Terminal";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.FromArgb(0, 192, 192);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(pb_connect);
            groupBox3.Controls.Add(cbo_Baudrate);
            groupBox3.Controls.Add(cbo_port);
            groupBox3.Controls.Add(btn_Disconnect);
            groupBox3.Controls.Add(btn_Connect);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(label1);
            groupBox3.Location = new Point(41, 27);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(314, 143);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Communicate";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(245, 39);
            label7.Name = "label7";
            label7.Size = new Size(63, 20);
            label7.TabIndex = 7;
            label7.Text = "Connect";
            // 
            // pb_connect
            // 
            pb_connect.Location = new Point(263, 62);
            pb_connect.Name = "pb_connect";
            pb_connect.Size = new Size(28, 22);
            pb_connect.TabIndex = 6;
            pb_connect.TabStop = false;
            // 
            // cbo_Baudrate
            // 
            cbo_Baudrate.FormattingEnabled = true;
            cbo_Baudrate.Items.AddRange(new object[] { "9600", "19200", "38400", "115200" });
            cbo_Baudrate.Location = new Point(81, 63);
            cbo_Baudrate.Name = "cbo_Baudrate";
            cbo_Baudrate.Size = new Size(142, 28);
            cbo_Baudrate.TabIndex = 5;
            // 
            // cbo_port
            // 
            cbo_port.FormattingEnabled = true;
            cbo_port.Items.AddRange(new object[] { "COM 1", "COM 2", "COM 3", "COM 4" });
            cbo_port.Location = new Point(83, 31);
            cbo_port.Name = "cbo_port";
            cbo_port.Size = new Size(140, 28);
            cbo_port.TabIndex = 4;
            // 
            // btn_Disconnect
            // 
            btn_Disconnect.Location = new Point(117, 97);
            btn_Disconnect.Name = "btn_Disconnect";
            btn_Disconnect.Size = new Size(106, 40);
            btn_Disconnect.TabIndex = 3;
            btn_Disconnect.Text = "Disconnect";
            btn_Disconnect.UseVisualStyleBackColor = true;
            // 
            // btn_Connect
            // 
            btn_Connect.Location = new Point(19, 97);
            btn_Connect.Name = "btn_Connect";
            btn_Connect.Size = new Size(92, 40);
            btn_Connect.TabIndex = 3;
            btn_Connect.Text = "Connect";
            btn_Connect.UseVisualStyleBackColor = true;
            btn_Connect.Click += btn_Connect_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 64);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 0;
            label2.Text = "BaudRate";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 34);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 0;
            label1.Text = "PORT";
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.Teal;
            groupBox4.Controls.Add(button4);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(comboBox3);
            groupBox4.Controls.Add(comboBox2);
            groupBox4.Controls.Add(comboBox1);
            groupBox4.Location = new Point(502, 824);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(860, 106);
            groupBox4.TabIndex = 7;
            groupBox4.TabStop = false;
            groupBox4.Text = "DEVICE TEST";
            // 
            // button4
            // 
            button4.Location = new Point(765, 43);
            button4.Name = "button4";
            button4.Size = new Size(71, 54);
            button4.TabIndex = 2;
            button4.Text = "SEND";
            button4.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Yellow;
            label5.Location = new Point(587, 34);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 1;
            label5.Text = "Data String";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Yellow;
            label4.Location = new Point(425, 34);
            label4.Name = "label4";
            label4.Size = new Size(113, 20);
            label4.TabIndex = 1;
            label4.Text = "Command Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Yellow;
            label3.Location = new Point(24, 34);
            label3.Name = "label3";
            label3.Size = new Size(65, 20);
            label3.TabIndex = 1;
            label3.Text = "PIC Type";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(587, 57);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(151, 28);
            comboBox3.TabIndex = 0;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "WHO_ARE_YOU ", "LED_TOGGLING_1 ", "LED_TOGGLING_2" });
            comboBox2.Location = new Point(416, 57);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "PIC_GEN", "PIC_DISP_3X3_GRAINS", "PIC_DISP_3X3_LIQUID", "PIC_DISP_3X3_PUREE", "PIC_DISP_6X6_GRAINS", "PIC_DISP_6X6_LIQUID", "PIC_DISP_6X6_PUREE", "PIC_REFRIGERATOR", "PIC_GRINDER", "PIC_IP", "PIC_CHIMNEY", "PIC_DISHWASHER", "PIC_WTS", "PIC_MOTOR_DRIVER1", "SM_PIC_MOTOR_DRIVER_X", "SM_PIC_MOTOR_DRIVER_Y", "SM_PIC_MOTOR_DRIVER_R1", "SM_PIC_MOTOR_DRIVER_R2", "SM_PIC_MOTOR_DRIVER_R3", "SM_PIC_MOTOR_DRIVER_R4", "SM_PIC_MOTOR_DRIVER_R5", "SM_PIC_MOTOR_DRIVER_L1", "SM_PIC_MOTOR_DRIVER_L2", "SM_PIC_MOTOR_DRIVER_L3", "SM_PIC_MOTOR_DRIVER_L4" });
            comboBox1.Location = new Point(24, 57);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(194, 28);
            comboBox1.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Yellow;
            label6.Location = new Point(1378, 881);
            label6.Name = "label6";
            label6.Size = new Size(128, 20);
            label6.TabIndex = 1;
            label6.Text = "STATUS MESSAGE";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(dataGridView1);
            groupBox5.Location = new Point(361, 12);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(725, 791);
            groupBox5.TabIndex = 8;
            groupBox5.TabStop = false;
            groupBox5.Text = "groupBox5";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(18, 34);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(684, 738);
            dataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(1882, 953);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(label6);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(txt_Status);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_connect).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxReceive;
        private Button button1;
        private TextBox txt_Status;
        private GroupBox groupBox1;
        private ListBox lst_History;
        private TextBox txt_cmd;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button btn_Disconnect;
        private Button btn_Connect;
        private Label label2;
        private Label label1;
        private GroupBox groupBox4;
        private Button button4;
        private Label label3;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private ComboBox comboBox3;
        private Label label5;
        private Label label4;
        private Label label6;
        private GroupBox groupBox5;
        private DataGridView dataGridView1;
        private ComboBox cbo_Baudrate;
        private ComboBox cbo_port;
        private PictureBox pb_connect;
        private Label label7;
    }
}
