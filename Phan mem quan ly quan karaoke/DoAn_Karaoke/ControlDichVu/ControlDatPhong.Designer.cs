namespace ControlDichVu
{
    partial class ControlDatPhong
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlDatPhong));
            this.lblPhong = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaDat = new System.Windows.Forms.TextBox();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDat = new System.Windows.Forms.Button();
            this.btnThemDichVu = new System.Windows.Forms.Button();
            this.btnCapNhatDichVu = new System.Windows.Forms.Button();
            this.btnHuyDat = new System.Windows.Forms.Button();
            this.btnXoaDichVu = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgv_DichVu = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoLuongHienCo = new txtChiNhapSo.txtChiNhapSo();
            this.txtThanhTien = new txtChiNhapSoThuc.txtChiNhapSoThuc();
            this.txtDonGiaBan = new txtChiNhapSoThuc.txtChiNhapSoThuc();
            this.txtSoLuong = new txtChiNhapSo.txtChiNhapSo();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_DichVu)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPhong
            // 
            this.lblPhong.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPhong.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhong.ForeColor = System.Drawing.Color.White;
            this.lblPhong.Location = new System.Drawing.Point(0, 0);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(708, 41);
            this.lblPhong.TabIndex = 0;
            this.lblPhong.Text = "PHÒNG";
            this.lblPhong.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã đặt:";
            // 
            // txtMaDat
            // 
            this.txtMaDat.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDat.Location = new System.Drawing.Point(97, 269);
            this.txtMaDat.Name = "txtMaDat";
            this.txtMaDat.Size = new System.Drawing.Size(193, 28);
            this.txtMaDat.TabIndex = 3;
            this.txtMaDat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhong.Location = new System.Drawing.Point(97, 303);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.Size = new System.Drawing.Size(193, 28);
            this.txtMaPhong.TabIndex = 5;
            this.txtMaPhong.TextChanged += new System.EventHandler(this.txtMaPhong_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Phòng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(314, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sản phẩm:";
            // 
            // cboSanPham
            // 
            this.cboSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSanPham.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSanPham.FormattingEnabled = true;
            this.cboSanPham.Location = new System.Drawing.Point(476, 269);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(223, 29);
            this.cboSanPham.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(314, 342);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Đơn giá bán:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Số lượng:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(314, 378);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 21);
            this.label7.TabIndex = 12;
            this.label7.Text = "Thành tiền:";
            // 
            // btnDat
            // 
            this.btnDat.BackColor = System.Drawing.SystemColors.Control;
            this.btnDat.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDat.Image = ((System.Drawing.Image)(resources.GetObject("btnDat.Image")));
            this.btnDat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDat.Location = new System.Drawing.Point(9, 425);
            this.btnDat.Name = "btnDat";
            this.btnDat.Size = new System.Drawing.Size(146, 40);
            this.btnDat.TabIndex = 14;
            this.btnDat.Text = "Đặt phòng";
            this.btnDat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDat.UseVisualStyleBackColor = false;
            // 
            // btnThemDichVu
            // 
            this.btnThemDichVu.BackColor = System.Drawing.SystemColors.Control;
            this.btnThemDichVu.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemDichVu.Image = ((System.Drawing.Image)(resources.GetObject("btnThemDichVu.Image")));
            this.btnThemDichVu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemDichVu.Location = new System.Drawing.Point(174, 425);
            this.btnThemDichVu.Name = "btnThemDichVu";
            this.btnThemDichVu.Size = new System.Drawing.Size(164, 40);
            this.btnThemDichVu.TabIndex = 15;
            this.btnThemDichVu.Text = "Thêm dịch vụ";
            this.btnThemDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemDichVu.UseVisualStyleBackColor = false;
            // 
            // btnCapNhatDichVu
            // 
            this.btnCapNhatDichVu.BackColor = System.Drawing.SystemColors.Control;
            this.btnCapNhatDichVu.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatDichVu.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhatDichVu.Image")));
            this.btnCapNhatDichVu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapNhatDichVu.Location = new System.Drawing.Point(352, 425);
            this.btnCapNhatDichVu.Name = "btnCapNhatDichVu";
            this.btnCapNhatDichVu.Size = new System.Drawing.Size(187, 40);
            this.btnCapNhatDichVu.TabIndex = 16;
            this.btnCapNhatDichVu.Text = "Cập nhật dịch vụ";
            this.btnCapNhatDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapNhatDichVu.UseVisualStyleBackColor = false;
            // 
            // btnHuyDat
            // 
            this.btnHuyDat.BackColor = System.Drawing.SystemColors.Control;
            this.btnHuyDat.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyDat.Image = ((System.Drawing.Image)(resources.GetObject("btnHuyDat.Image")));
            this.btnHuyDat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuyDat.Location = new System.Drawing.Point(9, 475);
            this.btnHuyDat.Name = "btnHuyDat";
            this.btnHuyDat.Size = new System.Drawing.Size(146, 40);
            this.btnHuyDat.TabIndex = 17;
            this.btnHuyDat.Text = "Hủy đặt";
            this.btnHuyDat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuyDat.UseVisualStyleBackColor = false;
            // 
            // btnXoaDichVu
            // 
            this.btnXoaDichVu.BackColor = System.Drawing.SystemColors.Control;
            this.btnXoaDichVu.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDichVu.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaDichVu.Image")));
            this.btnXoaDichVu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaDichVu.Location = new System.Drawing.Point(549, 425);
            this.btnXoaDichVu.Name = "btnXoaDichVu";
            this.btnXoaDichVu.Size = new System.Drawing.Size(150, 40);
            this.btnXoaDichVu.TabIndex = 18;
            this.btnXoaDichVu.Text = "Xóa dịch vụ";
            this.btnXoaDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaDichVu.UseVisualStyleBackColor = false;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.SystemColors.Control;
            this.btnThanhToan.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.Image = ((System.Drawing.Image)(resources.GetObject("btnThanhToan.Image")));
            this.btnThanhToan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThanhToan.Location = new System.Drawing.Point(549, 475);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(150, 40);
            this.btnThanhToan.TabIndex = 19;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThanhToan.UseVisualStyleBackColor = false;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "ThanhTien";
            this.Column6.HeaderText = "Thành tiền";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 130;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "DonGiaBan";
            this.Column5.HeaderText = "Đơn giá bán";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 130;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "SoLuong";
            this.Column4.HeaderText = "Số lượng";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 130;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "MaSP";
            this.Column3.HeaderText = "Mã sản phẩm";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 130;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "MaPhong";
            this.Column2.HeaderText = "Mã phòng";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 130;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaDat";
            this.Column1.HeaderText = "Mã đặt";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 130;
            // 
            // dtgv_DichVu
            // 
            this.dtgv_DichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_DichVu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dtgv_DichVu.Location = new System.Drawing.Point(6, 21);
            this.dtgv_DichVu.Name = "dtgv_DichVu";
            this.dtgv_DichVu.ReadOnly = true;
            this.dtgv_DichVu.RowTemplate.Height = 24;
            this.dtgv_DichVu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv_DichVu.Size = new System.Drawing.Size(683, 175);
            this.dtgv_DichVu.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgv_DichVu);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(695, 209);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách chi tiết dịch vụ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(314, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 22;
            this.label1.Text = "Số lượng hiện có:";
            // 
            // txtSoLuongHienCo
            // 
            this.txtSoLuongHienCo.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuongHienCo.Location = new System.Drawing.Point(476, 303);
            this.txtSoLuongHienCo.Name = "txtSoLuongHienCo";
            this.txtSoLuongHienCo.Size = new System.Drawing.Size(223, 28);
            this.txtSoLuongHienCo.TabIndex = 21;
            this.txtSoLuongHienCo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThanhTien.Location = new System.Drawing.Point(476, 375);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(223, 28);
            this.txtThanhTien.TabIndex = 13;
            this.txtThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDonGiaBan
            // 
            this.txtDonGiaBan.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonGiaBan.Location = new System.Drawing.Point(476, 339);
            this.txtDonGiaBan.Name = "txtDonGiaBan";
            this.txtDonGiaBan.Size = new System.Drawing.Size(223, 28);
            this.txtDonGiaBan.TabIndex = 10;
            this.txtDonGiaBan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(97, 339);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(193, 28);
            this.txtSoLuong.TabIndex = 8;
            this.txtSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ControlDatPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSoLuongHienCo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnXoaDichVu);
            this.Controls.Add(this.btnHuyDat);
            this.Controls.Add(this.btnCapNhatDichVu);
            this.Controls.Add(this.btnThemDichVu);
            this.Controls.Add(this.btnDat);
            this.Controls.Add(this.txtThanhTien);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDonGiaBan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.cboSanPham);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMaPhong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaDat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPhong);
            this.Name = "ControlDatPhong";
            this.Size = new System.Drawing.Size(708, 520);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_DichVu)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtMaDat;
        public System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cboSanPham;
        public txtChiNhapSo.txtChiNhapSo txtSoLuong;
        private System.Windows.Forms.Label label5;
        public txtChiNhapSoThuc.txtChiNhapSoThuc txtDonGiaBan;
        private System.Windows.Forms.Label label6;
        public txtChiNhapSoThuc.txtChiNhapSoThuc txtThanhTien;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Button btnDat;
        public System.Windows.Forms.Button btnThemDichVu;
        public System.Windows.Forms.Button btnCapNhatDichVu;
        public System.Windows.Forms.Button btnHuyDat;
        public System.Windows.Forms.Button btnXoaDichVu;
        public System.Windows.Forms.Button btnThanhToan;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        public System.Windows.Forms.DataGridView dtgv_DichVu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        public txtChiNhapSo.txtChiNhapSo txtSoLuongHienCo;
    }
}
