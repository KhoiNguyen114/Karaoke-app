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
using ControlDichVu;


namespace DoAnKaraoke
{
    public partial class FormGoiDichVu : Form
    {
        BLLDALDatPhong daDP = new BLLDALDatPhong();
        BLLDALSanPham daSP = new BLLDALSanPham();
        PHONG ph;

        public PHONG Ph
        {
            get { return ph; }
            set { ph = value; }
        }

        string tenPhong;

        public string TenPhong
        {
            get { return tenPhong; }
            set { tenPhong = value; }
        }
        
        public FormGoiDichVu()
        {
            InitializeComponent();
        }

        private void FormGoiDichVu_Load(object sender, EventArgs e)
        {
            this.Text = ph.TENPHONG;
            controlDatPhong1.txtMaPhong.Text = ph.TENPHONG;
            controlDatPhong1.btnDat.Click += btnDat_Click;
            controlDatPhong1.btnThemDichVu.Click += btnThemDichVu_Click;
            controlDatPhong1.btnCapNhatDichVu.Click += btnCapNhatDichVu_Click;
            controlDatPhong1.btnXoaDichVu.Click += btnXoaDichVu_Click;
            controlDatPhong1.btnThanhToan.Click += btnThanhToan_Click;
            controlDatPhong1.lblPhong.Text = ph.TENPHONG.ToUpper();
            controlDatPhong1.cboSanPham.SelectedIndexChanged += cboSanPham_SelectedIndexChanged;
            controlDatPhong1.txtSoLuong.TextChanged += txtSoLuong_TextChanged;
            controlDatPhong1.txtDonGiaBan.TextChanged += txtDonGiaBan_TextChanged;
            controlDatPhong1.btnHuyDat.Click += btnHuyDat_Click;
            controlDatPhong1.dtgv_DichVu.CellClick += dtgv_DichVu_CellClick;

            controlDatPhong1.cboSanPham.DataSource = daSP.loadSanPhamCombobox();
            controlDatPhong1.cboSanPham.ValueMember = "MASP";
            controlDatPhong1.cboSanPham.DisplayMember = "TENSP";

            loadDataGridView();

            if (daDP.kiemTraPhongDangThue(ph.MAPHONG))
            {
                controlDatPhong1.btnThanhToan.Enabled = false;
                controlDatPhong1.btnCapNhatDichVu.Enabled = false;
                controlDatPhong1.btnThemDichVu.Enabled = false;
                controlDatPhong1.btnXoaDichVu.Enabled = false;
                controlDatPhong1.txtMaPhong.Enabled = false;
                controlDatPhong1.txtDonGiaBan.Enabled = false;
                controlDatPhong1.btnHuyDat.Enabled = false;
                controlDatPhong1.cboSanPham.Enabled = false;
                controlDatPhong1.txtSoLuongHienCo.Enabled = false;
                controlDatPhong1.txtMaDat.Enabled = false;
                controlDatPhong1.txtSoLuong.Enabled = false;
                controlDatPhong1.txtThanhTien.Enabled = false;
            }
            else
            {
                controlDatPhong1.btnDat.Enabled = false;
                controlDatPhong1.txtDonGiaBan.Enabled = false;
                controlDatPhong1.txtThanhTien.Enabled = false;
                controlDatPhong1.txtMaDat.Text = daDP.traVeMaDatPhong(ph.MAPHONG) + "";
                controlDatPhong1.txtMaDat.Enabled = false;
                controlDatPhong1.txtMaPhong.Enabled = false;
                controlDatPhong1.txtSoLuongHienCo.Enabled = false;
            }
        }

        private void dtgv_DichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (controlDatPhong1.dtgv_DichVu.CurrentRow != null)
            {
                controlDatPhong1.txtMaDat.Text = controlDatPhong1.dtgv_DichVu.CurrentRow.Cells[0].Value.ToString();
                controlDatPhong1.cboSanPham.Text = daSP.traVeTenSanPham(controlDatPhong1.dtgv_DichVu.CurrentRow.Cells[2].Value.ToString());
                controlDatPhong1.txtSoLuong.Text = controlDatPhong1.dtgv_DichVu.CurrentRow.Cells[3].Value.ToString();
                controlDatPhong1.txtDonGiaBan.Text = controlDatPhong1.dtgv_DichVu.CurrentRow.Cells[4].Value.ToString();
                controlDatPhong1.txtThanhTien.Text = controlDatPhong1.dtgv_DichVu.CurrentRow.Cells[5].Value.ToString();
            }
        }

        public void loadDataGridView()
        {
            List<DichVuDatPhong> ds = Program.ds.Where(t => t.MaPhong == ph.MAPHONG).ToList();
            controlDatPhong1.dtgv_DichVu.DataSource = ds;
        }

