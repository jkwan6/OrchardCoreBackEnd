using OrchardCore.Modules.Manifest;

    [assembly: Module(
        Name = "FormModuleTest",
        Author = "Me",
        Description ="Stuff",
        Category = "Stuff",
        Dependencies = new[] { "OrchardCore.ContentFields" }
    )]