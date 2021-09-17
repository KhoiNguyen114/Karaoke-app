using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALNguoiDung
    {
        QuanLyQuanKaraokeDataContext qlkara = new QuanLyQuanKaraokeDataContext();
        public BLLDALNguoiDung()
        {

        }

        public IQueryable loadNguoiDung()
        {
            IQueryable ds = from k in qlkara.NGUOIDUNGs select new { k.MANV, k.TENDN };
            return ds;
        }

        public bool dangNhap(string pTenDangNhap, string pMatKhau)
        {
            NGUOIDUNG nv = qlkara.NGUOIDUNGs.Where(t => t.TENDN == pTenDangNhap && t.MATKHAU == pMatKhau).SingleOrDefault();
            if (nv == null)
                return false;
            return true;
        }

        public bool kiemTraMatKhauCu(string pTenDangNhap, string pMatKhau)
        {
            NGUOIDUNG nv = qlkara.NGUOIDUNGs.Where(t => t.TENDN == pTenDangNhap && t.MATKHAU == pMatKhau).SingleOrDefault();
            if (nv == null)
                return false;
            return true;
        }

        public bool doiMatKhau(string pTenDangNhap, string pMatKhauMoi)
        {
            try
            {
                NGUOIDUNG nd = qlkara.NGUOIDUNGs.Where(t => t.TENDN == pTenDangNhap).SingleOrDefault();
                if (nd == null)
                    return false;
                nd.MATKHAU = pMatKhauMoi;
                qlkara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public NGUOIDUNG traVeNguoiDung(string pTenDN)
        {
            NGUOIDUNG ng = qlkara.NGUOIDUNGs.Where(t => t.TENDN == pTenDN).SingleOrDefault();
            if (ng == null)
                return null;
            return ng;
        }

        public bool ktKhoaChinh(string pTenDN)
        {
            NGUOIDUNG ng = qlkara.NGUOIDUNGs.Where(t => t.TENDN == pTenDN).SingleOrDefault();
            if (ng == null)
                return true;
            return false;
        }

        public bool ktTrungNhanVien(string pMaNV)
        {
            NGUOIDUNG ng = qlkara.NGUOIDUNGs.Where(t => t.MANV == pMaNV).SingleOrDefault();
            if (ng == null)
                return true;
            return false;
        }

        public bool themNguoiDung(string pTenDN, string pMatKhau, string pMaNV)
        {
            try
            {
                NGUOIDUNG ng = new NGUOIDUNG();
                ng.MANV = pMaNV;
                ng.TENDN = pTenDN;
                ng.MATKHAU = pMatKhau;

                qlkara.NGUOIDUNGs.InsertOnSubmit(ng);
                qlkara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaNguoiDung(string pMaNV)
        {
            try
            {
                NGUOIDUNG ng = qlkara.NGUOIDUNGs.Where(t => t.MANV == pMaNV).SingleOrDefault();
                if (ng == null)
                    return false;

                qlkara.NGUOIDUNGs.DeleteOnSubmit(ng);
                qlkara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool kiemTraTrungTenTaiKhoan(string pMaNV, string pTenDN)
        {
            try
            {
                NGUOIDUNG ng = qlkara.NGUOIDUNGs.Where(t => t.MANV == pMaNV).SingleOrDefault();
                if (ng == null)
                    return false;
                if (ng.TENDN == pTenDN)
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
