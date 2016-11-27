using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Final_CV.Startup))]
namespace Final_CV
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
