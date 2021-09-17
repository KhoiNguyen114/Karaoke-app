using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL_DAL
{
    public class BLLDALChiTietNhapHang
    {
        QuanLyQuanKaraokeDataContext ql = new QuanLyQuanKaraokeDataContext();
        public BLLDALChiTietNhapHang()
        {

        }

        public IQueryable loadChiTietNhapHang()
        {
            IQueryable ds = from k in ql.CHITIETPHIEUNHAPs select new { k.MAPN, k.MASP, k.SOLUONG, k.DONGIANHAP, k.THANHTIEN };
            return ds;
        }

        public IQueryable loadChiTietHoaDonTheoMa(int pMaPN)
        {
            IQueryable ds = from k in ql.CHITIETPHIEUNHAPs where k.MAPN == pMaPN select new { k.MAPN, k.MASP, k.SOLUONG, k.DONGIANHAP, k.THANHTIEN };
            return ds;
        }

        public bool ktKhoaChinh(int pMaPhieuNhap, string pMaSP)
        {
            CHITIETPHIEUNHAP pn = ql.CHITIETPHIEUNHAPs.Where(t => t.MAPN == pMaPhieuNhap && t.MASP == pMaSP).SingleOrDefault();
            if (pn == null)
                return true;
            return false;
        }

        public bool ktTinhTrang(int pMaPN)
        {
            PHIEUNHAP pn = ql.PHIEUNHAPs.Where(t => t.MAPN == pMaPN).SingleOrDefault();
            if (pn == null)
                return false;
            if (pn.TINHTRANG == "Hủy")
            {
                return false;
            }
            return true;
        }

        public bool themChiTietPhieuNhap(int pMaPN, string pMaSP, int pSoLuong, double pDonGia, double pThanhTien)
        {
            try
            {
                CHITIETPHIEUNHAP ctpn = new CHITIETPHIEUNHAP();
                ctpn.MAPN = pMaPN;
                ctpn.MASP = pMaSP;
                ctpn.SOLUONG = pSoLuong;
                ctpn.DONGIANHAP = pDonGia;
                ctpn.THANHTIEN = pThanhTien;

                ql.CHITIETPHIEUNHAPs.InsertOnSubmit(ctpn);
                ql.SubmitChanges();

                SANPHAM sp = ql.SANPHAMs.Where(t => t.MASP == pMaSP).SingleOrDefault();
                if (sp == null)
                    return false;
                sp.SOLUONG += pSoLuong;
                ql.SubmitChanges();

                PHIEUNHAP pn = ql.PHIEUNHAPs.Where(t => t.MAPN == pMaPN).SingleOrDefault();
                pn.TONGTIENPN += pSoLuong * pDonGia;
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaChiTietPhieuNhap(int pMaPN, string pMaSP, int pSoLuong, double pDonGia, double pThanhTien)
        {
            try
            {
                CHITIETPHIEUNHAP ctpn = ql.CHITIETPHIEUNHAPs.Where(t => t.MAPN == pMaPN && t.MASP == pMaSP).SingleOrDefault();
                if (ctpn == null)
                    return false;
                ctpn.SOLUONG = pSoLuong;
                ctpn.DONGIANHAP = pDonGia;
                ctpn.THANHTIEN = pThanhTien;

                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaChiTietPhieuNhap(int pMaPN, string pMaSP)
        {
            try
            {
                CHITIETPHIEUNHAP ctpn = ql.CHITIETPHIEUNHAPs.Where(t => t.MAPN == pMaPN && t.MASP == pMaSP).SingleOrDefault();
                if (ctpn == null)
                    return false;

                ql.CHITIETPHIEUNHAPs.DeleteOnSubmit(ctpn);
                ql.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
