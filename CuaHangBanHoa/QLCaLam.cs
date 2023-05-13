using CuaHangBanHoa.DAO;
using CuaHangBanHoa.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangBanHoa
{
    public partial class QLCaLam : Form
    {
        private List<CaLamViecDTO> listCLV;
        private List<NhanVienDTO> listNV;
        private string maCLVDaChon;
        private string sdtNV;
        private int tongTienCLVDaChon;
    
        public QLCaLam()
        {
            InitializeComponent();

            //load thong tin
            loadDataCTNV();
            loadDataCLV_cb();
            loadNV_cb();
            dataChiTietNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataChiTietNhanVien.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //get data CLV

        }
        private void loadDataCTNV() {
            string qr = @"select * from ChiTietNhanVien";
            DataTable data = DataProvider.Instance.ExecuteQuery(qr);
            dataChiTietNhanVien.DataSource = data;
        }
        //load ca lam viec len cb
        private void loadDataCLV_cb() { 
            List<CaLamViecDTO> listCLV = getDataCLV();
            List<string> listCa = new List<string>();
            foreach(CaLamViecDTO ca in listCLV)
            {
                listCa.Add(ca.MaCLV);
            }
            cbCaLamViec.DataSource = listCa;
        }
     
        // load ten nhan vien len cb
        private void loadNV_cb()
        {
            List<NhanVienDTO> listNV = getDataNV();
            List<string> listTenNV = new List<string>();
            foreach (NhanVienDTO nv in listNV)
            {
                listTenNV.Add(nv.TenNV);
            }
           
            cbNhanVien.DataSource = listTenNV;
        }
        //get data CLV
        private List<CaLamViecDTO> getDataCLV() {
            List<CaLamViecDTO> list = new List<CaLamViecDTO>();
            string qr = "select * from CaLamViec";
            DataTable data = DataProvider.Instance.ExecuteQuery(qr);

            foreach (DataRow dr in data.Rows)
            {
                CaLamViecDTO nv = new CaLamViecDTO(dr);
                list.Add(nv);
            }
            return list;
        }
        //get data CTNV
        private List<ChiTietNhanVienDTO> getDataChiTietNhanVien()
        {
            List<ChiTietNhanVienDTO> list = new List<ChiTietNhanVienDTO>();
            string qr = "select * from ChiTietNhanVien";
            DataTable data = DataProvider.Instance.ExecuteQuery(qr);

            foreach (DataRow dr in data.Rows)
            {
                ChiTietNhanVienDTO nv = new ChiTietNhanVienDTO(dr);
                list.Add(nv);
            }
            return list;
        }
        //get data NV
        private List<NhanVienDTO> getDataNV()
        {
            List<NhanVienDTO> list = new List<NhanVienDTO>();
            string qr = "select * from NhanVien where PhanQuyen = 1";
            DataTable data = DataProvider.Instance.ExecuteQuery(qr);

            foreach (DataRow dr in data.Rows)
            {
                NhanVienDTO nv = new NhanVienDTO(dr);
                list.Add(nv);
            }
            return list;
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        //show all details ca lam viec 

        //add CTNV to database
        private void btnThemCaLam_Click(object sender, EventArgs e)
        {
            string qr = @"exec usp_insertChiTietNhanVien @maCa , @sdt , @tongCa , @tongTien ";
            int tongSoCa = (int )nmTongSoCa.Value;
            int tongTien = (int)(tongSoCa * tongTienCLVDaChon);
            DataProvider.Instance.ExecuteQuery(qr,new object[] {maCLVDaChon,sdtNV, tongSoCa, tongTien });
            loadDataCTNV();
            MessageBox.Show("Thêm Thành Công");
        }

        private void cbCaLamViec_Change(object sender, EventArgs e)
        {
            listCLV = getDataCLV();
            string maCa = cbCaLamViec.SelectedValue.ToString();
            maCLVDaChon = maCa;
            foreach (CaLamViecDTO ca in listCLV)
            {
                if (maCa == ca.MaCLV)
                {
                    lbTenCa.Text = ca.TenCLV;
                    tongTienCLVDaChon = ca.SoTien;
                    lbSoTienCa.Text = ca.SoTien.ToString() + " VNĐ";
                    lbGBD.Text = ca.GioBD.ToString() + " Giờ";
                    lbGKT.Text = ca.GioKT.ToString() + " Giờ";
                }
            }
        }

        private void cbNhanVien_change(object sender, EventArgs e)
        {
            listNV =getDataNV();
            string tenNV = cbNhanVien.SelectedValue.ToString();
            foreach(NhanVienDTO nhan in listNV)
            {
                if(nhan.TenNV == tenNV)
                {
                    sdtNV = nhan.Sdt;
                    lbChucVu.Text = nhan.ChucVu;
                    lbSdtNV.Text = nhan.Sdt;
                }
            }

        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            string maCa = dataChiTietNhanVien.CurrentRow.Cells[0].Value.ToString();
            string sdt = dataChiTietNhanVien.CurrentRow.Cells[1].Value.ToString();
            string qr = @"delete from ChiTietNhanVien where SdtNV = @sdt and MaCLV = @maCa ";
            DataProvider.Instance.ExecuteQuery(qr, new object[] {sdt,maCa});
            loadDataCTNV();
            MessageBox.Show("Xóa Thành Công !");
        }
    }
}
