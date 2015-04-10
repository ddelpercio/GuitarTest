using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuitarMate.Startup))]
namespace GuitarMate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
