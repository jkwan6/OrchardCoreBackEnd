using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCoreController.Drivers;
using OrchardCoreController.Migrations;
using OrchardCoreController.Models;

namespace OrchardCoreController
{
    public class Startup : OrchardCore.Modules.StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentPart<PersonPart>().UseDisplayDriver<PersonPartDisplayDriver>();
            services.AddScoped<IDataMigration, PersonMigrations>();
            services.AddContentManagement();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            //routes.MapAreaControllerRoute(
            //    name: "Home",
            //    areaName: "OrchardModule",
            //    pattern: "Home/Index",
            //    defaults: new { controller = "Home", action = "Index" }
            //);
        }
    }
}