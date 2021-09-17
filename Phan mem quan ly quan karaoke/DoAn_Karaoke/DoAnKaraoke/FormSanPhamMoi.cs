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
    public partial class FormSanPhamMoi : Form
    {
        BLLDALNhaCungCap daNCC = new BLLDALNhaCungCap();
        BLLDALLoaiDichVu daLoaiDV = new BLLDALLoaiDichVu();
        BLLDALSanPham daSP = new BLLDALSanPham();

        public FormSanPhamMoi()
        {
            InitializeComponent();
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaSP.Text.Trim()) || String.IsNullOrEmpty(txtTenSP.Text.Trim()) || String.IsNullOrEmpty(txtSoLuong.Text.Trim()) || String.IsNullOrEmpty(txtDonGiaNhap.Text.Trim()) || String.IsNullOrEmpty(txtDonGiaBan.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm, tên sản phẩm , đơn giá nhập, đơn giá bán, số lượng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaSP.Text.Trim().Length > 10)
            {
                MessageBox.Show("Mã sản phẩm không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!daSP.ktKhoaChinh(txtMaSP.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm này đã tồn tại nên không thể thêm! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double gia = double.Parse(txtDonGiaNhap.Text.Trim());
            double gia1 = double.Parse(txtDonGiaBan.Text.Trim());
            int soluong = int.Parse(txtSoLuong.Text.Trim());
            if (soluong < 0 || gia < 0 || gia1 < 0)
            {
                MessageBox.Show("Số lượng sản phẩm, đơn giá nhập, đơn giá bán chỉ có thể lớn hơn hoặc bằng 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (gia1 <= gia)
            {
                DialogResult r;
                r = MessageBox.Show("Đơn giá bán đang nhỏ hơn hoặc bằng đơn giá nhập! Bạn có chắc chắn muốn tiếp tục?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    if (daSP.themSP(txtMaSP.Text.Trim(), txtTenSP.Text.Trim(), soluong, gia, gia1, cboLoaiDichVu.SelectedValue.ToString(), cboNhaCungCap.SelectedValue.ToString()))
                    {
                        MessageBox.Show("Thêm sản phẩm mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm sản phẩm mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                if (daSP.themSP(txtMaSP.Text.Trim(), txtTenSP.Text.Trim(), soluong, gia, gia1, cboLoaiDichVu.SelectedValue.ToString(), cboNhaCungCap.SelectedValue.ToString()))
                {
                    MessageBox.Show("Thêm sản phẩm mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSP.ResetText();
            txtTenSP.ResetText();
            txtDonGiaNhap.ResetText();
            txtDonGiaBan.ResetText();
            txtMaSP.Focus();
        }

        private void FormSanPhamMoi_Load(object sender, EventArgs e)
        {
            cboLoaiDichVu.DataSource = daLoaiDV.loadLoaiDichVu();
            cboLoaiDichVu.ValueMember = "MALOAI";
            cboLoaiDichVu.DisplayMember = "TENLOAI";

            cboNhaCungCap.DataSource = daNCC.loadNhaCungCap();
            cboNhaCungCap.ValueMember = "MANCC";
            cboNhaCungCap.DisplayMember = "TENNCC";
        }
    }
}
