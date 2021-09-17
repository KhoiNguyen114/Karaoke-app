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
    public partial class FormThanhToan : Form
    {
        BLLDALDatPhong daDP = new BLLDALDatPhong();
        BLLDALLoaiKhachHang daLKH = new BLLDALLoaiKhachHang();
        BLLDALKhachHang daKH = new BLLDALKhachHang();
        BLLDALHoaDon daHD = new BLLDALHoaDon();
        BLLDALNhanVien daNV = new BLLDALNhanVien();
        BLLDALSanPham daSP = new BLLDALSanPham();
        BLLDALReprotHoaDon daRPHD = new BLLDALReprotHoaDon();
        PHONG ph;
        int maDat;

        public int MaDat
        {
            get { return maDat; }
            set { maDat = value; }
        }

        public PHONG Ph
        {
            get { return ph; }
            set { ph = value; }
        }

        public FormThanhToan()
        {
            InitializeComponent();
        }

        private void FormThanhToan_Load(object sender, EventArgs e)
        {
            this.Text += " - " + ph.TENPHONG;
            lblPhong.Text = ph.TENPHONG.ToUpper();
            lblNhanVien.Text += " " + daNV.traVeNhanVienDiemDanh(Program.tenDangNhap);
            txtTenPhong.Text = ph.TENPHONG;
            txtMaDat.Text = maDat + "";
            lblGiaPhong.Text += " " + daHD.traVeGiaPhong(maDat) + "đ/giờ";

            List<DichVuDatPhong> dsDV = Program.ds.Where(t => t.MaPhong == ph.MAPHONG).ToList();
            dtgv_DichVu.DataSource = dsDV;
            
            DateTime gioVao = DateTime.Parse(daHD.traVeGioVao(maDat));
            DateTime gioRa = DateTime.Now;
            
            txtTienDichVu.Text = Program.ds.Where(t => t.MaPhong == ph.MAPHONG).Sum(t => t.ThanhTien) + "";
            lblGioVao.Text =  gioVao + "";
            lblGioRa.Text = gioRa + "";


            txtTienPhong.Text = daHD.tinhTienPhong(maDat, gioVao, gioRa) + "";
            double tienPhong = double.Parse(txtTienPhong.Text.Trim());
            double tongDV = double.Parse(txtTienDichVu.Text.Trim());
            double tongTien = tienPhong + tongDV;
            txtTongTien.Text = tongTien + "";

            cboKhachHang.DataSource = daKH.loadKhachHang();
            cboKhachHang.ValueMember = "MAKH";
            cboKhachHang.DisplayMember = "TENKH";
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblGiamGia.Text = daLKH.traVeGiamGia(cboKhachHang.SelectedValue.ToString());
            double tongTien = double.Parse(txtTongTien.Text.Trim());
            txtThanhToan.Text = daHD.tinhTienThanhToanHD(tongTien, cboKhachHang.SelectedValue.ToString()) + "";
        }

        private void dtgv_DichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_DichVu.CurrentRow != null)
            {
                txtTenSanPham.Text = daSP.traVeTenSanPham(dtgv_DichVu.CurrentRow.Cells[2].Value.ToString());
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            List<DichVuDatPhong> dsDV = Program.ds.Where(t => t.MaPhong == ph.MAPHONG).ToList();
            double tienPhong = double.Parse(txtTienPhong.Text.Trim());
            double tongDV = double.Parse(txtTienDichVu.Text.Trim());
            double tongTien = double.Parse(txtTongTien.Text.Trim());
            double thanhToan = double.Parse(txtThanhToan.Text.Trim());
            string maNV = daNV.traVeMaNhanVien(Program.tenDangNhap);
            DateTime ngayLap = DateTime.Now;
            DateTime gioVao = DateTime.Parse(daHD.traVeGioVao(maDat));
            DateTime gioRa = DateTime.Now;
            if (!daHD.ktThanhToan1Lan(maDat))
            {
                MessageBox.Show("Mã đặt phòng này đã được thanh toán nên không thể thực hiện nữa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (daHD.xacNhanThanhToan(maNV, cboKhachHang.SelectedValue.ToString(), maDat, ngayLap, gioVao, gioRa, tienPhong, tongDV, tongTien, thanhToan, dsDV))
            {
                daDP.thayDoiTinhTrangPhongKhiXoa(ph.MAPHONG);
                Program.ds = daHD.capNhatSauKhiThanhToan(Program.ds, maDat, ph.MAPHONG);
                int maHD = daHD.traVeMaHD(maDat);
                daHD.thayDoiSoLuongKhiThem(maHD);
                MessageBox.Show("Thanh toán thành công! Hóa đơn đã được lưu lại!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                this.Close();
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        
    }
}
