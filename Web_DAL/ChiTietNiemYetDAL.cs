using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using Web_DTO;

namespace Web_DAL
{
    public class ChiTietNiemYetDAL
    {
        private ConnectContextDataContext _context;

        // Constructor để khởi tạo _context
        public ChiTietNiemYetDAL()
        {
            _context = new ConnectContextDataContext(); // Khởi tạo đối tượng ConnectContextDataContext
        }

        public ChiTietNiemYetDTO GetChiTietNiemYetByMaBan(string maBan)
        {
            var chiTietNiemYet = _context.ChiTietNiemYetBans.FirstOrDefault(ct => ct.MaBan == maBan);
            if (chiTietNiemYet != null)
            {
                return new ChiTietNiemYetDTO
                {
                    MaBan = chiTietNiemYet.MaBan,
                    MaNiemYet = chiTietNiemYet.MaNiemYet,
                    GiaTri = chiTietNiemYet.GiaTri
                };
            }
            return null;
        }
    }
}
