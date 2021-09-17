using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALLoaiKhachHang
    {
        QuanLyQuanKaraokeDataContext qlkaraoke = new QuanLyQuanKaraokeDataContext();
        public BLLDALLoaiKhachHang()
        {

        }

        public IQueryable loadLoaiKhachHang()
        {
            IQueryable ds = from k in qlkaraoke.LOAIKHACHHANGs select new { k.MALOAIKH, k.TENLOAI, k.GIAMGIA };
            return ds;
        }

        public bool ktKhoaChinh(string pMaLoai)
        {
            LOAIKHACHHANG kh = qlkaraoke.LOAIKHACHHANGs.Where(t => t.MALOAIKH == pMaLoai).SingleOrDefault();
            if (kh == null)
                return true;
            return false;
        }

        public string traVeGiamGia(string pMaKH)
        {
            KHACHHANG kh = qlkaraoke.KHACHHANGs.Where(t => t.MAKH == pMaKH).SingleOrDefault();
            if (kh == null)
                return null;
            LOAIKHACHHANG lkh = qlkaraoke.LOAIKHACHHANGs.Where(t => t.MALOAIKH == kh.MALOAIKH).SingleOrDefault();
            if (lkh == null)
                return null;
            return lkh.GIAMGIA * 100 + " %";

        }

        public bool themLoaiKH(string pMaLoai, string pTenLoai, double pGiamGia)
        {
            try
            {
                LOAIKHACHHANG loaiKH = new LOAIKHACHHANG();
                loaiKH.MALOAIKH = pMaLoai;
                loaiKH.TENLOAI = pTenLoai;
                loaiKH.GIAMGIA = pGiamGia;

                qlkaraoke.LOAIKHACHHANGs.InsertOnSubmit(loaiKH);
                qlkaraoke.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaLoaiKH(string pMaLoai, string pTenLoai, double pGiamGia)
        {
            try
            {
                LOAIKHACHHANG loaiKH = qlkaraoke.LOAIKHACHHANGs.Where(t => t.MALOAIKH == pMaLoai).SingleOrDefault();
                if (loaiKH == null)
                    return false;
                loaiKH.TENLOAI = pTenLoai;
                loaiKH.GIAMGIA = pGiamGia;

                qlkaraoke.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaLoaiKH(string pMaLoai)
        {
            try
            {
                LOAIKHACHHANG loaiKH = qlkaraoke.LOAIKHACHHANGs.Where(t => t.MALOAIKH == pMaLoai).SingleOrDefault();
                if (loaiKH == null)
                    return false;
                qlkaraoke.LOAIKHACHHANGs.DeleteOnSubmit(loaiKH);
                qlkaraoke.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
