using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleSite.Startup))]
namespace SampleSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
