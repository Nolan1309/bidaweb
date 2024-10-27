using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_DTO
{
    public class ChiTietNiemYetDTO
    {
        public string MaBan { get; set; }         // Mã bàn
        public string MaNiemYet { get; set; }     // Mã niêm yết
        public int? GiaTri { get; set; }           // Giá trị niêm yết

        // Constructor mặc định
        public ChiTietNiemYetDTO() { }

        // Constructor có tham số
        public ChiTietNiemYetDTO(string maBan, string maNiemYet, int giaTri)
        {
            MaBan = maBan;
            MaNiemYet = maNiemYet;
            GiaTri = giaTri;
        }
    }
}
