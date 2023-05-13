using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangBanHoa
{
    public partial class SanPham : UserControl
    {
        private string tenHang;
        private string maLoai;
        private string hinhAnh;
        private int soLuong;
        private int gia;
        private string maHang;

        public SanPham(string tenHang, string maLoai, string hinhAnh, int soLuong, int gia)
        {
            TenHang = tenHang;
            MaLoai = maLoai;
            HinhAnh = hinhAnh;
            SoLuong = soLuong;
            Gia = gia;
            InitializeComponent();
            //chen thong tin can thiet
            lbTenSP.Text = tenHang;
            lbLoai.Text = maLoai;
            lbSoLuong.Text += soLuong+" Cái";
            lbGia.Text += gia +" VNĐ";
            

            //chen hinh anh
            Bitmap bm = new Bitmap(Application.StartupPath +hinhAnh);
            picSP.Image = bm;

        }

        public string TenHang { get => tenHang; set => tenHang = value; }
        public string MaLoai { get => maLoai; set => maLoai = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int Gia { get => gia; set => gia = value; }
        public string MaHang { get => maHang; set => maHang = value; }

        private void FormSP_click(object sender, EventArgs e)
        {


        }
    }
}
