using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCoreController.Models;
using OrchardCoreController.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchardCoreController.Drivers
{
    public class PersonPartDisplayDriver : ContentPartDisplayDriver<PersonPart>
    {
        public override IDisplayResult Display(PersonPart part, BuildPartDisplayContext context) =>
            Initialize<PersonPartViewModel>(
                GetDisplayShapeType(context),
                viewModel => PopulateViewModel(part, viewModel))
            .Location("Detail", "Content:5")
            .Location("Summary", "Content:5");

        public override IDisplayResult Edit(PersonPart part, BuildPartEditorContext context) =>
            Initialize<PersonPartViewModel>(
                GetEditorShapeType(context),
                viewModel => PopulateViewModel(part, viewModel))
            .Location("Content:5");

        public override async Task<IDisplayResult> UpdateAsync(PersonPart part, IUpdateModel updater, UpdatePartEditorContext context)
        {
            var viewModel = new PersonPartViewModel();

            await updater.TryUpdateModelAsync(viewModel, Prefix);

            part.BirthDateUtc = viewModel.BirthDateUtc;
            part.Handedness = viewModel.Handedness;
            part.Name = viewModel.Name;

            return await EditAsync(part, context);
        }


        private static void PopulateViewModel(PersonPart part, PersonPartViewModel viewModel)
        {
            viewModel.BirthDateUtc = part.BirthDateUtc;
            viewModel.Handedness = part.Handedness;
            viewModel.Name = part.Name;
        }
    }
}
