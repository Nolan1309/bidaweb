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
        private ConnectContextDataContext _context; 
        DatabaseConnection db = new DatabaseConnection();
        public KhuVucDAL()
            {
                _context = new ConnectContextDataContext();
            }
        public List<KhuVucDTO> GetAllKhuVuc()
        {
            List<KhuVucDTO> khuVucList = new List<KhuVucDTO>();

            using (SqlConnection connection = db.Open())
            {
                string query = "SELECT MaKV, TenKV, GiaTien, MaLoaiBan FROM KHUVUC";
                SqlCommand command = new SqlCommand(query, connection);

                //connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    KhuVucDTO kv = new KhuVucDTO()
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


        public List<KhuVucDTO> GetKhuVucByLoaiBan(int maLoaiBan)
        {
            var query = from kv in _context.KHUVUCs
                        where kv.MaLoaiBan == maLoaiBan
                        select new KhuVucDTO
                        {
                            MaKV = kv.MaKV,
                            TenKV = kv.TenKV,
                            GiaTien = kv.GiaTien , 
                            MaLoaiBan = kv.MaLoaiBan
                        };

            return query.ToList();
        }
        public KhuVucDTO GetKhuVucByMa(string maKV)
        {
            var khuVuc = _context.KHUVUCs.FirstOrDefault(kv => kv.MaKV == maKV);
            if (khuVuc != null)
            {
                return new KhuVucDTO
                {
                    MaKV = khuVuc.MaKV,
                    TenKV = khuVuc.TenKV,
                    GiaTien = khuVuc.GiaTien,
                    MaLoaiBan = khuVuc.MaLoaiBan
                };
            }
            return null;
        }
    }
}
