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
    public partial class FormCauHinh : Form
    {
        BLLDALPhanQuyen CauHinh = new BLLDALPhanQuyen();
        public FormCauHinh()
        {
            InitializeComponent();
        }

        private void FormCauHinh_Load(object sender, EventArgs e)
        {

        }

        private void cbbServerName_DropDown(object sender, EventArgs e)
        {
            cbbServerName.DataSource = CauHinh.GetServerName();
            cbbServerName.DisplayMember = "ServerName";
        }

        private void cbbDBName_DropDown(object sender, EventArgs e)
        {
            cbbDBName.DataSource = CauHinh.GetDBName(cbbServerName.Text, txtUser.Text, txtPass.Text);
            cbbDBName.DisplayMember = "name";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CauHinh.SaveConfig(cbbServerName.Text, txtUser.Text, txtPass.Text, cbbDBName.Text);

            if (Program.formDangNhap == null || Program.formDangNhap.IsDisposed)
            {
                Program.formDangNhap = new FormDangNhap();
            }
            this.Visible = false;
            Program.formDangNhap.Show();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
