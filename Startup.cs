using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimeLineBlog.Startup))]
namespace TimeLineBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
