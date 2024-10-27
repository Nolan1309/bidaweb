using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_DAL;
using Web_DTO;
namespace Web_BUS
{
    public class LoaiBanBUS
    {
        private LoaiBanDAL loaiBanDAO;
        public LoaiBanBUS()
        {
            loaiBanDAO = new LoaiBanDAL();
        }
        // Lấy danh sách tất cả các loại bàn
        public List<LoaiBanDTO> GetAllLoaiBan()
        {
            return loaiBanDAO.GetAllLoaiBanDAL();
        }
        public LoaiBanDTO GetLoaiBanByMa(int maBan)
        {
            return loaiBanDAO.GetLoaiBanByMa(maBan);
        }

    }
}
