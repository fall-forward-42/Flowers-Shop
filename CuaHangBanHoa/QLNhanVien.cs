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
    public partial class QLNhanVien : Form
    {
        public QLNhanVien()
        {
            InitializeComponent();
            loadDataNhanVien();
            dataNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataNhanVien.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void QLNhanVien_Load(object sender, EventArgs e)
        {
           
        }
        private void loadDataNhanVien() {
            string qr = @"select * from NhanVien";
            DataTable data = DataProvider.Instance.ExecuteQuery(qr);
            dataNhanVien.DataSource = data;
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            string sdt = tbSdt.Text;
            string ten = tbTenNV.Text;
            string chucVu = tbChucVu.Text;
            string diaChi = tbDiaChi.Text;
            string mk = tbMk.Text;
            int gioiTinh;
            int phanQuyen;
            DateTime NgayVaoLam = dtNVL.Value;
            if (cbGioiTinh.SelectedText == "Nam")
            {
                gioiTinh = 1;
            }
            else 
            { 
               gioiTinh = 0;
            }
            if(cbPhanQuyen.SelectedText=="Quản Lý")
            {
                phanQuyen = 0;
            }
            else 
            {
                phanQuyen = 1;

            }
            string qr = @"exec usp_add_NhanVien @sdt , @ten , @gioi , @chuc , @dia , @phan , @ngay , @pass";
            DataProvider.Instance.ExecuteNonQuery(qr, new object[] { sdt, ten, gioiTinh, chucVu, diaChi, phanQuyen, NgayVaoLam, mk });
            loadDataNhanVien();
            tbSdt.ResetText();
            tbTenNV.ResetText();
               tbChucVu.ResetText();
            tbDiaChi.ResetText();
                tbMk.ResetText();

            MessageBox.Show("Thêm Thành Công !");
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            string sdt = dataNhanVien.SelectedCells[0].Value.ToString();
            string qr = @"delete from NhanVien where Sdt = @sdt ";
            DataProvider.Instance.ExecuteQuery(qr, new object[] {sdt});
            loadDataNhanVien();
            MessageBox.Show("Xóa Thành Công !");


        }
    }
}
