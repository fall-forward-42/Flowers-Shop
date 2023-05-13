using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanHoa.DTO
{
    public class CaLamViecDTO
    {
        private string maCLV;
        private string tenCLV;
        private int gioBD;
        private int gioKT;
        private int soTien;

        public string MaCLV { get => maCLV; set => maCLV = value; }
        public string TenCLV { get => tenCLV; set => tenCLV = value; }
        public int GioBD { get => gioBD; set => gioBD = value; }
        public int GioKT { get => gioKT; set => gioKT = value; }
        public int SoTien { get => soTien; set => soTien = value; }

        public CaLamViecDTO(DataRow row)
        {
            MaCLV = (string)row["MaCLV"];
            TenCLV = (string)row["TenCLV"];
            GioBD = (int)row["GioBD"];
            GioKT = (int)row["GioKT"];
            SoTien = (int)row["SoTien"];

        }

        public CaLamViecDTO(string maCLV, string tenCLV, int gioBD, int gioKT, int soTien)
        {
            MaCLV = maCLV;
            TenCLV = tenCLV;
            GioBD = gioBD;
            GioKT = gioKT;
            SoTien = soTien;
        }
    }
}
