using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_BUS;
using Web_DAL;
using Web_DTO;
namespace QuanLiBiDa_Web
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            string soDienThoai = input_sdt.Value.Trim();
            string tenKH = input_tenkh.Value.Trim();
            string matKhau = input_matkhau.Value.Trim();

            if (string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(tenKH) || string.IsNullOrEmpty(matKhau))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Vui lòng điền đầy đủ thông tin.');", true);
                return;
            }

            KhachHangBUS khachHangBUS = new KhachHangBUS();
            KhachHang khachHangMoi = new KhachHang
            {
                MaKH = khachHangBUS.GenerateMaKH(),
                TenKH = tenKH,
                SDT = soDienThoai,
                MatKhau = matKhau,
                MaLKH = "LKH02", 
                DiemTichLuy = 0
            };

            if (khachHangBUS.KiemTraTrungSoDienThoai(soDienThoai))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Số điện thoại đã tồn tại.');", true);
            }
            else
            {
                khachHangBUS.ThemKhachHang(khachHangMoi);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Đăng ký thành công!');", true);
                Response.Redirect("Login.aspx");
            }
        }
    }
}