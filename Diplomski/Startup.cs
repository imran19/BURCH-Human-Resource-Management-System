using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Diplomski.Startup))]
namespace Diplomski
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
