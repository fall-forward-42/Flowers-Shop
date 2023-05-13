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
    public partial class BanHang : Form
    {
        private List<LoaiHangHoaDTO> listLH;
        private string sdtNV;

        public string SdtNV { get => sdtNV; set => sdtNV = value; }

        public BanHang(string sdtNV)
        {
            SdtNV = sdtNV;
            
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            dataGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGioHang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //load cbLoaiHang
            loadDataLoaiHang_cb();
            lbTenNV.Text = sdtNV;
        }
        //tao SAN PHAM
        private void taoDanhSachSanPham(List<HangHoaDTO> listHH, int countSP)
        {
            flpDanhSachHangHoa.Controls.Clear();
            SanPham[] item = new SanPham[countSP];
            for(int i = 0; i < countSP; i++)
            {
                string tenHang = listHH[i].TenHang;
                string maLoai = listHH[i].MaHang;
                string hinhAnh =listHH[i].HinhAnh;
                int soLuong= listHH[i].SoLuong;
                int gia =listHH[i].Gia;
                item[i] = new SanPham(tenHang,maLoai,hinhAnh,soLuong,gia);
                item[i].Click += SP_clickEvent;
                flpDanhSachHangHoa.Controls.Add(item[i]);


            }
        }
        //click tung san pham cho vao gio hang
        private void SP_clickEvent(object sender, EventArgs e)
        {
            SanPham sp = sender as SanPham;
            //them sp moi vao gio hang
            DataGridViewRow row = (DataGridViewRow)dataGioHang.Rows[0].Clone();
            row.Cells[0].Value = sp.MaLoai;
            row.Cells[1].Value = sp.TenHang;
            row.Cells[2].Value = sp.Gia;
            row.Cells[3].Value = 1;
            dataGioHang.Rows.Add(row);
            
            

       }
        //load all hoa
        private void loadAllHangHoa_flowPanel() { 
            List<HangHoaDTO> listHH = new List<HangHoaDTO>();
            listHH = getDataHangHoa();
            int countSP = listHH.Count;
            taoDanhSachSanPham(listHH,countSP);

        }
        //get data hang hoa
        private List<HangHoaDTO> getDataHangHoa()
        {
            List<HangHoaDTO> list = new List<HangHoaDTO>();
            string qr = "select * from HangHoa";
            DataTable data = DataProvider.Instance.ExecuteQuery(qr);

            foreach (DataRow dr in data.Rows)
            {
                HangHoaDTO nv = new HangHoaDTO(dr);
                list.Add(nv);
            }
            return list;
        }
        //load loai hang on cb
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

        

        private void cbLoaiHang_change(object sender, EventArgs e)
        {
            listLH = getDataLoaiHang();
            string tenLoai = cbLoaiHang.SelectedValue.ToString();
            foreach (LoaiHangHoaDTO item in listLH)
            {
                if(item.TenLoaiHang == tenLoai)
                {
                    List<HangHoaDTO> list = new List<HangHoaDTO>();
                    string maLoai = item.MaLoaiHang;
                    string qr = @"select * from HangHoa where MaLoaiHang = @maLoai ";
                    DataTable data = DataProvider.Instance.ExecuteQuery(qr,new object[] { maLoai });
                    foreach (DataRow dr in data.Rows)
                    {
                        HangHoaDTO nv = new HangHoaDTO(dr);
                        list.Add(nv);
                    }
                    int listCount = list.Count;
                    taoDanhSachSanPham(list, listCount);

                }
            }
        }
        //hien thi tat ca san pham
        private void btnHienThiAll_Click(object sender, EventArgs e)
        {
            //liet ke tat ca san pham
            loadAllHangHoa_flowPanel();
        }
        //tim kiem theo san pham
        private DataTable timKiemTheoTenSp(string tenSP)
        {
            string qr1 = @"exec usp_TimSPTheoTen @tenSp ";
            DataTable data = DataProvider.Instance.ExecuteQuery(qr1, new object[] { tenSP });
            //co ket qua 
            if(data.Rows.Count > 0)
            {
                return data;
            }
            return null;
        }
        //tim kiem theo ten danh muc
        private DataTable timKiemTheoTenDanhMuc(string tenDanhMuc)
        {
            string qr1 = @"exec usp_TimTheoDanhMuc @tenSp ";
            DataTable data = DataProvider.Instance.ExecuteQuery(qr1, new object[] { tenDanhMuc });
            //co ket qua 
            if (data.Rows.Count > 0)
            {
                return data;
            }
            return null;
        }
        //tim kiem theo textBox
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string timKiem = tbTimKiem.Text;
            if (timKiem.Trim() != "")
            {
                
                List<HangHoaDTO> list = new List<HangHoaDTO>();

                if (timKiemTheoTenSp(timKiem) != null)
                {
                    DataTable dataTenSP = timKiemTheoTenSp(timKiem);
                    foreach (DataRow dr in dataTenSP.Rows)
                    {
                        HangHoaDTO nv = new HangHoaDTO(dr);
                        list.Add(nv);
                    }
                    int listCount = list.Count;
                    taoDanhSachSanPham(list, listCount);
                }
                else if (timKiemTheoTenDanhMuc(timKiem)!=null)
                {
                    DataTable dataTenDanhMuc = timKiemTheoTenDanhMuc(timKiem);
                    foreach (DataRow dr in dataTenDanhMuc.Rows)
                    {
                        HangHoaDTO nv = new HangHoaDTO(dr);
                        list.Add(nv);
                    }
                    int listCount = list.Count;
                    taoDanhSachSanPham(list, listCount);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm mong muốn");
                }




            }
            else
            {
                MessageBox.Show("Vui lòng Điền Thông Tin tìm kiếm");
            }
        }
        //tim kiem sp theo gia
       

        private void cbGiaMuonTim_change(object sender, EventArgs e)
        {
            List<HangHoaDTO> list = new List<HangHoaDTO>();
            string gia = cbGiaMuonTim.SelectedItem.ToString();
            int giaCanTim;
      
            if(gia =="Dưới 10.000.000 VNĐ")
            {
                giaCanTim = 10000000;
            }
            else if (gia == "Dưới 5.000.000 VNĐ")
            {
                giaCanTim = 5000000;

            }
            else if(gia == "Dưới 3.000.000 VNĐ")
            {
                giaCanTim = 3000000;

            }
            else 
            {
                giaCanTim = 1000000;

            }
            string qr = @"exec  usp_TimTheoGia @gia ";
            DataTable data = DataProvider.Instance.ExecuteQuery(qr, new object[] { giaCanTim });
            foreach (DataRow dr in data.Rows)
            {
                HangHoaDTO nv = new HangHoaDTO(dr);
                list.Add(nv);
            }
            int listCount = list.Count;
            taoDanhSachSanPham(list, listCount);
        }
        //xoa san pham trong gio
        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGioHang.SelectedRows)
            {
                dataGioHang.Rows.RemoveAt(row.Index);
            }
        }
        //xoa tat ca san pham
        private void btnXoaGioHang_Click(object sender, EventArgs e)
        {
            dataGioHang.Rows.Clear();
            MessageBox.Show(sdtNV);

        }
        //thanh toan
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int tongTien = 0;
            // string tenNV = lbTenNV.Text;
            string tenNV = SdtNV;
          
            string sdtKhachHang = tbSdtKhachHang.Text;
            DateTime ngayLap = dateNgayLap.Value;

            List<ChiTietHoaDonDTO> listCTHD = new List<ChiTietHoaDonDTO>();
            List<int> listTT = new List<int>();
            foreach (DataGridViewRow row in dataGioHang.Rows)
            {
                //tranh gap dong null cuoi cung
                if (row.Cells[2].Value != null)
                {
                    //tinh tong tien
                    tongTien += (int)row.Cells[2].Value * (int)row.Cells[3].Value;
                    listTT.Add(tongTien);
                    //lay tung dong san pham
                    string maHd = "none";
                    string maHang = row.Cells[0].Value.ToString();
                    string tenHang = row.Cells[1].Value.ToString();
                    int soLuong = (int)row.Cells[3].Value;
                    int thanhTien = tongTien;
                    ChiTietHoaDonDTO CTHD = new ChiTietHoaDonDTO(maHd, maHang, soLuong, thanhTien);
                    CTHD.TenHang = tenHang;
                    listCTHD.Add(CTHD);
                }
            }
            //tao form hoa don
            HoaDon hoaDon = new HoaDon(tenNV,sdtKhachHang,ngayLap,listCTHD,tongTien);
            //them hoa don vao database
            string qr = @"exec usp_LapHoaDon @sdtNV , @sdtKH , @ngay , @tongtien , @trangthai ";
            DataProvider.Instance.ExecuteQuery(qr, new object[] {tenNV,sdtKhachHang,ngayLap,tongTien,(int)1});
            //tao chi tiet hoa don - giam so luong hang da duoc ban ra
            hoaDon.lapCTHD(listCTHD, listTT);

            //reset thong tin nhap vao
            tbSdtKhachHang.Text="";
            dataGioHang.ClearSelection();

            //show hoa don
            hoaDon.ShowDialog();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Main fM = new Main();
            fM.ShowDialog();
        }

        private void btnThemSoLuong_Click(object sender, EventArgs e)
        {
            int soLuongCapNhat =(int)nmThemSp.Value;
            string maHang = dataGioHang.CurrentRow.Cells[0].Value.ToString();
            dataGioHang.CurrentRow.Cells[3].Value = soLuongCapNhat;

        }
    }
}
