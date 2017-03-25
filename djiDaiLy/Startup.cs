using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(djiDaiLy.Startup))]
namespace djiDaiLy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
