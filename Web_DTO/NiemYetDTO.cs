using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_DTO
{
    public class NiemYetDTO
    {
        public string MaNiemYet { get; set; }     // Mã niêm yết
        public string TenNiemYet { get; set; }    // Tên niêm yết

        // Constructor mặc định
        public NiemYetDTO() { }

        // Constructor có tham số
        public NiemYetDTO(string maNiemYet, string tenNiemYet)
        {
            MaNiemYet = maNiemYet;
            TenNiemYet = tenNiemYet;
        }
    }
}
