using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(luma.Startup))]
namespace luma
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
