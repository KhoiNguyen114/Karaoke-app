namespace DoAnKaraoke
{
    partial class FormTaoTaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTaoTaiKhoan));
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtTenDN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThemNVQL = new System.Windows.Forms.Button();
            this.btnXoaNVQL = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgv_TaiKhoan = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_TaiKhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(174, 108);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(227, 29);
            this.txtMatKhau.TabIndex = 18;
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            // txtTenDN
            // 
            this.txtTenDN.Location = new System.Drawing.Point(174, 71);
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Size = new System.Drawing.Size(227, 29);
            this.txtTenDN.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "Mật khẩu:";
            // 
            // cboMaNV
            // 
            this.cboMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaNV.FormattingEnabled = true;
            this.cboMaNV.Location = new System.Drawing.Point(174, 33);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(227, 30);
            this.cboMaNV.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "Mã nhân viên:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtMatKhau);
            this.groupBox5.Controls.Add(this.txtTenDN);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.cboMaNV);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 317);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(407, 193);
            this.groupBox5.TabIndex = 49;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Thông tin tài khoản";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tên đăng nhập:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThemNVQL);
            this.groupBox2.Controls.Add(this.btnXoaNVQL);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(425, 317);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 193);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // btnThemNVQL
            // 
            this.btnThemNVQL.Image = ((System.Drawing.Image)(resources.GetObject("btnThemNVQL.Image")));
            this.btnThemNVQL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemNVQL.Location = new System.Drawing.Point(15, 41);
            this.btnThemNVQL.Name = "btnThemNVQL";
            this.btnThemNVQL.Size = new System.Drawing.Size(128, 45);
            this.btnThemNVQL.TabIndex = 10;
            this.btnThemNVQL.Text = "Tạo Mới";
            this.btnThemNVQL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemNVQL.UseVisualStyleBackColor = true;
            this.btnThemNVQL.Click += new System.EventHandler(this.btnThemNVQL_Click);
            // 
            // btnXoaNVQL
            // 
            this.btnXoaNVQL.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaNVQL.Image")));
            this.btnXoaNVQL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaNVQL.Location = new System.Drawing.Point(15, 106);
            this.btnXoaNVQL.Name = "btnXoaNVQL";
            this.btnXoaNVQL.Size = new System.Drawing.Size(87, 45);
            this.btnXoaNVQL.TabIndex = 9;
            this.btnXoaNVQL.Text = "Xóa";
            this.btnXoaNVQL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaNVQL.UseVisualStyleBackColor = true;
            this.btnXoaNVQL.Click += new System.EventHandler(this.btnXoaNVQL_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgv_TaiKhoan);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 214);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tài khoản";
            // 
            // dtgv_TaiKhoan
            // 
            this.dtgv_TaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_TaiKhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dtgv_TaiKhoan.Location = new System.Drawing.Point(6, 27);
            this.dtgv_TaiKhoan.Name = "dtgv_TaiKhoan";
            this.dtgv_TaiKhoan.ReadOnly = true;
            this.dtgv_TaiKhoan.RowTemplate.Height = 24;
            this.dtgv_TaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv_TaiKhoan.Size = new System.Drawing.Size(576, 176);
            this.dtgv_TaiKhoan.TabIndex = 0;
            this.dtgv_TaiKhoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_TaiKhoan_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MANV";
            this.Column1.HeaderText = "Mã nhân viên";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 267;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TENDN";
            this.Column2.HeaderText = "Tên đăng nhập";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 266;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(626, 48);
            this.label2.TabIndex = 50;
            this.label2.Text = "TẠO TÀI KHOẢN";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormTaoTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 533);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Name = "FormTaoTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo tài khoản";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTaoTaiKhoan_FormClosed);
            this.Load += new System.EventHandler(this.FormTaoTaiKhoan_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_TaiKhoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtTenDN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMaNV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnThemNVQL;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnXoaNVQL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgv_TaiKhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}