using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MongoDBApi.Web.Startup))]
namespace MongoDBApi.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
