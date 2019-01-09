using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Movie_Rental.Startup))]
namespace Movie_Rental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
