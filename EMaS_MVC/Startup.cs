using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EMaS_MVC.Startup))]
namespace EMaS_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
