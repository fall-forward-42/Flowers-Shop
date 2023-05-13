using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanHoa.DTO
{
    public class KhachHangDTO
    {
        private string sdt;
        private string tenKH;
        private int gioiTinh;
        private string thongTinThem;

        public KhachHangDTO(string sdt, string tenKH, int gioiTinh, string thongTinThem)
        {
            Sdt = sdt;
            TenKH = tenKH;
            GioiTinh = gioiTinh;
            ThongTinThem = thongTinThem;
        }
        public KhachHangDTO(DataRow row)
        {
            Sdt = (string)row["Sdt"];
            TenKH = (string)row["TenKH"];
            GioiTinh = (int)row["GioiTinh"];
            ThongTinThem = (string)row["ThongTinThem"];
        }
        public string Sdt { get => sdt; set => sdt = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public int GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string ThongTinThem { get => thongTinThem; set => thongTinThem = value; }
    }
}
