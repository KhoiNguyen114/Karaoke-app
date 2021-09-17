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
    public partial class FormChucVu : Form
    {
        BLLDALChucVu daChucVu = new BLLDALChucVu();
        public FormChucVu()
        {
            InitializeComponent();
        }

        private void FormChucVu_Load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        public void loadDataGridView()
        {
            dtgv_ChucVu.DataSource = daChucVu.loadChucVu();
        }

        private void FormChucVu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.formMain.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaCV.Text.Trim()) || String.IsNullOrEmpty(txtTenCV.Text.Trim()) || String.IsNullOrEmpty(txtLuongCB.Text.Trim()))
            {
                MessageBox.Show("Mã chức vụ, tên chức vụ, lương cơ bản không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaCV.Text.Length > 10)
            {
                MessageBox.Show("Mã chức vụ không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenCV.Text.Trim().Length > 100)
            {
                MessageBox.Show("Tên chức vụ không được vượt quá 100 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!daChucVu.ktKhoaChinh(txtMaCV.Text.Trim()))
            {
                MessageBox.Show("Mã chức vụ này đã tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaCV.Focus();
                return;
            }
            double luongCB = double.Parse(txtLuongCB.Text.Trim());
            if (luongCB < 100000)
            {
                MessageBox.Show("Lương cơ bản phải lớn hơn 100.000 VNĐ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLuongCB.Text = "";
                txtLuongCB.Focus();
                return;
            }
            else
            {
                if (daChucVu.themChucVu(txtMaCV.Text.Trim(), txtTenCV.Text.Trim(), luongCB))
                {
                    loadDataGridView();
                    MessageBox.Show("Thêm chức vụ mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm chức vụ mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaCV.Text.Trim()))
            {
                MessageBox.Show("Mã loại khách hàng, tên loại khách hàng, số tiền giảm giá không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daChucVu.ktKhoaChinh(txtMaCV.Text.Trim()))
            {
                MessageBox.Show("Mã chức vụ này không tồn tại nên không thể xóa! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaCV.Focus();
                return;
            }
            if (!daChucVu.ktChucVuCoNhanVien(txtMaCV.Text.Trim()))
            {
                MessageBox.Show("Chức vụ này còn nhân viên đảm nhận nên không thể xóa! Nếu bạn muốn xóa, hãy cập nhật lại chức vụ cho nhân viên trước!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daChucVu.xoaChucVu(txtMaCV.Text.Trim()))
            {
                loadDataGridView();
                MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaCV.Text.Trim()) || String.IsNullOrEmpty(txtTenCV.Text.Trim()) || String.IsNullOrEmpty(txtLuongCB.Text.Trim()))
            {
                MessageBox.Show("Mã chức vụ, tên chức vụ, lương cơ bản không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daChucVu.ktKhoaChinh(txtMaCV.Text.Trim()))
            {
                MessageBox.Show("Mã chức vụ này không tồn tại nên không thể cập nhật! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaCV.Focus();
                return;
            }
            if (txtTenCV.Text.Trim().Length > 100)
            {
                MessageBox.Show("Tên chức vụ không được vượt quá 100 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double luongCB = double.Parse(txtLuongCB.Text.Trim());
            if (luongCB < 100000)
            {
                MessageBox.Show("Lương cơ bản phải lớn hơn 100.000 VNĐ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLuongCB.Text = "";
                txtLuongCB.Focus();
                return;
            }
            else
            {
                if (daChucVu.suaChucVu(txtMaCV.Text.Trim(), txtTenCV.Text.Trim(), luongCB))
                {
                    loadDataGridView();
                    MessageBox.Show("Cập nhật chức vụ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật chức vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void dtgv_ChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_ChucVu.CurrentRow != null)
            {
                txtMaCV.Text = dtgv_ChucVu.CurrentRow.Cells[0].Value.ToString();
                txtTenCV.Text = dtgv_ChucVu.CurrentRow.Cells[1].Value.ToString();
                txtLuongCB.Text = dtgv_ChucVu.CurrentRow.Cells[2].Value.ToString();
            }
        }
    }
}
