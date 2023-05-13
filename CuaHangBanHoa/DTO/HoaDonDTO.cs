using CuaHangBanHoa.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanHoa.DTO
{
    internal class HoaDonDTO
    {
        private string maHoaDon;
        private string sdtNV;
        private string sdtKH;
        private DateTime ngayLapHoaDon;
        private int tongTien;
        private int trangThai;


        public HoaDonDTO(string maHoaDon, string sdtNV, string sdtKH, DateTime ngayLapHoaDon, int tongTien, int trangThai)
        {
            MaHoaDon = maHoaDon;
            SdtNV = sdtNV;
            SdtKH = sdtKH;
            NgayLapHoaDon = ngayLapHoaDon;
            TongTien = tongTien;
            TrangThai = trangThai;
        }
        public HoaDonDTO(DataRow row)
        {
            MaHoaDon = (string)row["MaHoaDon"];
            SdtNV = (string)row["SdtNV"]; ;
            SdtKH = (string)row["SdtKH"]; ;
            NgayLapHoaDon = (DateTime)row["NgayLapHoaDon"]; ;
            TongTien = (int)row["TongTien"]; ;
            TrangThai = (int)row["TrangThai"]; ;
        }
         
        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string SdtNV { get => sdtNV; set => sdtNV = value; }
        public string SdtKH { get => sdtKH; set => sdtKH = value; }
        public DateTime NgayLapHoaDon { get => ngayLapHoaDon; set => ngayLapHoaDon = value; }
        public int TongTien { get => tongTien; set => tongTien = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
    }
}
