using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanHoa.DAO
{
    public class DataProvider
    {
        //singleton design pattern tạo 1 luồng truy cập đến dtb
        private static DataProvider instance; // crt+E+R để đóng gói instance phục vụ singleton

        // địa chỉ kết nối tới database
        private string connectionSTR = @"Data Source=LAPTOP-BUDQJ0PN\SQLEXPRESS;Initial Catalog=CuaHangBanHoa;Integrated Security=True";

        //cấu trúc singleton
        public static DataProvider Instance
        {
            //tạo tham chiếu DataProvider
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set => instance = value;
        }

        private DataProvider() { }//đảm bảo bên ngoài kh tác động dc vào constructer

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            //kết nối thông qua địa chỉ 
            //tự động giải phóng sau khi kết thúc khối lệnh
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                //mở database 
                connection.Open();
                //kết nối câu lệnh với dtb
                SqlCommand cmd = new SqlCommand(query, connection);

                //nếu cmd có tham số 
                if (parameter != null)
                {
                    string[] listPara = query.Split();
                    int i = 0;
                    //tìm tham số và thêm giá trị tham số
                    foreach (string item in listPara)
                    {
                        //nếu thấy tham số
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                //đổ data vào dataTable thông qua adapter
                adt.Fill(data);

                //đóng dtb
                connection.Close();
            }

            return data;

        }
        //trả về số dòng tìm thấy
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            //kết nối thông qua địa chỉ 
            //tự động giải phóng sau khi kết thúc khối lệnh
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                //mở database 
                connection.Open();
                //kết nối câu lệnh với dtb
                SqlCommand cmd = new SqlCommand(query, connection);

                //nếu cmd có tham số 
                if (parameter != null)
                {
                    string[] listPara = query.Split();
                    int i = 0;
                    //tìm tham số và thêm giá trị tham số
                    foreach (string item in listPara)
                    {
                        //nếu thấy tham số
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = cmd.ExecuteNonQuery();
                //đóng dtb
                connection.Close();
            }

            return data;

        }
        //trả về hàng đầu tiên
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            //kết nối thông qua địa chỉ 
            //tự động giải phóng sau khi kết thúc khối lệnh
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                //mở database 
                connection.Open();
                //kết nối câu lệnh với dtb
                SqlCommand cmd = new SqlCommand(query, connection);

                //nếu cmd có tham số 
                if (parameter != null)
                {
                    string[] listPara = query.Split();
                    int i = 0;
                    //tìm tham số và thêm giá trị tham số
                    foreach (string item in listPara)
                    {
                        //nếu thấy tham số
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = cmd.ExecuteScalar();
                //đóng dtb
                connection.Close();
            }

            return data;

        }
    }
}
