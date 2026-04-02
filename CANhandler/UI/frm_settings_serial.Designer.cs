namespace CANhandler.UI
{
    partial class frm_settings_serial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            brn_ok = new Button();
            btn_cancel = new Button();
            cbo_port_list = new ComboBox();
            cbo_baudrate = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 24);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 1;
            label1.Text = "PORT";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 65);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 1;
            label2.Text = "BAUD RATE";
            // 
            // brn_ok
            // 
            brn_ok.ForeColor = Color.Black;
            brn_ok.Location = new Point(115, 115);
            brn_ok.Name = "brn_ok";
            brn_ok.Size = new Size(94, 29);
            brn_ok.TabIndex = 2;
            brn_ok.Text = "OK";
            brn_ok.UseVisualStyleBackColor = true;
            brn_ok.Click += brn_ok_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.ForeColor = Color.Black;
            btn_cancel.Location = new Point(215, 115);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(94, 29);
            btn_cancel.TabIndex = 3;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // cbo_port_list
            // 
            cbo_port_list.FormattingEnabled = true;
            cbo_port_list.Location = new Point(115, 24);
            cbo_port_list.Name = "cbo_port_list";
            cbo_port_list.Size = new Size(366, 28);
            cbo_port_list.TabIndex = 4;
            // 
            // cbo_baudrate
            // 
            cbo_baudrate.FormattingEnabled = true;
            cbo_baudrate.Location = new Point(115, 65);
            cbo_baudrate.Name = "cbo_baudrate";
            cbo_baudrate.Size = new Size(194, 28);
            cbo_baudrate.TabIndex = 5;
            // 
            // frm_settings_serial
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 64, 64);
            ClientSize = new Size(515, 207);
            Controls.Add(cbo_baudrate);
            Controls.Add(cbo_port_list);
            Controls.Add(btn_cancel);
            Controls.Add(brn_ok);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frm_settings_serial";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Serial Parameter settings";
            TopMost = true;
            Load += frm_settings_serial_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button brn_ok;
        private Button btn_cancel;
        private ComboBox cbo_port_list;
        private ComboBox cbo_baudrate;
    }
}