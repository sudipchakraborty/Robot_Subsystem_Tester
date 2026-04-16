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
            btn_save = new Button();
            btn_export = new Button();
            btn_clear = new Button();
            txt_msg = new RichTextBox();
            SuspendLayout();
            // 
            // btn_save
            // 
            btn_save.Location = new Point(421, 21);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(81, 74);
            btn_save.TabIndex = 1;
            btn_save.Text = "SAVE";
            btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_export
            // 
            btn_export.Location = new Point(421, 228);
            btn_export.Name = "btn_export";
            btn_export.Size = new Size(81, 196);
            btn_export.TabIndex = 1;
            btn_export.Text = "EXPORT";
            btn_export.UseVisualStyleBackColor = true;
            // 
            // btn_clear
            // 
            btn_clear.Location = new Point(421, 101);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(81, 121);
            btn_clear.TabIndex = 2;
            btn_clear.Text = "CLEAR";
            btn_clear.UseVisualStyleBackColor = true;
            btn_clear.Click += btn_clear_Click;
            // 
            // txt_msg
            // 
            txt_msg.Location = new Point(12, 21);
            txt_msg.Name = "txt_msg";
            txt_msg.Size = new Size(391, 403);
            txt_msg.TabIndex = 3;
            txt_msg.Text = "";
            // 
            // frm_Inbuilt_Simulator
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(519, 446);
            Controls.Add(txt_msg);
            Controls.Add(btn_clear);
            Controls.Add(btn_export);
            Controls.Add(btn_save);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frm_Inbuilt_Simulator";
            Text = "frm_Inbuilt_Simulator";
            TopMost = true;
            Load += frm_Inbuilt_Simulator_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button btn_save;
        private Button btn_export;
        private Button btn_clear;
        private RichTextBox txt_msg;
    }
}