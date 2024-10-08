using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_DTO;
using Web_DAL;
using Web_BUS;
using System.Text;
namespace QuanLiBiDa_Web
{
    public partial class Home : System.Web.UI.Page
    {
        //protected DropDownList khuVuc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadKhuVuc();
                LoadTatCaBan();
            }
        }
        private void LoadKhuVuc()
        {
            KhuVucBUS khuVucBUS = new KhuVucBUS();
            List<KhuVuc> khuVucList = khuVucBUS.GetAllKhuVuc();

            // Bind dữ liệu vào dropdown list
            khuVuc.DataSource = khuVucList;
            khuVuc.DataTextField = "TenKV";
            khuVuc.DataValueField = "MaKV";
            khuVuc.DataBind();

            // Thêm một tùy chọn mặc định
            khuVuc.Items.Insert(0, new ListItem("-- Chọn khu vực --", ""));
        }
        protected void khuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedKhuVuc = khuVuc.SelectedValue;

            if (!string.IsNullOrEmpty(selectedKhuVuc))
            {
                LoadBanTheoKhuVuc(selectedKhuVuc);
            }
        }

        private void LoadBanTheoKhuVuc(string maKhuVuc)
        {
            BanBUS banBUS = new BanBUS();
            List<Ban> banList = banBUS.GetBanByKhuVuc(maKhuVuc);

            ban.DataSource = banList;
            ban.DataTextField = "TenBan";
            ban.DataValueField = "MaBan";
            ban.DataBind();

            ban.Items.Insert(0, new ListItem("-- Chọn bàn --", ""));
        }
        private void LoadTatCaBan()
        {
            BanBUS banBUS = new BanBUS();
            List<Ban> banList = banBUS.GetAllBan();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<script type='text/javascript'>");
            sb.AppendLine("var banData = " + Newtonsoft.Json.JsonConvert.SerializeObject(banList) + ";");
            sb.AppendLine("</script>");

            // Đưa script vào cuối thẻ <head> hoặc <body>
            ClientScript.RegisterStartupScript(this.GetType(), "loadBanData", sb.ToString());
        }
        protected override void Render(HtmlTextWriter writer)
        {
            // Đăng ký cho sự kiện event validation
            foreach (ListItem item in ban.Items)
            {
                ClientScript.RegisterForEventValidation(ban.UniqueID, item.Value);
            }
            base.Render(writer);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
          
            if (Session["KhachHang"] != null)
            {
                var khachHang = (KhachHang)Session["KhachHang"];
                string selectedBan = ban.SelectedValue;
                string selectedKhuVuc = khuVuc.SelectedValue;

                BanBUS banBUS = new BanBUS();
                Ban selectedBanInfo = banBUS.GetBanByMaBan(selectedBan);

                if (selectedBanInfo != null && selectedBanInfo.TrangThai == "Trống")
                {

                    string thoiGianDatBanString = Request.Form["thoiGianDatBan"];                  
                    DateTime thoiGianDatBan;
                    if (DateTime.TryParse(thoiGianDatBanString, out thoiGianDatBan))
                    {
                        HoaDonBUS hoaDonBUS = new HoaDonBUS();
                        int maHoaDonCaoNhat = hoaDonBUS.LayMaHoaDonCaoNhat();
                        HoaDonDTO hoaDon = new HoaDonDTO
                        {
                            MaHDBH = maHoaDonCaoNhat + 1,
                            MaNV = "NV001", 
                            MaBan = selectedBan,
                            NgayXuatHD = DateTime.Now,
                            TongTien = 50000, 
                            MaKH = khachHang.MaKH,
                            SoTienThanhToan = 0,
                            ThoiGianDatCoc = thoiGianDatBan,
                            TienDatCoc = 50000 
                        };                
                        hoaDonBUS.ThemHoaDon(hoaDon);
                        HoaDonDTO hoaDonMoi = hoaDonBUS.LayHoaDonMoiNhat(maHoaDonCaoNhat + 1);
                        banBUS.UpdateBanTrangThai(selectedBan, khachHang.MaKH, "Đã đặt", hoaDonMoi);
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Đặt bàn thành công và hóa đơn đã được tạo!');", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Vui lòng nhập ngày giờ hợp lệ.');", true);                   
                    }                   
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Bàn đã được đặt!');", true);
                }
            }
            else
            {
                // Sử dụng JavaScript để hiển thị thông báo rồi chuyển trang sau 2 giây (2000ms)
                string script = @"<script type='text/javascript'>
                            alert('Vui lòng đăng nhập để đặt bàn!');
                            setTimeout(function() {
                                window.location.href = 'Login.aspx';
                            }, 1000);
                          </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "redirectLogin", script);
            }
        }
       


    }
}