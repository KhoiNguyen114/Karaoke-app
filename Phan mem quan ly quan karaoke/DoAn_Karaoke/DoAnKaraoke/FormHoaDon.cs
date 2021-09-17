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
    public partial class FormHoaDon : Form
    {
        BLLDALHoaDon daHD = new BLLDALHoaDon();
        BLLDALDatPhong daDP = new BLLDALDatPhong();
        BLLDALChiTietHoaDon daCTHD = new BLLDALChiTietHoaDon();
        BLLDALKhachHang daKH = new BLLDALKhachHang();
        BLLDALSanPham daSP = new BLLDALSanPham();
        BLLDALNhanVien daNV = new BLLDALNhanVien();
        BLLDALReprotHoaDon daRPHD = new BLLDALReprotHoaDon();
        public FormHoaDon()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void loadDataGridViewHoaDon()
        {
            dtgv_HoaDon.DataSource = daHD.loadHoaDon();
        }

        public void loadDataGridViewCTHD()
        {
            dtgv_CTHD.DataSource = daCTHD.loadChiTietHoaDon();
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            loadDataGridViewHoaDon();
            loadDataGridViewCTHD();

            cboKhachHang.DataSource = daKH.loadKhachHang();
            cboKhachHang.ValueMember = "MAKH";
            cboKhachHang.DisplayMember = "TENKH";

            cboMaDatPhong.DataSource = daDP.loadDatPhong();
            cboMaDatPhong.ValueMember = "MADAT";
            cboMaDatPhong.DisplayMember = "MADAT";

            cboNhanVien.DataSource = daNV.loadNhanVien();
            cboNhanVien.ValueMember = "MANV";
            cboNhanVien.DisplayMember = "TENNV";

            cboSanPham.DataSource = daSP.loadSanPhamCombobox();
            cboSanPham.ValueMember = "MASP";
            cboSanPham.DisplayMember = "TENSP";

            cboMaHoaDon.DataSource = daHD.loadHoaDon();
            cboMaHoaDon.ValueMember = "MAHD";
            cboMaHoaDon.DisplayMember = "MAHD";

            cboTinhTrang.DataSource = daHD.loadTInhTrang();

            txtDonGiaBan.Enabled = false;
            
        }

        private void FormHoaDon_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.formMain.Show();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void btnThem_Click(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(txtMaHoaDon.Text.Trim()))
        //    {
        //        MessageBox.Show("Mã hóa đơn không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    if (txtMaHoaDon.Text.Trim().Length > 10)
        //    {
        //        MessageBox.Show("Mã hóa đơn không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    int maDat = int.Parse(cboMaDatPhong.SelectedValue.ToString());
        //    int maHD = int.Parse(txtMaHoaDon.Text.Trim());
        //    if (!daHD.ktMoiHoaDon1MaDat(maDat))
        //    {
        //        MessageBox.Show("Mỗi mã đặt phòng chỉ có 1 hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    if (!daHD.ktKhoaChinh(maHD))
        //    {
        //        MessageBox.Show("Mã hóa đơn này đã tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    string pgioVao = daHD.traVeGioVao(maDat);
        //    DateTime gioVao = DateTime.Parse(pgioVao);
        //    DateTime ngayLap = DateTime.Now;
        //    if (daHD.themHoaDon(maHD, cboNhanVien.SelectedValue.ToString(), cboKhachHang.SelectedValue.ToString(), maDat, gioVao, ngayLap))
        //    {
        //        loadDataGridViewHoaDon();
        //        cboMaHoaDon.DataSource = daHD.loadHoaDon();
        //        MessageBox.Show("Thêm hóa đơn mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
        //    }
        //    else
        //    {
        //        MessageBox.Show("Thêm hóa đơn mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //}

        //private void btnCapNhat_Click(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(txtMaHoaDon.Text.Trim()) || String.IsNullOrEmpty(txtTienPhong.Text.Trim()) || String.IsNullOrEmpty(txtTienDichVu.Text.Trim()) || String.IsNullOrEmpty(txtTongTien.Text.Trim()))
        //    {
        //        MessageBox.Show("Mã hóa đơn, tiền phòng, tiền dịch vụ, tổng tiền, thanh toán không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    int maHD = int.Parse(txtMaHoaDon.Text.Trim());
        //    if (daHD.ktKhoaChinh(maHD))
        //    {
        //        MessageBox.Show("Mã hóa đơn này không tồn tại nên không thể cập nhật! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    int maDat = int.Parse(cboMaDatPhong.SelectedValue.ToString());
        //    string pgioVao = daHD.traVeGioVao(maDat);
        //    DateTime gioVao = DateTime.Parse(pgioVao);
        //    DateTime gioRa = dpk_GioRa.Value;
        //    DateTime ngayLap = dpk_NgayLap.Value;
        //    double tienPhong = double.Parse(txtTienPhong.Text.Trim());
        //    double tienDichVu = double.Parse(txtTienDichVu.Text.Trim());
        //    double tongTien = double.Parse(txtTongTien.Text.Trim());
        //    double thanhToan = double.Parse(txtThanhToan.Text.Trim());

        //    if (daHD.suaHoaDon(maHD, cboNhanVien.SelectedValue.ToString(), cboKhachHang.SelectedValue.ToString(), ngayLap, gioVao, gioRa, tienPhong, tienDichVu, tongTien, thanhToan))
        //    {
        //        loadDataGridViewHoaDon();
        //        cboMaHoaDon.DataSource = daHD.loadHoaDon();
        //        MessageBox.Show("Cập nhật hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Cập nhật hóa đơn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //}

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(txtMaHoaDon.Text.Trim()))
            //{
            //    MessageBox.Show("Mã hóa đơn không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //int maHD = int.Parse(txtMaHoaDon.Text.Trim());
            //if (daHD.ktKhoaChinh(maHD))
            //{
            //    MessageBox.Show("Mã hóa đơn này không tồn tại nên không thể xóa! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //DialogResult r;
            //r = MessageBox.Show("Nếu bạn xóa hóa đơn này thì toàn bộ chi tiết hóa đơn có mã hóa đơn này cũng sẽ bị xóa theo. Bạn có muốn tiếp tục không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (r == DialogResult.Yes)
            //{
            //    if (daHD.xoaHoaDon(maHD))
            //    {
            //        loadDataGridViewHoaDon();
            //        cboMaHoaDon.DataSource = daHD.loadHoaDon();
            //        loadDataGridViewCTHD();
            //        MessageBox.Show("Xóa hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Xóa hóa đơn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}
            if (String.IsNullOrEmpty(txtMaHoaDon.Text.Trim()))
            {
                MessageBox.Show("Mã hóa đơn không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maHD = int.Parse(txtMaHoaDon.Text.Trim());
            if (daHD.khoiPhucSoLuongHuy(maHD))
            {
                loadDataGridViewHoaDon();
                MessageBox.Show("Hủy hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else
            {
                MessageBox.Show("Hủy hóa đơn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //private void btnThemCTHD_Click(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(txtSoLuong.Text.Trim()) || String.IsNullOrEmpty(txtThanhTienCTHD.Text.Trim()) || String.IsNullOrEmpty(txtDonGiaBan.Text.Trim()))
        //    {
        //        MessageBox.Show("Số lượng, đơn giá bán, thành tiền không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    int maHD = int.Parse(cboMaHoaDon.SelectedValue.ToString());
        //    if (!daCTHD.ktKhoaChinhCTHD(maHD, cboSanPham.SelectedValue.ToString()))
        //    {
        //        MessageBox.Show("Mã chi tiết hóa đơn (Mã hóa đơn và mã sản phẩm) này đã tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    int? soLuongSP = daSP.traVeSoLuong(cboSanPham.SelectedValue.ToString());
        //    int soLuong = int.Parse(txtSoLuong.Text.Trim());
        //    if (soLuong < 0)
        //    {
        //        MessageBox.Show("Số lượng sản phẩm phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    double donGia = double.Parse(txtDonGiaBan.Text.Trim());
        //    double thanhTien = double.Parse(txtThanhTienCTHD.Text.Trim());
        //    if (soLuongSP == 0)
        //    {
        //        MessageBox.Show("Sản phẩm này đã hết hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    else
        //    {
        //        if (soLuong <= soLuongSP)
        //        {
        //            if (daCTHD.themCTHD(maHD, cboSanPham.SelectedValue.ToString(), soLuong, donGia, thanhTien))
        //            {
        //                loadDataGridViewCTHD();
        //                cboSanPham.DataSource = daSP.loadSanPhamCombobox();
        //                daSP.capNhatTinhTrang();
        //                MessageBox.Show("Thêm chi tiết hóa đơn mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            else
        //            {
        //                MessageBox.Show("Thêm chi tiết hóa đơn mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Số lượng nhập vào đang lớn hơn số lượng sản phẩm hiện có! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //    }
            
        //}

        //private void btnCapNhatCTHD_Click(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(txtSoLuong.Text.Trim()) || String.IsNullOrEmpty(txtThanhTienCTHD.Text.Trim()) || String.IsNullOrEmpty(txtDonGiaBan.Text.Trim()))
        //    {
        //        MessageBox.Show("Số lượng, đơn giá bán, thành tiền không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    if (daCTHD.ktKhoaChinhCTHD(cboMaHoaDon.SelectedValue.ToString(), cboSanPham.SelectedValue.ToString()))
        //    {
        //        MessageBox.Show("Mã chi tiết hóa đơn (Mã hóa đơn và mã sản phẩm) này không tồn tại nên không thể cập nhật! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    int? soLuongSPCTHD = daCTHD.traVeSoLuong(cboMaHoaDon.SelectedValue.ToString(), cboSanPham.SelectedValue.ToString());
        //    int soLuong = int.Parse(txtSoLuong.Text.Trim());
        //    double donGia = double.Parse(txtDonGiaBan.Text.Trim());
        //    double thanhTien = double.Parse(txtThanhTienCTHD.Text.Trim());
        //    int? soLuongSP = daSP.traVeSoLuong(cboSanPham.SelectedValue.ToString());
        //    if (soLuongSP == 0)
        //    {
        //        if (soLuong <= soLuongSPCTHD)
        //        {
        //            if (daCTHD.suaCTHD(cboMaHoaDon.SelectedValue.ToString(), cboSanPham.SelectedValue.ToString(), soLuong, donGia, thanhTien))
        //            {
        //                loadDataGridViewCTHD();
        //                cboSanPham.DataSource = daSP.loadSanPhamCombobox();
        //                MessageBox.Show("Cập nhật chi tiết hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            else
        //            {
        //                MessageBox.Show("Cập nhật chi tiết hóa đơn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Số lượng nhập vào đang lớn hơn số lượng sản phẩm hiện có! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        if (soLuong <= soLuongSP)
        //        {
        //            if (daCTHD.suaCTHD(cboMaHoaDon.SelectedValue.ToString(), cboSanPham.SelectedValue.ToString(), soLuong, donGia, thanhTien))
        //            {
        //                loadDataGridViewCTHD();
        //                cboSanPham.DataSource = daSP.loadSanPhamCombobox();
        //                MessageBox.Show("Cập nhật chi tiết hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            else
        //            {
        //                MessageBox.Show("Cập nhật chi tiết hóa đơn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Số lượng nhập vào đang lớn hơn số lượng sản phẩm hiện có! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //    }
        //}

        //private void btnXoaCTHD_Click(object sender, EventArgs e)
        //{
        //    if (daCTHD.ktKhoaChinhCTHD(cboMaHoaDon.SelectedValue.ToString(), cboSanPham.SelectedValue.ToString()))
        //    {
        //        MessageBox.Show("Mã chi tiết hóa đơn (Mã hóa đơn và mã sản phẩm) này không tồn tại nên không thể xóa! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    if (daCTHD.xoaCTHD(cboMaHoaDon.SelectedValue.ToString(), cboSanPham.SelectedValue.ToString()))
        //    {
        //        loadDataGridViewCTHD();
        //        cboSanPham.DataSource = daSP.loadSanPhamCombobox();
        //        daSP.capNhatTinhTrang();
        //        MessageBox.Show("Xóa chi tiết hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Xóa chi tiết hóa đơn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //}

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSoLuong.Text.Trim()) && !String.IsNullOrEmpty(txtDonGiaBan.Text.Trim()))
            {
                int sl = int.Parse(txtSoLuong.Text.Trim());
                double dgb = double.Parse(txtDonGiaBan.Text.Trim());
                txtThanhTienCTHD.Text = sl * dgb + "";
            }
        }

        private void txtDonGiaBan_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSoLuong.Text.Trim()) && !String.IsNullOrEmpty(txtDonGiaBan.Text.Trim()))
            {
                int sl = int.Parse(txtSoLuong.Text.Trim());
                double dgb = double.Parse(txtDonGiaBan.Text.Trim());
                txtThanhTienCTHD.Text = sl * dgb + "";
            }
        }

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            double? donGiaBan = daSP.traVeDonGiaBan(cboSanPham.SelectedValue.ToString());
            txtDonGiaBan.Text = donGiaBan + "";
            txtSoLuongSP.Text = daSP.traVeSoLuong(cboSanPham.SelectedValue.ToString()) + "";
        }

        private void cboMaDatPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtgv_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_HoaDon.CurrentRow != null)
            {
                txtMaHoaDon.Text = dtgv_HoaDon.CurrentRow.Cells[0].Value.ToString();
                dpk_GioVao.Text = dtgv_HoaDon.CurrentRow.Cells[5].Value.ToString();
                try
                {
                    dpk_GioRa.Text = dtgv_HoaDon.CurrentRow.Cells[6].Value.ToString();
                }
                catch
                {
                    dpk_GioRa.Text = "";
                }

                cboKhachHang.Text = daKH.traVeTenKhachHang(dtgv_HoaDon.CurrentRow.Cells[2].Value.ToString());
                cboNhanVien.Text = daNV.traVeTenNhanVien(dtgv_HoaDon.CurrentRow.Cells[1].Value.ToString());
                cboMaDatPhong.Text = dtgv_HoaDon.CurrentRow.Cells[3].Value.ToString();
                txtTienPhong.Text = dtgv_HoaDon.CurrentRow.Cells[7].Value.ToString();
                txtTienDichVu.Text = dtgv_HoaDon.CurrentRow.Cells[8].Value.ToString();
                txtTongTien.Text = dtgv_HoaDon.CurrentRow.Cells[9].Value.ToString();
                txtThanhToan.Text = dtgv_HoaDon.CurrentRow.Cells[10].Value.ToString();
                cboTinhTrang.Text = dtgv_HoaDon.CurrentRow.Cells[11].Value.ToString();

                dtgv_CTHD.DataSource = daCTHD.loadChiTietHoaDonTheoMa(int.Parse(dtgv_HoaDon.CurrentRow.Cells[0].Value.ToString()));
            }
        }

        private void dtgv_CTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_CTHD.CurrentRow != null)
            {
                cboMaHoaDon.Text = dtgv_CTHD.CurrentRow.Cells[0].Value.ToString();
                cboSanPham.Text = daSP.traVeTenSanPham(dtgv_CTHD.CurrentRow.Cells[1].Value.ToString());
                txtSoLuong.Text = dtgv_CTHD.CurrentRow.Cells[2].Value.ToString();
                txtDonGiaBan.Text = dtgv_CTHD.CurrentRow.Cells[3].Value.ToString();
                txtThanhTienCTHD.Text = dtgv_CTHD.CurrentRow.Cells[4].Value.ToString();
            }
        }

        //private void btnTinhTienPhong_Click(object sender, EventArgs e)
        //{
        //    txtTienDichVu.Text = daHD.tongTienDichVu(int.Parse(dtgv_HoaDon.CurrentRow.Cells[0].Value.ToString()))+ "";
        //    int maDat = int.Parse(cboMaDatPhong.SelectedValue.ToString());
        //    string pgioVao = daHD.traVeGioVao(maDat);
        //    DateTime gioVao = DateTime.Parse(pgioVao);
        //    DateTime gioRa = DateTime.Now;
        //    txtTienPhong.Text = daHD.tinhTienPhong(int.Parse(dtgv_HoaDon.CurrentRow.Cells[3].Value.ToString()),gioVao,gioRa) + "";


        //    double tienDichVu = 0;
        //    if (!String.IsNullOrEmpty(txtTienDichVu.Text.Trim()))
        //    {
        //        tienDichVu = double.Parse(txtTienDichVu.Text.Trim());
        //    }
        //    double tienPhong = double.Parse(txtTienPhong.Text.Trim());
        //    double tongTien = tienDichVu + tienPhong;
        //    txtTongTien.Text = tongTien.ToString() + "";

        //    txtThanhToan.Text = daHD.tinhTienThanhToanHD(tongTien, cboKhachHang.SelectedValue.ToString()) + "";
        //}



        private void cboSanPham_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (dtgv_HoaDon.CurrentRow != null)
            {
                //FormInHoaDon frm = new FormInHoaDon();
                //frm.MaHD = int.Parse(dtgv_HoaDon.CurrentRow.Cells[0].Value.ToString());
                //frm.TienPhong = double.Parse(dtgv_HoaDon.CurrentRow.Cells[7].Value.ToString());
                //frm.TongTien = double.Parse(dtgv_HoaDon.CurrentRow.Cells[9].Value.ToString());
                //frm.ThanhToan = double.Parse(dtgv_HoaDon.CurrentRow.Cells[10].Value.ToString());
                //frm.Show();
                int maHD = int.Parse(dtgv_HoaDon.CurrentRow.Cells[0].Value.ToString());
                ReportInHoaDon rpt = new ReportInHoaDon();
                rpt.lblNgayLap.Text = daRPHD.traVeNgayLap(maHD).Value.Date + "";
                rpt.lblNgayLap.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(daRPHD.traVeNgayLap(maHD).ToString()));
                rpt.lblGioVao.Text = string.Format("{0:hh:mm:ss tt}", DateTime.Parse(daRPHD.traVeGioVao(maHD).ToString()));
                rpt.lblGioRa.Text = string.Format("{0:hh:mm:ss tt}", DateTime.Parse(daRPHD.traVeGioRa(maHD).ToString()));
                rpt.lblTongTien.Text = string.Format("{0:0,0} VNĐ", daRPHD.traVeTongTien(maHD));
                rpt.lblThanhToan.Text = string.Format("{0:0,0} VNĐ", daRPHD.traVeThanhToan(maHD));
                rpt.lblTienPhong.Text = string.Format("{0:0,0} VNĐ", daRPHD.traVeTienPhong(maHD));
                rpt.lblTienDichVu.Text = string.Format("{0:0,0} VNĐ", daRPHD.traVeTienDichVu(maHD));
                rpt.DataSource = daRPHD.xuatHoaDon(maHD); 
                rpt.ShowPreviewDialog();
            }
        }


    }
}
