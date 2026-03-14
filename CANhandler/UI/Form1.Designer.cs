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
            label6 = new Label();
            groupBox5 = new GroupBox();
            dg_prg = new DataGridView();
            col_line_no = new DataGridViewTextBoxColumn();
            col_enable = new DataGridViewCheckBoxColumn();
            col_pic_type = new DataGridViewComboBoxColumn();
            col_Action = new DataGridViewComboBoxColumn();
            col_Command = new DataGridViewComboBoxColumn();
            col_MSB = new DataGridViewTextBoxColumn();
            col_LSB = new DataGridViewTextBoxColumn();
            col_delay = new DataGridViewTextBoxColumn();
            col_loop = new DataGridViewTextBoxColumn();
            groupBox7 = new GroupBox();
            btn_prg_send = new Button();
            button7 = new Button();
            button5 = new Button();
            btn_run = new Button();
            button3 = new Button();
            button2 = new Button();
            label13 = new Label();
            textBox1 = new TextBox();
            groupBox8 = new GroupBox();
            btn_export = new Button();
            btn_Open = new Button();
            btn_Save = new Button();
            btn_new_prg = new Button();
            textBox2 = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_connect).BeginInit();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dg_prg).BeginInit();
            groupBox7.SuspendLayout();
            groupBox8.SuspendLayout();
            SuspendLayout();
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
            groupBox1.Location = new Point(725, 785);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(766, 66);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "History";
            // 
            // lst_History
            // 
            lst_History.FormattingEnabled = true;
            lst_History.Location = new Point(20, 26);
            lst_History.Name = "lst_History";
            lst_History.Size = new Size(721, 24);
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
            groupBox3.Location = new Point(12, 119);
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
            groupBox5.Controls.Add(dg_prg);
            groupBox5.Location = new Point(361, 176);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(1343, 555);
            groupBox5.TabIndex = 8;
            groupBox5.TabStop = false;
            groupBox5.Text = "PROGRAM";
            // 
            // dg_prg
            // 
            dg_prg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_prg.Columns.AddRange(new DataGridViewColumn[] { col_line_no, col_enable, col_pic_type, col_Action, col_Command, col_MSB, col_LSB, col_delay, col_loop });
            dg_prg.Location = new Point(18, 34);
            dg_prg.Name = "dg_prg";
            dg_prg.RowHeadersWidth = 51;
            dg_prg.Size = new Size(1311, 511);
            dg_prg.TabIndex = 0;
            // 
            // col_line_no
            // 
            col_line_no.HeaderText = "Line No.";
            col_line_no.MinimumWidth = 6;
            col_line_no.Name = "col_line_no";
            col_line_no.ReadOnly = true;
            col_line_no.Width = 125;
            // 
            // col_enable
            // 
            col_enable.HeaderText = "Enable";
            col_enable.MinimumWidth = 6;
            col_enable.Name = "col_enable";
            col_enable.Width = 125;
            // 
            // col_pic_type
            // 
            col_pic_type.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            col_pic_type.HeaderText = "PIC Type";
            col_pic_type.Items.AddRange(new object[] { "PIC_DISP_3X3_GRAINS", "PIC_DISP_3X3_LIQUID", "PIC_DISP_3X3_PUREE", "PIC_DISP_6X6_GRAINS", "PIC_DISP_6X6_LIQUID", "PIC_DISP_6X6_PUREE", "PIC_IP", "PIC_CHIMNEY", "PIC_DISHWASHER", "PIC_WTS", "PIC_MOTOR_DRIVER1", "SM_PIC_MOTOR_DRIVER_X", "SM_PIC_MOTOR_DRIVER_Y", "SM_PIC_MOTOR_DRIVER_R1", "SM_PIC_MOTOR_DRIVER_R2", "SM_PIC_MOTOR_DRIVER_R3", "SM_PIC_MOTOR_DRIVER_R4", "SM_PIC_MOTOR_DRIVER_R5", "SM_PIC_MOTOR_DRIVER_L1", "SM_PIC_MOTOR_DRIVER_L2", "SM_PIC_MOTOR_DRIVER_L3", "SM_PIC_MOTOR_DRIVER_L4" });
            col_pic_type.MinimumWidth = 6;
            col_pic_type.Name = "col_pic_type";
            col_pic_type.Width = 250;
            // 
            // col_Action
            // 
            col_Action.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            col_Action.HeaderText = "Action";
            col_Action.Items.AddRange(new object[] { "Read", "Write", "Execute" });
            col_Action.MinimumWidth = 6;
            col_Action.Name = "col_Action";
            col_Action.Width = 125;
            // 
            // col_Command
            // 
            col_Command.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            col_Command.HeaderText = "Command";
            col_Command.Items.AddRange(new object[] { "Dispense", "PB6_LED", "PB5_LED", "Erase_Log", "Who_Are_You", "Read_Log_Count", "Read_Logs" });
            col_Command.MinimumWidth = 6;
            col_Command.Name = "col_Command";
            col_Command.Width = 125;
            // 
            // col_MSB
            // 
            col_MSB.HeaderText = "MSB";
            col_MSB.MinimumWidth = 6;
            col_MSB.Name = "col_MSB";
            col_MSB.Width = 125;
            // 
            // col_LSB
            // 
            col_LSB.HeaderText = "LSB";
            col_LSB.MinimumWidth = 6;
            col_LSB.Name = "col_LSB";
            col_LSB.Width = 125;
            // 
            // col_delay
            // 
            col_delay.HeaderText = "Delay";
            col_delay.MinimumWidth = 6;
            col_delay.Name = "col_delay";
            col_delay.Width = 125;
            // 
            // col_loop
            // 
            col_loop.HeaderText = "Loop";
            col_loop.MinimumWidth = 6;
            col_loop.Name = "col_loop";
            col_loop.Width = 125;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(btn_prg_send);
            groupBox7.Controls.Add(button7);
            groupBox7.Controls.Add(button5);
            groupBox7.Controls.Add(btn_run);
            groupBox7.Controls.Add(button3);
            groupBox7.Controls.Add(button2);
            groupBox7.Location = new Point(1710, 15);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(148, 552);
            groupBox7.TabIndex = 10;
            groupBox7.TabStop = false;
            groupBox7.Text = "Control Panel";
            // 
            // btn_prg_send
            // 
            btn_prg_send.Location = new Point(22, 143);
            btn_prg_send.Name = "btn_prg_send";
            btn_prg_send.Size = new Size(86, 44);
            btn_prg_send.TabIndex = 3;
            btn_prg_send.Text = "SEND";
            btn_prg_send.UseVisualStyleBackColor = true;
            btn_prg_send.Click += btn_prg_send_Click;
            // 
            // button7
            // 
            button7.Location = new Point(22, 476);
            button7.Name = "button7";
            button7.Size = new Size(86, 65);
            button7.TabIndex = 2;
            button7.Text = "RESET";
            button7.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(22, 383);
            button5.Name = "button5";
            button5.Size = new Size(86, 87);
            button5.TabIndex = 2;
            button5.Text = "STOP";
            button5.UseVisualStyleBackColor = true;
            // 
            // btn_run
            // 
            btn_run.Location = new Point(22, 288);
            btn_run.Name = "btn_run";
            btn_run.Size = new Size(86, 45);
            btn_run.TabIndex = 2;
            btn_run.Text = "RUN";
            btn_run.UseVisualStyleBackColor = true;
            btn_run.Click += button3_Click;
            // 
            // button3
            // 
            button3.Location = new Point(22, 193);
            button3.Name = "button3";
            button3.Size = new Size(86, 89);
            button3.TabIndex = 2;
            button3.Text = "PAUSE";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(22, 91);
            button2.Name = "button2";
            button2.Size = new Size(86, 46);
            button2.TabIndex = 2;
            button2.Text = "START";
            button2.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(1113, 23);
            label13.Name = "label13";
            label13.Size = new Size(88, 20);
            label13.TabIndex = 1;
            label13.Text = "Current Line";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1207, 20);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(83, 27);
            textBox1.TabIndex = 0;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(btn_export);
            groupBox8.Controls.Add(btn_Open);
            groupBox8.Controls.Add(btn_Save);
            groupBox8.Controls.Add(btn_new_prg);
            groupBox8.Controls.Add(label13);
            groupBox8.Controls.Add(textBox2);
            groupBox8.Controls.Add(textBox1);
            groupBox8.Location = new Point(361, 27);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(1343, 138);
            groupBox8.TabIndex = 11;
            groupBox8.TabStop = false;
            groupBox8.Text = "Control";
            // 
            // btn_export
            // 
            btn_export.Location = new Point(315, 58);
            btn_export.Name = "btn_export";
            btn_export.Size = new Size(77, 59);
            btn_export.TabIndex = 5;
            btn_export.Text = "Export";
            btn_export.UseVisualStyleBackColor = true;
            btn_export.Click += btn_export_Click;
            // 
            // btn_Open
            // 
            btn_Open.Location = new Point(196, 58);
            btn_Open.Name = "btn_Open";
            btn_Open.Size = new Size(99, 59);
            btn_Open.TabIndex = 4;
            btn_Open.Text = "Open";
            btn_Open.UseVisualStyleBackColor = true;
            btn_Open.Click += btn_Open_Click;
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(103, 58);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(87, 59);
            btn_Save.TabIndex = 3;
            btn_Save.Text = "Save";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // btn_new_prg
            // 
            btn_new_prg.Location = new Point(18, 58);
            btn_new_prg.Name = "btn_new_prg";
            btn_new_prg.Size = new Size(79, 59);
            btn_new_prg.TabIndex = 2;
            btn_new_prg.Text = "New";
            btn_new_prg.UseVisualStyleBackColor = true;
            btn_new_prg.Click += btn_new_prg_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1207, 58);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(83, 27);
            textBox2.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(1882, 953);
            Controls.Add(groupBox8);
            Controls.Add(groupBox7);
            Controls.Add(groupBox5);
            Controls.Add(groupBox3);
            Controls.Add(label6);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(txt_Status);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_connect).EndInit();
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dg_prg).EndInit();
            groupBox7.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxReceive;
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
        private Label label6;
        private GroupBox groupBox5;
        private DataGridView dg_prg;
        private ComboBox cbo_Baudrate;
        private ComboBox cbo_port;
        private PictureBox pb_connect;
        private Label label7;
        private GroupBox groupBox7;
        private Button button5;
        private Button button3;
        private Button button2;
        private Label label13;
        private TextBox textBox1;
        private Button btn_run;
        private DataGridViewTextBoxColumn col_line_no;
        private DataGridViewCheckBoxColumn col_enable;
        private DataGridViewComboBoxColumn col_pic_type;
        private DataGridViewComboBoxColumn col_Action;
        private DataGridViewComboBoxColumn col_Command;
        private DataGridViewTextBoxColumn col_MSB;
        private DataGridViewTextBoxColumn col_LSB;
        private DataGridViewTextBoxColumn col_delay;
        private DataGridViewTextBoxColumn col_loop;
        private Button button7;
        private GroupBox groupBox8;
        private TextBox textBox2;
        private Button btn_new_prg;
        private Button btn_Save;
        private Button btn_Open;
        private Button btn_export;
        private Button btn_prg_send;
    }
}
