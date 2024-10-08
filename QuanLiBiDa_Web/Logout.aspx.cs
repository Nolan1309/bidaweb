using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLiBiDa_Web
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Xóa session khi người dùng đăng xuất
            Session["KhachHang"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}