using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSharpTeacher.Startup))]
namespace CSharpTeacher
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
