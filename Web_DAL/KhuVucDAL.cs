using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_DTO;
namespace Web_DAL
{
    public class KhuVucDAL
    {
        //private string connectionString = "your_connection_string_here"; // Thay thế bằng chuỗi kết nối của bạn
        DatabaseConnection db = new DatabaseConnection();
        public List<KhuVuc> GetAllKhuVuc()
        {
            List<KhuVuc> khuVucList = new List<KhuVuc>();

            using (SqlConnection connection = db.Open())
            {
                string query = "SELECT MaKV, TenKV, GiaTien, MaLoaiBan FROM KHUVUC";
                SqlCommand command = new SqlCommand(query, connection);

                //connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    KhuVuc kv = new KhuVuc()
                    {
                        MaKV = reader["MaKV"].ToString(),
                        TenKV = reader["TenKV"].ToString(),
                        GiaTien = Convert.ToInt32(reader["GiaTien"]),
                        MaLoaiBan = reader["MaLoaiBan"] != DBNull.Value ? Convert.ToInt32(reader["MaLoaiBan"]) : (int?)null
                    };
                    khuVucList.Add(kv);
                }
            }
            db.Close();

            return khuVucList;
        }
    }
}
