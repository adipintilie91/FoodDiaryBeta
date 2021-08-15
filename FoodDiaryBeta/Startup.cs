using Microsoft.Owin;
using Owin;
using System.Web.Http.Controllers;

[assembly: OwinStartupAttribute(typeof(FoodDiaryBeta.Startup))]
namespace FoodDiaryBeta
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        

    }
}
