    using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanHoa.DTO
{
    public class NhanVienDTO
    {
        private string sdt;
        private string tenNV;
        private int gioiTinh;
        private string chucVu;
        private string diaChi;
        private int phanQuyen;
        private DateTime ngayVaoLam;
        private string matKhau;

        public NhanVienDTO(string sdt, string tenNV, int gioiTinh, string chucVu, string diaChi, int phanQuyen, DateTime ngayVaoLam, string matKhau)
        {
            Sdt = sdt;
            TenNV = tenNV;
            GioiTinh = gioiTinh;
            ChucVu = chucVu;
            DiaChi = diaChi;
            PhanQuyen = phanQuyen;
            NgayVaoLam = ngayVaoLam;
            MatKhau = matKhau;
            
        }
        public NhanVienDTO(DataRow row) {
            Sdt = (string)row["Sdt"];
            TenNV = (string)row["TenNV"];
            GioiTinh = (int)row["GioiTinh"];
            ChucVu = (string)row["ChucVu"];
            DiaChi = (string)row["DiaChi"];
            PhanQuyen = (int)row["PhanQuyen"];
            ngayVaoLam = (DateTime)row["NgayVaolam"];
            MatKhau = (string)row["MatKhau"];



        }

        public string Sdt { get => sdt; set => sdt = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public int GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public int PhanQuyen { get => phanQuyen; set => phanQuyen = value; }
        public DateTime NgayVaoLam { get => ngayVaoLam; set => ngayVaoLam = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
    }
}
