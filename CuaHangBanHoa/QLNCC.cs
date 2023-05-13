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

namespace CuaHangBanHoa
{
    public partial class QLNCC : Form
    {
        public QLNCC()
        {
            InitializeComponent();
            loadDataNCC();
            dataNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataNCC.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void loadDataNCC()
        {
            string qr = @"select * from NhaCungCap";
            DataTable data = DataProvider.Instance.ExecuteQuery(qr);
            dataNCC.DataSource = data;
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            string sdt = tbSdt.Text;
            string ten = tbNCC.Text;
            string diachi = tbDiaChi.Text;
            
            string qr = @"insert into NhaCungCap values ( @sdt , @ten , @gioitinh )";
            DataProvider.Instance.ExecuteQuery(qr, new object[] { sdt, ten, diachi });
            loadDataNCC();
            MessageBox.Show("Thêm Thành Công !");
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            string sdt = dataNCC.CurrentRow.Cells[0].Value.ToString();
            string qr = @"delete from NhaCungCap where Sdt = @sdt";
            DataProvider.Instance.ExecuteQuery(qr, new object[] { sdt });
            loadDataNCC();
            MessageBox.Show("Xóa Thành Công !");
        }
    }
}
