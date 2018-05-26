using djiDaiLy.Models;
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
        // This method gets called by the runtime. Use this method to add services to the container.

    }
}