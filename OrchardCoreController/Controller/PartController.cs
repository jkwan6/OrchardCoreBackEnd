using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Handlers;
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

        public async void test()
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

            //await _contentManager.SaveDraftAsync(contentItem);
            //await _contentManager.PublishAsync(contentItem);

        }

        private void AddValidationErrorsToModelState(ContentValidateResult result)
        {
            foreach (var error in result.Errors)
            {
                if (error.MemberNames != null && error.MemberNames.Any())
                {
                    foreach (var memberName in error.MemberNames)
                    {
                        ModelState.AddModelError(memberName, error.ErrorMessage);
                    }
                }
                else
                {
                    ModelState.AddModelError(String.Empty, error.ErrorMessage);
                }
            }
        }
    }
}
