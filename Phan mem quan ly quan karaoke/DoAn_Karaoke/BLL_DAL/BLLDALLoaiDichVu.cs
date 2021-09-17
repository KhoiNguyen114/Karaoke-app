using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALLoaiDichVu
    {
        QuanLyQuanKaraokeDataContext qlKara = new QuanLyQuanKaraokeDataContext();
        public BLLDALLoaiDichVu()
        {

        }

        public IQueryable loadLoaiDichVu()
        {
            IQueryable ds = from k in qlKara.LOAIDICHVUs select new { k.MALOAI, k.TENLOAI };
            return ds;
        }

        public string traVeTenLoai(string pMaLoai)
        {
            try
            {
                string kq = "";
                LOAIDICHVU loaiDichVu = qlKara.LOAIDICHVUs.Where(t => t.MALOAI == pMaLoai).SingleOrDefault();
                kq = loaiDichVu.TENLOAI;
                return kq;
            }
            catch
            {
                return null;
            }
        }

        public bool ktKhoaChinh(string MaLoai)
        {
            LOAIDICHVU l = qlKara.LOAIDICHVUs.Where(t => t.MALOAI == MaLoai).SingleOrDefault();
            if (l == null)
                return true;
            return false;
        }

        public bool themLoaiDichVu(string MaLoai, string TenLoai)
        {
            try
            {
                LOAIDICHVU l = new LOAIDICHVU();
                l.MALOAI = MaLoai;
                l.TENLOAI = TenLoai;


                qlKara.LOAIDICHVUs.InsertOnSubmit(l);
                qlKara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaLoaiDichVu(string MaLoai, string TenLoai)
        {
            try
            {
                LOAIDICHVU l = qlKara.LOAIDICHVUs.Where(t => t.MALOAI == MaLoai).SingleOrDefault();
                if (l == null)
                    return false;

                l.TENLOAI = TenLoai;

                qlKara.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaLoaiDichVu(string MaLoai)
        {
            try
            {
                LOAIDICHVU l = qlKara.LOAIDICHVUs.Where(t => t.MALOAI == MaLoai).SingleOrDefault();
                if (l == null)
                    return false;

                qlKara.LOAIDICHVUs.DeleteOnSubmit(l);
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
