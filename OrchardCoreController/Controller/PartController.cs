using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using OrchardCoreController.Models;
using SQLitePCL;

namespace OrchardCoreController.Controller
{
    public class PartController : ControllerBase
    {
        private readonly IContentManager _contentManager;
        public PartController(IContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        public async void test()
        {

            //var test = await _contentManager.GetAsync("4x6ay4kqv774k4xv7fp5tc91dh");

            var contentItem = await _contentManager.NewAsync("PersonPage");
            var personPart = contentItem.As<PersonPart>();
            personPart.Name = "Test123";
            personPart.Biography = new TextField();
            personPart.Biography.Text = "Test Biography123";
            personPart.Handedness = Handedness.Right;
            personPart.BirthDateUtc = DateTime.UtcNow;
            personPart.Apply();
            await _contentManager.CreateAsync(contentItem, VersionOptions.Latest);
            //await _contentManager.PublishAsync(contentItem);

        }
    }
}
