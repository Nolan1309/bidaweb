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
   
        public void TaoHoaDonDatBan(HoaDonDTO hoaDon)
        {
            HoaDonDAL hoaDonDAL = new HoaDonDAL();
            hoaDonDAL.ThemHoaDon(hoaDon); 
        }
 
        public HoaDonDTO LayHoaDonMoiNhat(int mahoadon)
        {
            return hoaDonDAL.LayHoaDonMoiNhat(mahoadon);
        }
        public void ThemHoaDon(HoaDonDTO hoaDon)
        {
            HoaDonDAL hoaDonDAL = new HoaDonDAL();
            hoaDonDAL.ThemHoaDon(hoaDon);
        }
      
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
