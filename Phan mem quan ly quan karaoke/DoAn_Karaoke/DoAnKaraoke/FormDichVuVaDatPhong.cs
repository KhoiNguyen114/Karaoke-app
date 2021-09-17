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
    public partial class FormDichVuVaDatPhong : Form
    {
        BLLDALDatPhong daDP = new BLLDALDatPhong();
        BLLDALPhong daPhong = new BLLDALPhong();

        public FormDichVuVaDatPhong()
        {
            InitializeComponent();
        }

        private void FormDichVuVaDatPhong_Load(object sender, EventArgs e)
        {
            loadDanhSachTinhTrangPhong();
        }

        public void loadDanhSachTinhTrangPhong()
        {
            panel1.Controls.Clear();
            List<PHONG> ds = daDP.loadDanhSachPhong();
            int bienChay = 0;
            for (int i = 0; i < ds.Count / 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    if (bienChay < ds.Count)
                    {
                        ControlPhong btn = new ControlPhong();
                        btn.Top = 173 * i;
                        btn.Left = 210 * j;
                        btn.Name = "btn " + bienChay;
                        btn.label1.ForeColor = Color.Black;
                        btn.label1.Text = ds[bienChay].TENPHONG;
                        btn.Po = ds[bienChay];
                        if (ds[bienChay].TINHTRANG == "Đang thuê")
                        {
                            btn.BackColor = Color.Yellow;
                        }
                        else if (ds[bienChay].TINHTRANG == "Tạm ngưng")
                        {
                            btn.BackColor = Color.Red;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                        }
                        btn.Click += btn_Click;
                        panel1.Controls.Add(btn);
                        bienChay++;
                    }
                }
            }            
        }

        private void btn_Click(object sender, EventArgs e)
        {
            ControlPhong a = (ControlPhong)sender;            
            if (!daDP.kiemTraPhongTamNgung(a.Po.MAPHONG))
            {
                MessageBox.Show("Phòng này đang tạm ngưng nên không thể gọi dịch vụ hay đặt!", "Tạm ngưng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FormGoiDichVu frm = new FormGoiDichVu();
            frm.Ph = a.Po;
            frm.ShowDialog();
            loadDanhSachTinhTrangPhong();
        }

        private void FormDichVuVaDatPhong_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.formMain.Show();
        }
        

        /// 
        //public List<SANPHAM> list_()
        //{
        //    // đầu tiền khi add vô một sản phẩm nào đó// thì m add vô cái list này hoặc datataable
        //    // list thì add
        //    // taable thì addRow
        //    List<SANPHAM> lisSPChon = new List<SANPHAM>();
        //    //SANPHAM  này là m tạo một class SanPham mới chứa mấy thuốc tính cần add vô

        //    // không đọc dòng này à...
        //    // Class này chứa mấy thuốc tính cần add vô

        //    // đầu tiền int maPhong....
        //    // int maSanP
        //    //string tenSP
        //    // int soLuong
        //    SANPHAM sp = new SANPHAM() { TENSP,SOLUONG,DONGIABAN};
        //    // số lướng j j đó m tự nhpj
        //    // khi sản phẩm có dữ liệu aadd vô
        //    // list này là listAor nhé
        //    lisSPChon.Add(sp);
        //}


        //// đây là phần UI ngta nhìn mình đã chọn bao nhiêu sản phẩm
        //public void gaiDien(DataGridView dgv)
        //{

        //    // tới chỗ này m truy vấn
        //    // load theo mãPhongf
        //    // 

        //    // hiểu chưa
        //    // hiểu sơ sơ, nè giờ nhìn cái giao diện user control t mới mường tượng hồi trưa
        //    var db = list_().Where(m=>m.  // mã phòng == maPhongf).toLisst();
        //    dgv.DataSource = db;
        //    /// khi đây là chưa thanh toán
        //    /// 
        //    //Chỗ này khi tắt đi thì cái dữ liệu trên datagridview còn không?

        //    // còn nhé miễn list còn, ủa nếu vậy thì list mỗi lần mình thêm ở 2 phòng khác nhau thì list nó thay đổi
        //    // thì làm sao nó xử lí nhỉ, hiểu ý t không. Ví dụ phòng 1 đặt thì list đang lưu dữ liệu phòng 1, rồi cái
        //    // phòng 2 đăt thì nó lưu phòng 2 nhưng m mở lên dữ liệu phòng 1 thì có phải mất rồi không?
        //    // có một nút buuton thanh toán
        //    Button btnA = new Button();
        //    btnA.Click += btnA_Click;
        //}

        //private void btnA_Click(object sender, EventArgs e)
        //{
        //    // sau khi nhấp vào btn này thì List kiad sẽ thanh toán
        //    List<SANPHAM> list = list_();
        //    // hàm trên này thêm một hóa đơn

        //    // thêm xong hóa đơn thì lấy cái mã hóa đơn đó bắt đầu thêm chi tiết hóa đơn
        //    string maHD = "";// vừa mới thêm hóa đơn xong
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        // đây là hàm thêm sản phẩm xuống cớ sở dữ liệu với mã hóa đơn và mã sản phẩm
        //        // ví dụ đây là hàm thêm
        //        string maSp = list[i].MASP;
        //        int? soLuong = list[i].SOLUONG;
        //        double? giaBan = list[i].DONGIABAN;
        //        double? thanhTien = soLuong * giaBan;
        //        // gọi hàm thêm
        //        themCTHD(maSp, maHD, soLuong, giaBan, thanhTien);
        //    }
        //    // clead lisst ddos ddi
        //    list.Clear();

        //    // sau ddos ai muốn thêm gì thì cứ gọi hàm này///
        //}

        //public bool themCTHD(string maSP, string maHD, int? sol, double? giaBan, double? thanhTien)
        //{
        //    // còn viết thêm xuống database.....
        //    return true;
        //}
    }
}
