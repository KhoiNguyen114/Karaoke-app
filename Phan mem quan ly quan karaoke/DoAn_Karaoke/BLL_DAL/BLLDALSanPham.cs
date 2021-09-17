using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL_DAL
{
    public class BLLDALSanPham
    {
        QuanLyQuanKaraokeDataContext qlKara = new QuanLyQuanKaraokeDataContext();
        public BLLDALSanPham()
        {

        }

        public IQueryable loadSanPham()
        {
            qlKara.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, qlKara.SANPHAMs);
            IQueryable ds = from sp in qlKara.SANPHAMs select new { sp.MASP, sp.TENSP, sp.SOLUONG, sp.DONGIANHAP, sp.DONGIABAN, sp.MALOAI, sp.MANCC, sp.TINHTRANG };
            return ds;
        }

        public List<SANPHAM> loadSanPhamCombobox()
        {
            qlKara.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, qlKara.SANPHAMs);
            var ds = new List<SANPHAM>();
            ds = (from sp in qlKara.SANPHAMs select sp).ToList();
            return ds;
        }       

        public IQueryable loadDanhSachSanPhamTheoTimKiem(string ptenSanPham)
        {
            IQueryable ds = from sp in qlKara.SANPHAMs where sp.TENSP.Contains(ptenSanPham) || sp.MASP.Contains(ptenSanPham) select new { sp.MASP, sp.TENSP, sp.SOLUONG, sp.DONGIANHAP, sp.DONGIABAN, sp.MALOAI, sp.MANCC, sp.TINHTRANG };
            return ds;
        }

        public bool ktKhoaChinh(string MaSP)
        {
            SANPHAM sp = qlKara.SANPHAMs.Where(t => t.MASP == MaSP).SingleOrDefault();
            if (sp == null)
                return true;
            return false;
        }


        public string traVeTenSanPham(string pMaSP)
        {
            try
            {
                SANPHAM sp = qlKara.SANPHAMs.Where(t => t.MASP == pMaSP).SingleOrDefault();
                if (sp == null)
                    return null;
                return sp.TENSP;
            }
            catch
            {
                return null;
            }
        }

        public int? traVeSoLuong(string pMaSP)
        {
            try
            {
                SANPHAM sp = qlKara.SANPHAMs.Where(t => t.MASP == pMaSP).SingleOrDefault();
                if (sp == null)
                    return null;
                return sp.SOLUONG;
            }
            catch
            {
                return null;
            }
        }

        public double? traVeDonGiaBan(string pMaSP)
        {
            SANPHAM sp = qlKara.SANPHAMs.Where(t => t.MASP == pMaSP).SingleOrDefault();
            if (sp == null)
                return -1;
            return sp.DONGIABAN;
        }

        public double? traVeDonGiaNhap(string pMaSP)
        {
            SANPHAM sp = qlKara.SANPHAMs.Where(t => t.MASP == pMaSP).SingleOrDefault();
            if (sp == null)
                return -1;
            return sp.DONGIANHAP;
        }

        public void capNhatTinhTrang()
        {
            qlKara.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, qlKara.SANPHAMs);
            List<SANPHAM> dssp = qlKara.SANPHAMs.ToList();
            foreach(SANPHAM sp in dssp)
            {
                if (sp.SOLUONG == 0)
                {
                    sp.TINHTRANG = "Hết hàng";
                    qlKara.SubmitChanges();
                }
                else
                {
                    sp.TINHTRANG = "Còn";
                    qlKara.SubmitChanges();
                }
            }
        }

        //Kiểm tra tổng số lượng trong list
        public int? tongSoLuongSPTrongList(string pMaSP, List<DichVuDatPhong> ds)
        {
            int? soLuong = 0;
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaSP == pMaSP)
                {
                    soLuong += ds[i].SoLuong;
                }
            }
            return soLuong;
        }

        //Khi cập nhật thì trên list là 400, textbox là 495 thì sẽ tính ra hiệu số là 95
        public int? traVeHieuSoSPKhiCapNhat(string pMaSP, int pMaDat, int pSoLuong, List<DichVuDatPhong> ds)
        {
            int? soLuong = 0;
            int a = pSoLuong;
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaSP == pMaSP && ds[i].MaDat == pMaDat)
                {
                    soLuong += ds[i].SoLuong;
                }
            }
            return a - soLuong;
        }

        public bool themSP(string MaSP, string TenSP, int soluong, double gianhap, double giaban, string maloai, string mancc)
        {
            try
            {
                SANPHAM sp = new SANPHAM();
                sp.MASP = MaSP;
                sp.TENSP = TenSP;
                sp.SOLUONG = soluong;
                sp.DONGIANHAP = gianhap;
                sp.DONGIABAN = giaban;
                sp.MALOAI = maloai;
                sp.MANCC = mancc;

                if (soluong > 0)
                {
                    sp.TINHTRANG = "Còn";
                }
                else
                {
                    sp.TINHTRANG = "Hết hàng";
                }
                qlKara.SANPHAMs.InsertOnSubmit(sp);
                qlKara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaSP(string MaSP, string TenSP, int soluong, double gianhap, double giaban, string maloai, string mancc)
        {
            try
            {
                SANPHAM sp = qlKara.SANPHAMs.Where(t => t.MASP == MaSP).SingleOrDefault();
                if (sp == null)
                    return false;

                sp.TENSP = TenSP;
                sp.SOLUONG = soluong;
                sp.DONGIANHAP = gianhap;
                sp.DONGIABAN = giaban;
                sp.MALOAI = maloai;
                sp.MANCC = mancc;

                if (soluong > 0)
                {
                    sp.TINHTRANG = "Còn";
                }
                else
                {
                    sp.TINHTRANG = "Hết hàng";
                }

                qlKara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaSP(string MaSP)
        {
            try
            {
                SANPHAM sp = qlKara.SANPHAMs.Where(t => t.MASP == MaSP).SingleOrDefault();
                if (sp == null)
                    return false;

                qlKara.SANPHAMs.DeleteOnSubmit(sp);
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
