using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DentistManager.DentistUI.Startup))]
namespace DentistManager.DentistUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
