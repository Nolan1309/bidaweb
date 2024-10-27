using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Web_DAL;
using Web_DTO;

namespace Web_BUS
{
    public class ChiTietNiemYetBUS
    {
        private ChiTietNiemYetDAL chiTietNiemYetDAL = new ChiTietNiemYetDAL();

        public ChiTietNiemYetDTO GetChiTietNiemYetByMaBan(string maBan)
        {
            return chiTietNiemYetDAL.GetChiTietNiemYetByMaBan(maBan);
        }
    }
}
