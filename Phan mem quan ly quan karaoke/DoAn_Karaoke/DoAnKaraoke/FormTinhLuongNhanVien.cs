using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;

namespace DoAnKaraoke
{
    public partial class FormTinhLuongNhanVien : Form
    {
        BLLDALChucVu daCV = new BLLDALChucVu();
        BLLDALNhanVien daNV = new BLLDALNhanVien();
        BLLDALThongKe daTK = new BLLDALThongKe();
        BLLDALDiemDanh daDD = new BLLDALDiemDanh();

        public FormTinhLuongNhanVien()
        {
            InitializeComponent();
        }

        private void FormTinhLuongNhanVien_Load(object sender, EventArgs e)
        {
            cboThang.DataSource = daTK.loadDuLieu(1, 12);
            cboNam.DataSource = daTK.loadDuLieu(2000, 2030);
            cboThang.Enabled = false;
            cboNhanVien.Enabled = false;
            
            cboNhanVien.DataSource = daNV.loadNhanVien();
            cboNhanVien.ValueMember = "MANV";
            cboNhanVien.DisplayMember = "TENNV";
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int thang = int.Parse(cboThang.SelectedValue.ToString());
            int nam = int.Parse(cboNam.SelectedValue.ToString());
            int? soNgayLam = daDD.tinhSoNgayLamViec(cboNhanVien.SelectedValue.ToString(),thang,nam);
            txtSoNgayLam.Text = soNgayLam + "";
            string chucVu = daCV.traVeTenChucVuTinhLuong(cboNhanVien.SelectedValue.ToString());
            txtTenCV.Text = chucVu;
            txtLuongCB.Text = daCV.traVeLuongCB(cboNhanVien.SelectedValue.ToString()) + "";

        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboThang.Enabled = true;
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboNhanVien.Enabled = true;
        }

        private void FormTinhLuongNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.formMain.Show();
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            int soNgay = int.Parse(txtSoNgayLam.Text.Trim());
            double luongCB = double.Parse(txtLuongCB.Text.Trim());
            txtLuongThucNhan.Text = soNgay * luongCB + "";

            cboThang.Enabled = false;
            cboNhanVien.Enabled = false;
        }
    }
}
