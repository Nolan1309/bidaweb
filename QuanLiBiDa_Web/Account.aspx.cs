using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_DTO;
using Web_DAL;
using Web_BUS;
namespace QuanLiBiDa_Web
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["KhachHang"] != null)
                {
                    var khachHang = (KhachHang)Session["KhachHang"];
                    LoadThongTinKhachHang(khachHang);
                    LoadLichSuDatBan(khachHang.MaKH);
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void LoadThongTinKhachHang(KhachHang khachHang)
        {
            inputTenKH.Text = khachHang.TenKH;
            inputSDT.Text = khachHang.SDT;
        }

        private void LoadLichSuDatBan(string maKH)
        {
            BanBUS datBanBUS = new BanBUS();
            List<Ban> lichSu = datBanBUS.GetLichSuDatBan(maKH);

            dlLichSuDatBan.DataSource = lichSu;
            dlLichSuDatBan.DataBind();
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (Session["KhachHang"] != null)
            {
                var khachHang = (KhachHang)Session["KhachHang"];
                khachHang.TenKH = inputTenKH.Text.Trim();
                khachHang.SDT = inputSDT.Text.Trim();
                khachHang.MatKhau = inputMatKhau.Text.Trim();

                KhachHangBUS khachHangBUS = new KhachHangBUS();
                khachHangBUS.UpdateKhachHang(khachHang);

                lblMessage.Text = "Cập nhật thông tin thành công!";
            }
        }
    }
}