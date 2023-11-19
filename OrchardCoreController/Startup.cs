using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCoreController.Drivers;
using OrchardCoreController.Migrations;
using OrchardCoreController.Models;
using OrchardCore.Modules;
using OrchardCore.Users.Services;
using OrchardCore.ContentManagement.Metadata;

namespace OrchardCoreController
{
    public class Startup : OrchardCore.Modules.StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentPart<PersonPart>().UseDisplayDriver<PersonPartDisplayDriver>();
            services.AddScoped<IDataMigration, PersonMigrations>();
            services.AddScoped<IOrchardHelper, DefaultOrchardHelper>();
            services.AddScoped<IMembershipService, MembershipService>();
            services.AddScoped<IContentDefinitionManager, ContentDefinitionManager>();

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