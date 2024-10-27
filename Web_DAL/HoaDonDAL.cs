using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_DTO;
namespace Web_DAL
{
    public class HoaDonDAL
    {
  
        public void ThemHoaDon(HoaDonDTO hoaDon)
        {
            using (var db = new ConnectContextDataContext()) 
            {
         
                var hoaDonMoi = new HOADON
                {
                    MaHDBH = hoaDon.MaHDBH,
                    MaNV = hoaDon.MaNV,
                    MaBan = hoaDon.MaBan,
                    NgayXuatHD = hoaDon.NgayXuatHD,
                    TongTien = hoaDon.TongTien,
                    MaKH = hoaDon.MaKH,
                    SoTienThanhToan = hoaDon.SoTienThanhToan,
                    ThoiGianDatCoc = hoaDon.ThoiGianDatCoc,
                    TienDatCoc = hoaDon.TienDatCoc
                };
                db.HOADONs.InsertOnSubmit(hoaDonMoi);
                db.SubmitChanges();
            }
        }
        public int LayMaHoaDonCaoNhat()
        {
            using (var db = new ConnectContextDataContext()) // Thay bằng tên DataContext của bạn
            {
                // Kiểm tra nếu không có hóa đơn nào
                if (!db.HOADONs.Any())
                {
                    return 0; // Hoặc bạn có thể trả về giá trị mặc định khác nếu không có hóa đơn
                }

                // Trả về mã hóa đơn cao nhất
                return db.HOADONs.Max(h => h.MaHDBH);
            }
        }

        public HoaDonDTO LayHoaDonMoiNhat(int mahoadon)
        {
            using (var db = new ConnectContextDataContext()) 
            {
                var hoaDon = db.HOADONs
                                .OrderByDescending(h => h.NgayXuatHD)
                                .FirstOrDefault(h => h.MaHDBH == mahoadon);

                if (hoaDon != null)
                {
                    // Chuyển đổi từ entity HOADON sang DTO HoaDonDTO
                    return new HoaDonDTO
                    {
                        MaHDBH = hoaDon.MaHDBH,
                        MaNV = hoaDon.MaNV,
                        MaBan = hoaDon.MaBan,
                        NgayXuatHD = hoaDon.NgayXuatHD,
                        TongTien = hoaDon.TongTien,
                        DiemTL = hoaDon.DiemTL,
                        GiamGia = hoaDon.GiamGia,
                        MaKH = hoaDon.MaKH,
                        SoTienThanhToan = hoaDon.SoTienThanhToan,
                        ThoiGianVao = hoaDon.ThoiGianVao,
                        ThoiGianRa = hoaDon.ThoiGianRa,
                        ThoiGianDatCoc = hoaDon.ThoiGianDatCoc,
                        TienDatCoc = hoaDon.TienDatCoc
                    };
                }

                return null; // Nếu không tìm thấy hóa đơn
            }
        }

        // Cập nhật hóa đơn sau khi khách hàng thanh toán
        public void CapNhatHoaDonThanhToan(int maHoaDon, int tongTien, int soTienThanhToan)
        {
            using (SqlConnection conn = new SqlConnection("your_connection_string"))
            {
                SqlCommand cmd = new SqlCommand("UPDATE HOADON SET TongTien = @TongTien, SoTienThanhToan = @SoTienThanhToan WHERE MaHDBH = @MaHDBH", conn);
                cmd.Parameters.AddWithValue("@MaHDBH", maHoaDon);
                cmd.Parameters.AddWithValue("@TongTien", tongTien);
                cmd.Parameters.AddWithValue("@SoTienThanhToan", soTienThanhToan);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
