using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClubCompetition.Startup))]
namespace ClubCompetition
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
