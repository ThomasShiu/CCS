using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CCS.Startup))]
namespace CCS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
