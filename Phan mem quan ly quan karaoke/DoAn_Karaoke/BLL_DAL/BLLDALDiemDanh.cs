using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALDiemDanh
    {
        QuanLyQuanKaraokeDataContext qlkara = new QuanLyQuanKaraokeDataContext();
        public BLLDALDiemDanh()
        {

        }

        public bool ktKhoaChinh(string pMaNV, DateTime pNgayDD)
        {
            DIEMDANH dd = qlkara.DIEMDANHs.Where(t => t.MANV == pMaNV && t.NGAYDD == pNgayDD).SingleOrDefault();
            if (dd == null)
                return true;
            return false;
        }

        public int? tinhSoNgayLamViec(string pMaNV, int pThang, int pNam)
        {
            int? soNgay = qlkara.DIEMDANHs.Count(t => t.MANV == pMaNV && t.NGAYDD.Year == pNam && t.NGAYDD.Month == pThang);
            return soNgay;
        }

        public bool themDiemDanh(string pMaNV, DateTime pNgayDD)
        {
            try
            {
                DIEMDANH dd = new DIEMDANH();
                dd.MANV = pMaNV;
                dd.NGAYDD = pNgayDD;

                qlkara.DIEMDANHs.InsertOnSubmit(dd);
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
