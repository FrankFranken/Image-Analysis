using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Image_Analysis.Startup))]
namespace Image_Analysis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
