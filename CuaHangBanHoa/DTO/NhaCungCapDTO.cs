using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanHoa.DTO
{
    public class NhaCungCapDTO
    {
        private string sdt;
        private string tenNCC;
        private string diaChi;

        public NhaCungCapDTO(string sdt, string tenNCC, string diaChi)
        {
            Sdt = sdt;
            TenNCC = tenNCC;
            DiaChi = diaChi;
        }
        public NhaCungCapDTO(DataRow row)
        {
            Sdt = (string)row["Sdt"];
            TenNCC = (string)row["TenNCC"];
            DiaChi = (string)row["DiaChi"];
        }

        public string Sdt { get => sdt; set => sdt = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }
}
