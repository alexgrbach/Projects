using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BarBlog.Web.Startup))]
namespace BarBlog.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
