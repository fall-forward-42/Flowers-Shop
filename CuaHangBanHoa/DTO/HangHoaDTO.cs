using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanHoa.DTO
{
    public class HangHoaDTO
    {
        private string maHang;
        private string tenHang;
        private string maLoaiHang;
        private string hinhAnh;
        private string sdtNCC;
        private int soLuong;
        private int gia;

        public HangHoaDTO(string maHang, string tenHang, string maLoaiHang, string hinhAnh, string sdtNCC, int soLuong, int gia)
        {
            MaHang = maHang;
            TenHang = tenHang;
            MaLoaiHang = maLoaiHang;
            HinhAnh = hinhAnh;
            SdtNCC = sdtNCC;
            SoLuong = soLuong;
            Gia = gia;
        }
        public HangHoaDTO(DataRow row)
        {
            MaHang = (string)row["MaHang"];
            TenHang = (string)row["TenHang"];
            MaLoaiHang = (string)row["MaLoaiHang"];
            HinhAnh = (string)row["HinhAnh"];
            SdtNCC = (string)row["SdtNCC"];
            SoLuong = (int)row["SoLuong"];
            Gia = (int)row["Gia"];
        }
        public string MaHang { get => maHang; set => maHang = value; }
        public string TenHang { get => tenHang; set => tenHang = value; }
        public string MaLoaiHang { get => maLoaiHang; set => maLoaiHang = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public string SdtNCC { get => sdtNCC; set => sdtNCC = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int Gia { get => gia; set => gia = value; }
    }
}
