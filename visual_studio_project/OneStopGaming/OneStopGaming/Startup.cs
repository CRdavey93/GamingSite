using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OneStopGaming.Startup))]
namespace OneStopGaming
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
