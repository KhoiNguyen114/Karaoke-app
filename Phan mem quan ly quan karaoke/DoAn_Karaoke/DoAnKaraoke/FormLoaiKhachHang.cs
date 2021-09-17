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
    public partial class FormLoaiKhachHang : Form
    {
        BLLDALLoaiKhachHang daLoaiKH = new BLLDALLoaiKhachHang();
        public FormLoaiKhachHang()
        {
            InitializeComponent();
        }

        private void FormLoaiKhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.formMain.Show();
        }

        private void dtgv_LoaiKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_LoaiKH.CurrentRow != null)
            {
                txtMaLoaiKH.Text = dtgv_LoaiKH.CurrentRow.Cells[0].Value.ToString();
                txtTenLoaiKH.Text = dtgv_LoaiKH.CurrentRow.Cells[1].Value.ToString();
                txtGiamGia.Text = dtgv_LoaiKH.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void FormLoaiKhachHang_Load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        public void loadDataGridView()
        {
            dtgv_LoaiKH.DataSource = daLoaiKH.loadLoaiKhachHang();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.formMain.Show();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaLoaiKH.Text.Trim()) || String.IsNullOrEmpty(txtTenLoaiKH.Text.Trim()) || String.IsNullOrEmpty(txtGiamGia.Text.Trim()))
            {
                MessageBox.Show("Mã loại khách hàng, tên loại khách hàng, số tiền giảm giá không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenLoaiKH.Text.Trim().Length > 500)
            {
                MessageBox.Show("Tên loại khách hàng không được vượt quá 500 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daLoaiKH.ktKhoaChinh(txtMaLoaiKH.Text.Trim()))
            {
                MessageBox.Show("Mã loại khách hàng này không tồn tại nên không thể cập nhật! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double giamGia = double.Parse(txtGiamGia.Text.Trim());
            if (giamGia < 0)
            {
                MessageBox.Show("Giảm giá chỉ có thể từ 0 đến 1! Tương ứng từ 0% đến 100%", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGiamGia.Text = "";
                txtGiamGia.Focus();
            }
            else if (giamGia > 1)
            {
                MessageBox.Show("Giảm giá hiện tại là đang lớn hơn 100%! Xin vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (giamGia < 0.5)
                {
                    if (daLoaiKH.suaLoaiKH(txtMaLoaiKH.Text.Trim(), txtTenLoaiKH.Text.Trim(), giamGia))
                    {
                        loadDataGridView();
                        MessageBox.Show("Cập nhật loại khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật loại khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    DialogResult r;
                    r = MessageBox.Show("Giảm giá hiện tại là đang lớn hơn 50%, bạn có chắc chắn muốn cập nhật không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (daLoaiKH.suaLoaiKH(txtMaLoaiKH.Text.Trim(), txtTenLoaiKH.Text.Trim(), giamGia))
                        {
                            loadDataGridView();
                            MessageBox.Show("Cập nhật loại khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật loại khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaLoaiKH.Text.Trim()) || String.IsNullOrEmpty(txtTenLoaiKH.Text.Trim()) || String.IsNullOrEmpty(txtGiamGia.Text.Trim()))
            {
                MessageBox.Show("Mã loại khách hàng, tên loại khách hàng, số tiền giảm giá không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaLoaiKH.Text.Length > 10)
            {
                MessageBox.Show("Mã loại khách hàng không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenLoaiKH.Text.Trim().Length > 500)
            {
                MessageBox.Show("Tên loại khách hàng không được vượt quá 500 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!daLoaiKH.ktKhoaChinh(txtMaLoaiKH.Text.Trim()))
            {
                MessageBox.Show("Mã loại khách hàng này đã tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double giamGia = double.Parse(txtGiamGia.Text.Trim());
            if (giamGia < 0)
            {
                MessageBox.Show("Giảm giá chỉ có thể từ 0 đến 1! Tương ứng từ 0% đến 100%", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGiamGia.Text = "";
                txtGiamGia.Focus();
            }
            else if (giamGia > 1)
            {
                MessageBox.Show("Giảm giá hiện tại là đang lớn hơn 100%! Xin vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (giamGia < 0.5)
                {
                    if (daLoaiKH.themLoaiKH(txtMaLoaiKH.Text.Trim(), txtTenLoaiKH.Text.Trim(), giamGia))
                    {
                        loadDataGridView();
                        MessageBox.Show("Thêm loại khách hàng mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm loại khách hàng mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    DialogResult r;
                    r = MessageBox.Show("Giảm giá hiện tại là đang lớn hơn 50%, bạn có chắc chắn muốn thêm không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (daLoaiKH.themLoaiKH(txtMaLoaiKH.Text.Trim(), txtTenLoaiKH.Text.Trim(), giamGia))
                        {
                            loadDataGridView();
                            MessageBox.Show("Thêm loại khách hàng mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thêm loại khách hàng mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaLoaiKH.Text.Trim()))
            {
                MessageBox.Show("Mã loại khách hàng, tên loại khách hàng, số tiền giảm giá không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daLoaiKH.ktKhoaChinh(txtMaLoaiKH.Text.Trim()))
            {
                MessageBox.Show("Mã loại khách hàng này không tồn tại nên không thể xóa! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult r;
            r = MessageBox.Show("Khi xóa đi loại khách hàng này thì toàn bộ khách hàng thuộc loại khách hàng này cũng sẽ bị xóa. Bạn có muốn tiếp tục không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (daLoaiKH.xoaLoaiKH(txtMaLoaiKH.Text.Trim()))
                {
                    loadDataGridView();
                    MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

    }
}
