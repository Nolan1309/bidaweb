using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_DTO;
namespace Web_DAL
{
    public class KhachHangDAL
    {
        private DatabaseConnection db = new DatabaseConnection();

        public KhachHang GetKhachHangByCredentials(string username, string password)
        {
            using (SqlConnection connection = db.Open())
            {
                string query = "SELECT * FROM KhachHang WHERE SDT = @username AND MatKhau = @password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    KhachHang kh = new KhachHang
                    {
                        MaKH = reader["MaKH"].ToString(),
                        TenKH = reader["TenKH"].ToString(),
                        SDT = reader["SDT"].ToString(),
                        MatKhau = reader["MatKhau"].ToString()
                    };
                    return kh;
                }
            }
            return null; // Nếu không tìm thấy khách hàng
        }

        public string GetMaxMaKH()
        {
            using (SqlConnection connection = db.Open())
            {
                string query = "SELECT MAX(MaKH) FROM KHACHHANG";
                SqlCommand command = new SqlCommand(query, connection);
                object result = command.ExecuteScalar();
                return result != DBNull.Value ? (string)result : null;
            }
        }
        public void UpdateKhachHang(KhachHang khachHang)
        {
            using (SqlConnection connection = db.Open())
            {
                string query = "UPDATE KhachHang SET TenKH = @TenKH, SDT = @SDT, MatKhau = @MatKhau WHERE MaKH = @MaKH";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenKH", khachHang.TenKH);
                command.Parameters.AddWithValue("@SDT", khachHang.SDT);
                command.Parameters.AddWithValue("@MatKhau", khachHang.MatKhau);
                command.Parameters.AddWithValue("@MaKH", khachHang.MaKH);
                command.ExecuteNonQuery();
            }
        }
        public bool KiemTraTrungSoDienThoai(string soDienThoai)
        {
            using (SqlConnection connection = db.Open())
            {
                string query = "SELECT COUNT(*) FROM KHACHHANG WHERE SDT = @SoDienThoai";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                return (int)command.ExecuteScalar() > 0;
            }
        }

        public void ThemKhachHang(KhachHang khachHang)
        {
            using (SqlConnection connection = db.Open())
            {
                string query = "INSERT INTO KHACHHANG (MaKH, TenKH, SDT, MatKhau, MaLKH, DiemTichLuy) VALUES (@MaKH, @TenKH, @SoDienThoai, @MatKhau, @LoaiKH, @DiemTichLuy)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaKH", khachHang.MaKH);
                command.Parameters.AddWithValue("@TenKH", khachHang.TenKH);
                command.Parameters.AddWithValue("@SoDienThoai", khachHang.SDT);
                command.Parameters.AddWithValue("@MatKhau", khachHang.MatKhau);
                command.Parameters.AddWithValue("@LoaiKH", khachHang.MaLKH);
                command.Parameters.AddWithValue("@DiemTichLuy", khachHang.DiemTichLuy);
                command.ExecuteNonQuery();
            }
        }


    }
}
