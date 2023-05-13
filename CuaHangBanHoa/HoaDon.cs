using CuaHangBanHoa.DAO;
using CuaHangBanHoa.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangBanHoa
{
    public partial class HoaDon : Form
    {
        private string maHoaDon;
        private string sdtNV;
        private string sdtKH;
        private DateTime ngayLapHoaDon;
        private int tongThanhTien;
        private int trangThai;
        private List<ChiTietHoaDonDTO> listCTHD;

        public HoaDon(string tenNV, string sdtKH, DateTime ngayLap , List<ChiTietHoaDonDTO> listCTHD , int tongThanhTien)
        {
            InitializeComponent();

            SdtNV = tenNV;
            SdtKH = sdtKH;
            NgayLapHoaDon = ngayLap;
            ListCTHD    = listCTHD;
            TongThanhTien = tongThanhTien;

            lbTenNV.Text = SdtNV;
            lbSdtKH.Text = sdtKH;
            lbNgayLap.Text = NgayLapHoaDon.ToString("dd MMMM yyyy");
            lbTongTien.Text = TongThanhTien + " VNĐ";
            string noiDungSP="";
            foreach (ChiTietHoaDonDTO CTHD in ListCTHD)
            {
                string tenHang = CTHD.TenHang;
                int soLuong = CTHD.SoLuong;
                noiDungSP += tenHang + " x " + soLuong + "\n";

            }
            lbCacSP.Text = noiDungSP;
            lbCacSP.MaximumSize = new Size(600, 100);
            lbCacSP.AutoSize = true;
            plSanPham.Controls.Add(lbCacSP);


        }
        public void lapCTHD(List<ChiTietHoaDonDTO> listCTHD, List<int> listTT)
        {
            string qr1 = @"select MaHoaDon from HoaDon order by MaHoaDon desc , NgayLapHoaDon asc   ";
            DataTable excuteQr1 = DataProvider.Instance.ExecuteQuery(qr1);
            //lay ma hoa don vua tao

            DataRow MaHoaDonRow = excuteQr1.Rows[0];
            string MaHoaDon = MaHoaDonRow[0].ToString();

            //them chi tiet cho hoa don da lap
            string qr2 = @"insert into ChiTietHoaDon values ( @mhd , @mahang , @soluong , @thanhtien )";
            int indexTT = 0;
            foreach (ChiTietHoaDonDTO CTHD in listCTHD)
            {
                int thanhTienE = listTT[indexTT];
                DataProvider.Instance.ExecuteQuery(qr2, new object[] { MaHoaDon, CTHD.MaHang, CTHD.SoLuong, thanhTienE });
                indexTT++;
            }
        }
        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string SdtNV { get => sdtNV; set => sdtNV = value; }
        public string SdtKH { get => sdtKH; set => sdtKH = value; }
        public DateTime NgayLapHoaDon { get => ngayLapHoaDon; set => ngayLapHoaDon = value; }
        public int TongThanhTien { get => tongThanhTien; set => tongThanhTien = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
        public List<ChiTietHoaDonDTO> ListCTHD { get => listCTHD; set => listCTHD = value; }
    }
}
