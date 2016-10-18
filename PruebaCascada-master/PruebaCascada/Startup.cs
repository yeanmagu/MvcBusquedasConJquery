using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PruebaCascada.Startup))]
namespace PruebaCascada
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
