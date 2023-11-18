using System.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using OrchardCore.Admin;
using OrchardCore.Data.Migration;
using OrchardCore.DisplayManagement.Descriptors;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Theming;
using OrchardCore.Environment.Commands;
using OrchardCore.Environment.Shell.Configuration;
using OrchardCore.Environment.Shell.Scope;
using OrchardCore.Mvc.Core.Utilities;
using OrchardCore.Navigation;
using OrchardCore.Recipes.Services;
using OrchardCore.ResourceManagement;
using OrchardCore.Security;
using OrchardCore.Security.Permissions;
using OrchardCore.Settings;
using OrchardCore.Setup.Events;
using OrchardCore.Sms;
using OrchardCore.Users;
using OrchardCore.Users.Commands;
using OrchardCore.Users.Controllers;
using OrchardCore.Users.Drivers;
using OrchardCore.Users.Handlers;
using OrchardCore.Users.Models;
using OrchardCore.Users.Services;
using OrchardCore.Users.ViewModels;
using YesSql.Filters.Query;
using Microsoft.AspNetCore.Identity;
using UserOptions = OrchardCore.Users.UserOptions;
using Microsoft.Extensions.Logging;

namespace CommerceProductModule
{
    public class Startup : OrchardCore.Modules.StartupBase
    {
        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<UserOptions>(userOptions =>
            //{
            //    var configuration = ShellScope.Services.GetRequiredService<IShellConfiguration>();
            //    configuration.GetSection("OrchardCore_Users").Bind(userOptions);
            //});

            //// Add ILookupNormalizer as Singleton because it is needed by UserIndexProvider
            //services.TryAddSingleton<ILookupNormalizer, UpperInvariantLookupNormalizer>();

            //// Add the default token providers used to generate tokens for reset passwords, change email,
            //// and for two-factor authentication token generation.
            //var identityBuilder = services.AddIdentity<OrchardCore.Users.IUser, IRole>(options =>
            //{
            //    // Specify OrchardCore User requirements.
            //    // A user name cannot include an @ symbol, i.e. be an email address
            //    // An email address must be provided, and be unique.
            //    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._+";
            //    options.User.RequireUniqueEmail = true;
            //});

            //var phoneNumberProviderType = typeof(PhoneNumberTokenProvider<>).MakeGenericType(identityBuilder.UserType);
            //identityBuilder.AddTokenProvider(TokenOptions.DefaultPhoneProvider, phoneNumberProviderType);
            //var emailTokenProviderType = typeof(EmailTokenProvider<>).MakeGenericType(identityBuilder.UserType);
            //identityBuilder.AddTokenProvider(TokenOptions.DefaultEmailProvider, emailTokenProviderType);
            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
            //    options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
            //    options.Tokens.ChangeEmailTokenProvider = TokenOptions.DefaultEmailProvider;
            //    options.Tokens.ChangePhoneNumberTokenProvider = TokenOptions.DefaultPhoneProvider;
            //});
            //services.AddPhoneFormatValidator();
            //// Configure the authentication options to use the application cookie scheme as the default sign-out handler.
            //// This is required for security modules like the OpenID module (that uses SignOutAsync()) to work correctly.
            //services.AddAuthentication(options => options.DefaultSignOutScheme = IdentityConstants.ApplicationScheme);

            //services.AddUsers();

            //services.ConfigureApplicationCookie(options =>
            //{
            //    var userOptions = ShellScope.Services.GetRequiredService<IOptions<OrchardCore.Users.UserOptions>>();

            //    options.Cookie.Name = "orchauth_" + HttpUtility.UrlEncode(_tenantName);

            //    // Don't set the cookie builder 'Path' so that it uses the 'IAuthenticationFeature' value
            //    // set by the pipeline and comming from the request 'PathBase' which already ends with the
            //    // tenant prefix but may also start by a path related e.g to a virtual folder.

            //    options.LoginPath = "/" + userOptions.Value.LoginPath;
            //    options.LogoutPath = "/" + userOptions.Value.LogoffPath;
            //    options.AccessDeniedPath = "/Error/403";
            //});


            services.AddScoped<UserManager<IUser>, UserManager<IUser>>();

            //services.AddSingleton<IUsersAdminListFilterParser>(sp =>
            //{
            //    var filterProviders = sp.GetServices<IUsersAdminListFilterProvider>();
            //    var builder = new QueryEngineBuilder<User>();
            //    foreach (var provider in filterProviders)
            //    {
            //        provider.Build(builder);
            //    }

            //    var parser = builder.Build();

            //    return new DefaultUsersAdminListFilterParser(parser);
            //});

            //services.AddTransient<IUsersAdminListFilterProvider, DefaultUsersAdminListFilterProvider>();
            //services.AddTransient<IConfigureOptions<ResourceManagementOptions>, OrchardCore.Users.UserOptionsConfiguration>();
            //services.AddScoped<IDisplayDriver<UserMenu>, UserMenuDisplayDriver>();
            //services.AddScoped<IShapeTableProvider, OrchardCore.Users.UserMenuShapeTableProvider>();
        }
    }
}