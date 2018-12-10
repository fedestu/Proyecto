using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Computacion.Startup))]
namespace Computacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
