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
    public partial class FormLoaiDichVu : Form
    {
        BLLDALLoaiDichVu daDV = new BLLDALLoaiDichVu();
        public FormLoaiDichVu()
        {
            InitializeComponent();
        }

        private void FormLoaiPhong_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.formMain.Show();
        }
        private void FormLoaiDichVu_Load(object sender, EventArgs e)
        {
            loadDataGridView();
            
        }
        public void loadDataGridView()
        {
            dtgv_LoaiDichVu.DataSource = daDV.loadLoaiDichVu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaLoai.Text.Trim()) || String.IsNullOrEmpty(txtTenLoai.Text.Trim()))
            {
                MessageBox.Show("Mã loại, tên loại dịch vụ không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaLoai.Text.Trim().Length > 10)
            {
                MessageBox.Show("Mã loại không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenLoai.Text.Trim().Length > 500)
            {
                MessageBox.Show("Tên loại không được vượt quá 500 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!daDV.ktKhoaChinh(txtMaLoai.Text.Trim()))
            {
                MessageBox.Show("Mã loại này đã tồn tại nên không thể thêm! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daDV.themLoaiDichVu(txtMaLoai.Text.Trim(), txtTenLoai.Text.Trim()))
            {
                loadDataGridView();
                MessageBox.Show("Thêm loại dịch vụ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm loại dịch vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaLoai.Text.Trim()))
            {
                MessageBox.Show("Mã loại không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daDV.ktKhoaChinh(txtMaLoai.Text.Trim()))
            {
                MessageBox.Show("Mã loại dịch vụ này không tồn tại nên không thể xóa! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult r;
            r = MessageBox.Show("Khi xóa đi loại dịch vụ này thì những sản phẩm thuộc loại dịch vụ này cũng bị xóa. Bạn có muốn tiếp tục không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (daDV.xoaLoaiDichVu(txtMaLoai.Text.Trim()))
                {
                    loadDataGridView();
                    MessageBox.Show("Xóa Loại dịch vụ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa loại dịch vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaLoai.Text.Trim()) || String.IsNullOrEmpty(txtTenLoai.Text.Trim()))
            {
                MessageBox.Show("Mã loại, tên loại dịch vụ không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenLoai.Text.Trim().Length > 500)
            {
                MessageBox.Show("Tên loại không được vượt quá 500 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daDV.ktKhoaChinh(txtMaLoai.Text.Trim()))
            {
                MessageBox.Show("Mã loại dịch vụ này không tồn tại nên không thể cập nhật! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daDV.suaLoaiDichVu(txtMaLoai.Text.Trim(), txtTenLoai.Text.Trim()))
            {
                loadDataGridView();
                MessageBox.Show("Cập nhật loại dịch vụ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật loại dịch vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.formMain.Show();
        }

        private void dtgv_LoaiDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_LoaiDichVu.CurrentRow != null)
            {
                txtMaLoai.Text = dtgv_LoaiDichVu.CurrentRow.Cells[0].Value.ToString();
                txtTenLoai.Text = dtgv_LoaiDichVu.CurrentRow.Cells[1].Value.ToString();
            }
        }

        
    }
}
