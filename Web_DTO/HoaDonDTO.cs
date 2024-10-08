using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_DTO
{
    public class HoaDonDTO
    {
       public int MaHDBH { get; set; } // Mã hóa đơn bán hàng
        public string MaNV { get; set; } // Mã nhân viên tạo hóa đơn
        public string MaBan { get; set; } // Mã bàn được đặt
        public DateTime? NgayXuatHD { get; set; } // Ngày xuất hóa đơn
        public int? TongTien { get; set; } // Tổng tiền hóa đơn
        public int? DiemTL { get; set; } // Điểm tích lũy
        public double? GiamGia { get; set; } // Phần trăm giảm giá
        public string MaKH { get; set; } // Mã khách hàng
        public int? SoTienThanhToan { get; set; } // Số tiền khách hàng đã thanh toán
        public DateTime? ThoiGianVao { get; set; } // Thời gian khách hàng vào chơi
        public DateTime? ThoiGianRa { get; set; } // Thời gian khách hàng ra
        public DateTime? ThoiGianDatCoc { get; set; } // Thời gian đặt cọc
        public int? TienDatCoc { get; set; } 
    }

}
