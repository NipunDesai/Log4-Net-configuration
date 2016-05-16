using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Log4Netconfiguration.Startup))]
namespace Log4Netconfiguration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
