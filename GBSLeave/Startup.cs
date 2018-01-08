using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GBSLeave.Startup))]
namespace GBSLeave
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
