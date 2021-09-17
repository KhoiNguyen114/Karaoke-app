namespace DoAnKaraoke
{
    partial class FormTinhLuongNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTinhLuongNhanVien));
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoNgayLam = new txtChiNhapSo.txtChiNhapSo();
            this.txtLuongCB = new txtChiNhapSoThuc.txtChiNhapSoThuc();
            this.txtTenCV = new System.Windows.Forms.TextBox();
            this.lblLuongCB = new System.Windows.Forms.Label();
            this.lblTenCV = new System.Windows.Forms.Label();
            this.btnTinhLuong = new System.Windows.Forms.Button();
            this.txtLuongThucNhan = new txtChiNhapSoThuc.txtChiNhapSoThuc();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(222, 111);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(256, 30);
            this.cboNhanVien.TabIndex = 5;
            this.cboNhanVien.SelectedIndexChanged += new System.EventHandler(this.cboNhanVien_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nhân Viên:";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Số Ngày Làm:";
            // 
            // txtSoNgayLam
            // 
            this.txtSoNgayLam.Enabled = false;
            this.txtSoNgayLam.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoNgayLam.Location = new System.Drawing.Point(222, 150);
            this.txtSoNgayLam.Name = "txtSoNgayLam";
            this.txtSoNgayLam.Size = new System.Drawing.Size(256, 29);
            this.txtSoNgayLam.TabIndex = 7;
            this.txtSoNgayLam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLuongCB
            // 
            this.txtLuongCB.Enabled = false;
            this.txtLuongCB.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuongCB.Location = new System.Drawing.Point(222, 233);
            this.txtLuongCB.Name = "txtLuongCB";
            this.txtLuongCB.Size = new System.Drawing.Size(256, 29);
            this.txtLuongCB.TabIndex = 12;
            this.txtLuongCB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTenCV
            // 
            this.txtTenCV.Enabled = false;
            this.txtTenCV.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenCV.Location = new System.Drawing.Point(222, 191);
            this.txtTenCV.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenCV.Name = "txtTenCV";
            this.txtTenCV.Size = new System.Drawing.Size(256, 29);
            this.txtTenCV.TabIndex = 10;
            // 
            // lblLuongCB
            // 
            this.lblLuongCB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLuongCB.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuongCB.Location = new System.Drawing.Point(28, 234);
            this.lblLuongCB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLuongCB.Name = "lblLuongCB";
            this.lblLuongCB.Size = new System.Drawing.Size(136, 26);
            this.lblLuongCB.TabIndex = 11;
            this.lblLuongCB.Text = "Lương Cơ Bản :";
            this.lblLuongCB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenCV
            // 
            this.lblTenCV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTenCV.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenCV.Location = new System.Drawing.Point(29, 192);
            this.lblTenCV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenCV.Name = "lblTenCV";
            this.lblTenCV.Size = new System.Drawing.Size(135, 26);
            this.lblTenCV.TabIndex = 9;
            this.lblTenCV.Text = "Chức Vụ :";
            this.lblTenCV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTinhLuong
            // 
            this.btnTinhLuong.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhLuong.Image = ((System.Drawing.Image)(resources.GetObject("btnTinhLuong.Image")));
            this.btnTinhLuong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTinhLuong.Location = new System.Drawing.Point(209, 329);
            this.btnTinhLuong.Name = "btnTinhLuong";
            this.btnTinhLuong.Size = new System.Drawing.Size(161, 42);
            this.btnTinhLuong.TabIndex = 13;
            this.btnTinhLuong.Text = "Tính Lương";
            this.btnTinhLuong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTinhLuong.UseVisualStyleBackColor = true;
            this.btnTinhLuong.Click += new System.EventHandler(this.btnTinhLuong_Click);
            // 
            // txtLuongThucNhan
            // 
            this.txtLuongThucNhan.Enabled = false;
            this.txtLuongThucNhan.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuongThucNhan.Location = new System.Drawing.Point(222, 274);
            this.txtLuongThucNhan.Name = "txtLuongThucNhan";
            this.txtLuongThucNhan.Size = new System.Drawing.Size(256, 29);
            this.txtLuongThucNhan.TabIndex = 15;
            this.txtLuongThucNhan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 275);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 26);
            this.label3.TabIndex = 14;
            this.label3.Text = "Lương Thực Nhận:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboNam
            // 
            this.cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNam.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(222, 33);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(256, 30);
            this.cboNam.TabIndex = 16;
            this.cboNam.SelectedIndexChanged += new System.EventHandler(this.cboNam_SelectedIndexChanged);
            // 
            // cboThang
            // 
            this.cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThang.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Location = new System.Drawing.Point(222, 72);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(256, 30);
            this.cboThang.TabIndex = 17;
            this.cboThang.SelectedIndexChanged += new System.EventHandler(this.cboThang_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 26);
            this.label4.TabIndex = 18;
            this.label4.Text = "Năm:";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 26);
            this.label5.TabIndex = 19;
            this.label5.Text = "Tháng:";
            // 
            // FormTinhLuongNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 397);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboThang);
            this.Controls.Add(this.cboNam);
            this.Controls.Add(this.txtLuongThucNhan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTinhLuong);
            this.Controls.Add(this.txtLuongCB);
            this.Controls.Add(this.txtTenCV);
            this.Controls.Add(this.lblLuongCB);
            this.Controls.Add(this.lblTenCV);
            this.Controls.Add(this.txtSoNgayLam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboNhanVien);
            this.Controls.Add(this.label2);
            this.Name = "FormTinhLuongNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tính lương nhân viên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTinhLuongNhanVien_FormClosing);
            this.Load += new System.EventHandler(this.FormTinhLuongNhanVien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private txtChiNhapSo.txtChiNhapSo txtSoNgayLam;
        private txtChiNhapSoThuc.txtChiNhapSoThuc txtLuongCB;
        private System.Windows.Forms.TextBox txtTenCV;
        private System.Windows.Forms.Label lblLuongCB;
        private System.Windows.Forms.Label lblTenCV;
        private System.Windows.Forms.Button btnTinhLuong;
        private txtChiNhapSoThuc.txtChiNhapSoThuc txtLuongThucNhan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}