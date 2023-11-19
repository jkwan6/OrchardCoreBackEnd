using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.Autoroute.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.Abstractions;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.ContentManagement.Routing;
using OrchardCore.Lists.GraphQL;
using OrchardCore.Lists.Models;
using OrchardCore.Lists.ViewModels;
using OrchardCore.Markdown.Models;
using OrchardCore.Title.Models;
using OrchardCoreController.Models;
using SQLitePCL;
using System.ComponentModel;
using System.Net;
using System.Security.Claims;
using YesSql.Services;
using OrchardCore;
using OrchardCore.Users.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using OrchardCore.Users;
using Newtonsoft.Json.Linq;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.Users.Models;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Users.ViewModels;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.Workflows.Helpers;

namespace OrchardCoreController.Controller
{
    public class PartController : ControllerBase
    {
        private readonly IContentManager _contentManager;
        private readonly IContentDefinitionManager _contentDefinitionManager;
        private readonly IOrchardHelper _orchardHelper;
        private readonly IMembershipService _membershipService;
        private readonly UserManager<IUser> _userManager;
        public PartController(
            IContentManager contentManager, 
            IOrchardHelper orchardHelper, 
            IMembershipService membershipService,
            UserManager<IUser> userManager,
            IContentDefinitionManager contentDefinitionManager
            )
        {
            _contentManager = contentManager;
            _orchardHelper = orchardHelper;
            _membershipService = membershipService;
            _userManager = userManager;
            _contentDefinitionManager = contentDefinitionManager;
        }

        public async Task<IActionResult> test()
        {

            //var test = await _contentManager.GetAsync("4x6ay4kqv774k4xv7fp5tc91dh");
            var contentItem = await _contentManager.NewAsync("PersonPage");

            var personPart = contentItem.As<PersonPart>();
            personPart.Name = "Test1233";
            personPart.Biography = new TextField
            {
                Text = "Test Biography123",
            };
            personPart.Handedness = Handedness.Right;
            personPart.BirthDateUtc = DateTime.UtcNow;
            personPart.Apply();


            //await _contentManager.CreateContentItemVersionAsync(contentItem);
            var result = await _contentManager.UpdateValidateAndCreateAsync(contentItem, VersionOptions.Draft);
            //await _contentManager.CreateAsync(contentItem, VersionOptions.Draft);
            //await _contentManager.SaveDraftAsync(contentItem);
            //await _contentManager.PublishAsync(contentItem);
            return Ok();

        }

        public async Task<IActionResult> test1()
        {
            bool latest = true;
            bool[] x = { latest };
            //var contentItem = await _contentManager.GetAsync("4rav79ey99bxs2mk5yknz9q65b");
            //var contentItem = await _contentManager.GetVersionAsync("4bx5pg5efnwaj24684vxrjggxt");
            var contentItem = await _contentManager.GetAsync("4hn4czpdcgsbks3k8benf2s5m2", VersionOptions.Latest);
            //await _contentManager.CreateContentItemVersionAsync(contentItem);
            //var result = await _contentManager.UpdateValidateAndCreateAsync(contentItem, VersionOptions.Draft);
            await _contentManager.RemoveAsync(contentItem);
            //await _contentManager.CreateAsync(contentItem, VersionOptions.Draft);
            //await _contentManager.SaveDraftAsync(contentItem);
            //await _contentManager.PublishAsync(contentItem);
            return Ok();

        }

        public async Task<IActionResult> test2()
        {
            var contentItemParent = await _contentManager.GetAsync("4v2gb31g5wjhczzsdh4w00dkwq", VersionOptions.Latest);
            var contentItemChild = await _contentManager.GetAsync("4rmrnygcxwxdhz3q28gj0xxkw4", VersionOptions.Latest);

            contentItemChild.Weld<ContainedPart>();
            await contentItemChild.AlterAsync<ContainedPart>(async t => {
                t.ListContentItemId = "4v2gb31g5wjhczzsdh4w00dkwq";
                t.ListContentType = "Blog";
            });

            await _contentManager.UpdateAsync(contentItemChild);

            return Ok();

        }

        public async Task<IActionResult> test3()
        {
            var contentItem = await _contentManager.GetAsync("4v2gb31g5wjhczzsdh4w00dkwq", VersionOptions.Latest);
            //contentItem.ContentItem();



            var x = await _orchardHelper.QueryListItemsAsync(
                "4v2gb31g5wjhczzsdh4w00dkwq",
                x => x.ContentType == "BlogPost");
            var abc = x.ToList();
            var qwe = abc[1];
            return Ok();

        }


        public async Task<IActionResult> test4()
        {
            var contentItem123 = await _contentManager.GetAsync("4v2gb31g5wjhczzsdh4w00dkwq", VersionOptions.Latest);
            //contentItem.ContentItem();

            var test = await _membershipService.GetUserAsync("admin");

            var test2 = await _userManager.FindByEmailAsync("kwcw@live.com");

            var contentTypeDefinitions = GetContentTypeDefinitions();

            List<ContentItem> contentItems = new List<ContentItem>();

            foreach (var contentTypeDefinition in contentTypeDefinitions)
            {
                var isNew = false;
                var contentItem = await GetUserSettingsAsync((User)test2, contentTypeDefinition, () => isNew = true);
                contentItems.Add(contentItem);
            }


            var x = await _orchardHelper.QueryListItemsAsync(
                "4v2gb31g5wjhczzsdh4w00dkwq",
                x => x.ContentType == "BlogPost");
            var abc = x.ToList();
            var qwe = abc[1];
            return Ok();

        }




        public async Task<IActionResult> test5()
        {



            return Ok();
        }




        private IEnumerable<ContentTypeDefinition> GetContentTypeDefinitions()
    => _contentDefinitionManager
        .ListTypeDefinitions()
        .Where(x => x.GetStereotype() == "CustomUserSettings");

        private async Task<ContentItem> GetUserSettingsAsync(User user, ContentTypeDefinition settingsType, Action isNew = null)
        {
            JToken property;
            ContentItem contentItem;

            if (user.Properties.TryGetValue(settingsType.Name, out property))
            {
                var existing = property.ToObject<ContentItem>();

                // Create a new item to take into account the current type definition.
                contentItem = await _contentManager.NewAsync(existing.ContentType);
                contentItem.Merge(existing);
            }
            else
            {
                contentItem = await _contentManager.NewAsync(settingsType.Name);
                isNew?.Invoke();
            }

            return contentItem;
        }



    }
}
