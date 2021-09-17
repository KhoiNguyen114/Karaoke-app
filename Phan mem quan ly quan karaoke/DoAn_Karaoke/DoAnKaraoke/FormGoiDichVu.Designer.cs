namespace DoAnKaraoke
{
    partial class FormGoiDichVu
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
            this.controlDatPhong1 = new ControlDichVu.ControlDatPhong();
            this.SuspendLayout();
            // 
            // controlDatPhong1
            // 
            this.controlDatPhong1.BackColor = System.Drawing.Color.Salmon;
            this.controlDatPhong1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlDatPhong1.Location = new System.Drawing.Point(0, 0);
            this.controlDatPhong1.Name = "controlDatPhong1";
            this.controlDatPhong1.Size = new System.Drawing.Size(712, 518);
            this.controlDatPhong1.TabIndex = 0;
            // 
            // FormGoiDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 518);
            this.Controls.Add(this.controlDatPhong1);
            this.Name = "FormGoiDichVu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGoiDichVu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGoiDichVu_FormClosing);
            this.Load += new System.EventHandler(this.FormGoiDichVu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlDichVu.ControlDatPhong controlDatPhong1;

    }
}