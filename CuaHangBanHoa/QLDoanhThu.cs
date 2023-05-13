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
    public partial class QLDoanhThu : Form
    {
        private List<HoaDonDTO> listHDDT;
        public QLDoanhThu()
        {
            InitializeComponent();
            loadDataAllHD();
            dataHDDT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataHDDT.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataAllHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataAllHD.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void loadDataAllHD()
        {
            string qr = @"select * from HoaDon";
            DataTable data = DataProvider.Instance.ExecuteQuery(qr);
            dataAllHD.DataSource = data;
        }
        private List<HoaDonDTO> getDataHoaDon()
        {
            List<HoaDonDTO> list = new List<HoaDonDTO>();
            string qr = "select * from CaLamViec";
            DataTable data = DataProvider.Instance.ExecuteQuery(qr);

            foreach (DataRow dr in data.Rows)
            {
                HoaDonDTO nv = new HoaDonDTO(dr);
                list.Add(nv);
            }
            return list;
        }
        private int tinhDoanhThu(List<HoaDonDTO> list)
        {
            int tong = 0;
            foreach(HoaDonDTO item in list) {
                tong = +item.TongTien;
            }
            return tong;
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            listHDDT = new List<HoaDonDTO>();
            tbTongDoanhThu.Text = "";
            string thang = tbThang.Text;
            string nam = tbNam.Text;
            if (thang == null && nam == null)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            }
            else
            {
                //get data cac hoa don duoc chon
                string qr = "select * from HoaDon where Month(NgayLapHoaDon) = @ThangCanTinh and Year(NgayLapHoaDon) = @NamCanTinh ";
                DataTable data = DataProvider.Instance.ExecuteQuery(qr, new object[] { thang, nam });
                if (data != null && data.Rows.Count > 0)
                {
                    //cho len bieu do
                    dataHDDT.DataSource = data;
                    foreach (DataRow dr in data.Rows)
                    {
                        HoaDonDTO item = new HoaDonDTO(dr);
                        listHDDT.Add(item);
                    }
                    //tinh doanh thu
                    int tongDoanhThu = tinhDoanhThu(listHDDT);
                    tbTongDoanhThu.Text += tongDoanhThu;

                }
                else
                {
                    MessageBox.Show("Không tồn tại doanh thu");
                }

            }
            
         

        }
    }
}
