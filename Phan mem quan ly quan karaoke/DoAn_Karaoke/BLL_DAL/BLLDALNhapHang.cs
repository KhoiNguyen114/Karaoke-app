using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALNhapHang
    {
        QuanLyQuanKaraokeDataContext ql = new QuanLyQuanKaraokeDataContext();
        public BLLDALNhapHang()
        {

        }

        public IQueryable loadNhapHang()
        {
            IQueryable ds = from k in ql.PHIEUNHAPs select new { k.MAPN, k.MANV, k.MANCC, k.NGAYLAPPN, k.TONGTIENPN, k.TINHTRANG };
            return ds;
        }
        
        public List<string> loadTInhTrang()
        {
            List<string> ds = new List<string>();
            ds.Add("Có hiệu lực");
            ds.Add("Hủy");
            return ds;
        }

        public bool ktKhoaChinh(int pMaPhieuNhap)
        {
            PHIEUNHAP pn = ql.PHIEUNHAPs.Where(t => t.MAPN == pMaPhieuNhap).SingleOrDefault();
            if (pn == null)
                return true;
            return false;
        }

        public bool themPhieuNhap(string pMaNV, string pMaNCC, DateTime pNgayLap)
        {
            try
            {
                PHIEUNHAP pn = new PHIEUNHAP();
                pn.MANV = pMaNV;
                pn.MANCC = pMaNCC;
                pn.NGAYLAPPN = pNgayLap;
                pn.TONGTIENPN = 0;
                pn.TINHTRANG = "Có hiệu lực";

                ql.PHIEUNHAPs.InsertOnSubmit(pn);
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaPhieuNhap(int pMaPN, string pMaNV, string pMaNCC, DateTime pNgayLap, double pTongTien)
        {
            try
            {
                PHIEUNHAP pn = ql.PHIEUNHAPs.Where(t => t.MAPN == pMaPN).SingleOrDefault();
                if (pn == null)
                    return false;
                pn.MANV = pMaNV;
                pn.MANCC = pMaNCC;
                pn.NGAYLAPPN = pNgayLap;
                pn.TONGTIENPN = pTongTien;

                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaPhieuNhap(int pMaPN)
        {
            try
            {
                PHIEUNHAP pn = ql.PHIEUNHAPs.Where(t => t.MAPN == pMaPN).SingleOrDefault();
                if (pn == null)
                    return false;

                ql.PHIEUNHAPs.DeleteOnSubmit(pn);
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool khoiPhucSoLuongHuy(int pMaPN)
        {
            try
            {
                PHIEUNHAP pn = ql.PHIEUNHAPs.Where(t => t.MAPN == pMaPN).SingleOrDefault();
                if (pn == null)
                    return false;
                pn.TINHTRANG = "Hủy";
                ql.SubmitChanges();

                List<CHITIETPHIEUNHAP> ds = ql.CHITIETPHIEUNHAPs.Where(t => t.MAPN == pMaPN).ToList();
                for (int i = 0; i < ds.Count; i++)
                {
                    string ma = ds[i].MASP;
                    SANPHAM sp = ql.SANPHAMs.Where(t => t.MASP == ma).SingleOrDefault();
                    sp.SOLUONG -= ds[i].SOLUONG;
                    ql.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
