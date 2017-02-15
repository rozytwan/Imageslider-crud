using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DbSlider.Startup))]
namespace DbSlider
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
