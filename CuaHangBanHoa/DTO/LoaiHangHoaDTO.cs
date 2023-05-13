using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanHoa.DTO
{
    public class LoaiHangHoaDTO
    {
        private string maLoaiHang;
        private string tenLoaiHang;
        private string moTa;

        public LoaiHangHoaDTO(string maLoaiHang, string tenLoaiHang, string moTa)
        {
            MaLoaiHang = maLoaiHang;
            TenLoaiHang = tenLoaiHang;
            MoTa = moTa;
        }
        public LoaiHangHoaDTO(DataRow row)
        {
            MaLoaiHang = (string)row["MaLoaiHang"];
            TenLoaiHang = (string)row["TenLoaiHang"];   
            MoTa = (string)row["MoTa"];
        }
        public string MaLoaiHang { get => maLoaiHang; set => maLoaiHang = value; }
        public string TenLoaiHang { get => tenLoaiHang; set => tenLoaiHang = value; }
        public string MoTa { get => moTa; set => moTa = value; }
    }
}
