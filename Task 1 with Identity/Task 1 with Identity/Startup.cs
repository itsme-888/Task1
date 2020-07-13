using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Task_1_with_Identity.Startup))]
namespace Task_1_with_Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
