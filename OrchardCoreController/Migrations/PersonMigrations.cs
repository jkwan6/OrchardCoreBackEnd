using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCoreController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchardCoreController.Migrations
{
    public class PersonMigrations: DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public PersonMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }


        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition(
                nameof(PersonPart),
                part => part
                        .Attachable()
                        .WithField(
                            nameof(PersonPart.Biography),
                            field => field
                                    .OfType(nameof(TextField))
                                    .WithDisplayName(nameof(PersonPart.Biography))
                                    .WithSettings(new TextFieldSettings
                                    {
                                        Hint = "The Person's Biography"
                                    }).WithEditor("TextArea")));

            _contentDefinitionManager.AlterTypeDefinition(
                "PersonPage",
                type => type
                        .Creatable()
                        .Listable()
                        .WithPart(nameof(PersonPart)));
            return 1;
        }

    }
}
