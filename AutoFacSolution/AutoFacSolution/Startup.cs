using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoFacSolution.Startup))]
namespace AutoFacSolution
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
