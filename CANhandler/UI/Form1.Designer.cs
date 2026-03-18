namespace CANhandler
{
    partial class frm_main
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
            components = new System.ComponentModel.Container();
            groupBox7 = new GroupBox();
            chk_loop = new CheckBox();
            btn_prg_send = new Button();
            btn_Stop = new Button();
            groupBox1 = new GroupBox();
            rbtn_externalSim = new RadioButton();
            rbtn_InbuiltSim = new RadioButton();
            rbtn_real_hardware = new RadioButton();
            btn_run = new Button();
            btn_pause = new Button();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem1 = new ToolStripMenuItem();
            recentFilesToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            exutToolStripMenuItem = new ToolStripMenuItem();
            communicationToolStripMenuItem = new ToolStripMenuItem();
            serialToolStripMenuItem = new ToolStripMenuItem();
            tCPToolStripMenuItem = new ToolStripMenuItem();
            uDPToolStripMenuItem = new ToolStripMenuItem();
            disconnectToolStripMenuItem = new ToolStripMenuItem();
            communicationBusToolStripMenuItem = new ToolStripMenuItem();
            cANToolStripMenuItem = new ToolStripMenuItem();
            modBusToolStripMenuItem = new ToolStripMenuItem();
            programToolStripMenuItem = new ToolStripMenuItem();
            rUNToolStripMenuItem = new ToolStripMenuItem();
            sTOPToolStripMenuItem = new ToolStripMenuItem();
            pAUSEToolStripMenuItem = new ToolStripMenuItem();
            resetToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            packetMonitorToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
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
            statusStrip = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lbl_message = new ToolStripStatusLabel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            InsertRow = new ToolStripMenuItem();
            DeleteRow = new ToolStripMenuItem();
            btn_resume = new Button();
            groupBox7.SuspendLayout();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dg_prg).BeginInit();
            statusStrip.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(btn_resume);
            groupBox7.Controls.Add(chk_loop);
            groupBox7.Controls.Add(btn_prg_send);
            groupBox7.Controls.Add(btn_Stop);
            groupBox7.Controls.Add(groupBox1);
            groupBox7.Controls.Add(btn_run);
            groupBox7.Controls.Add(btn_pause);
            groupBox7.Location = new Point(1303, 31);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(167, 619);
            groupBox7.TabIndex = 10;
            groupBox7.TabStop = false;
            groupBox7.Text = "Control Panel";
            // 
            // chk_loop
            // 
            chk_loop.AutoSize = true;
            chk_loop.ForeColor = Color.White;
            chk_loop.Location = new Point(10, 430);
            chk_loop.Name = "chk_loop";
            chk_loop.Size = new Size(67, 24);
            chk_loop.TabIndex = 14;
            chk_loop.Text = "LOOP";
            chk_loop.UseVisualStyleBackColor = true;
            chk_loop.CheckedChanged += chk_loop_CheckedChanged;
            // 
            // btn_prg_send
            // 
            btn_prg_send.Location = new Point(6, 227);
            btn_prg_send.Name = "btn_prg_send";
            btn_prg_send.Size = new Size(143, 152);
            btn_prg_send.TabIndex = 3;
            btn_prg_send.Text = "SEND";
            btn_prg_send.UseVisualStyleBackColor = true;
            btn_prg_send.Click += btn_prg_send_Click;
            // 
            // btn_Stop
            // 
            btn_Stop.Location = new Point(6, 162);
            btn_Stop.Name = "btn_Stop";
            btn_Stop.Size = new Size(155, 59);
            btn_Stop.TabIndex = 2;
            btn_Stop.Text = "STOP";
            btn_Stop.UseVisualStyleBackColor = true;
            btn_Stop.Click += btn_Stop_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbtn_externalSim);
            groupBox1.Controls.Add(rbtn_InbuiltSim);
            groupBox1.Controls.Add(rbtn_real_hardware);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(4, 471);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(145, 142);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Interface";
            // 
            // rbtn_externalSim
            // 
            rbtn_externalSim.AutoSize = true;
            rbtn_externalSim.Location = new Point(6, 56);
            rbtn_externalSim.Name = "rbtn_externalSim";
            rbtn_externalSim.Size = new Size(114, 24);
            rbtn_externalSim.TabIndex = 2;
            rbtn_externalSim.TabStop = true;
            rbtn_externalSim.Text = "External-Sim";
            rbtn_externalSim.UseVisualStyleBackColor = true;
            rbtn_externalSim.CheckedChanged += rbtn_externalSim_CheckedChanged;
            // 
            // rbtn_InbuiltSim
            // 
            rbtn_InbuiltSim.AutoSize = true;
            rbtn_InbuiltSim.Location = new Point(6, 26);
            rbtn_InbuiltSim.Name = "rbtn_InbuiltSim";
            rbtn_InbuiltSim.Size = new Size(103, 24);
            rbtn_InbuiltSim.TabIndex = 1;
            rbtn_InbuiltSim.TabStop = true;
            rbtn_InbuiltSim.Text = "Inbuilt-Sim";
            rbtn_InbuiltSim.UseVisualStyleBackColor = true;
            rbtn_InbuiltSim.CheckedChanged += rbtn_InbuiltSim_CheckedChanged;
            // 
            // rbtn_real_hardware
            // 
            rbtn_real_hardware.AutoSize = true;
            rbtn_real_hardware.Location = new Point(6, 86);
            rbtn_real_hardware.Name = "rbtn_real_hardware";
            rbtn_real_hardware.Size = new Size(128, 24);
            rbtn_real_hardware.TabIndex = 0;
            rbtn_real_hardware.TabStop = true;
            rbtn_real_hardware.Text = "Real Hardware";
            rbtn_real_hardware.UseVisualStyleBackColor = true;
            rbtn_real_hardware.CheckedChanged += rbtn_real_hardware_CheckedChanged;
            // 
            // btn_run
            // 
            btn_run.Location = new Point(4, 26);
            btn_run.Name = "btn_run";
            btn_run.Size = new Size(157, 58);
            btn_run.TabIndex = 2;
            btn_run.Text = "RUN";
            btn_run.UseVisualStyleBackColor = true;
            btn_run.Click += btn_run_Click;
            // 
            // btn_pause
            // 
            btn_pause.Location = new Point(6, 90);
            btn_pause.Name = "btn_pause";
            btn_pause.Size = new Size(71, 66);
            btn_pause.TabIndex = 2;
            btn_pause.Text = "PAUSE";
            btn_pause.UseVisualStyleBackColor = true;
            btn_pause.Click += btn_pause_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, communicationToolStripMenuItem, communicationBusToolStripMenuItem, programToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1482, 28);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { fileToolStripMenuItem, openToolStripMenuItem1, recentFilesToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, exportToolStripMenuItem, exutToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(46, 24);
            toolStripMenuItem1.Text = "File";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(170, 26);
            fileToolStripMenuItem.Text = "New";
            fileToolStripMenuItem.Click += fileToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem1
            // 
            openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            openToolStripMenuItem1.Size = new Size(170, 26);
            openToolStripMenuItem1.Text = "Open";
            openToolStripMenuItem1.Click += openToolStripMenuItem1_Click;
            // 
            // recentFilesToolStripMenuItem
            // 
            recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
            recentFilesToolStripMenuItem.Size = new Size(170, 26);
            recentFilesToolStripMenuItem.Text = "Recent Files";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(170, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(170, 26);
            saveAsToolStripMenuItem.Text = "Save As";
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(170, 26);
            exportToolStripMenuItem.Text = "Export";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // exutToolStripMenuItem
            // 
            exutToolStripMenuItem.Name = "exutToolStripMenuItem";
            exutToolStripMenuItem.Size = new Size(170, 26);
            exutToolStripMenuItem.Text = "Exit";
            // 
            // communicationToolStripMenuItem
            // 
            communicationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { serialToolStripMenuItem, tCPToolStripMenuItem, uDPToolStripMenuItem, disconnectToolStripMenuItem });
            communicationToolStripMenuItem.Name = "communicationToolStripMenuItem";
            communicationToolStripMenuItem.Size = new Size(114, 24);
            communicationToolStripMenuItem.Text = "Physical Layer";
            // 
            // serialToolStripMenuItem
            // 
            serialToolStripMenuItem.Name = "serialToolStripMenuItem";
            serialToolStripMenuItem.Size = new Size(165, 26);
            serialToolStripMenuItem.Text = "Serial";
            // 
            // tCPToolStripMenuItem
            // 
            tCPToolStripMenuItem.Name = "tCPToolStripMenuItem";
            tCPToolStripMenuItem.Size = new Size(165, 26);
            tCPToolStripMenuItem.Text = "TCP";
            // 
            // uDPToolStripMenuItem
            // 
            uDPToolStripMenuItem.Name = "uDPToolStripMenuItem";
            uDPToolStripMenuItem.Size = new Size(165, 26);
            uDPToolStripMenuItem.Text = "UDP";
            // 
            // disconnectToolStripMenuItem
            // 
            disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            disconnectToolStripMenuItem.Size = new Size(165, 26);
            disconnectToolStripMenuItem.Text = "Disconnect";
            // 
            // communicationBusToolStripMenuItem
            // 
            communicationBusToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cANToolStripMenuItem, modBusToolStripMenuItem });
            communicationBusToolStripMenuItem.Name = "communicationBusToolStripMenuItem";
            communicationBusToolStripMenuItem.Size = new Size(155, 24);
            communicationBusToolStripMenuItem.Text = "Communication Bus";
            // 
            // cANToolStripMenuItem
            // 
            cANToolStripMenuItem.Name = "cANToolStripMenuItem";
            cANToolStripMenuItem.Size = new Size(146, 26);
            cANToolStripMenuItem.Text = "CAN";
            // 
            // modBusToolStripMenuItem
            // 
            modBusToolStripMenuItem.Name = "modBusToolStripMenuItem";
            modBusToolStripMenuItem.Size = new Size(146, 26);
            modBusToolStripMenuItem.Text = "ModBus";
            // 
            // programToolStripMenuItem
            // 
            programToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rUNToolStripMenuItem, sTOPToolStripMenuItem, pAUSEToolStripMenuItem, resetToolStripMenuItem });
            programToolStripMenuItem.Name = "programToolStripMenuItem";
            programToolStripMenuItem.Size = new Size(80, 24);
            programToolStripMenuItem.Text = "Program";
            // 
            // rUNToolStripMenuItem
            // 
            rUNToolStripMenuItem.Name = "rUNToolStripMenuItem";
            rUNToolStripMenuItem.Size = new Size(129, 26);
            rUNToolStripMenuItem.Text = "Run";
            rUNToolStripMenuItem.Click += rUNToolStripMenuItem_Click;
            // 
            // sTOPToolStripMenuItem
            // 
            sTOPToolStripMenuItem.Name = "sTOPToolStripMenuItem";
            sTOPToolStripMenuItem.Size = new Size(129, 26);
            sTOPToolStripMenuItem.Text = "Stop";
            // 
            // pAUSEToolStripMenuItem
            // 
            pAUSEToolStripMenuItem.Name = "pAUSEToolStripMenuItem";
            pAUSEToolStripMenuItem.Size = new Size(129, 26);
            pAUSEToolStripMenuItem.Text = "Pause";
            // 
            // resetToolStripMenuItem
            // 
            resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resetToolStripMenuItem.Size = new Size(129, 26);
            resetToolStripMenuItem.Text = "Reset";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, packetMonitorToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(58, 24);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(191, 26);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // packetMonitorToolStripMenuItem
            // 
            packetMonitorToolStripMenuItem.Name = "packetMonitorToolStripMenuItem";
            packetMonitorToolStripMenuItem.Size = new Size(191, 26);
            packetMonitorToolStripMenuItem.Text = "Packet Monitor";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(133, 26);
            aboutToolStripMenuItem.Text = "About";
            // 
            // dg_prg
            // 
            dg_prg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_prg.Columns.AddRange(new DataGridViewColumn[] { col_line_no, col_enable, col_pic_type, col_Action, col_Command, col_MSB, col_LSB, col_delay, col_loop });
            dg_prg.Location = new Point(0, 31);
            dg_prg.Name = "dg_prg";
            dg_prg.RowHeadersWidth = 51;
            dg_prg.Size = new Size(1297, 618);
            dg_prg.TabIndex = 0;
            dg_prg.CellMouseDown += dg_prg_CellMouseDown;
            dg_prg.KeyDown += dg_prg_KeyDown;
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
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(0, 192, 192);
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, lbl_message });
            statusStrip.Location = new Point(0, 653);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1482, 26);
            statusStrip.TabIndex = 14;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(119, 20);
            toolStripStatusLabel1.Text = "Current Line: 000";
            // 
            // lbl_message
            // 
            lbl_message.Name = "lbl_message";
            lbl_message.Size = new Size(148, 20);
            lbl_message.Text = "Message: Data saved";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { InsertRow, DeleteRow });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(172, 52);
            // 
            // InsertRow
            // 
            InsertRow.Name = "InsertRow";
            InsertRow.Size = new Size(171, 24);
            InsertRow.Text = "Insert Row";
            InsertRow.Click += InsertRow_Click;
            // 
            // DeleteRow
            // 
            DeleteRow.Name = "DeleteRow";
            DeleteRow.Size = new Size(171, 24);
            DeleteRow.Text = "Delete Row(s)";
            DeleteRow.Click += DeleteRow_Click;
            // 
            // btn_resume
            // 
            btn_resume.Location = new Point(83, 90);
            btn_resume.Name = "btn_resume";
            btn_resume.Size = new Size(78, 66);
            btn_resume.TabIndex = 15;
            btn_resume.Text = "RESUME";
            btn_resume.UseVisualStyleBackColor = true;
            btn_resume.Click += btn_resume_Click;
            // 
            // frm_main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(1482, 679);
            Controls.Add(statusStrip);
            Controls.Add(dg_prg);
            Controls.Add(groupBox7);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "frm_main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Robot Subsystem Test Interface V1.0";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dg_prg).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxReceive;
        private GroupBox groupBox7;
        private Button btn_Stop;
        private Button btn_pause;
        private Button btn_run;
        private Button btn_prg_send;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem communicationToolStripMenuItem;
        private DataGridView dg_prg;
        private DataGridViewTextBoxColumn col_line_no;
        private DataGridViewCheckBoxColumn col_enable;
        private DataGridViewComboBoxColumn col_pic_type;
        private DataGridViewComboBoxColumn col_Action;
        private DataGridViewComboBoxColumn col_Command;
        private DataGridViewTextBoxColumn col_MSB;
        private DataGridViewTextBoxColumn col_LSB;
        private DataGridViewTextBoxColumn col_delay;
        private DataGridViewTextBoxColumn col_loop;
        private GroupBox groupBox1;
        private RadioButton rbtn_real_hardware;
        private RadioButton rbtn_InbuiltSim;
        private ToolStripMenuItem openToolStripMenuItem1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem exutToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem serialToolStripMenuItem;
        private ToolStripMenuItem tCPToolStripMenuItem;
        private ToolStripMenuItem uDPToolStripMenuItem;
        private ToolStripMenuItem disconnectToolStripMenuItem;
        private ToolStripMenuItem communicationBusToolStripMenuItem;
        private ToolStripMenuItem cANToolStripMenuItem;
        private ToolStripMenuItem modBusToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem programToolStripMenuItem;
        private ToolStripMenuItem rUNToolStripMenuItem;
        private ToolStripMenuItem sTOPToolStripMenuItem;
        private ToolStripMenuItem pAUSEToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem packetMonitorToolStripMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem resetToolStripMenuItem;
        private ToolStripStatusLabel lbl_message;
        private RadioButton rbtn_externalSim;
        private ToolStripMenuItem recentFilesToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem InsertRow;
        private ToolStripMenuItem DeleteRow;
        private CheckBox chk_loop;
        private Button btn_resume;
    }
}
