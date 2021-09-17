using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALKhachHang
    {
        QuanLyQuanKaraokeDataContext qlkraoke = new QuanLyQuanKaraokeDataContext();
        public BLLDALKhachHang()
        {

        }
        
        public IQueryable loadKhachHang()
        {
            IQueryable ds = from k in qlkraoke.KHACHHANGs select new { k.MAKH, k.TENKH, k.GIOITINH, k.NGAYSINH, k.DIENTHOAI, k.DIACHI, k.MALOAIKH };
            return ds;
        }       

        public bool ktKhoaChinh(string pMaKH)
        {
            KHACHHANG kh = qlkraoke.KHACHHANGs.Where(t => t.MAKH == pMaKH).SingleOrDefault();
            if (kh == null)
                return true;
            return false;
        }

        public bool themKhachHang(string pMaKH, string pTenKH, string pGioiTinh, DateTime pNgaySinh, string pDienThoai, string pDiaChi, string pMaLoaiKH)
        {
            try
            {
                KHACHHANG kh = new KHACHHANG();
                kh.MAKH = pMaKH;
                kh.TENKH = pTenKH;
                kh.GIOITINH = pGioiTinh;
                kh.NGAYSINH = pNgaySinh;
                kh.DIENTHOAI = pDienThoai;
                kh.DIACHI = pDiaChi;
                kh.MALOAIKH = pMaLoaiKH;

                qlkraoke.KHACHHANGs.InsertOnSubmit(kh);
                qlkraoke.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaKhachHang(string pMaKH, string pTenKH, string pGioiTinh, DateTime pNgaySinh, string pDienThoai, string pDiaChi, string pMaLoaiKH)
        {
            try
            {
                KHACHHANG kh = qlkraoke.KHACHHANGs.Where(t => t.MAKH == pMaKH).SingleOrDefault();
                if (kh == null)
                    return false;
                kh.TENKH = pTenKH;
                kh.GIOITINH = pGioiTinh;
                kh.NGAYSINH = pNgaySinh;
                kh.DIENTHOAI = pDienThoai;
                kh.DIACHI = pDiaChi;
                kh.MALOAIKH = pMaLoaiKH;

                qlkraoke.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaKhachHang(string pMaKH)
        {
            try
            {
                KHACHHANG kh = qlkraoke.KHACHHANGs.Where(t => t.MAKH == pMaKH).SingleOrDefault();
                if (kh == null)
                    return false;
                qlkraoke.KHACHHANGs.DeleteOnSubmit(kh);
                qlkraoke.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string traVeTenLoaiKhachHang(string pMaLoaiKH)
        {
            try
            {
                string kq = "";
                LOAIKHACHHANG loaiKH = qlkraoke.LOAIKHACHHANGs.Where(t => t.MALOAIKH == pMaLoaiKH).SingleOrDefault();
                kq = loaiKH.TENLOAI;
                return kq;
            }
            catch
            {
                return null;
            }
        }

        public string traVeTenKhachHang(string pMaKH)
        {
            try
            {
                KHACHHANG kh = qlkraoke.KHACHHANGs.Where(t => t.MAKH == pMaKH).SingleOrDefault();
                if (kh == null)
                    return null;
                return kh.TENKH;
            }
            catch
            {
                return null;
            }
        }
    }
}
