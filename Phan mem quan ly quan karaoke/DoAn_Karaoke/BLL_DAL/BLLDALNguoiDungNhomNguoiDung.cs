using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALNguoiDungNhomNguoiDung
    {
        QuanLyQuanKaraokeDataContext qlkara = new QuanLyQuanKaraokeDataContext();
        public BLLDALNguoiDungNhomNguoiDung()
        {

        }
        public IQueryable LoadQLNguoiDung()
        {

            IQueryable ng = from k in qlkara.QL_NGUOIDUNGNHOMNGUOIDUNGs select new { k.TENDN, k.MANHOM, k.GHICHU };
            return ng;

        }

        public IQueryable LoadMaNhom()
        {
            IQueryable ma = from m in qlkara.NHOMNGUOIDUNGs select new { m.MANHOM, m.TENNHOM };
            return ma;

        }

        public IQueryable LoadTenDN()
        {
            IQueryable ten = from t in qlkara.NGUOIDUNGs select new { t.TENDN };
            return ten;
        }

        public string traVeTenNhom(string pMaNhom)
        {
            NHOMNGUOIDUNG ng = qlkara.NHOMNGUOIDUNGs.Where(t => t.MANHOM == pMaNhom).SingleOrDefault();
            if (ng == null)
                return null;
            return ng.TENNHOM;
        }

        public bool ThemQLNguoiDung(string _TenDN, string _MaNhom, string _GhiChu)
        {
            try
            {
                QL_NGUOIDUNGNHOMNGUOIDUNG ngdung = new QL_NGUOIDUNGNHOMNGUOIDUNG();
                ngdung.TENDN = _TenDN;
                ngdung.MANHOM = _MaNhom;
                ngdung.GHICHU = _GhiChu;

                qlkara.QL_NGUOIDUNGNHOMNGUOIDUNGs.InsertOnSubmit(ngdung);
                qlkara.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool xoaQLNguoiDung(string pTenDN, string pMaNhom)
        {
            try
            {
                QL_NGUOIDUNGNHOMNGUOIDUNG nv = qlkara.QL_NGUOIDUNGNHOMNGUOIDUNGs.Where(t => t.TENDN == pTenDN && t.MANHOM == pMaNhom).SingleOrDefault();
                if (nv == null)
                    return false;

                qlkara.QL_NGUOIDUNGNHOMNGUOIDUNGs.DeleteOnSubmit(nv);
                qlkara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ktKhoaChinhQLNguoiDung(string pTenDN, string pMaNhom)
        {
            QL_NGUOIDUNGNHOMNGUOIDUNG ng = qlkara.QL_NGUOIDUNGNHOMNGUOIDUNGs.Where(t => t.TENDN == pTenDN && t.MANHOM == pMaNhom).SingleOrDefault();
            if (ng == null)
                return true;
            return false;
        }
    }
}
