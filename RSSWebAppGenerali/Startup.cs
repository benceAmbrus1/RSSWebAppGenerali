using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RSSWebAppGenerali.Startup))]
namespace RSSWebAppGenerali
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
