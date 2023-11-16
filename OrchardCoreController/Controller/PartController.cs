using Microsoft.AspNetCore.Mvc;
using OrchardCore.Autoroute.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.ContentManagement.Routing;
using OrchardCore.Lists.GraphQL;
using OrchardCore.Lists.Models;
using OrchardCore.Markdown.Models;
using OrchardCore.Title.Models;
using OrchardCoreController.Models;
using SQLitePCL;
using System.Net;
using System.Security.Claims;

namespace OrchardCoreController.Controller
{
    public class PartController : ControllerBase
    {
        private readonly IContentManager _contentManager;
        
        public PartController(IContentManager contentManager)
        {
            _contentManager = contentManager;
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

            //var test = await _contentManager.GetAsync("4x6ay4kqv774k4xv7fp5tc91dh");

            var contentItemParent1 = await _contentManager.GetAsync("44xe4hqzxnb8wtqsrzsp99zhmd", VersionOptions.Latest);

            var contentItemParent = await _contentManager.GetAsync("4v2gb31g5wjhczzsdh4w00dkwq", VersionOptions.Latest);
            var contentItemChild = await _contentManager.GetAsync("4z0afz604nwe227nca05med9cq", VersionOptions.Latest);

            contentItemChild.Weld<ContainedPart>();
            await contentItemChild.AlterAsync<ContainedPart>(async t => {
                t.ListContentItemId = "4v2gb31g5wjhczzsdh4w00dkwq";
                t.ListContentType = "Blog";
            });

            await _contentManager.UpdateAsync(contentItemChild);



            //var contentItemListList = contentItemList.As<ListPart>();

            //var contentItem = await _contentManager.NewAsync("BlogPost");
            //var titlePart = contentItem.As<TitlePart>();
            //var autoRoutePart = contentItem.As<AutoroutePart>();
            //var markdownBody = contentItem.As<MarkdownBodyPart>();

            //titlePart.Title = "TestBlogPost";
            //titlePart.Apply();

            //markdownBody.Markdown = "test";
            //markdownBody.Apply();

            //var result = await _contentManager.UpdateValidateAndCreateAsync(contentItem, VersionOptions.Draft);

            //await _contentManager.CreateContentItemVersionAsync(contentItem);
            //await _contentManager.CreateAsync(contentItem, VersionOptions.Draft);
            //await _contentManager.SaveDraftAsync(contentItem);
            //await _contentManager.PublishAsync(contentItem);
            return Ok();

        }

        public async Task<IActionResult> test3()
        {

            //var test = await _contentManager.GetAsync("4x6ay4kqv774k4xv7fp5tc91dh");

            var contentItemParent1 = await _contentManager.GetAsync("4gpxqvkvbqj4w3agagw6zedzns", VersionOptions.Latest);

            var contentItemParent = await _contentManager.GetAsync("4h4bnc2kgsd16r13ww07t9bent", VersionOptions.Latest);
            var contentItemChild = await _contentManager.GetAsync("4khhpavv843wf639rkw36rrr48", VersionOptions.Latest);

            contentItemChild.Weld<ContainedPart>();
            await contentItemChild.AlterAsync<ContainedPart>(async t => {
                t.ListContentItemId = "4h4bnc2kgsd16r13ww07t9bent";
                t.ListContentType = "test";
            });

            var containedPart = contentItemChild.As<ContainedPart>();
            containedPart.ListContentItemId = "4h4bnc2kgsd16r13ww07t9bent";
            containedPart.Apply();


            //var contentItemListList = contentItemList.As<ListPart>();

            //var contentItem = await _contentManager.NewAsync("BlogPost");
            //var titlePart = contentItem.As<TitlePart>();
            //var autoRoutePart = contentItem.As<AutoroutePart>();
            //var markdownBody = contentItem.As<MarkdownBodyPart>();

            //titlePart.Title = "TestBlogPost";
            //titlePart.Apply();

            //markdownBody.Markdown = "test";
            //markdownBody.Apply();

            //var result = await _contentManager.UpdateValidateAndCreateAsync(contentItem, VersionOptions.Draft);

            //await _contentManager.CreateContentItemVersionAsync(contentItem);
            //await _contentManager.CreateAsync(contentItem, VersionOptions.Draft);
            //await _contentManager.SaveDraftAsync(contentItem);
            //await _contentManager.PublishAsync(contentItem);
            return Ok();

        }
    }
}
