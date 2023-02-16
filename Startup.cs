using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADONETStoredProcedures.Startup))]
namespace ADONETStoredProcedures
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
