using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALDatPhong
    {
        QuanLyQuanKaraokeDataContext qlkara = new QuanLyQuanKaraokeDataContext();
        public BLLDALDatPhong()
        {

        }

        public List<PHONG> loadDanhSachPhong()
        {
            qlkara.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, qlkara.PHONGs);
            List<PHONG> ds = new List<PHONG>();
            ds = qlkara.PHONGs.Select(t => t).ToList();
            return ds;
        }

        public IQueryable loadDatPhong()
        {
            IQueryable ds = from k in qlkara.DATPHONGs select new { k.MADAT, k.MAPHONG, k.GIOVAO };
            return ds;
        }

        public bool ktKhoaChinh(int pMaDat)
        {
            DATPHONG dt = qlkara.DATPHONGs.Where(t => t.MADAT == pMaDat).SingleOrDefault();
            if (dt == null)
                return true;
            return false;
        }

        public bool themDatPhong(string pMaPhong, DateTime pGioVao)
        {
            try
            {
                DATPHONG dt = new DATPHONG();
                dt.MAPHONG = pMaPhong;
                dt.GIOVAO = pGioVao;

                qlkara.DATPHONGs.InsertOnSubmit(dt);
                qlkara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaDatPhong(int pMaDat)
        {
            try
            {
                DATPHONG dt = qlkara.DATPHONGs.Where(t => t.MADAT == pMaDat).SingleOrDefault();
                if (dt == null)
                    return false;

                qlkara.DATPHONGs.DeleteOnSubmit(dt);
                qlkara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool kiemTraPhong(string pMaPhong)
        {
            try
            {
                PHONG dt = qlkara.PHONGs.Where(t => t.MAPHONG == pMaPhong).SingleOrDefault();
                if (dt == null)
                    return false;
                if (dt.TINHTRANG == "Đang thuê" || dt.TINHTRANG == "Tạm ngưng")
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool kiemTraPhongDangThue(string pMaPhong)
        {
            try
            {
                PHONG dt = qlkara.PHONGs.Where(t => t.MAPHONG == pMaPhong).SingleOrDefault();
                if (dt == null)
                    return false;
                if (dt.TINHTRANG == "Đang thuê")
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool kiemTraPhongTamNgung(string pMaPhong)
        {
            try
            {
                PHONG dt = qlkara.PHONGs.Where(t => t.MAPHONG == pMaPhong).SingleOrDefault();
                if (dt == null)
                    return false;
                if (dt.TINHTRANG == "Tạm ngưng")
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void thayDoiTinhTrangPhong(string pMaPhong)
        {
            try
            {
                PHONG dt = qlkara.PHONGs.Where(t => t.MAPHONG == pMaPhong).SingleOrDefault();
                if (dt == null)
                    return;
                dt.TINHTRANG = "Đang thuê";
                qlkara.SubmitChanges();
            }
            catch
            {
                return;
            }
        }

        public void thayDoiTinhTrangPhongKhiXoa(string pMaPhong)
        {
            try
            {
                PHONG dt = qlkara.PHONGs.Where(t => t.MAPHONG == pMaPhong).SingleOrDefault();
                if (dt == null)
                    return;
                dt.TINHTRANG = "Trống";
                qlkara.SubmitChanges();
            }
            catch
            {
                return;
            }
        }

        public bool kiemTraDatPhongThanhToan(int pMaDat)
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

        //Thao tác trên form gọi dịch vụ
        public int traVeMaDatPhong(string pMaPhong)
        {
            try
            {
                var ds = from k in qlkara.DATPHONGs where k.MAPHONG == pMaPhong orderby k.MADAT descending select k;
                if (ds == null)
                    return -1;
                DATPHONG dp = ds.First();
                return dp.MADAT;
            }
            catch
            {
                return -1;
            }
        }

        public bool kiemTraKhoaChinhListDV(int pMaDat, string pMaSP, List<DichVuDatPhong> ds)
        {
            DichVuDatPhong dvdp = ds.Where(t => t.MaDat == pMaDat && t.MaSP == pMaSP).SingleOrDefault();
            if (dvdp == null)
                return true;
            return false;
        }

        public bool themDichVu(int pMaDat, string pMaPhong, string pMaSP, int pSoLuong, double pDonGia, double pThanhTien, List<DichVuDatPhong> ds)
        {
            try
            {
                DichVuDatPhong dvdp = new DichVuDatPhong();
                dvdp.MaDat = pMaDat;
                dvdp.MaPhong = pMaPhong;                
                dvdp.MaSP = pMaSP;
                dvdp.SoLuong = pSoLuong;
                dvdp.DonGiaBan = pDonGia;
                dvdp.ThanhTien = pThanhTien;
                ds.Add(dvdp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaDichVu(int pMaDat, string pMaPhong, string pMaSP, int pSoLuong, double pDonGia, double pThanhTien, List<DichVuDatPhong> ds)
        {
            try
            {
                DichVuDatPhong dvdp = ds.Where(t => t.MaDat == pMaDat && t.MaSP == pMaSP && t.MaPhong == pMaPhong).SingleOrDefault();
                if (dvdp == null)
                    return false;
                dvdp.SoLuong = pSoLuong;
                dvdp.DonGiaBan = pDonGia;
                dvdp.ThanhTien = pThanhTien;
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaDichVu(int pMaDat, string pMaPhong, string pMaSP, List<DichVuDatPhong> ds)
        {
            try
            {
                DichVuDatPhong dvdp = ds.Where(t => t.MaDat == pMaDat && t.MaSP == pMaSP && t.MaPhong == pMaPhong).SingleOrDefault();
                if (dvdp == null)
                    return false;

                ds.Remove(dvdp);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public class DichVuDatPhong
    {
        string maPhong, maSP;
        int? maDat;

        public int? MaDat
        {
            get { return maDat; }
            set { maDat = value; }
        }

        public string MaPhong
        {
            get { return maPhong; }
            set { maPhong = value; }
        }

        public string MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }
        
        int? soLuong;

        public int? SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        double? donGiaBan, thanhTien;

        public double? DonGiaBan
        {
            get { return donGiaBan; }
            set { donGiaBan = value; }
        }

        public double? ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
        }
        
    }
}
