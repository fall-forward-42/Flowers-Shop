using CuaHangBanHoa.DAO;
using CuaHangBanHoa.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangBanHoa
{
    public partial class QLKho : Form
    {
        private List<NhaCungCapDTO> listNCC = new List<NhaCungCapDTO>();
        private List<LoaiHangHoaDTO> listLHang = new List<LoaiHangHoaDTO>();
        private string maLoai;
        private string sdtNCC;

        public QLKho()
        {
            InitializeComponent();
            loadDataKho();
            loadDataLoaiHang_cb();
            loadDataNCC_cb();
            dataKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataKho.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        
        private void loadDataKho()
        {
            string qr = @"select * from HangHoa";
            DataTable data = DataProvider.Instance.ExecuteQuery(qr);
            dataKho.DataSource = data;
        }
        //load nha cung cap
        private void loadDataNCC_cb()
        {
            List<NhaCungCapDTO> list = getDataNCC();
            List<string> name = new List<string>();
            foreach (NhaCungCapDTO ca in list)
            {
                name.Add(ca.TenNCC);
            }
            cbNCC.DataSource = name;
        }
        //get data ncc
        private List<NhaCungCapDTO> getDataNCC()
        {
            List<NhaCungCapDTO> list = new List<NhaCungCapDTO>();
            string qr = "select * from NhaCungCap";
            DataTable data = DataProvider.Instance.ExecuteQuery(qr);

            foreach (DataRow dr in data.Rows)
            {
                NhaCungCapDTO nv = new NhaCungCapDTO(dr);
                list.Add(nv);
            }
            return list;
        }
       
        //load loai hang
        private void loadDataLoaiHang_cb()
        {
            List<LoaiHangHoaDTO> list = getDataLoaiHang();
            List<string> name = new List<string>();
            foreach (LoaiHangHoaDTO ca in list)
            {
                name.Add(ca.TenLoaiHang);
            }
            cbLoaiHang.DataSource = name;
        }
        //get data loai hang
        private List<LoaiHangHoaDTO> getDataLoaiHang()
        {
            List<LoaiHangHoaDTO> list = new List<LoaiHangHoaDTO>();
            string qr = "select * from LoaiHangHoa";
            DataTable data = DataProvider.Instance.ExecuteQuery(qr);

            foreach (DataRow dr in data.Rows)
            {
                LoaiHangHoaDTO nv = new LoaiHangHoaDTO(dr);
                list.Add(nv);
            }
            return list;
        }
        //them hang vao kho
        private void btnThemCaLam_Click(object sender, EventArgs e)
        {
            string tenHang = tbTenHang.Text;
            string hinhAnh = "none";
            int soLuong = (int)nmSoLuong.Value;
            string gia = tbGia.Text;

            string qr = "exec usp_themSanPham @ten , @maLoai , @hinhAnh , @sdtNCC , @soluong , @gia ";
            DataProvider.Instance.ExecuteQuery(qr, new object[] { tenHang, maLoai, hinhAnh, sdtNCC, soLuong, gia });
            loadDataKho();
            MessageBox.Show("Thêm Thành Công");
        }

        private void cbNCC_change(object sender, EventArgs e)
        {
            listNCC = getDataNCC();
            string tenNCC = cbNCC.SelectedValue.ToString();
            foreach (NhaCungCapDTO nhan in listNCC)
            {
                if (nhan.TenNCC == tenNCC)
                {
                    lbDiaChi.Text = nhan.TenNCC;
                    sdtNCC = nhan.Sdt;
                }
            }
        }

        private void cbLoaiHang_change(object sender, EventArgs e)
        {
            listLHang = getDataLoaiHang();
            string tenNCC = cbLoaiHang.SelectedValue.ToString();
            foreach (LoaiHangHoaDTO nhan in listLHang)
            {
                if (nhan.TenLoaiHang == tenNCC)
                {
                    lbMoTa.Text = nhan.MoTa;
                    maLoai = nhan.MaLoaiHang;
                }
            }
        }
        //xoa kho hang
        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            string maHang = dataKho.CurrentRow.Cells[0].Value.ToString();
            string qr = @"delete from HangHoa where MaHang = @sdt  ";
            DataProvider.Instance.ExecuteQuery(qr, new object[] {maHang });
            loadDataKho();
            MessageBox.Show("Xóa Thành Công !");
        }
    }
}
