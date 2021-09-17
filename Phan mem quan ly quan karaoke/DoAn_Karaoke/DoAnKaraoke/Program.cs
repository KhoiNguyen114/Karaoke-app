using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;

namespace DoAnKaraoke
{
    static class Program
    {
        public static FormMain formMain = null;
        public static FormDangNhap formDangNhap = null;
        public static FormDoiMatKhau formDoiMatKhau = null;

        public static FormPhong formPhong = null;
        public static FormLoaiKhachHang formLoaiKhachHang = null;
        public static FormKhachHang formKhachHang = null;
        public static FormNhanVien formNhanVien = null;
        public static FormNhaCungCap formNhaCungCap = null;
        public static FormChucVu formChucVu = null;

        public static FormHoaDon formHoaDon = null;
        public static FormNhapHang formNhapHang = null;

        public static FormSanPham formSanPham = null;
        public static FormLoaiDichVu formLoaiDichVu = null;
        public static FormThongTin formThongTin = null;
        public static FormTaoTaiKhoan formTaoTaiKhoan = null;
        public static FormThongKeDoanhThu formThongKeDoanhThu = null;
        public static FormThongKePhieuNhap formThongKePhieuNhap = null;
        public static FormDiemDanh formDiemDanh = null;
        public static FormTinhLuongNhanVien formTinhLuongNhanVien = null;
        public static FormQuanLyNguoiDung formQuanLyNguoiDung = null;
        public static FormDichVuVaDatPhong formDichVuVaDatPhong = null;

        public static string tenDangNhap = null;
        public static List<DichVuDatPhong> ds = new List<DichVuDatPhong>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formDangNhap = new FormDangNhap();
            formMain = new FormMain();
            Application.Run(formDangNhap);
        }       
    }
}
