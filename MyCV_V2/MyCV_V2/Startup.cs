using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyCV_V2.Startup))]
namespace MyCV_V2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
