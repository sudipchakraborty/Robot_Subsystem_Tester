namespace CANhandler.UI
{
    partial class frm_Inbuilt_Simulator
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
            txt_msg = new TextBox();
            btn_save = new Button();
            btn_export = new Button();
            SuspendLayout();
            // 
            // txt_msg
            // 
            txt_msg.BackColor = Color.FromArgb(0, 64, 64);
            txt_msg.ForeColor = Color.White;
            txt_msg.Location = new Point(12, 12);
            txt_msg.Multiline = true;
            txt_msg.Name = "txt_msg";
            txt_msg.Size = new Size(780, 412);
            txt_msg.TabIndex = 0;
            // 
            // btn_save
            // 
            btn_save.Location = new Point(821, 260);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(81, 104);
            btn_save.TabIndex = 1;
            btn_save.Text = "SAVE";
            btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_export
            // 
            btn_export.Location = new Point(821, 370);
            btn_export.Name = "btn_export";
            btn_export.Size = new Size(81, 54);
            btn_export.TabIndex = 1;
            btn_export.Text = "EXPORT";
            btn_export.UseVisualStyleBackColor = true;
            // 
            // frm_Inbuilt_Simulator
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(924, 446);
            Controls.Add(btn_export);
            Controls.Add(btn_save);
            Controls.Add(txt_msg);
            Name = "frm_Inbuilt_Simulator";
            Text = "frm_Inbuilt_Simulator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_msg;
        private Button btn_save;
        private Button btn_export;
    }
}