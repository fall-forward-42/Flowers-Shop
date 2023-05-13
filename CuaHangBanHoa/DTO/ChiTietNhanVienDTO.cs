using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanHoa.DTO
{
    public class ChiTietNhanVienDTO
    {
        private string maCLV;
        private string sdtNV;
        private int tongCaLam;
        private int tongTien;

        public ChiTietNhanVienDTO(string maCLV, string sdtNV, int tongCaLam, int tongTien)
        {
            MaCLV = maCLV;
            SdtNV = sdtNV;
            TongCaLam = tongCaLam;
            TongTien = tongTien;
        }
        public ChiTietNhanVienDTO(DataRow row)
        {
            MaCLV = (string)row["MaCLV"];
            SdtNV = (string)row["SdtNV"];
            TongCaLam = (int)row["TongCaLam"];
            TongTien = (int)row["TongTien"];
        }

        public string MaCLV { get => maCLV; set => maCLV = value; }
        public string SdtNV { get => sdtNV; set => sdtNV = value; }
        public int TongCaLam { get => tongCaLam; set => tongCaLam = value; }
        public int TongTien { get => tongTien; set => tongTien = value; }
    }
}
