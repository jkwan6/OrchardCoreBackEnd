using CustomFormModule.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;

namespace CustomFormModule
{
    public class Startup : StartupBase
    {
        public override void Configure(IApplicationBuilder app)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentPart<PersonPart>();
        }
    }
}