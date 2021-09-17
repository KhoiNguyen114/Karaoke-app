using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALPhong
    {
        QuanLyQuanKaraokeDataContext qlKara = new QuanLyQuanKaraokeDataContext();
        public BLLDALPhong()
        {

        }

        public IQueryable loadPhong()
        {
            IQueryable ds = from k in qlKara.PHONGs select new { k.MAPHONG, k.TENPHONG, k.GIAPHONG, k.TINHTRANG };
            return ds;
        }

        public bool ktKhoaChinh(string pMaPhong)
        {
            PHONG p = qlKara.PHONGs.Where(t => t.MAPHONG == pMaPhong).SingleOrDefault();
            if (p == null)
                return true;
            return false;
        }

        public string traVeTenPhong(string pMaPhong)
        {
            PHONG p = qlKara.PHONGs.Where(t => t.MAPHONG == pMaPhong).SingleOrDefault();
            if (p == null)
                return null;
            return p.TENPHONG;
        }

        public string traVeTinhTrang(string pMaPhong)
        {
            PHONG p = qlKara.PHONGs.Where(t => t.MAPHONG == pMaPhong).SingleOrDefault();
            if (p == null)
                return null;
            return p.TINHTRANG;
        }

        public string traVeMaPhong(string pTenPhong)
        {
            PHONG p = qlKara.PHONGs.Where(t => t.TENPHONG == pTenPhong).SingleOrDefault();
            if (p == null)
                return null;
            return p.MAPHONG;
        }

        public List<string> loadCombobox()
        {
            List<string> ds = new List<string>();
            ds.Add("Trống");
            ds.Add("Đang thuê");
            ds.Add("Tạm ngưng");
            return ds;
        }

        public bool themPhong(string pMaPhong, string pTenPhong, double pGiaPhong, string pTinhTrang)
        {
            try
            {
                PHONG p = new PHONG();
                p.MAPHONG = pMaPhong;
                p.TENPHONG = pTenPhong;
                p.GIAPHONG = pGiaPhong;
                p.TINHTRANG = pTinhTrang;

                qlKara.PHONGs.InsertOnSubmit(p);
                qlKara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaPhong(string pMaPhong, string pTenPhong, double pGiaPhong, string pTinhTrang)
        {
            try
            {
                PHONG p = qlKara.PHONGs.Where(t => t.MAPHONG == pMaPhong).SingleOrDefault();
                if (p == null)
                    return false;
                p.TENPHONG = pTenPhong;
                p.GIAPHONG = pGiaPhong;
                p.TINHTRANG = pTinhTrang;

                qlKara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaPhong(string pMaPhong)
        {
            try
            {
                PHONG p = qlKara.PHONGs.Where(t => t.MAPHONG == pMaPhong).SingleOrDefault();
                if (p == null)
                    return false;

                qlKara.PHONGs.DeleteOnSubmit(p);
                qlKara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
