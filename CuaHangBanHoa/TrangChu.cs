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
    public partial class TrangChu : Form
    {
        private string sdt;
        private string mk;
        private List<NhanVienDTO> listNV;

        public TrangChu(string sdt, string mk)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            this.sdt = sdt;
            this.mk = mk;
            listNV = getDataNhanVienBysdt(this.sdt);
            if (listNV.Count>0)
            {
                lbName.Text = listNV[0].TenNV.ToString();
            }
            else
            {
                MessageBox.Show("Tài Khoản không tồn tại");
            }
           
           
            
        }
        private List<NhanVienDTO> getDataNhanVienBysdt(string sdt) {
             List<NhanVienDTO> listNV = new List<NhanVienDTO>();
            string qr = "select * from NhanVien where Sdt = @sdt";
            DataTable data =  DataProvider.Instance.ExecuteQuery(qr,new object[] {sdt});
           
                foreach (DataRow dr in data.Rows)
                {
                    NhanVienDTO nv = new NhanVienDTO(dr);
                    listNV.Add(nv);
                }
            return listNV;
        }
        
        private void TrangChu_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //mỗi lần click tại slidebar thì sẽ thay đổi form theo từng nút đó
        private void thayDoiPanel(object formNew) {
            if (this.mainPanel.Controls.Count > 0)
                this.mainPanel.Controls.RemoveAt(0);
            Form form = formNew as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(form);
            this.mainPanel.Tag = form;
            form.Show();
        
        }
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            thayDoiPanel(new QLNhanVien());

        }

        private void btnCaLamViec_Click(object sender, EventArgs e)
        {
            thayDoiPanel(new QLCaLam());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            thayDoiPanel(new QLKhachHang());
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            thayDoiPanel(new QLNCC());

        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            thayDoiPanel(new QLKho());

        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            thayDoiPanel(new QLDoanhThu());

        }
        //click logo to back home
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void btnLogo_click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
        //click dang xuat
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Main fM = new Main();
            fM.ShowDialog();
        }
    }
}
