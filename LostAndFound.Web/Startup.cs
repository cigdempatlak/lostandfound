using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LostAndFound.Web.Startup))]
namespace LostAndFound.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
