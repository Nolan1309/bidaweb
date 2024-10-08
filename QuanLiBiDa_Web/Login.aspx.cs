using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_DAL;
using Web_DTO;
using Web_BUS;
namespace QuanLiBiDa_Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = inputUsername.Text;
            string password = inputPassword.Text;

            KhachHangBUS khachHangBUS = new KhachHangBUS();
            KhachHang khachHang = khachHangBUS.Login(username, password); // Kiểm tra đăng nhập với dữ liệu trong DB

            if (khachHang != null)
            {
                // Lưu thông tin khách hàng vào session
                Session["KhachHang"] = khachHang;
                Response.Redirect("Home.aspx"); // Chuyển hướng đến trang Home
            }
            else
            {
                // Hiển thị thông báo lỗi đăng nhập
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Sai tên đăng nhập hoặc mật khẩu!');", true);
            }
        }
    }
}