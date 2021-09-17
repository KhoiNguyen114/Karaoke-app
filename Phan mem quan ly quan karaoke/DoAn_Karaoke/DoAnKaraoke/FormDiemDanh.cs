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
    public partial class FormDiemDanh : Form
    {
        BLLDALNhanVien daNV = new BLLDALNhanVien();
        BLLDALDiemDanh daDD = new BLLDALDiemDanh();

        public FormDiemDanh()
        {
            InitializeComponent();
        }

        private void FormDiemDanh_Load(object sender, EventArgs e)
        {
            txtTenNV.Text = daNV.traVeNhanVienDiemDanh(Program.tenDangNhap);
        }

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            DateTime ngayDD = DateTime.Now;
            string maNV = daNV.traVeMaNhanVien(Program.tenDangNhap);
            if (!daDD.ktKhoaChinh(maNV, ngayDD))
            {
                MessageBox.Show("Bạn đã điểm danh hôm nay rồi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daDD.themDiemDanh(maNV, ngayDD))
            {
                MessageBox.Show("Điểm danh thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("Điểm danh thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void FormDiemDanh_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.formMain.Show();
        }
    }
}
