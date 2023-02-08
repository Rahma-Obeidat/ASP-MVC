using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Forms_Authontication.Startup))]
namespace Forms_Authontication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
