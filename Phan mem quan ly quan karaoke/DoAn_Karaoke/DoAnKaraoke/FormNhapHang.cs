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
using DevExpress.XtraReports.UI;
using DoAnKaraoke.XtraReport;

namespace DoAnKaraoke
{
    public partial class FormNhapHang : Form
    {
        BLLDALNhapHang daNH = new BLLDALNhapHang();
        BLLDALNhaCungCap daNCC = new BLLDALNhaCungCap();
        BLLDALSanPham daSP = new BLLDALSanPham();
        BLLDALChiTietNhapHang daCTNH = new BLLDALChiTietNhapHang();
        BLLDALNhanVien daNV = new BLLDALNhanVien();
        BLLDALReportPhieuNhap daRPPN = new BLLDALReportPhieuNhap();

        public FormNhapHang()
        {
            InitializeComponent();
        }

        private void FormNhapHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.formMain.Show();
        }

        public void loadDataGridView()
        {
            dtgv_PhieuNhap.DataSource = daNH.loadNhapHang();
        }

        public void loadDataGridViewCTPN()
        {
            dtgv_CTPN.DataSource = daCTNH.loadChiTietNhapHang();
        }

        private void FormNhapHang_Load(object sender, EventArgs e)
        {
            loadDataGridView();
            loadDataGridViewCTPN();

            cboNhanVien.DataSource = daNV.loadNhanVien();
            cboNhanVien.ValueMember = "MANV";
            cboNhanVien.DisplayMember = "TENNV";

            cboMaPhieuNhap.DataSource = daNH.loadNhapHang();
            cboMaPhieuNhap.DisplayMember = "MAPN";
            cboMaPhieuNhap.ValueMember = "MAPN";

            cboSanPham.DataSource = daSP.loadSanPham();
            cboSanPham.ValueMember = "MASP";
            cboSanPham.DisplayMember = "TENSP";

            cboNhaCungCap.DataSource = daNCC.loadNhaCungCap();
            cboNhaCungCap.ValueMember = "MANCC";
            cboNhaCungCap.DisplayMember = "TENNCC";

            cboTinhTrang.DataSource = daNH.loadTInhTrang();
        }

