using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_DAL;
using Web_DTO;
namespace Web_BUS
{
    public class KhuVucBUS
    {
        private KhuVucDAL khuVucDAL;

        public KhuVucBUS()
        {
            khuVucDAL = new KhuVucDAL();
        }

        public List<KhuVuc> GetAllKhuVuc()
        {
            return khuVucDAL.GetAllKhuVuc();
        }
    }
}
