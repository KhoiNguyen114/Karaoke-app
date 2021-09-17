using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL_DAL
{
    public class BLLDALChiTietHoaDon
    {
        QuanLyQuanKaraokeDataContext qlkara = new QuanLyQuanKaraokeDataContext();
        public BLLDALChiTietHoaDon()
        {

        }

        public IQueryable loadChiTietHoaDon()
        {
            IQueryable ds = from k in qlkara.CHITIETHOADONs select new { k.MAHD, k.MASP, k.SOLUONG, k.DONGIABAN, k.THANHTIEN };
            return ds;
        }

        public IQueryable loadChiTietHoaDonTheoMa(int pMaHD)
        {
            IQueryable ds = from k in qlkara.CHITIETHOADONs where k.MAHD == pMaHD select new { k.MAHD, k.MASP, k.SOLUONG, k.DONGIABAN, k.THANHTIEN };
            return ds;
        }

        public bool ktKhoaChinhCTHD(int pMaHD, string pMaSP)
        {
            CHITIETHOADON cthd = qlkara.CHITIETHOADONs.Where(t => t.MAHD == pMaHD && t.MASP == pMaSP).SingleOrDefault();
            if (cthd == null)
                return true;
            return false;
        }

        public int? traVeSoLuong(int pMaHD, string pMaSP)
        {
            CHITIETHOADON cthd = qlkara.CHITIETHOADONs.Where(t => t.MAHD == pMaHD && t.MASP == pMaSP).SingleOrDefault();
            if (cthd == null)
                return -1;
            return cthd.SOLUONG;
        }

        public bool themCTHD(int pMaHD, string pMaSP, int pSoLuong, double pDonGiaBan, double pThanhTien)
        {
            try
            {
                CHITIETHOADON cthd = new CHITIETHOADON();
                cthd.MAHD = pMaHD;
                cthd.MASP = pMaSP;
                cthd.SOLUONG = pSoLuong;
                cthd.DONGIABAN = pDonGiaBan;
                cthd.THANHTIEN = pThanhTien;

                qlkara.CHITIETHOADONs.InsertOnSubmit(cthd);
                qlkara.SubmitChanges();

                SANPHAM sp = qlkara.SANPHAMs.Where(t => t.MASP == pMaSP).SingleOrDefault();
                if (sp == null)
                    return false;
                sp.SOLUONG -= pSoLuong;
                qlkara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaCTHD(int pMaHD, string pMaSP, int pSoLuong, double pDonGiaBan, double pThanhTien)
        {
            try
            {
                CHITIETHOADON cthd = qlkara.CHITIETHOADONs.Where(t => t.MAHD == pMaHD && t.MASP == pMaSP).SingleOrDefault();
                if (cthd == null)
                    return false;
                cthd.SOLUONG = pSoLuong;
                cthd.DONGIABAN = pDonGiaBan;
                cthd.THANHTIEN = pThanhTien;

                qlkara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaCTHD(int pMaHD, string pMaSP)
        {
            try
            {
                CHITIETHOADON cthd = qlkara.CHITIETHOADONs.Where(t => t.MAHD == pMaHD && t.MASP == pMaSP).SingleOrDefault();
                if (cthd == null)
                    return false;

                qlkara.CHITIETHOADONs.DeleteOnSubmit(cthd);
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
