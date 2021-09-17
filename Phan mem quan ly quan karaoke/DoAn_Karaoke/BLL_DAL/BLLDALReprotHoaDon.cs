using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALReprotHoaDon
    {
        QuanLyQuanKaraokeDataContext qlkara = new QuanLyQuanKaraokeDataContext();
        public DataTable xuatHoaDon(int pMaHD)
        {
            var ds = (from k in qlkara.HOADONs
                      join cthd in qlkara.CHITIETHOADONs on k.MAHD equals cthd.MAHD
                      join sp in qlkara.SANPHAMs on cthd.MASP equals sp.MASP
                      join nv in qlkara.NHANVIENs on k.MANV equals nv.MANV
                      join kh in qlkara.KHACHHANGs on k.MAKH equals kh.MAKH
                      where k.MAHD == pMaHD
                      select new
                      {
                            k.MAHD,
                            k.NGAYLAPHD,
                            kh.TENKH,
                            nv.TENNV,
                            sp.TENSP,
                            cthd.SOLUONG,
                            cthd.DONGIABAN,
                            cthd.THANHTIEN,
                            k.TIENPHONG,
                            k.TIENDICHVU,
                            k.TONGTIENHD,
                            k.THANHTOAN,
                      }).ToList();
            DataTable dt = new DataTable();
            dt = ToDataTable(ds);
            return dt;
        }

        public DateTime? traVeNgayLap(int pMaHD)
        {
            HOADON hd = qlkara.HOADONs.Where(t => t.MAHD == pMaHD).SingleOrDefault();
            if (hd == null)
                return null;
            return hd.NGAYLAPHD;
        }

        public double? traVeTongTien(int pMaHD)
        {
            HOADON hd = qlkara.HOADONs.Where(t => t.MAHD == pMaHD).SingleOrDefault();
            if (hd == null)
                return null;
            return hd.TONGTIENHD;
        }
        public double? traVeThanhToan(int pMaHD)
        {
            HOADON hd = qlkara.HOADONs.Where(t => t.MAHD == pMaHD).SingleOrDefault();
            if (hd == null)
                return null;
            return hd.THANHTOAN;
        }

        public double? traVeTienPhong(int pMaHD)
        {
            HOADON hd = qlkara.HOADONs.Where(t => t.MAHD == pMaHD).SingleOrDefault();
            if (hd == null)
                return null;
            return hd.TIENPHONG;
        }

        public double? traVeTienDichVu(int pMaHD)
        {
            HOADON hd = qlkara.HOADONs.Where(t => t.MAHD == pMaHD).SingleOrDefault();
            if (hd == null)
                return null;
            return hd.TIENDICHVU;
        }

        public DateTime? traVeGioVao(int pMaHD)
        {
            HOADON hd = qlkara.HOADONs.Where(t => t.MAHD == pMaHD).SingleOrDefault();
            if (hd == null)
                return null;
            return hd.GIOVAO;
        }

        public DateTime? traVeGioRa(int pMaHD)
        {
            HOADON hd = qlkara.HOADONs.Where(t => t.MAHD == pMaHD).SingleOrDefault();
            if (hd == null)
                return null;
            return hd.GIORA;
        }

        private DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                dt.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {//inserting property values to datatable rows
                    values[i] = props[i].GetValue(item, null);
                }
                dt.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dt;
        }
    }

    
}
