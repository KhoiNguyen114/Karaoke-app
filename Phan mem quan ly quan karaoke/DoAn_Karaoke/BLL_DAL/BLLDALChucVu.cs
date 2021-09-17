using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALChucVu
    {
        QuanLyQuanKaraokeDataContext qlkaraoke = new QuanLyQuanKaraokeDataContext();
        public BLLDALChucVu()
        {

        }

        public IQueryable loadChucVu()
        {
            IQueryable ds = from c in qlkaraoke.CHUCVUs select new { c.MACV, c.TENCV, c.LUONGCB };
            return ds;
        }

        public bool ktKhoaChinh(string pMaCV)
        {
            CHUCVU cv = qlkaraoke.CHUCVUs.Where(t => t.MACV == pMaCV).SingleOrDefault();
            if (cv == null)
                return true;
            return false;
        }

        public string traVeTenChucVu(string pMaCV)
        {
            try
            {
                string kq = "";
                CHUCVU chucvu = qlkaraoke.CHUCVUs.Where(t => t.MACV == pMaCV).SingleOrDefault();
                kq = chucvu.TENCV;
                return kq;
            }
            catch
            {
                return null;
            }
        }

        public string traVeTenChucVuTinhLuong(string pMaNV)
        {
            try
            {
                string kq = "";
                NHANVIEN nv = qlkaraoke.NHANVIENs.Where(t => t.MANV == pMaNV).SingleOrDefault();
                if (nv == null)
                    return null;
                CHUCVU chucvu = qlkaraoke.CHUCVUs.Where(t => t.MACV == nv.MACV).SingleOrDefault();
                kq = chucvu.TENCV;
                return kq;
            }
            catch
            {
                return null;
            }
        }

        public double? traVeLuongCB(string pMaNV)
        {
            try
            {
                NHANVIEN nv = qlkaraoke.NHANVIENs.Where(t => t.MANV == pMaNV).SingleOrDefault();
                if (nv == null)
                    return -1;
                CHUCVU chucvu = qlkaraoke.CHUCVUs.Where(t => t.MACV == nv.MACV).SingleOrDefault();                
                return chucvu.LUONGCB;
            }
            catch
            {
                return -1;
            }
        }

        public bool themChucVu(string pMaCV, string pTenCV, double pLuongCB)
        {
            try
            {
                CHUCVU chucVu = new CHUCVU();
                chucVu.MACV = pMaCV;
                chucVu.TENCV = pTenCV;
                chucVu.LUONGCB = pLuongCB;

                qlkaraoke.CHUCVUs.InsertOnSubmit(chucVu);
                qlkaraoke.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaChucVu(string pMaCV, string pTenCV, double pLuongCB)
        {
            try
            {
                CHUCVU chucVu = qlkaraoke.CHUCVUs.Where(t => t.MACV == pMaCV).SingleOrDefault();
                if (chucVu == null)
                    return false;
                chucVu.TENCV = pTenCV;
                chucVu.LUONGCB = pLuongCB;

                qlkaraoke.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaChucVu(string pMaCV)
        {
            try
            {
                CHUCVU chucVu = qlkaraoke.CHUCVUs.Where(t => t.MACV == pMaCV).SingleOrDefault();
                if (chucVu == null)
                    return false;
                qlkaraoke.CHUCVUs.DeleteOnSubmit(chucVu);
                qlkaraoke.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ktChucVuCoNhanVien(string pMaCV)
        {
            try
            {
                NHANVIEN nv = qlkaraoke.NHANVIENs.Where(t => t.MACV == pMaCV).SingleOrDefault();
                if (nv == null)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
