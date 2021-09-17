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
    public partial class FormPhong : Form
    {
        BLLDALPhong daPhong = new BLLDALPhong();
        public FormPhong()
        {
            InitializeComponent();
        }

        private void FormLoaiPhong_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.formMain.Show();
        }

        private void FormPhong_Load(object sender, EventArgs e)
        {
            loadDataGridView();

            cboTinhTrang.DataSource = daPhong.loadCombobox();
        }

        public void loadDataGridView()
        {
            dtgv_Phong.DataSource = daPhong.loadPhong();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.formMain.Show();
        }

        private void dtgv_Phong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_Phong.CurrentRow != null)
            {
                txtMaPhong.Text = dtgv_Phong.CurrentRow.Cells[0].Value.ToString();
                txtTenPhong.Text = dtgv_Phong.CurrentRow.Cells[1].Value.ToString();
                txtGiaPhong.Text = dtgv_Phong.CurrentRow.Cells[2].Value.ToString();
                cboTinhTrang.Text = daPhong.traVeTinhTrang(dtgv_Phong.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaPhong.Text.Trim()) || String.IsNullOrEmpty(txtTenPhong.Text.Trim()) || String.IsNullOrEmpty(txtGiaPhong.Text.Trim()))
            {
                MessageBox.Show("Mã phòng, tên phòng, giá phòng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaPhong.Text.Trim().Length > 10)
            {
                MessageBox.Show("Mã phòng không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenPhong.Text.Trim().Length > 100)
            {
                MessageBox.Show("Tên phòng không được vượt quá 100 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double gia = double.Parse(txtGiaPhong.Text.Trim());
            if (!daPhong.ktKhoaChinh(txtMaPhong.Text.Trim()))
            {
                MessageBox.Show("Mã phòng này đã tồn tại nên không thể thêm! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daPhong.themPhong(txtMaPhong.Text.Trim(), txtTenPhong.Text.Trim(), gia, cboTinhTrang.SelectedValue.ToString()))
            {
                loadDataGridView();
                MessageBox.Show("Thêm phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaPhong.Text.Trim()))
            {
                MessageBox.Show("Mã phòng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daPhong.ktKhoaChinh(txtMaPhong.Text.Trim()))
            {
                MessageBox.Show("Mã phòng này không tồn tại nên không thể cập nhật! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daPhong.xoaPhong(txtMaPhong.Text.Trim()))
            {
                loadDataGridView();
                MessageBox.Show("Xóa phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }   
                
            
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaPhong.Text.Trim()) || String.IsNullOrEmpty(txtTenPhong.Text.Trim()) || String.IsNullOrEmpty(txtGiaPhong.Text.Trim()))
            {
                MessageBox.Show("Mã phòng, tên phòng, giá phòng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaPhong.Text.Trim().Length > 10)
            {
                MessageBox.Show("Mã phòng không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenPhong.Text.Trim().Length > 100)
            {
                MessageBox.Show("Tên phòng không được vượt quá 100 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double gia = double.Parse(txtGiaPhong.Text.Trim());
            if (daPhong.ktKhoaChinh(txtMaPhong.Text.Trim()))
            {
                MessageBox.Show("Mã phòng này không tồn tại nên không thể cập nhật! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (daPhong.suaPhong(txtMaPhong.Text.Trim(), txtTenPhong.Text.Trim(), gia, cboTinhTrang.SelectedValue.ToString()))
            {
                loadDataGridView();
                MessageBox.Show("Cập nhật phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    
        }        
    }
}
