using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnywayStore.Startup))]
namespace AnywayStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
