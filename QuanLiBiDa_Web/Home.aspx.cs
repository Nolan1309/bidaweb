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
                LoadLoaiBan();
            }
        }
        private void LoadKhuVuc()
        {
            KhuVucBUS khuVucBUS = new KhuVucBUS();
            List<KhuVucDTO> khuVucList = khuVucBUS.GetAllKhuVuc();

            khuVuc.DataSource = khuVucList;
            khuVuc.DataTextField = "TenKV";
            khuVuc.DataValueField = "MaKV";
            khuVuc.DataBind();

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

            ClientScript.RegisterStartupScript(this.GetType(), "loadBanData", sb.ToString());
        }
        protected override void Render(HtmlTextWriter writer)
        {

            foreach (ListItem item in ban.Items)
            {
                ClientScript.RegisterForEventValidation(ban.UniqueID, item.Value);
            }
            base.Render(writer);
        }
        private void LoadLoaiBan()
        {
            LoaiBanBUS loaiBanBUS = new LoaiBanBUS();
            List<LoaiBanDTO> loaiBanList = loaiBanBUS.GetAllLoaiBan();

            loaiBan.DataSource = loaiBanList;
            loaiBan.DataTextField = "TenLoaiBan"; // Đảm bảo tên thuộc tính đúng với DTO
            loaiBan.DataValueField = "MaBan";     // Đảm bảo tên thuộc tính đúng với DTO
            loaiBan.DataBind();

            loaiBan.Items.Insert(0, new ListItem("-- Chọn loại bàn --", ""));
        }
        private void LoadKhuVucTheoLoaiBan(int maLoaiBan)
        {
            KhuVucBUS khuVucBUS = new KhuVucBUS();
            List<KhuVucDTO> khuVucList = khuVucBUS.GetKhuVucByLoaiBan(maLoaiBan);

            khuVuc.DataSource = khuVucList;
            khuVuc.DataTextField = "TenKV";
            khuVuc.DataValueField = "MaKV";
            khuVuc.DataBind();

            khuVuc.Items.Insert(0, new ListItem("-- Chọn khu vực --", ""));
        }


        protected void loaiBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedLoaiBan = int.Parse(loaiBan.SelectedValue);

            if (selectedLoaiBan > 0)
            {
                LoadKhuVucTheoLoaiBan(selectedLoaiBan);
            }
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
                    DateTime? thoiGianKTDatCoc = null;

                    if (!string.IsNullOrEmpty(Request.Form["thoiGianKTDatCoc"]))
                    {
                        thoiGianKTDatCoc = DateTime.Parse(Request.Form["thoiGianKTDatCoc"]);
                    }

                    if (DateTime.TryParse(thoiGianDatBanString, out thoiGianDatBan) && thoiGianKTDatCoc != null)
                    {
                        // Tính số giờ đặt cọc
                        double soGioDatCoc = (thoiGianKTDatCoc.Value - thoiGianDatBan).TotalHours;

                        // Lấy thông tin chi tiết niêm yết (phần trăm đặt cọc)
                        ChiTietNiemYetBUS chiTietNiemYetBUS = new ChiTietNiemYetBUS();
                        ChiTietNiemYetDTO chiTietNiemYet = chiTietNiemYetBUS.GetChiTietNiemYetByMaBan(selectedBan);
                        double phanTramDatCoc = (chiTietNiemYet.GiaTri ?? 0) / 100.0;


                        // Lấy giá 1 tiếng của bàn
                        LoaiBanBUS loaiBanBUS = new LoaiBanBUS();
                        KhuVucBUS khuVucBUS = new KhuVucBUS();
                        KhuVucDTO khuVucBan = khuVucBUS.GetKhuVucByMa(selectedKhuVuc);
                        LoaiBanDTO loaiBan = loaiBanBUS.GetLoaiBanByMa(khuVucBan.MaLoaiBan ?? 0);

                        int giaGioChoi = loaiBan.GiaGioChoi ?? 0;
                        int giaKhuVuc = khuVucBan.GiaTien ?? 0;
                        int giaMotTieng = giaGioChoi + giaKhuVuc;




                        // Tính tiền đặt cọc
                        double tienDatCoc = soGioDatCoc * giaMotTieng * phanTramDatCoc;

                        // Tạo hóa đơn mới
                        HoaDonBUS hoaDonBUS = new HoaDonBUS();
                        int maHoaDonCaoNhat = hoaDonBUS.LayMaHoaDonCaoNhat();
                        HoaDonDTO hoaDon = new HoaDonDTO
                        {
                            MaHDBH = maHoaDonCaoNhat + 1,
                            MaNV = "NV001",
                            MaBan = selectedBan,
                            TongTien = (int)tienDatCoc,
                            MaKH = khachHang.MaKH,
                            SoTienThanhToan = (int)tienDatCoc,
                            ThoiGianDatCoc = thoiGianDatBan,
                            TienDatCoc = (int)tienDatCoc,
                            ThoiGianKTDatCoc = thoiGianKTDatCoc
                        };
                        hoaDonBUS.ThemHoaDon(hoaDon);
                        HoaDonDTO hoaDonMoi = hoaDonBUS.LayHoaDonMoiNhat(maHoaDonCaoNhat + 1);
                        banBUS.UpdateBanTrangThai(selectedBan, selectedKhuVuc, "Đã đặt", hoaDonMoi);

                        // Thông báo đặt bàn thành công
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Đặt bàn thành công và hóa đơn đã được tạo!');", true);
                    }
                    else
                    {
                        // Thông báo lỗi nếu ngày giờ không hợp lệ
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Vui lòng nhập ngày giờ hợp lệ.');", true);
                    }
                }
                else
                {
                    // Thông báo nếu bàn đã được đặt
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Bàn đã được đặt!');", true);
                }
            }
            else
            {
                // Thông báo yêu cầu đăng nhập
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