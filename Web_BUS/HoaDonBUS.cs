using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_DTO;
using Web_DAL;
namespace Web_BUS
{
    public class HoaDonBUS
    {
        HoaDonDAL hoaDonDAL = new HoaDonDAL();
        // Tạo hóa đơn mới khi khách hàng đặt bàn
        public void TaoHoaDonDatBan(HoaDonDTO hoaDon)
        {
            HoaDonDAL hoaDonDAL = new HoaDonDAL();
            hoaDonDAL.ThemHoaDon(hoaDon); // Gọi DAL để thêm hóa đơn vào cơ sở dữ liệu
        }
        // Lấy hóa đơn mới nhất của khách hàng cho một bàn cụ thể
        public HoaDonDTO LayHoaDonMoiNhat(int mahoadon)
        {
            return hoaDonDAL.LayHoaDonMoiNhat(mahoadon);
        }
        public void ThemHoaDon(HoaDonDTO hoaDon)
        {
            HoaDonDAL hoaDonDAL = new HoaDonDAL();
            hoaDonDAL.ThemHoaDon(hoaDon);
        }
        // Cập nhật tổng tiền hóa đơn khi khách hàng thanh toán
        public void CapNhatHoaDonThanhToan(int maHoaDon, int tongTien, int soTienThanhToan)
        {
            HoaDonDAL hoaDonDAL = new HoaDonDAL();
            hoaDonDAL.CapNhatHoaDonThanhToan(maHoaDon, tongTien, soTienThanhToan);
        }
        public int LayMaHoaDonCaoNhat()
        {
            return hoaDonDAL.LayMaHoaDonCaoNhat();
        }
    }
}
