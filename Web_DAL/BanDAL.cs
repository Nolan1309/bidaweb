using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_DTO;
namespace Web_DAL
{
    public class BanDAL
    {
        DatabaseConnection db = new DatabaseConnection();

        public List<Ban> GetLichSuDatBanByKhachHang(string maKH)
        {
            List<Ban> lichSuList = new List<Ban>();

            using (SqlConnection connection = db.Open())
            {
                string query = "SELECT  MaBan, TenBan, MaKV,TrangThai FROM BAN WHERE MaKH = @MaKH";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaKH", maKH);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Ban lichSu = new Ban
                    {
                        MaBan = reader["MaBan"].ToString(),
                        TenBan = reader["TenBan"].ToString(),
                        MaKV = reader["MaKV"].ToString(),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                    lichSuList.Add(lichSu);
                }
            }

            return lichSuList;
        }
        public List<Ban> GetAllBan()
        {
            List<Ban> banList = new List<Ban>();

            using (SqlConnection connection = db.Open())
            {
                string query = "SELECT MaBan, TenBan, MaKV FROM BAN WHERE TrangThai = N'Trống';";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Ban ban = new Ban()
                    {
                        MaBan = reader["MaBan"].ToString(),
                        TenBan = reader["TenBan"].ToString(),
                        MaKV = reader["MaKV"].ToString()
                    };
                    banList.Add(ban);
                }
            }

            return banList;
        }
        public List<Ban> GetBanByKhuVuc(string maKhuVuc)
        {
            List<Ban> banList = new List<Ban>();

            using (SqlConnection connection = db.Open())
            {
                string query = "SELECT MaBan, TenBan FROM BAN WHERE MaKV = @MaKV AND TrangThai = N'Trống'";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaKV", maKhuVuc);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Ban ban = new Ban()
                    {
                        MaBan = reader["MaBan"].ToString(),
                        TenBan = reader["TenBan"].ToString(),
                    };
                    banList.Add(ban);
                }
            }

            return banList;
        }

        // Lấy thông tin bàn theo mã bàn
        public Ban GetBanByMaBan(string maBan)
        {
            Ban ban = null;

            using (SqlConnection connection = db.Open())
            {
                string query = "SELECT MaBan, TenBan, TrangThai FROM BAN WHERE MaBan = @MaBan";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaBan", maBan);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ban = new Ban()
                    {
                        MaBan = reader["MaBan"].ToString(),
                        TenBan = reader["TenBan"].ToString(),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                }
            }

            return ban;
        }

        public void UpdateBanTrangThai(string maBan, string maKH, string trangThai, HoaDonDTO hoaDonMoi)
        {
            using (var db = new ConnectContextDataContext()) // Thay thế bằng tên DbContext của bạn
            {
                // Tìm bàn với mã bàn tương ứng
                var ban = db.BANs.FirstOrDefault(b => b.MaBan == maBan);

                if (ban != null)
                {
                    // Cập nhật trạng thái và mã khách hàng
                    ban.TrangThai = trangThai;
                    ban.MaKH = maKH;
                    ban.HDHienTai = hoaDonMoi.MaHDBH;
                  
                    // Lưu các thay đổi vào cơ sở dữ liệu
                    db.SubmitChanges();
                }
            }
        }

    }

}
