using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServiciosWeb.Startup))]
namespace ServiciosWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
