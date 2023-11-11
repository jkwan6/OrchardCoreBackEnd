using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "ControllerModule",
    Author = "Me",
    Website = "https://orchardcore.net",
    Version = "0.0.1",
    Description = "Controller Module",
    Category = "Controller Category",
    Dependencies = new[] { "OrchardCore.ContentFields" }
)]