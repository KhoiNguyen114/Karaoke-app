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
    public partial class FormKhachHang : Form
    {
        BLLDALKhachHang daKH = new BLLDALKhachHang();
        BLLDALLoaiKhachHang daLoaiKH = new BLLDALLoaiKhachHang();
        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void FormKhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.formMain.Show();
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            loadDataGridView();

            cboLoaiKH.DataSource = daLoaiKH.loadLoaiKhachHang();
            cboLoaiKH.DisplayMember = "TENLOAI";
            cboLoaiKH.ValueMember = "MALOAIKH";

        }

        private void dtgv_KhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dtgv_KhachHang.CurrentRow != null)
            {
                txtMaKH.Text = dtgv_KhachHang.CurrentRow.Cells[0].Value.ToString();
                txtTenKH.Text = dtgv_KhachHang.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dtgv_KhachHang.CurrentRow.Cells[5].Value.ToString();
                txtDienThoai.Text = dtgv_KhachHang.CurrentRow.Cells[4].Value.ToString();
                cboLoaiKH.Text = daKH.traVeTenLoaiKhachHang(dtgv_KhachHang.CurrentRow.Cells[6].Value.ToString());
                dpk_NgaySinh.Text = dtgv_KhachHang.CurrentRow.Cells[3].Value.ToString();
                checkGioiTinh(gbGioiTinh, dtgv_KhachHang.CurrentRow.Cells[2].Value.ToString());
            }
        }

        public void checkGioiTinh(GroupBox gb, string pGioiTinh)
        {
            for (int i = 0; i < gb.Controls.Count; i++)
            {
                RadioButton rb = (RadioButton)gb.Controls[i];
                if (rb.Text == pGioiTinh)
                {
                    rb.Checked = true;
                }
            }
        }

        public bool ktCheckGioiTinh(GroupBox gb)
        {
            for (int i = 0; i < gb.Controls.Count; i++)
            {
                RadioButton rb = (RadioButton)gb.Controls[i];
                if (rb.Checked)
                {
                    return true;
                }
            }
            return false;
        }

        public string traVeGioiTinh(GroupBox gb)
        {
            string kq = "";
            for (int i = 0; i < gb.Controls.Count; i++)
            {
                RadioButton rb = (RadioButton)gb.Controls[i];
                if (rb.Checked)
                {
                    kq = rb.Text;
                    return kq;
                }
            }
            return kq;
        }

        public void loadDataGridView()
        {
            dtgv_KhachHang.DataSource = daKH.loadKhachHang();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaKH.Text) || String.IsNullOrEmpty(txtTenKH.Text) || String.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Mã khách hàng, tên khách hàng, số điện thoại khách hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtDienThoai.Text.Length > 10 || txtMaKH.Text.Length > 10)
                {
                    MessageBox.Show("Số điện thoại, mã khách hàng không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!ktCheckGioiTinh(gbGioiTinh))
                    {
                        MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if(!daKH.ktKhoaChinh(txtMaKH.Text.Trim()))
                        {
                            MessageBox.Show("Mã khách hàng này đã tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DateTime ns = DateTime.Parse(dpk_NgaySinh.Text);
                            if (daKH.themKhachHang(txtMaKH.Text.Trim(), txtTenKH.Text.Trim(), traVeGioiTinh(gbGioiTinh), ns, txtDienThoai.Text.Trim(), txtDiaChi.Text.Trim(), cboLoaiKH.SelectedValue.ToString()))
                            {
                                loadDataGridView();
                                MessageBox.Show("Thêm khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Thêm khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }                        
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Mã khách hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (daKH.xoaKhachHang(txtMaKH.Text.Trim()))
                {
                    loadDataGridView();
                    MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaKH.Text) || String.IsNullOrEmpty(txtTenKH.Text) || String.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Mã khách hàng, tên khách hàng, số điện thoại khách hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtDienThoai.Text.Length > 10 || txtMaKH.Text.Length > 10)
                {
                    MessageBox.Show("Số điện thoại, mã khách hàng không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!ktCheckGioiTinh(gbGioiTinh))
                    {
                        MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (daKH.ktKhoaChinh(txtMaKH.Text.Trim()))
                        {
                            MessageBox.Show("Mã khách hàng này chưa tồn tại nên không thể cập nhật! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DateTime ns = DateTime.Parse(dpk_NgaySinh.Text);
                            if (daKH.suaKhachHang(txtMaKH.Text.Trim(), txtTenKH.Text.Trim(), traVeGioiTinh(gbGioiTinh), ns, txtDienThoai.Text.Trim(), txtDiaChi.Text.Trim(), cboLoaiKH.SelectedValue.ToString()))
                            {
                                loadDataGridView();
                                MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.formMain.Show();
        }

        private void cboLoaiKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dtgv_KhachHang.DataSource = daKH.loadKhachHangTheoCombobox(cboLoaiKH.SelectedValue.ToString());

        }
    }
}
