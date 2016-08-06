using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EstacionamientoDF.Startup))]
namespace EstacionamientoDF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
