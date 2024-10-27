using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_DTO
{
    public class LoaiBanDTO
    {
        public int MaBan { get; set; }  // Mã loại bàn
    public string TenLoaiBan { get; set; }  // Tên loại bàn
    public int? GiaGioChoi { get; set; }  // Giá giờ chơi

    // Constructor (nếu cần)
    public LoaiBanDTO() {}

    public LoaiBanDTO(int maBan, string tenLoaiBan, int giaGioChoi)
    {
        this.MaBan = maBan;
        this.TenLoaiBan = tenLoaiBan;
        this.GiaGioChoi = giaGioChoi;
   
    }
    }

}
