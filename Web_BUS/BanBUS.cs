using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_DTO;
using Web_DAL;
namespace Web_BUS
{
    public class BanBUS
    {
        private BanDAL banDAL;
        public List<Ban> GetLichSuDatBan(string maKH)
        {
            return banDAL.GetLichSuDatBanByKhachHang(maKH);
        }
        public BanBUS()
        {
            banDAL = new BanDAL();
        }
        public List<Ban> GetAllBan()
        {
            return banDAL.GetAllBan();
        }
        public List<Ban> GetBanByKhuVuc(string maKhuVuc)
        {
            BanDAL banDAL = new BanDAL();
            return banDAL.GetBanByKhuVuc(maKhuVuc);
        }
        // Lấy thông tin bàn dựa theo mã bàn
        public Ban GetBanByMaBan(string maBan)
        {
            return banDAL.GetBanByMaBan(maBan);
        }

        // Cập nhật trạng thái bàn và mã khách hàng
        public void UpdateBanTrangThai(string maBan, string maKV, string trangThai, HoaDonDTO hoaDonMoi)
        {
            banDAL.UpdateBanTrangThai(maBan, maKV, trangThai, hoaDonMoi);
        }
    }

}
