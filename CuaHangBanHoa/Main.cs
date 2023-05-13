using CuaHangBanHoa.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CuaHangBanHoa.DTO;


namespace CuaHangBanHoa
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string sdt = tbTaiKhoan.Text;
            string mk = tbMk.Text;

            string qr = @"select * from NhanVien where Sdt = @sdt and MatKhau = @mk and PhanQuyen = 1";
            DataTable dataNhanVien = DataProvider.Instance.ExecuteQuery(qr, new object[] { sdt, mk });


            string qr2 = @"select * from NhanVien where Sdt = @sdt and MatKhau = @mk and PhanQuyen = 0";
            DataTable dataAdmin = DataProvider.Instance.ExecuteQuery(qr2, new object[] { sdt, mk });

            if (dataAdmin.Rows.Count > 0)
            {
                TrangChu trangChu = new TrangChu(sdt, mk);
                this.Hide();
                trangChu.ShowDialog();

            }
            else if (dataNhanVien.Rows.Count > 0)
            {
                BanHang banHang = new BanHang(sdt);
                this.Hide();
                banHang.ShowDialog();
            }
            else {
                MessageBox.Show("Tài khoản không tồn tại");
            }
        }
    }
}
