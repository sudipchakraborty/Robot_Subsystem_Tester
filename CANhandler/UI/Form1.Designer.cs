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
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pb_tx = new PictureBox();
            pb_rx = new PictureBox();
            pb_connection = new PictureBox();
            chk_auto_connect = new CheckBox();
            btn_disconnect = new Button();
            btn_connect = new Button();
            btn_resume = new Button();
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
            commToolStripMenuItem = new ToolStripMenuItem();
            uSBToolStripMenuItem = new ToolStripMenuItem();
            aPIToolStripMenuItem = new ToolStripMenuItem();
            websocketToolStripMenuItem = new ToolStripMenuItem();
            tcpToolStripMenuItem = new ToolStripMenuItem();
            udpToolStripMenuItem = new ToolStripMenuItem();
            iPCToolStripMenuItem = new ToolStripMenuItem();
            ProtocolToolStripMenuItem = new ToolStripMenuItem();
            kbusToolStripMenuItem = new ToolStripMenuItem();
            rAWBinaryToolStripMenuItem = new ToolStripMenuItem();
            aSCIIToolStripMenuItem = new ToolStripMenuItem();
            cANToolStripMenuItem = new ToolStripMenuItem();
            modBusToolStripMenuItem = new ToolStripMenuItem();
            customToolStripMenuItem = new ToolStripMenuItem();
            programToolStripMenuItem = new ToolStripMenuItem();
            rUNToolStripMenuItem = new ToolStripMenuItem();
            sTOPToolStripMenuItem = new ToolStripMenuItem();
            pAUSEToolStripMenuItem = new ToolStripMenuItem();
            resetToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            packetMonitorToolStripMenuItem = new ToolStripMenuItem();
            terminalToolStripMenuItem = new ToolStripMenuItem();
            debugInterfaceToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            fAQToolStripMenuItem = new ToolStripMenuItem();
            sendMailToDeveloperToolStripMenuItem = new ToolStripMenuItem();
            relatedDOcumentsToolStripMenuItem = new ToolStripMenuItem();
            dg_prg = new DataGridView();
            col_line_no = new DataGridViewTextBoxColumn();
            col_enable = new DataGridViewCheckBoxColumn();
            col_pic_type = new DataGridViewComboBoxColumn();
            col_cast = new DataGridViewComboBoxColumn();
            col_Operation = new DataGridViewComboBoxColumn();
            col_Command = new DataGridViewComboBoxColumn();
            col_data = new DataGridViewTextBoxColumn();
            col_delay = new DataGridViewTextBoxColumn();
            col_loop = new DataGridViewTextBoxColumn();
            statusStrip = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lbl_message = new ToolStripStatusLabel();
            tssl_comport = new ToolStripStatusLabel();
            tssl_baudrate = new ToolStripStatusLabel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            InsertRow = new ToolStripMenuItem();
            DeleteRow = new ToolStripMenuItem();
            groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_tx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_rx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_connection).BeginInit();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dg_prg).BeginInit();
            statusStrip.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(button1);
            groupBox7.Controls.Add(label3);
            groupBox7.Controls.Add(label2);
            groupBox7.Controls.Add(label1);
            groupBox7.Controls.Add(pb_tx);
            groupBox7.Controls.Add(pb_rx);
            groupBox7.Controls.Add(pb_connection);
            groupBox7.Controls.Add(chk_auto_connect);
            groupBox7.Controls.Add(btn_disconnect);
            groupBox7.Controls.Add(btn_connect);
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
            // button1
            // 
            button1.Location = new Point(6, 334);
            button1.Name = "button1";
            button1.Size = new Size(71, 61);
            button1.TabIndex = 21;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Yellow;
            label3.Location = new Point(63, 375);
            label3.Name = "label3";
            label3.Size = new Size(27, 20);
            label3.TabIndex = 20;
            label3.Text = "RX";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Yellow;
            label2.Location = new Point(64, 345);
            label2.Name = "label2";
            label2.Size = new Size(26, 20);
            label2.TabIndex = 20;
            label2.Text = "TX";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Yellow;
            label1.Location = new Point(6, 311);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 20;
            label1.Text = "Connection";
            // 
            // pb_tx
            // 
            pb_tx.BackColor = Color.Silver;
            pb_tx.Location = new Point(97, 341);
            pb_tx.Name = "pb_tx";
            pb_tx.Size = new Size(27, 24);
            pb_tx.TabIndex = 19;
            pb_tx.TabStop = false;
            // 
            // pb_rx
            // 
            pb_rx.BackColor = Color.Silver;
            pb_rx.Location = new Point(97, 371);
            pb_rx.Name = "pb_rx";
            pb_rx.Size = new Size(27, 24);
            pb_rx.TabIndex = 19;
            pb_rx.TabStop = false;
            // 
            // pb_connection
            // 
            pb_connection.BackColor = Color.Maroon;
            pb_connection.Location = new Point(97, 311);
            pb_connection.Name = "pb_connection";
            pb_connection.Size = new Size(27, 24);
            pb_connection.TabIndex = 19;
            pb_connection.TabStop = false;
            // 
            // chk_auto_connect
            // 
            chk_auto_connect.AutoSize = true;
            chk_auto_connect.ForeColor = Color.Cyan;
            chk_auto_connect.Location = new Point(10, 411);
            chk_auto_connect.Name = "chk_auto_connect";
            chk_auto_connect.Size = new Size(121, 24);
            chk_auto_connect.TabIndex = 18;
            chk_auto_connect.Text = "Auto Connect";
            chk_auto_connect.UseVisualStyleBackColor = true;
            chk_auto_connect.CheckedChanged += chk_auto_connect_CheckedChanged;
            // 
            // btn_disconnect
            // 
            btn_disconnect.Location = new Point(17, 243);
            btn_disconnect.Name = "btn_disconnect";
            btn_disconnect.Size = new Size(144, 35);
            btn_disconnect.TabIndex = 17;
            btn_disconnect.Text = "DIsconnect";
            btn_disconnect.UseVisualStyleBackColor = true;
            btn_disconnect.Click += btn_disconnect_Click;
            // 
            // btn_connect
            // 
            btn_connect.Location = new Point(17, 204);
            btn_connect.Name = "btn_connect";
            btn_connect.Size = new Size(144, 33);
            btn_connect.TabIndex = 16;
            btn_connect.Text = "Connect";
            btn_connect.UseVisualStyleBackColor = true;
            btn_connect.Click += btn_connect_Click_2;
            // 
            // btn_resume
            // 
            btn_resume.Location = new Point(17, 150);
            btn_resume.Name = "btn_resume";
            btn_resume.Size = new Size(73, 39);
            btn_resume.TabIndex = 15;
            btn_resume.Text = "RESUME";
            btn_resume.UseVisualStyleBackColor = true;
            btn_resume.Click += btn_resume_Click;
            // 
            // chk_loop
            // 
            chk_loop.AutoSize = true;
            chk_loop.ForeColor = Color.FromArgb(128, 255, 255);
            chk_loop.Location = new Point(10, 441);
            chk_loop.Name = "chk_loop";
            chk_loop.Size = new Size(67, 24);
            chk_loop.TabIndex = 14;
            chk_loop.Text = "LOOP";
            chk_loop.UseVisualStyleBackColor = true;
            chk_loop.CheckedChanged += chk_loop_CheckedChanged;
            // 
            // btn_prg_send
            // 
            btn_prg_send.Location = new Point(17, 26);
            btn_prg_send.Name = "btn_prg_send";
            btn_prg_send.Size = new Size(144, 72);
            btn_prg_send.TabIndex = 3;
            btn_prg_send.Text = "SEND";
            btn_prg_send.UseVisualStyleBackColor = true;
            btn_prg_send.Click += btn_prg_send_Click;
            // 
            // btn_Stop
            // 
            btn_Stop.Location = new Point(97, 104);
            btn_Stop.Name = "btn_Stop";
            btn_Stop.Size = new Size(64, 40);
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
            btn_run.Location = new Point(17, 104);
            btn_run.Name = "btn_run";
            btn_run.Size = new Size(73, 40);
            btn_run.TabIndex = 2;
            btn_run.Text = "RUN";
            btn_run.UseVisualStyleBackColor = true;
            btn_run.Click += btn_run_Click;
            // 
            // btn_pause
            // 
            btn_pause.Location = new Point(97, 150);
            btn_pause.Name = "btn_pause";
            btn_pause.Size = new Size(64, 39);
            btn_pause.TabIndex = 2;
            btn_pause.Text = "PAUSE";
            btn_pause.UseVisualStyleBackColor = true;
            btn_pause.Click += btn_pause_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, communicationToolStripMenuItem, ProtocolToolStripMenuItem, programToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
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
            fileToolStripMenuItem.Size = new Size(224, 26);
            fileToolStripMenuItem.Text = "New";
            fileToolStripMenuItem.Click += fileToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem1
            // 
            openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            openToolStripMenuItem1.Size = new Size(224, 26);
            openToolStripMenuItem1.Text = "Open";
            openToolStripMenuItem1.Click += openToolStripMenuItem1_Click;
            // 
            // recentFilesToolStripMenuItem
            // 
            recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
            recentFilesToolStripMenuItem.Size = new Size(224, 26);
            recentFilesToolStripMenuItem.Text = "Recent Files";
            recentFilesToolStripMenuItem.Click += recentFilesToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(224, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(224, 26);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(224, 26);
            exportToolStripMenuItem.Text = "Export";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // exutToolStripMenuItem
            // 
            exutToolStripMenuItem.Name = "exutToolStripMenuItem";
            exutToolStripMenuItem.Size = new Size(224, 26);
            exutToolStripMenuItem.Text = "Exit";
            exutToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // communicationToolStripMenuItem
            // 
            communicationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { commToolStripMenuItem, uSBToolStripMenuItem, aPIToolStripMenuItem, websocketToolStripMenuItem, tcpToolStripMenuItem, udpToolStripMenuItem, iPCToolStripMenuItem });
            communicationToolStripMenuItem.Name = "communicationToolStripMenuItem";
            communicationToolStripMenuItem.Size = new Size(128, 24);
            communicationToolStripMenuItem.Text = "Communication";
            communicationToolStripMenuItem.DropDownOpening += communicationToolStripMenuItem_DropDownOpening;
            communicationToolStripMenuItem.Click += communicationToolStripMenuItem_Click;
            communicationToolStripMenuItem.MouseDown += communicationToolStripMenuItem_MouseDown;
            // 
            // commToolStripMenuItem
            // 
            commToolStripMenuItem.Name = "commToolStripMenuItem";
            commToolStripMenuItem.Size = new Size(169, 26);
            commToolStripMenuItem.Text = "Comm. Port";
            commToolStripMenuItem.Click += ToolStripMenuItem_Seria_Click;
            // 
            // uSBToolStripMenuItem
            // 
            uSBToolStripMenuItem.Name = "uSBToolStripMenuItem";
            uSBToolStripMenuItem.Size = new Size(169, 26);
            uSBToolStripMenuItem.Text = "USB";
            // 
            // aPIToolStripMenuItem
            // 
            aPIToolStripMenuItem.Name = "aPIToolStripMenuItem";
            aPIToolStripMenuItem.Size = new Size(169, 26);
            aPIToolStripMenuItem.Text = "API";
            // 
            // websocketToolStripMenuItem
            // 
            websocketToolStripMenuItem.Name = "websocketToolStripMenuItem";
            websocketToolStripMenuItem.Size = new Size(169, 26);
            websocketToolStripMenuItem.Text = "Websocket";
            // 
            // tcpToolStripMenuItem
            // 
            tcpToolStripMenuItem.Name = "tcpToolStripMenuItem";
            tcpToolStripMenuItem.Size = new Size(169, 26);
            tcpToolStripMenuItem.Text = "TCP";
            tcpToolStripMenuItem.Click += ToolStripMenuItem_TCP_Click;
            // 
            // udpToolStripMenuItem
            // 
            udpToolStripMenuItem.Name = "udpToolStripMenuItem";
            udpToolStripMenuItem.Size = new Size(169, 26);
            udpToolStripMenuItem.Text = "UDP";
            udpToolStripMenuItem.Click += ToolStripMenuItem_UDP_Click;
            // 
            // iPCToolStripMenuItem
            // 
            iPCToolStripMenuItem.Name = "iPCToolStripMenuItem";
            iPCToolStripMenuItem.Size = new Size(169, 26);
            iPCToolStripMenuItem.Text = "IPC";
            // 
            // ProtocolToolStripMenuItem
            // 
            ProtocolToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kbusToolStripMenuItem, cANToolStripMenuItem, modBusToolStripMenuItem, customToolStripMenuItem });
            ProtocolToolStripMenuItem.Name = "ProtocolToolStripMenuItem";
            ProtocolToolStripMenuItem.Size = new Size(79, 24);
            ProtocolToolStripMenuItem.Text = "Protocol";
            // 
            // kbusToolStripMenuItem
            // 
            kbusToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rAWBinaryToolStripMenuItem, aSCIIToolStripMenuItem });
            kbusToolStripMenuItem.Name = "kbusToolStripMenuItem";
            kbusToolStripMenuItem.Size = new Size(146, 26);
            kbusToolStripMenuItem.Text = "Kbus";
            // 
            // rAWBinaryToolStripMenuItem
            // 
            rAWBinaryToolStripMenuItem.Name = "rAWBinaryToolStripMenuItem";
            rAWBinaryToolStripMenuItem.Size = new Size(175, 26);
            rAWBinaryToolStripMenuItem.Text = "RAW(Binary)";
            // 
            // aSCIIToolStripMenuItem
            // 
            aSCIIToolStripMenuItem.Name = "aSCIIToolStripMenuItem";
            aSCIIToolStripMenuItem.Size = new Size(175, 26);
            aSCIIToolStripMenuItem.Text = "ASCII";
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
            // customToolStripMenuItem
            // 
            customToolStripMenuItem.Name = "customToolStripMenuItem";
            customToolStripMenuItem.Size = new Size(146, 26);
            customToolStripMenuItem.Text = "Custom";
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
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, packetMonitorToolStripMenuItem, terminalToolStripMenuItem, debugInterfaceToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(58, 24);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(202, 26);
            settingsToolStripMenuItem.Text = "Inbuilt Simulator";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // packetMonitorToolStripMenuItem
            // 
            packetMonitorToolStripMenuItem.Name = "packetMonitorToolStripMenuItem";
            packetMonitorToolStripMenuItem.Size = new Size(202, 26);
            packetMonitorToolStripMenuItem.Text = "Packet Monitor";
            // 
            // terminalToolStripMenuItem
            // 
            terminalToolStripMenuItem.Name = "terminalToolStripMenuItem";
            terminalToolStripMenuItem.Size = new Size(202, 26);
            terminalToolStripMenuItem.Text = "Terminal";
            // 
            // debugInterfaceToolStripMenuItem
            // 
            debugInterfaceToolStripMenuItem.Name = "debugInterfaceToolStripMenuItem";
            debugInterfaceToolStripMenuItem.Size = new Size(202, 26);
            debugInterfaceToolStripMenuItem.Text = "Debug Interface";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem, fAQToolStripMenuItem, sendMailToDeveloperToolStripMenuItem, relatedDOcumentsToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(224, 26);
            aboutToolStripMenuItem.Text = "About";
            // 
            // fAQToolStripMenuItem
            // 
            fAQToolStripMenuItem.Name = "fAQToolStripMenuItem";
            fAQToolStripMenuItem.Size = new Size(224, 26);
            fAQToolStripMenuItem.Text = "FAQ";
            // 
            // sendMailToDeveloperToolStripMenuItem
            // 
            sendMailToDeveloperToolStripMenuItem.Name = "sendMailToDeveloperToolStripMenuItem";
            sendMailToDeveloperToolStripMenuItem.Size = new Size(224, 26);
            sendMailToDeveloperToolStripMenuItem.Text = "Send Email";
            // 
            // relatedDOcumentsToolStripMenuItem
            // 
            relatedDOcumentsToolStripMenuItem.Name = "relatedDOcumentsToolStripMenuItem";
            relatedDOcumentsToolStripMenuItem.Size = new Size(224, 26);
            relatedDOcumentsToolStripMenuItem.Text = "Related DOcuments";
            // 
            // dg_prg
            // 
            dg_prg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_prg.Columns.AddRange(new DataGridViewColumn[] { col_line_no, col_enable, col_pic_type, col_cast, col_Operation, col_Command, col_data, col_delay, col_loop });
            dg_prg.Location = new Point(0, 31);
            dg_prg.Name = "dg_prg";
            dg_prg.RowHeadersWidth = 51;
            dg_prg.Size = new Size(1297, 618);
            dg_prg.TabIndex = 0;
            dg_prg.CellMouseDown += dg_prg_CellMouseDown;
            dg_prg.CellValueChanged += dg_prg_CellValueChanged;
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
            col_pic_type.MinimumWidth = 6;
            col_pic_type.Name = "col_pic_type";
            col_pic_type.Width = 250;
            // 
            // col_cast
            // 
            col_cast.HeaderText = "Cast";
            col_cast.MinimumWidth = 6;
            col_cast.Name = "col_cast";
            col_cast.Width = 125;
            // 
            // col_Operation
            // 
            col_Operation.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            col_Operation.HeaderText = "Operation";
            col_Operation.Items.AddRange(new object[] { "Read", "Write", "Execute" });
            col_Operation.MinimumWidth = 6;
            col_Operation.Name = "col_Operation";
            col_Operation.Width = 125;
            // 
            // col_Command
            // 
            col_Command.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            col_Command.HeaderText = "Command";
            col_Command.Items.AddRange(new object[] { "Dispense", "PB6_LED", "PB5_LED", "Erase_Log", "Who_Are_You", "Read_Log_Count", "Read_Logs" });
            col_Command.MinimumWidth = 6;
            col_Command.Name = "col_Command";
            col_Command.Width = 250;
            // 
            // col_data
            // 
            col_data.HeaderText = "DATA";
            col_data.MinimumWidth = 6;
            col_data.Name = "col_data";
            col_data.Width = 200;
            // 
            // col_delay
            // 
            col_delay.HeaderText = "Delay";
            col_delay.MinimumWidth = 6;
            col_delay.Name = "col_delay";
            col_delay.Width = 75;
            // 
            // col_loop
            // 
            col_loop.HeaderText = "Loop";
            col_loop.MinimumWidth = 6;
            col_loop.Name = "col_loop";
            col_loop.Width = 75;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(0, 192, 192);
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, lbl_message, tssl_comport, tssl_baudrate });
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
            // tssl_comport
            // 
            tssl_comport.Name = "tssl_comport";
            tssl_comport.Size = new Size(50, 20);
            tssl_comport.Text = "COM1";
            // 
            // tssl_baudrate
            // 
            tssl_baudrate.Name = "tssl_baudrate";
            tssl_baudrate.Size = new Size(41, 20);
            tssl_baudrate.Text = "9600";
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
            ((System.ComponentModel.ISupportInitialize)pb_tx).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_rx).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_connection).EndInit();
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
        private GroupBox groupBox1;
        private RadioButton rbtn_real_hardware;
        private RadioButton rbtn_InbuiltSim;
        private ToolStripMenuItem openToolStripMenuItem1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem exutToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem commToolStripMenuItem;
        private ToolStripMenuItem tcpToolStripMenuItem;
        private ToolStripMenuItem udpToolStripMenuItem;
        private ToolStripMenuItem ProtocolToolStripMenuItem;
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
        private ToolStripStatusLabel tssl_comport;
        private ToolStripStatusLabel tssl_baudrate;
        private CheckBox chk_auto_connect;
        private Button btn_disconnect;
        private Button btn_connect;
        private ToolStripMenuItem kbusToolStripMenuItem;
        private ToolStripMenuItem uSBToolStripMenuItem;
        private ToolStripMenuItem aPIToolStripMenuItem;
        private ToolStripMenuItem websocketToolStripMenuItem;
        private ToolStripMenuItem iPCToolStripMenuItem;
        private ToolStripMenuItem customToolStripMenuItem;
        private ToolStripMenuItem terminalToolStripMenuItem;
        private ToolStripMenuItem debugInterfaceToolStripMenuItem;
        private ToolStripMenuItem fAQToolStripMenuItem;
        private ToolStripMenuItem sendMailToDeveloperToolStripMenuItem;
        private ToolStripMenuItem relatedDOcumentsToolStripMenuItem;
        private ToolStripMenuItem aSCIIToolStripMenuItem;
        private ToolStripMenuItem rAWBinaryToolStripMenuItem;
        private Label label1;
        private PictureBox pb_tx;
        private PictureBox pb_rx;
        private PictureBox pb_connection;
        private Label label3;
        private Label label2;
        private DataGridViewTextBoxColumn col_line_no;
        private DataGridViewCheckBoxColumn col_enable;
        private DataGridViewComboBoxColumn col_pic_type;
        private DataGridViewComboBoxColumn col_cast;
        private DataGridViewComboBoxColumn col_Operation;
        private DataGridViewComboBoxColumn col_Command;
        private DataGridViewTextBoxColumn col_data;
        private DataGridViewTextBoxColumn col_delay;
        private DataGridViewTextBoxColumn col_loop;
        private Button button1;
    }
}
