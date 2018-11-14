using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SelfLearning.Startup))]
namespace SelfLearning
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
