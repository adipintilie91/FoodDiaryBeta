using Microsoft.Owin;
using Owin;

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
