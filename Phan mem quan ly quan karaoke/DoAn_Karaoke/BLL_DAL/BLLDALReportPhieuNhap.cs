using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALReportPhieuNhap
    {
        QuanLyQuanKaraokeDataContext qlkara = new QuanLyQuanKaraokeDataContext();
        public DataTable xuatPhieuNhap(int pMaPN)
        {
            var ds = (from pn in qlkara.PHIEUNHAPs
                      join ctpn in qlkara.CHITIETPHIEUNHAPs on pn.MAPN equals ctpn.MAPN
                      join ncc in qlkara.NHACUNGCAPs on pn.MANCC equals ncc.MANCC
                      join nv in qlkara.NHANVIENs on pn.MANV equals nv.MANV
                      join sp in qlkara.SANPHAMs on ctpn.MASP equals sp.MASP
                      where pn.MAPN == pMaPN
                      select new
                      {
                          pn.MAPN,
                          nv.TENNV,
                          ncc.TENNCC,
                          pn.NGAYLAPPN,
                          pn.TONGTIENPN,
                          sp.TENSP,
                          ctpn.SOLUONG,
                          ctpn.DONGIANHAP,
                          ctpn.THANHTIEN,
                      }).ToList();
            DataTable dt = new DataTable();
            dt = ToDataTable(ds);
            return dt;
        }

        public double? traVeTongTien(int pMaPN)
        {
            PHIEUNHAP pn = qlkara.PHIEUNHAPs.Where(t => t.MAPN == pMaPN).SingleOrDefault();
            if (pn == null)
                return null;
            return pn.TONGTIENPN;
        }

        public DateTime? traVeNgayLap(int pMaPN)
        {
            PHIEUNHAP pn = qlkara.PHIEUNHAPs.Where(t => t.MAPN == pMaPN).SingleOrDefault();
            if (pn == null)
                return null;
            return pn.NGAYLAPPN;
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
