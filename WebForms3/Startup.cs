using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebForms3.Startup))]
namespace WebForms3
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
