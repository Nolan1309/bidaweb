using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_DAL;
using Web_DTO;
namespace Web_BUS
{
    public class KhachHangBUS
    {
        private KhachHangDAL khachHangDAL = new KhachHangDAL();
        public void UpdateKhachHang(KhachHang khachHang)
        {
            khachHangDAL.UpdateKhachHang(khachHang);
        }
        public KhachHang Login(string username, string password)
        {
            return khachHangDAL.GetKhachHangByCredentials(username, password);
        }

        // Hàm tạo mã khách hàng tự động
        public string GenerateMaKH()
        {
            // Lấy mã khách hàng lớn nhất hiện tại từ cơ sở dữ liệu
            string maxMaKH = khachHangDAL.GetMaxMaKH();

            // Nếu chưa có mã nào thì bắt đầu từ KH001
            if (string.IsNullOrEmpty(maxMaKH))
            {
                return "KH001";
            }

            // Tách phần số từ mã KH (VD: KH001 -> 001)
            int soHienTai = int.Parse(maxMaKH.Substring(2));

            // Tăng phần số lên 1 và định dạng lại theo KHxxx
            int soMoi = soHienTai + 1;
            return "KH" + soMoi.ToString("D3");
        }

        // Kiểm tra số điện thoại đã tồn tại chưa
        public bool KiemTraTrungSoDienThoai(string soDienThoai)
        {
            return khachHangDAL.KiemTraTrungSoDienThoai(soDienThoai);
        }

        // Thêm khách hàng mới
        public void ThemKhachHang(KhachHang khachHang)
        {
            khachHangDAL.ThemKhachHang(khachHang);
        }
    }
}
