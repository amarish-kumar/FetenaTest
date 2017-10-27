using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fetena.Startup))]
namespace Fetena
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