        private void btnHuyDat_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Phòng này hiện đang đặt và chưa thanh toán, bạn có chắc chắn muốn hủy không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                List<DichVuDatPhong> ds = Program.ds.Where(t => t.MaPhong == ph.MAPHONG).ToList();
                int maDat = daDP.traVeMaDatPhong(ph.MAPHONG);
                if (ds.Any())
                {
                    MessageBox.Show("Phòng này đang có gọi dịch vụ nên không thể hủy! Xin vui lòng thanh toán hoặc xóa dịch vụ trước khi hủy!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (daDP.xoaDatPhong(maDat))
                {
                    daDP.thayDoiTinhTrangPhongKhiXoa(ph.MAPHONG);
                    MessageBox.Show("Hủy đặt phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hủy đặt phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void txtDonGiaBan_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(controlDatPhong1.txtSoLuong.Text.Trim()) && !String.IsNullOrEmpty(controlDatPhong1.txtDonGiaBan.Text.Trim()))
            {
                int sl = int.Parse(controlDatPhong1.txtSoLuong.Text.Trim());
                double dgb = double.Parse(controlDatPhong1.txtDonGiaBan.Text.Trim());
                controlDatPhong1.txtThanhTien.Text = sl * dgb + "";
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(controlDatPhong1.txtSoLuong.Text.Trim()) && !String.IsNullOrEmpty(controlDatPhong1.txtDonGiaBan.Text.Trim()))
            {
                int sl = int.Parse(controlDatPhong1.txtSoLuong.Text.Trim());
                double dgb = double.Parse(controlDatPhong1.txtDonGiaBan.Text.Trim());
                controlDatPhong1.txtThanhTien.Text = sl * dgb + "";
            }
        }

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            double? donGiaBan = daSP.traVeDonGiaBan(controlDatPhong1.cboSanPham.SelectedValue.ToString());
            controlDatPhong1.txtDonGiaBan.Text = donGiaBan + "";
            controlDatPhong1.txtSoLuongHienCo.Text = daSP.traVeSoLuong(controlDatPhong1.cboSanPham.SelectedValue.ToString()) + "";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            double? tongTT = Program.ds.Where(t => t.MaPhong == ph.MAPHONG).Sum(t => t.ThanhTien);
            int maDat = int.Parse(controlDatPhong1.txtMaDat.Text.Trim());
            FormThanhToan frm = new FormThanhToan();
            frm.Ph = ph;
            frm.MaDat = maDat;
            frm.ShowDialog();
            this.Close();
        }

        private void btnXoaDichVu_Click(object sender, EventArgs e)
        {
            int maDat = daDP.traVeMaDatPhong(ph.MAPHONG);
            if (daDP.kiemTraKhoaChinhListDV(maDat, controlDatPhong1.cboSanPham.SelectedValue.ToString(), Program.ds))
            {
                MessageBox.Show("Phòng này chưa có loại dịch vụ này nên không thể xóa! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daDP.xoaDichVu(maDat, ph.MAPHONG, controlDatPhong1.cboSanPham.SelectedValue.ToString(), Program.ds))
            {
                loadDataGridView();
                MessageBox.Show("Xóa dịch vụ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa dịch vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhatDichVu_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(controlDatPhong1.txtSoLuong.Text.Trim()) || String.IsNullOrEmpty(controlDatPhong1.txtDonGiaBan.Text.Trim()) || String.IsNullOrEmpty(controlDatPhong1.txtThanhTien.Text.Trim()))
            {
                MessageBox.Show("Số lượng, đơn giá bán, thành tiền không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int soLuong = int.Parse(controlDatPhong1.txtSoLuong.Text);
            int? soLuongHienCo = daSP.traVeSoLuong(controlDatPhong1.cboSanPham.SelectedValue.ToString());
            double donGiaBan = double.Parse(controlDatPhong1.txtDonGiaBan.Text);
            double thanhTien = double.Parse(controlDatPhong1.txtThanhTien.Text);
            int maDat = daDP.traVeMaDatPhong(ph.MAPHONG);
            if (soLuong < 0 || thanhTien < 0)
            {
                MessageBox.Show("Số lượng, thành tiền không được nhỏ hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daDP.kiemTraKhoaChinhListDV(maDat, controlDatPhong1.cboSanPham.SelectedValue.ToString(), Program.ds))
            {
                MessageBox.Show("Phòng này chưa có loại dịch vụ này nên không thể cập nhật! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (soLuongHienCo == 0)
            {
                MessageBox.Show("Sản phẩm này đã hết hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (soLuong > soLuongHienCo)
                {
                    MessageBox.Show("Số lượng nhập vào đang lớn hơn số lượng sản phẩm hiện có! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int tongSLList = (int) daSP.tongSoLuongSPTrongList(controlDatPhong1.cboSanPham.SelectedValue.ToString(), Program.ds);
                int hieuSo = (int) daSP.traVeHieuSoSPKhiCapNhat(controlDatPhong1.cboSanPham.SelectedValue.ToString(), maDat, soLuong, Program.ds);
                if (tongSLList + hieuSo > soLuongHienCo)
                {
                    MessageBox.Show("Tổng số lượng sản phẩm này trong danh sách đang lớn hơn số lượng sản phẩm hiện có! Xin vui lòng kiểm tra lại ở sản phẩm này ở các phòng khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (daDP.suaDichVu(maDat, ph.MAPHONG, controlDatPhong1.cboSanPham.SelectedValue.ToString(), soLuong, donGiaBan, thanhTien, Program.ds))
                {
                    loadDataGridView();
                    MessageBox.Show("Cập nhật dịch vụ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật dịch vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThemDichVu_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(controlDatPhong1.txtSoLuong.Text.Trim()) || String.IsNullOrEmpty(controlDatPhong1.txtDonGiaBan.Text.Trim()) || String.IsNullOrEmpty(controlDatPhong1.txtThanhTien.Text.Trim()))
            {
                MessageBox.Show("Số lượng, đơn giá bán, thành tiền không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int soLuong = int.Parse(controlDatPhong1.txtSoLuong.Text);
            int? soLuongHienCo = daSP.traVeSoLuong(controlDatPhong1.cboSanPham.SelectedValue.ToString());
            double donGiaBan = double.Parse(controlDatPhong1.txtDonGiaBan.Text);
            double thanhTien = double.Parse(controlDatPhong1.txtThanhTien.Text);
            int maDat = daDP.traVeMaDatPhong(ph.MAPHONG);
            if (!daDP.kiemTraKhoaChinhListDV(maDat, controlDatPhong1.cboSanPham.SelectedValue.ToString(), Program.ds))
            {
                MessageBox.Show("Phòng này đã có loại dịch vụ này rồi! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (soLuong < 0 || thanhTien < 0)
            {
                MessageBox.Show("Số lượng, thành tiền không được nhỏ hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (soLuongHienCo == 0)
            {
                MessageBox.Show("Sản phẩm này đã hết hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (soLuong > soLuongHienCo)
                {
                    MessageBox.Show("Số lượng nhập vào đang lớn hơn số lượng sản phẩm hiện có! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int tongSLList = (int) daSP.tongSoLuongSPTrongList(controlDatPhong1.cboSanPham.SelectedValue.ToString(), Program.ds);
                if (tongSLList + soLuong > soLuongHienCo)
                {
                    MessageBox.Show("Tổng số lượng sản phẩm này trong danh sách đang lớn hơn số lượng sản phẩm hiện có! Xin vui lòng kiểm tra lại ở sản phẩm này ở các phòng khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (daDP.themDichVu(maDat, ph.MAPHONG, controlDatPhong1.cboSanPham.SelectedValue.ToString(), soLuong, donGiaBan, thanhTien, Program.ds))
                {
                    loadDataGridView();
                    controlDatPhong1.btnThanhToan.Enabled = true;
                    MessageBox.Show("Thêm dịch vụ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm dịch vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            DateTime gioVao = DateTime.Now;
            if (!daDP.kiemTraPhong(ph.MAPHONG))
            {
                MessageBox.Show("Phòng này đang được thuê hoặc tạm ngưng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daDP.themDatPhong(ph.MAPHONG,gioVao))
            {
                daDP.thayDoiTinhTrangPhong(ph.MAPHONG);                
                MessageBox.Show("Đặt phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                controlDatPhong1.btnThemDichVu.Enabled = true;
                controlDatPhong1.btnXoaDichVu.Enabled = true;
                controlDatPhong1.btnCapNhatDichVu.Enabled = true;
                controlDatPhong1.txtSoLuong.Enabled = true;
                controlDatPhong1.btnHuyDat.Enabled = true;
                controlDatPhong1.cboSanPham.Enabled = true;
                controlDatPhong1.txtMaDat.Text = daDP.traVeMaDatPhong(ph.MAPHONG) + "";
                controlDatPhong1.txtMaDat.Enabled = false;
                controlDatPhong1.txtThanhTien.Enabled = false;
                controlDatPhong1.txtSoLuongHienCo.Enabled = false;
            }
            else
            {
                MessageBox.Show("Đặt phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void FormGoiDichVu_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
