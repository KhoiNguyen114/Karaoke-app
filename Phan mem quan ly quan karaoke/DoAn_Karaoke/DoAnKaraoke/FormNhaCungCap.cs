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
    public partial class FormNhaCungCap : Form
    {
        BLLDALNhaCungCap daNCC = new BLLDALNhaCungCap();
        public FormNhaCungCap()
        {
            InitializeComponent();
        }

        private void FormNhaCungCap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.formMain.Show();
        }

        private void FormNhaCungCap_Load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        public void loadDataGridView()
        {
            dtgv_NhaCungCap.DataSource = daNCC.loadNhaCungCap();
        }

        private void dtgv_NhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_NhaCungCap.CurrentRow != null)
            {
                txtMaNCC.Text = dtgv_NhaCungCap.CurrentRow.Cells[0].Value.ToString();
                txtTenNCC.Text = dtgv_NhaCungCap.CurrentRow.Cells[1].Value.ToString();
                txtDienThoai.Text = dtgv_NhaCungCap.CurrentRow.Cells[2].Value.ToString();
                txtDiaChi.Text = dtgv_NhaCungCap.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaNCC.Text.Trim()) || String.IsNullOrEmpty(txtTenNCC.Text.Trim()) || String.IsNullOrEmpty(txtDiaChi.Text.Trim()) || String.IsNullOrEmpty(txtDienThoai.Text.Trim()))
            {
                MessageBox.Show("Mã nhà cung cấp, tên nhà cung cấp, địa chỉ, điện thoại không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaNCC.Text.Trim().Length > 10 || txtDienThoai.Text.Trim().Length > 10)
            {
                MessageBox.Show("Mã nhà cung cấp và số điện thoại không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenNCC.Text.Trim().Length > 100)
            {
                MessageBox.Show("Tên nhà cung cấp không được vượt quá 100 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiaChi.Text.Trim().Length > 500)
            {
                MessageBox.Show("Địa chỉ nhà cung cấp không được vượt quá 500 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!daNCC.ktKhoaChinh(txtMaNCC.Text.Trim()))
            {
                MessageBox.Show("Mã nhà cung cấp này đã tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daNCC.themNhaCungCap(txtMaNCC.Text.Trim(), txtTenNCC.Text.Trim(), txtDienThoai.Text.Trim(), txtDiaChi.Text.Trim()))
            {
                loadDataGridView();
                MessageBox.Show("Thêm nhà cung cấp mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm nhà cung cấp mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaNCC.Text.Trim()) || String.IsNullOrEmpty(txtTenNCC.Text.Trim()) || String.IsNullOrEmpty(txtDiaChi.Text.Trim()) || String.IsNullOrEmpty(txtDienThoai.Text.Trim()))
            {
                MessageBox.Show("Mã nhà cung cấp, tên nhà cung cấp, địa chỉ, điện thoại không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaNCC.Text.Trim().Length > 10)
            {
                MessageBox.Show("Mã nhà cung cấp không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daNCC.ktKhoaChinh(txtMaNCC.Text.Trim()))
            {
                MessageBox.Show("Mã nhà cung cấp này không tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult r;
            r = MessageBox.Show("Khi xóa đi nhà cung cấp này thì toàn bộ sản phẩm do nhà cung cấp này cung cấp cũng sẽ bị xóa! Bạn có muốn tiếp tục không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (daNCC.xoaNhaCungCap(txtMaNCC.Text.Trim()))
                {
                    loadDataGridView();
                    MessageBox.Show("Xóa nhà cung cấp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa nhà cung cấp thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaNCC.Text.Trim()) || String.IsNullOrEmpty(txtTenNCC.Text.Trim()) || String.IsNullOrEmpty(txtDiaChi.Text.Trim()) || String.IsNullOrEmpty(txtDienThoai.Text.Trim()))
            {
                MessageBox.Show("Mã nhà cung cấp, tên nhà cung cấp, địa chỉ, điện thoại không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaNCC.Text.Trim().Length > 10 || txtDienThoai.Text.Trim().Length > 10)
            {
                MessageBox.Show("Mã nhà cung cấp và số điện thoại không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenNCC.Text.Trim().Length > 100)
            {
                MessageBox.Show("Tên nhà cung cấp không được vượt quá 100 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiaChi.Text.Trim().Length > 500)
            {
                MessageBox.Show("Địa chỉ nhà cung cấp không được vượt quá 500 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daNCC.ktKhoaChinh(txtMaNCC.Text.Trim()))
            {
                MessageBox.Show("Mã nhà cung cấp này không tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (daNCC.suaNhaCungCap(txtMaNCC.Text.Trim(), txtTenNCC.Text.Trim(), txtDienThoai.Text.Trim(), txtDiaChi.Text.Trim()))
            {
                loadDataGridView();
                MessageBox.Show("Cập nhật nhà cung cấp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật nhà cung cấp thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.formMain.Show();
        }


    }
}
