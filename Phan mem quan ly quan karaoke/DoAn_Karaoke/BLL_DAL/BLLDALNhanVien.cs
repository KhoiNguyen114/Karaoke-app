using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALNhanVien
    {
        QuanLyQuanKaraokeDataContext qlkaraoke = new QuanLyQuanKaraokeDataContext();
        public BLLDALNhanVien()
        {

        }

        public IQueryable loadNhanVien()
        {
            IQueryable ds = from nv in qlkaraoke.NHANVIENs select new { nv.MANV, nv.TENNV, nv.GIOITINH, nv.NGAYSINH, nv.DIENTHOAI, nv.DIACHI, nv.MACV, nv.NGAYVL };
            return ds;
        }

        public string traVeTenNhanVien(string pMaNV)
        {
            try
            {
                NHANVIEN nv = qlkaraoke.NHANVIENs.Where(t => t.MANV == pMaNV).SingleOrDefault();
                if (nv == null)
                    return null;
                return nv.TENNV;
            }
            catch
            {
                return null;
            }
        }

        public string traVeMaNhanVien(string pTenDN)
        {
            try
            {
                NGUOIDUNG ng = qlkaraoke.NGUOIDUNGs.Where(t => t.TENDN == pTenDN).SingleOrDefault();
                if (ng == null)
                    return null;
                NHANVIEN nv = qlkaraoke.NHANVIENs.Where(t => t.MANV == ng.MANV).SingleOrDefault();
                if (nv == null)
                    return null;
                return nv.MANV;
            }
            catch
            {
                return null;
            }
        }

        public string traVeNhanVienDiemDanh(string pTenDN)
        {
            try
            {
                NGUOIDUNG ng = qlkaraoke.NGUOIDUNGs.Where(t => t.TENDN == pTenDN).SingleOrDefault();
                if (ng == null)
                    return null;
                NHANVIEN nv = qlkaraoke.NHANVIENs.Where(t => t.MANV == ng.MANV).SingleOrDefault();
                if (nv == null)
                    return null;
                return nv.TENNV;
            }
            catch
            {
                return null;
            }
        }

        public bool ktKhoaChinh(string pMaNV)
        {
            NHANVIEN nv = qlkaraoke.NHANVIENs.Where(t => t.MANV == pMaNV).SingleOrDefault();
            if (nv == null)
                return true;
            return false;
        }

        public bool themNhanVien(string pMaNV, string pTenNV, string pGioiTinh, DateTime pNgaySinh, string pDienThoai, string pDiaChi, string pMaCV, DateTime pNgayVL)
        {
            try
            {
                NHANVIEN nv = new NHANVIEN();
                nv.MANV = pMaNV;
                nv.TENNV = pTenNV;
                nv.GIOITINH = pGioiTinh;
                nv.NGAYSINH = pNgaySinh;
                nv.DIENTHOAI = pDienThoai;
                nv.DIACHI = pDiaChi;
                nv.MACV = pMaCV;
                nv.NGAYVL = pNgayVL;

                qlkaraoke.NHANVIENs.InsertOnSubmit(nv);
                qlkaraoke.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaNhanVien(string pMaNV, string pTenNV, string pGioiTinh, DateTime pNgaySinh, string pDienThoai, string pDiaChi, string pMaCV, DateTime pNgayVL)
        {
            try
            {
                NHANVIEN nv = qlkaraoke.NHANVIENs.Where(t => t.MANV == pMaNV).SingleOrDefault();
                if (nv == null)
                    return false;
                nv.TENNV = pTenNV;
                nv.GIOITINH = pGioiTinh;
                nv.NGAYSINH = pNgaySinh;
                nv.DIENTHOAI = pDienThoai;
                nv.DIACHI = pDiaChi;
                nv.MACV = pMaCV;
                nv.NGAYVL = pNgayVL;

                qlkaraoke.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaNhanVien(string pMaNV)
        {
            try
            {
                NHANVIEN nv = qlkaraoke.NHANVIENs.Where(t => t.MANV == pMaNV).SingleOrDefault();
                if (nv == null)
                    return false;
                qlkaraoke.NHANVIENs.DeleteOnSubmit(nv);
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
