using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_DTO
{
    public class HoaDonDTO
    {
        public int MaHDBH { get; set; }          // Mã hóa đơn bán hàng
        public string MaNV { get; set; }         // Mã nhân viên thực hiện giao dịch
        public string MaBan { get; set; }        // Mã bàn được đặt
        public DateTime? NgayXuatHD { get; set; } // Ngày xuất hóa đơn
        public int? TongTien { get; set; }        // Tổng tiền của hóa đơn
        public int? DiemTL { get; set; }          // Điểm tích lũy từ hóa đơn
        public double? GiamGia { get; set; }       // Phần trăm giảm giá
        public string MaKH { get; set; }         // Mã khách hàng
        public int? SoTienThanhToan { get; set; } // Số tiền thanh toán thực tế
        public DateTime? ThoiGianVao { get; set; } // Thời gian khách vào
        public DateTime? ThoiGianRa { get; set; }  // Thời gian khách ra
        public DateTime? ThoiGianDatCoc { get; set; } // Thời gian đặt cọc
        public int? TienDatCoc { get; set; }      // Số tiền đặt cọc
        public DateTime? ThoiGianKTDatCoc { get; set; } // Thời gian kết thúc đặt cọc
        public int? SoPhutTreToiDa { get; set; }  // Số phút trễ tối đa

        // Constructor mặc định
        public HoaDonDTO() { }

        // Constructor có tham số
        public HoaDonDTO(int maHDBH, string maNV, string maBan, DateTime? ngayXuatHD, int tongTien, int diemTL,
                         float giamGia, string maKH, int soTienThanhToan, DateTime? thoiGianVao, DateTime? thoiGianRa,
                         DateTime? thoiGianDatCoc, int tienDatCoc, DateTime? thoiGianKTDatCoc, int soPhutTreToiDa)
        {
            MaHDBH = maHDBH;
            MaNV = maNV;
            MaBan = maBan;
            NgayXuatHD = ngayXuatHD;
            TongTien = tongTien;
            DiemTL = diemTL;
            GiamGia = giamGia;
            MaKH = maKH;
            SoTienThanhToan = soTienThanhToan;
            ThoiGianVao = thoiGianVao;
            ThoiGianRa = thoiGianRa;
            ThoiGianDatCoc = thoiGianDatCoc;
            TienDatCoc = tienDatCoc;
            ThoiGianKTDatCoc = thoiGianKTDatCoc;
            SoPhutTreToiDa = soPhutTreToiDa;
        }
    }
}
