using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Commerce.Abstractions;
using OrchardCore.Commerce.Services;
using OrchardCore.ContentManagement;
using OrchardCore.Modules;

namespace TestModule
{
    public class Startup: OrchardCore.Modules.StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IProductService, ProductService>();

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