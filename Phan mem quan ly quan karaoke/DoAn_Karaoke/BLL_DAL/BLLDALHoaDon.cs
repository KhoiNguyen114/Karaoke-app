using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALHoaDon
    {
        QuanLyQuanKaraokeDataContext qlkara = new QuanLyQuanKaraokeDataContext();
        public BLLDALHoaDon()
        {

        }

        public IQueryable loadHoaDon()
        {
            IQueryable ds = from k in qlkara.HOADONs select new { k.MAHD, k.MANV, k.MAKH, k.MADAT, k.NGAYLAPHD, k.GIOVAO, k.GIORA, k.TIENPHONG, k.TIENDICHVU, k.TONGTIENHD, k.THANHTOAN, k.TINHTRANG };
            return ds;
        }

        public List<string> loadTInhTrang()
        {
            List<string> ds = new List<string>();
            ds.Add("Có hiệu lực");
            ds.Add("Hủy");
            return ds;
        }

        public bool ktKhoaChinh(int pMaHD)
        {
            HOADON hd = qlkara.HOADONs.Where(t => t.MAHD == pMaHD).SingleOrDefault();
            if (hd == null)
                return true;
            return false;
        }

        public bool ktMoiHoaDon1MaDat(int pMaDat)
        {
            HOADON hd = qlkara.HOADONs.Where(t => t.MADAT == pMaDat).SingleOrDefault();
            if (hd == null)
                return true;
            return false;
        }

        //Thêm hóa đơn và chi tiết hóa đơn khi thanh toán
        public int traVeMaHD(int pMaDat)
        {
            try
            {
                HOADON hd = qlkara.HOADONs.Where(t => t.MADAT == pMaDat).SingleOrDefault();
                if (hd == null)
                    return -1;
                return hd.MAHD;
            }
            catch
            {
                return -1;
            }
        }

        public bool ktThanhToan1Lan(int pMaDat)
        {
            try
            {
                HOADON hd = qlkara.HOADONs.Where(t => t.MADAT == pMaDat).SingleOrDefault();
                if (hd == null)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool xacNhanThanhToan(string pMaNV, string pMaKH, int pMaDat, DateTime pNgayLap, DateTime pGioVao, DateTime pGioRa, double pTienPhong, double pTienDichVu, double pTongTienHD, double pThanhToan, List<DichVuDatPhong> ds)
        {
            try
            {
                HOADON hd = new HOADON();
                hd.MANV = pMaNV;
                hd.MAKH = pMaKH;
                hd.MADAT = pMaDat;
                hd.NGAYLAPHD = pNgayLap;
                hd.GIOVAO = pGioVao;
                hd.GIORA = pGioRa;
                hd.TIENPHONG = pTienPhong;
                hd.TIENDICHVU = pTienDichVu;
                hd.TONGTIENHD = pTongTienHD;
                hd.THANHTOAN = pThanhToan;
                hd.TINHTRANG = "Có hiệu lực";

                qlkara.HOADONs.InsertOnSubmit(hd);
                qlkara.SubmitChanges();
                for (int i = 0; i < ds.Count; i++)
                {
                    CHITIETHOADON cthd = new CHITIETHOADON();
                    cthd.MAHD = hd.MAHD;
                    cthd.MASP = ds[i].MaSP;
                    cthd.SOLUONG = ds[i].SoLuong;
                    cthd.DONGIABAN = ds[i].DonGiaBan;
                    cthd.THANHTIEN = ds[i].ThanhTien;

                    qlkara.CHITIETHOADONs.InsertOnSubmit(cthd);
                    qlkara.SubmitChanges();
                }
                ds.Clear();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<DichVuDatPhong> capNhatSauKhiThanhToan(List<DichVuDatPhong> ds, int pMaDat, string pMaPhong)
        {
            for (int i = ds.Count-1; i >= 0 ; i--)
            {
                if (ds[i].MaDat == pMaDat && ds[i].MaPhong == pMaPhong)
                {
                    ds.Remove(ds[i]);
                }
            }
            return ds;
        }

        public bool themHoaDon(int pMaHD, string pMaNV, string pMaKH, int pMaDat, DateTime pGioVao, DateTime pNgayLap)
        {
            try
            {
                HOADON hd = new HOADON();
                hd.MAHD = pMaHD;
                hd.MANV = pMaNV;
                hd.MAKH = pMaKH;
                hd.MADAT = pMaDat;
                hd.NGAYLAPHD = pNgayLap;
                hd.GIOVAO = pGioVao;
                hd.GIORA = null;
                hd.TIENPHONG = 0;
                hd.TIENDICHVU = 0;
                hd.TONGTIENHD = 0;
                hd.THANHTOAN = 0;
                hd.TINHTRANG = "Có hiệu lực";

                qlkara.HOADONs.InsertOnSubmit(hd);
                qlkara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaHoaDon(int pMaHD, string pMaNV, string pMaKH, DateTime pNgayLap, DateTime pGioVao, DateTime pGioRa, double pTienPhong, double pTienDichVu, double pTongTien, double pThanhToan)
        {
            try
            {
                HOADON hd = qlkara.HOADONs.Where(t => t.MAHD == pMaHD).SingleOrDefault();
                if (hd == null)
                    return false;
                hd.MANV = pMaNV;
                hd.MAKH = pMaKH;
                hd.NGAYLAPHD = pNgayLap;
                hd.GIOVAO = pGioVao;
                hd.GIORA = pGioRa;
                hd.TIENPHONG = pTienPhong;
                hd.TIENDICHVU = pTienDichVu;
                hd.TONGTIENHD = pTongTien;
                hd.THANHTOAN = pThanhToan;

                qlkara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaHoaDon(int pMaHD)
        {
            try
            {
                HOADON hd = qlkara.HOADONs.Where(t => t.MAHD == pMaHD).SingleOrDefault();
                if (hd == null)
                    return false;

                qlkara.HOADONs.DeleteOnSubmit(hd);
                qlkara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool thayDoiSoLuongKhiThem(int pMaHD)
        {
            try
            {
                List<CHITIETHOADON> ds = qlkara.CHITIETHOADONs.Where(t => t.MAHD == pMaHD).ToList();
                for (int i = 0; i < ds.Count; i++)
                {
                    string ma = ds[i].MASP;
                    SANPHAM sp = qlkara.SANPHAMs.Where(t => t.MASP == ma).SingleOrDefault();
                    sp.SOLUONG -= ds[i].SOLUONG;
                    qlkara.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        } 

        public bool khoiPhucSoLuongHuy(int pMaHD)
        {
            try
            {
                HOADON hd = qlkara.HOADONs.Where(t => t.MAHD == pMaHD).SingleOrDefault();
                if (hd == null)
                    return false;
                hd.TINHTRANG = "Hủy";
                qlkara.SubmitChanges();

                List<CHITIETHOADON> ds = qlkara.CHITIETHOADONs.Where(t => t.MAHD == pMaHD).ToList();
                for (int i = 0; i < ds.Count; i++)
                {
                    string ma = ds[i].MASP;
                    SANPHAM sp = qlkara.SANPHAMs.Where(t => t.MASP == ma).SingleOrDefault();
                    sp.SOLUONG += ds[i].SOLUONG;
                    qlkara.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        } 

        public string traVeGioVao(int pMaDat)
        {
            DATPHONG dp = qlkara.DATPHONGs.Where(t => t.MADAT == pMaDat).SingleOrDefault();
            if (dp == null)
                return null;
            DateTime? kq = dp.GIOVAO;
            return kq.ToString();
        }

        public double? traVeGiaPhong(int pMaDat)
        {
            try
            {
                DATPHONG dp = qlkara.DATPHONGs.Where(t => t.MADAT == pMaDat).SingleOrDefault();
                if (dp == null)
                    return -1;
                string ma = dp.MAPHONG;
                PHONG p = qlkara.PHONGs.Where(t => t.MAPHONG == ma).SingleOrDefault();
                if (p == null)
                    return -1;
                return p.GIAPHONG;
            }
            catch
            {
                return -1;
            }
        }

        public double? tongTienDichVu(int pMaHD)
        {
            double? kq = 0;
            kq = qlkara.CHITIETHOADONs.Where(t => t.MAHD == pMaHD).Sum(t => t.THANHTIEN);
            return kq;
        }

        public double? tinhTienPhong(int pMaDat, DateTime pGioVao, DateTime pGioRa)
        {
            double? kq = 0;
            int year = pGioVao.Year;
            int month = pGioVao.Month;
            int day = pGioVao.Day;
            int hour = pGioVao.Hour;
            int minute = pGioVao.Minute;
            int second = pGioVao.Second;
            DateTime time = new DateTime(year, month, day, hour, minute, second);
            TimeSpan ts = pGioRa.Subtract(time);
            int gio = ts.Hours;
            double phut = (double)ts.Minutes/60;
            double timeHat = gio + phut;
            string a = String.Format("{0:0.00}",timeHat);
            kq = double.Parse(a);
            double? giaPhong = traVeGiaPhong(pMaDat);
            kq = kq * giaPhong;
            return kq;
        }

        public double? tinhTienThanhToanHD(double pTongTien, string pMaKH)
        {
            double? kq = 0;
            KHACHHANG kh = qlkara.KHACHHANGs.Where(t => t.MAKH == pMaKH).SingleOrDefault();
            if(kh == null)
                return -1;
            string maLoai = kh.MALOAIKH;
            LOAIKHACHHANG lkh = qlkara.LOAIKHACHHANGs.Where(t => t.MALOAIKH == maLoai).SingleOrDefault();
            if (lkh == null)
                return -1;
            double? giamGia = lkh.GIAMGIA;
            kq = pTongTien - (giamGia*pTongTien);
            return kq;
        }

        

    }
}
