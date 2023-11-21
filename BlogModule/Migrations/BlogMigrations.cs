using BlogModule.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Media.Fields;
using OrchardCore.Media.Settings;
using OrchardCore.Taxonomies.Fields;
using OrchardCore.Taxonomies.Settings;

namespace BlogModule.Migrations
{
    public class BlogMigrations: DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public BlogMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition(
                nameof(BlogPart),
                part => {
                    part.Attachable();
                    part.WithField(
                            nameof(BlogPart.Subtitle),
                            field => field
                                    .OfType(nameof(TextField))
                                    .WithDisplayName(nameof(BlogPart.Subtitle))
                                    .WithSettings(new TextFieldSettings
                                    {
                                        Hint = "Subtitle"
                                    }).WithEditor("TextArea"));

                    part.WithField(
                            nameof(BlogPart.Tags),
                            field => field
                                    .OfType(nameof(TaxonomyField))
                                    .WithDisplayName(nameof(BlogPart.Tags))
                                    .WithSettings(new TaxonomyFieldSettings
                                    {
                                        Required = false,
                                        Unique = false,
                                        LeavesOnly = false,
                                        Open = true,
                                    }).WithEditor("Tags"));

                    part.WithField(
                            nameof(BlogPart.BannerImage),
                            field => field
                                    .OfType(nameof(MediaField))
                                    .WithDisplayName(nameof(BlogPart.BannerImage))
                                    .WithSettings(new MediaFieldSettings
                                    {
                                        AllowAnchors = true,
                                        Multiple = false,
                                        Required = false,
                                        AllowMediaText = false,
                                    }).WithEditor("Standard"));

                    part.WithField(
                            nameof(BlogPart.Category),
                            field => field
                                    .OfType(nameof(TaxonomyField))
                                    .WithDisplayName(nameof(BlogPart.Category))
                                    .WithSettings(new TaxonomyFieldSettings
                                    {
                                        Required = false,
                                        Unique = true,
                                        LeavesOnly = true
                                    }).WithEditor("Standard"));
                });


            _contentDefinitionManager.AlterTypeDefinition(
                "Blog",
                type => type
                        .Creatable()
                        .Listable()
                        .Draftable()
                        .Versionable()
                        .Securable()
                        .WithPart(nameof(BlogPart))
                        .WithPart("Title")
                        .WithPart("Autoroute")
                        .WithPart("MarkdownBody"));

            return 1;
        }

    }
}
