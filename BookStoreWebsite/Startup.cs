using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookStoreWebsite.Startup))]
namespace BookStoreWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
