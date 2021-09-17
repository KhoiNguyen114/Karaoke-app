using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALNhaCungCap
    {
        QuanLyQuanKaraokeDataContext qlkara = new QuanLyQuanKaraokeDataContext();
        public BLLDALNhaCungCap()
        {

        }

        public IQueryable loadNhaCungCap()
        {
            IQueryable ds = from k in qlkara.NHACUNGCAPs select new { k.MANCC, k.TENNCC, k.DIENTHOAI, k.DIACHI };
            return ds;
        }

        public string traVeTenNhaCungCap(string pMaNCC)
        {
            try
            {
                string kq = "";
                NHACUNGCAP nhaCungCap = qlkara.NHACUNGCAPs.Where(t => t.MANCC == pMaNCC).SingleOrDefault();
                kq = nhaCungCap.TENNCC;
                return kq;
            }
            catch
            {
                return null;
            }
        }

        public bool ktKhoaChinh(string pMaNCC)
        {
            NHACUNGCAP nc = qlkara.NHACUNGCAPs.Where(t => t.MANCC == pMaNCC).SingleOrDefault();
            if (nc == null)
                return true;
            return false;
        }

        public bool themNhaCungCap(string pMaNCC, string pTenNCC, string pDienThoai, string pDiaChi)
        {
            try
            {
                NHACUNGCAP nc = new NHACUNGCAP();
                nc.MANCC = pMaNCC;
                nc.TENNCC = pTenNCC;
                nc.DIACHI = pDiaChi;
                nc.DIENTHOAI = pDienThoai;

                qlkara.NHACUNGCAPs.InsertOnSubmit(nc);
                qlkara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaNhaCungCap(string pMaNCC, string pTenNCC, string pDienThoai, string pDiaChi)
        {
            try
            {
                NHACUNGCAP nc = qlkara.NHACUNGCAPs.Where(t => t.MANCC == pMaNCC).SingleOrDefault();
                if (nc == null)
                    return false;
                nc.TENNCC = pTenNCC;
                nc.DIACHI = pDiaChi;
                nc.DIENTHOAI = pDienThoai;

                qlkara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaNhaCungCap(string pMaNCC)
        {
            try
            {
                NHACUNGCAP nc = qlkara.NHACUNGCAPs.Where(t => t.MANCC == pMaNCC).SingleOrDefault();
                if (nc == null)
                    return false;

                qlkara.NHACUNGCAPs.DeleteOnSubmit(nc);
                qlkara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