        private void dtgv_PhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_PhieuNhap.CurrentRow != null)
            {
                txtMaPhieuNhap.Text = dtgv_PhieuNhap.CurrentRow.Cells[0].Value.ToString();
                dpk_NgayLap.Text = dtgv_PhieuNhap.CurrentRow.Cells[3].Value.ToString();
                cboNhanVien.Text = daNV.traVeTenNhanVien(dtgv_PhieuNhap.CurrentRow.Cells[1].Value.ToString());
                cboNhaCungCap.Text = daNCC.traVeTenNhaCungCap(dtgv_PhieuNhap.CurrentRow.Cells[2].Value.ToString());
                try
                {
                    txtTongTien.Text = dtgv_PhieuNhap.CurrentRow.Cells[4].Value.ToString();
                }
                catch
                {
                    txtTongTien.Text = "";
                }
                dtgv_CTPN.DataSource = daCTNH.loadChiTietHoaDonTheoMa(int.Parse(dtgv_PhieuNhap.CurrentRow.Cells[0].Value.ToString()));
                cboTinhTrang.Text = dtgv_PhieuNhap.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void dtgv_CTPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_CTPN.CurrentRow != null)
            {
                cboMaPhieuNhap.Text = dtgv_CTPN.CurrentRow.Cells[0].Value.ToString();
                cboSanPham.Text = daSP.traVeTenSanPham(dtgv_CTPN.CurrentRow.Cells[1].Value.ToString());
                try
                {
                    txtDonGiaNhap.Text = dtgv_CTPN.CurrentRow.Cells[3].Value.ToString();
                    txtThanhTien.Text = dtgv_CTPN.CurrentRow.Cells[4].Value.ToString();
                    txtSoLuong.Text = dtgv_CTPN.CurrentRow.Cells[2].Value.ToString();
                }
                catch
                {
                    txtTongTien.Text = "";
                    txtDonGiaNhap.Text = "";
                    txtThanhTien.Text = "";
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {    
            string maNV = daNV.traVeMaNhanVien(Program.tenDangNhap);
            DateTime ngayLap = dpk_NgayLap.Value;
            if (daNH.themPhieuNhap(maNV, cboNhaCungCap.SelectedValue.ToString(), ngayLap))
            {
                loadDataGridView();
                cboMaPhieuNhap.DataSource = daNH.loadNhapHang();
                MessageBox.Show("Thêm phiếu nhập mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm phiếu nhập mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //private void btnCapNhat_Click(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(txtMaPhieuNhap.Text.Trim()))
        //    {
        //        MessageBox.Show("Mã phiếu nhập không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    if (daNH.ktKhoaChinh(txtMaPhieuNhap.Text.Trim()))
        //    {
        //        MessageBox.Show("Mã phiếu nhập này không tồn tại nên không thể cập nhật! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    DateTime ngayLap = dpk_NgayLap.Value;
        //    double tongTien = double.Parse(txtTongTien.Text.Trim());
        //    if (daNH.suaPhieuNhap(txtMaPhieuNhap.Text.Trim(), cboNhanVien.SelectedValue.ToString(), cboNhaCungCap.SelectedValue.ToString(), ngayLap,tongTien))
        //    {
        //        loadDataGridView();
        //        cboMaPhieuNhap.DataSource = daNH.loadNhapHang();
        //        MessageBox.Show("Cập nhật phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Cập nhật phiếu nhập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //}

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(txtMaPhieuNhap.Text.Trim()))
            //{
            //    MessageBox.Show("Mã phiếu nhập không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //if (daNH.ktKhoaChinh(txtMaPhieuNhap.Text.Trim()))
            //{
            //    MessageBox.Show("Mã phiếu nhập này không tồn tại nên không thể xóa! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //DialogResult r;
            //r = MessageBox.Show("Nếu bạn xóa phiếu nhập này thì toàn bộ chi tiết phiếu nhập có mã phiếu nhập này cũng sẽ bị xóa theo. Bạn có muốn tiếp tục không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (r == DialogResult.Yes)
            //{
            //    if (daNH.xoaPhieuNhap(txtMaPhieuNhap.Text.Trim()))
            //    {
            //        loadDataGridView();
            //        cboMaPhieuNhap.DataSource = daNH.loadNhapHang();
            //        loadDataGridViewCTPN();
            //        MessageBox.Show("Xóa phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Xóa phiếu nhập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}

            if (String.IsNullOrEmpty(txtMaPhieuNhap.Text.Trim()))
            {
                MessageBox.Show("Mã phiếu nhập không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int maPN = int.Parse(txtMaPhieuNhap.Text.Trim());
            if (daNH.khoiPhucSoLuongHuy(maPN))
            {
                loadDataGridView();
                cboMaPhieuNhap.DataSource = daNH.loadNhapHang();
                MessageBox.Show("Hủy phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else
            {
                MessageBox.Show("Hủy phiếu nhập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnThemCTPN_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSoLuong.Text.Trim()) || String.IsNullOrEmpty(txtThanhTien.Text.Trim()) || String.IsNullOrEmpty(txtDonGiaNhap.Text.Trim()))
            {
                MessageBox.Show("Số lượng, đơn giá nhập, thành tiền không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int maPN = int.Parse(cboMaPhieuNhap.SelectedValue.ToString());
            if (!daCTNH.ktKhoaChinh(maPN, cboSanPham.SelectedValue.ToString()))
            {
                MessageBox.Show("Mã chi tiết phiếu nhập (Mã phiếu nhập và mã sản phẩm) này đã tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!daCTNH.ktTinhTrang(maPN))
            {
                MessageBox.Show("Phiếu nhập này đã bị hủy nên không thể thêm chi tiết phiếu nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int soLuong = int.Parse(txtSoLuong.Text.Trim());
            double donGia = double.Parse(txtDonGiaNhap.Text.Trim());
            double thanhTien = double.Parse(txtThanhTien.Text.Trim());
            if (soLuong < 0)
            {
                MessageBox.Show("Số lượng sản phẩm phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (daCTNH.themChiTietPhieuNhap(maPN, cboSanPham.SelectedValue.ToString(), soLuong, donGia, thanhTien))
            {
                loadDataGridViewCTPN();
                loadDataGridView();
                daSP.capNhatTinhTrang();
                MessageBox.Show("Thêm chi tiết phiếu nhập mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm chi tiết phiếu nhập mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //private void btnCapNhatCTPN_Click(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(txtSoLuong.Text.Trim()) || String.IsNullOrEmpty(txtThanhTien.Text.Trim()) || String.IsNullOrEmpty(txtDonGiaNhap.Text.Trim()))
        //    {
        //        MessageBox.Show("Số lượng, đơn giá nhập, thành tiền không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    if (daCTNH.ktKhoaChinh(cboMaPhieuNhap.SelectedValue.ToString(), cboSanPham.SelectedValue.ToString()))
        //    {
        //        MessageBox.Show("Mã chi tiết phiếu nhập (Mã phiếu nhập và mã sản phẩm) này không tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    int soLuong = int.Parse(txtSoLuong.Text.Trim());
        //    double donGia = double.Parse(txtDonGiaNhap.Text.Trim());
        //    double thanhTien = double.Parse(txtThanhTien.Text.Trim());
        //    if (soLuong < 0)
        //    {
        //        MessageBox.Show("Số lượng sản phẩm phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
            
        //    if (daCTNH.suaChiTietPhieuNhap(cboMaPhieuNhap.SelectedValue.ToString(), cboSanPham.SelectedValue.ToString(), soLuong, donGia, thanhTien))
        //    {
        //        loadDataGridViewCTPN();
        //        loadDataGridView();
        //        MessageBox.Show("Cập nhật chi tiết phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Cập nhật chi tiết phiếu nhập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //}

        //private void btnXoaCTPN_Click(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(txtSoLuong.Text.Trim()) || String.IsNullOrEmpty(txtThanhTien.Text.Trim()) || String.IsNullOrEmpty(txtDonGiaNhap.Text.Trim()))
        //    {
        //        MessageBox.Show("Số lượng, đơn giá nhập, thành tiền không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    if (daCTNH.ktKhoaChinh(cboMaPhieuNhap.SelectedValue.ToString(), cboSanPham.SelectedValue.ToString()))
        //    {
        //        MessageBox.Show("Mã chi tiết phiếu nhập (Mã phiếu nhập và mã sản phẩm) này không tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    if (daCTNH.xoaChiTietPhieuNhap(cboMaPhieuNhap.SelectedValue.ToString(), cboSanPham.SelectedValue.ToString()))
        //    {
        //        loadDataGridViewCTPN();
        //        loadDataGridView();
        //        MessageBox.Show("Xóa chi tiết phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Xóa chi tiết phiếu nhập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //}

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSoLuong.Text.Trim()) && !String.IsNullOrEmpty(txtDonGiaNhap.Text.Trim()))
            {
                int sl = int.Parse(txtSoLuong.Text.Trim());
                double dgb = double.Parse(txtDonGiaNhap.Text.Trim());
                txtThanhTien.Text = sl * dgb + "";
            }
        }

        private void txtDonGiaNhap_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSoLuong.Text.Trim()) && !String.IsNullOrEmpty(txtDonGiaNhap.Text.Trim()))
            {
                int sl = int.Parse(txtSoLuong.Text.Trim());
                double dgb = double.Parse(txtDonGiaNhap.Text.Trim());
                txtThanhTien.Text = sl * dgb + "";
            }
        }

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            double? donGiaBan = daSP.traVeDonGiaNhap(cboSanPham.SelectedValue.ToString());
            txtDonGiaNhap.Text = donGiaBan + "";
        }

        private void btnInPhieuNhap_Click(object sender, EventArgs e)
        {
            if (dtgv_PhieuNhap.CurrentRow != null)
            {
                int maPN = int.Parse(dtgv_PhieuNhap.CurrentRow.Cells[0].Value.ToString());
                ReportInPhieuNhap rpt = new ReportInPhieuNhap();
                rpt.lblNgayLap.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(daRPPN.traVeNgayLap(maPN).ToString()));
                rpt.lblTongTien.Text = string.Format("{0:0,0} VNĐ", daRPPN.traVeTongTien(maPN));
                rpt.DataSource = daRPPN.xuatPhieuNhap(maPN);
                rpt.ShowPreviewDialog();
            }
        }

        private void btnThemSanPhamMoi_Click(object sender, EventArgs e)
        {
            FormSanPhamMoi frm = new FormSanPhamMoi();
            frm.ShowDialog();

            cboSanPham.DataSource = daSP.loadSanPham();
        }
    }
}
