using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuanLiBiDa_Web.Startup))]
namespace QuanLiBiDa_Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
