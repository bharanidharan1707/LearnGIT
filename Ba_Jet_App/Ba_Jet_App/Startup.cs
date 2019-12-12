using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ba_Jet_App.Startup))]
namespace Ba_Jet_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
