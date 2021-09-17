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
    public partial class FormSanPham : Form
    {
        BLLDALSanPham daSP = new BLLDALSanPham();
        BLLDALLoaiDichVu daLoaiDV = new BLLDALLoaiDichVu();
        BLLDALNhaCungCap daNCC = new BLLDALNhaCungCap();

        public FormSanPham()
        {
            InitializeComponent();
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {
            loadDataGridView();

            cboLoaiDichVu.DataSource = daLoaiDV.loadLoaiDichVu();
            cboLoaiDichVu.ValueMember = "MALOAI";
            cboLoaiDichVu.DisplayMember = "TENLOAI";

            cboNhaCungCap.DataSource = daNCC.loadNhaCungCap();
            cboNhaCungCap.ValueMember = "MANCC";
            cboNhaCungCap.DisplayMember = "TENNCC";
        }

        private void FormSanPham_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.formMain.Show();
        }

        public void loadDataGridView()
        {
            dtgv_SanPham.DataSource = daSP.loadSanPham();
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
                        loadDataGridView();
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
                    loadDataGridView();
                    MessageBox.Show("Thêm sản phẩm mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaSP.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daSP.ktKhoaChinh(txtMaSP.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm này không tồn tại nên không thể cập nhật! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult r;
            r = MessageBox.Show("Khi bạn xóa sản phẩm này thì toàn bộ chi tiết hóa đơn, chi tiết phiếu nhập có mã sản phẩm này cũng sẽ bị xóa theo. Bạn có muốn tiếp tục không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (daSP.xoaSP(txtMaSP.Text.Trim()))
                {
                    loadDataGridView();
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaSP.Text.Trim()) || String.IsNullOrEmpty(txtTenSP.Text.Trim()) || String.IsNullOrEmpty(txtSoLuong.Text.Trim()) || String.IsNullOrEmpty(txtDonGiaNhap.Text.Trim()) || String.IsNullOrEmpty(txtDonGiaBan.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm, tên sản phẩm, đơn giá nhập, đơn giá bán không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daSP.ktKhoaChinh(txtMaSP.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm này không tồn tại nên không thể cập nhật! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double gia = double.Parse(txtDonGiaNhap.Text.Trim());
            double gia1 = double.Parse(txtDonGiaBan.Text.Trim());
            int soLuong = int.Parse(txtSoLuong.Text.Trim());
            if (soLuong < 0 || gia < 0 || gia1 < 0)
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


                    if (daSP.suaSP(txtMaSP.Text.Trim(), txtTenSP.Text.Trim(), soLuong, gia, gia1, cboLoaiDichVu.SelectedValue.ToString(), cboNhaCungCap.SelectedValue.ToString()))
                    {
                        loadDataGridView();
                        MessageBox.Show("Cập nhật sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            else
            {

                if (daSP.suaSP(txtMaSP.Text.Trim(), txtTenSP.Text.Trim(), soLuong, gia, gia1, cboLoaiDichVu.SelectedValue.ToString(), cboNhaCungCap.SelectedValue.ToString()))
                {
                    loadDataGridView();
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSP.ResetText();
            txtTenSP.ResetText();
            txtSoLuong.ResetText();
            txtDonGiaNhap.ResetText();
            txtDonGiaBan.ResetText();
            txtMaSP.Focus();
        }

        

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.formMain.Show();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dtgv_SanPham.DataSource = daSP.loadDanhSachSanPhamTheoTimKiem(txtTimKiem.Text.Trim());
        }

        private void dtgv_SanPham_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_SanPham.CurrentRow != null)
            {
                txtMaSP.Text = dtgv_SanPham.CurrentRow.Cells[0].Value.ToString();
                txtTenSP.Text = dtgv_SanPham.CurrentRow.Cells[1].Value.ToString();
                txtSoLuong.Text = dtgv_SanPham.CurrentRow.Cells[2].Value.ToString();
                txtDonGiaNhap.Text = dtgv_SanPham.CurrentRow.Cells[3].Value.ToString();
                txtDonGiaBan.Text = dtgv_SanPham.CurrentRow.Cells[4].Value.ToString();
                cboLoaiDichVu.Text = daLoaiDV.traVeTenLoai(dtgv_SanPham.CurrentRow.Cells[5].Value.ToString());
                cboNhaCungCap.Text = daNCC.traVeTenNhaCungCap(dtgv_SanPham.CurrentRow.Cells[6].Value.ToString());
                txtTinhTrang.Text = dtgv_SanPham.CurrentRow.Cells[7].Value.ToString();
            }
        }

        

        
    }
}
