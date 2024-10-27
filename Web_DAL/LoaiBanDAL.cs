using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_DTO;
namespace Web_DAL
{
    public class LoaiBanDAL
    {
        private ConnectContextDataContext context;
        public LoaiBanDAL()
            {
                context = new ConnectContextDataContext();
            }
        public List<LoaiBanDTO> GetAllLoaiBanDAL()
        {
            var query = from lb in context.LoaiBans
                        select new LoaiBanDTO
                        {
                            MaBan = lb.maban,
                            TenLoaiBan = lb.tenloaiban,
                            GiaGioChoi = lb.GiaGioChoi ?? 0, 
                        
                        };

            return query.ToList();
        }
        public LoaiBanDTO GetLoaiBanByMa(int maBan)
        {
            var loaiBan = context.LoaiBans.FirstOrDefault(lb => lb.maban == maBan);
            if (loaiBan != null)
            {
                return new LoaiBanDTO
                {
                    MaBan = loaiBan.maban,
                    TenLoaiBan = loaiBan.tenloaiban,
                    GiaGioChoi = loaiBan.GiaGioChoi
                };
            }
            return null;
        }
    }
}
