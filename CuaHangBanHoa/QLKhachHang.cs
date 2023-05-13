using CuaHangBanHoa.DAO;
using CuaHangBanHoa.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangBanHoa
{
    public partial class QLKhachHang : Form
    {
        public QLKhachHang()
        {
            InitializeComponent();
            loadDataKH();
            dataKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataKH.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void loadDataKH()
        {
            string qr = @"select * from KhachHang";
            DataTable data = DataProvider.Instance.ExecuteQuery(qr);
            dataKH.DataSource = data;
        }
        private List<KhachHangDTO> getDataKH()
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            string qr = "select * from CaLamViec";
            DataTable data = DataProvider.Instance.ExecuteQuery(qr);

            foreach (DataRow dr in data.Rows)
            {
                KhachHangDTO nv = new KhachHangDTO(dr);
                list.Add(nv);
            }
            return list;
        }
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            string sdt = tbSdt.Text;
            string ten = tbHoTen.Text;
            int gioi;
            if(cbGioiTinh.SelectedText == "Nam")
            {
                gioi = 1;
            }
            else
            {
                gioi = 0;
            }
            string thongTin = tbThongTin.Text;
            string qr = @"insert into KhachHang values ( @sdt , @ten , @gioitinh , @thongtin )";
            DataProvider.Instance.ExecuteQuery(qr, new object[] {sdt,ten,gioi,thongTin  });
            loadDataKH();
            MessageBox.Show("Thêm Thành Công !");


        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            string sdt = dataKH.CurrentRow.Cells[0].Value.ToString();
            string qr = @"delete from KhachHang where SdtNV = @sdt";
            DataProvider.Instance.ExecuteQuery(qr, new object[] { sdt });
            loadDataKH();
            MessageBox.Show("Xóa Thành Công !");
        }
    }
}
