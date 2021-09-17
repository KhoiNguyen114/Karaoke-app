using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;

namespace DoAnKaraoke
{
    public partial class FormMain : Form
    {
        BLLDALNguoiDung daND = new BLLDALNguoiDung();
        BLLDALPhanQuyen daPQ = new BLLDALPhanQuyen();
        BLLDALNhanVien daNV = new BLLDALNhanVien();
        string tenDangNhap;

        public string TenDangNhap
        {
            get { return tenDangNhap; }
            set { tenDangNhap = value; }
        }

        public FormMain()
        {
            InitializeComponent();
            
        }

        

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau frm = new FormDoiMatKhau();            
            this.Visible = false;
            frm.Show();
        }

        private void loạiPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPhong frm = new FormPhong();
            this.Visible = false;
            frm.Show();
        }

        private void loạiNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoaiKhachHang frm = new FormLoaiKhachHang();
            this.Visible = false;
            frm.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhachHang frm = new FormKhachHang();
            this.Visible = false;
            frm.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhanVien frm = new FormNhanVien();
            this.Visible = false;
            frm.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhaCungCap frm = new FormNhaCungCap();
            this.Visible = false;
            frm.Show();
        }

        private void đặtPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        
        {
            FormDichVuVaDatPhong frm = new FormDichVuVaDatPhong();
            this.Visible = false;
            frm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormThongTin frm = new FormThongTin();
            this.Visible = false;
            frm.Show();
        }

        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhapHang frm = new FormNhapHang();
            this.Visible = false;
            frm.Show();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSanPham frm = new FormSanPham();
            this.Visible = false;
            frm.Show();
        }

        private void loạiDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoaiDichVu frm = new FormLoaiDichVu();
            this.Visible = false;
            frm.Show();
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChucVu frm = new FormChucVu();
            this.Visible = false;
            frm.Show();    
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHoaDon frm = new FormHoaDon();
            this.Visible = false;
            frm.Show();  
        }

        private void FindMenuPhanQuyen(ToolStripItemCollection mnuItems, string PScreenName, bool pEnable)
        {

            foreach (ToolStripItem menu in mnuItems)
            {
                if (menu is ToolStripMenuItem && ((ToolStripMenuItem)(menu)).DropDownItems.Count > 0)
                {
                    FindMenuPhanQuyen(((ToolStripMenuItem)(menu)).DropDownItems, PScreenName, pEnable);
                    menu.Enabled = CheckAllMenuChildVisible(((ToolStripMenuItem)(menu)).DropDownItems);
                    menu.Visible = menu.Enabled;
                }
                else if (string.Equals(PScreenName, menu.Tag))
                {
                    menu.Enabled = pEnable;
                    menu.Visible = pEnable;
                }
            }
        }

        private bool CheckAllMenuChildVisible(ToolStripItemCollection mnuItems)
        {
            foreach (ToolStripItem menuItem in mnuItems)
            {
                if (menuItem is ToolStripMenuItem && menuItem.Enabled)
                {
                    return true;

                }
                else if (menuItem is ToolStripSeparator)
                {
                    continue;
                }
            }
            return false;

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            List<MaNhomNguoiDung> nhomND = daPQ.getMaNhomNguoiDung(TenDangNhap);
            foreach (MaNhomNguoiDung item in nhomND)
            {
                List<DanhSachManHinh> dsQuyen = daPQ.getMaManHinh(item.MaNhom);
                for (int i = 0; i < dsQuyen.Count; i++)
                {
                    FindMenuPhanQuyen(this.menuStrip1.Items, dsQuyen[i].MaManHinh, Convert.ToBoolean(dsQuyen[i].CoQuyen.ToString()));
                }

            }

            Program.formMain.Text =  "Xin chào " + daNV.traVeNhanVienDiemDanh(Program.tenDangNhap) + " !";
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Visible = false;
            Program.formDangNhap.Show();
        }

        private void tạoTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTaoTaiKhoan frm = new FormTaoTaiKhoan();
            this.Visible = false;
            frm.Show();  
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        
        private void theoNgàyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormThongKeDoanhThu frm = new FormThongKeDoanhThu();
            this.Visible = false;
            frm.Show();  
        }

        private void hoáĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormThongKePhieuNhap frm = new FormThongKePhieuNhap();
            this.Visible = false;
            frm.Show();  
        }

        private void điểmDanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDiemDanh frm = new FormDiemDanh();
            this.Visible = false;
            frm.Show();  
        }

        private void lươngNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTinhLuongNhanVien frm = new FormTinhLuongNhanVien();
            this.Visible = false;
            frm.Show();  
        }

        private void cấpQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQuanLyNguoiDung frm = new FormQuanLyNguoiDung();
            this.Visible = false;
            frm.Show();  
        }
    }
}
