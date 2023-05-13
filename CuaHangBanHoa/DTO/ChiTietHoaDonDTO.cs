using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanHoa.DTO
{
    public class ChiTietHoaDonDTO
    {
        private string maHoaDon;
        private string maHang;
        private int soLuong;
        private int thanhTien;
        private string tenHang;

        public ChiTietHoaDonDTO(string maHoaDon, string maHang, int soLuong, int thanhTien)
        {
            MaHoaDon = maHoaDon;
            MaHang = maHang;
            SoLuong = soLuong;
            ThanhTien = thanhTien;
        }
        public ChiTietHoaDonDTO(DataRow row)
        {
            MaHoaDon = (string)row["MaHoaDon"];
            MaHang = (string)row["MaHang"];
            SoLuong = (int)row["SoLuong"];
            ThanhTien = (int)row["ThanhTien"];
        }   
        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string MaHang { get => maHang; set => maHang = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int ThanhTien { get => thanhTien; set => thanhTien = value; }
        public string TenHang { get => tenHang; set => tenHang = value; }
    }
}
