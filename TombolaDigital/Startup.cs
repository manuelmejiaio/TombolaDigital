using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TombolaDigital.Startup))]
namespace TombolaDigital
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
