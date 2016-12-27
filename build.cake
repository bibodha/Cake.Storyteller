#r "Cake.Storyteller/bin/Debug/Cake.Storyteller.dll"

var target = Argument("Target", "Default");

Task("Default")
    .Description("Test")
    .Does(() => {
        Information("Running default task");
        StorytellerOpen("Test", new StorytellerSettings {
            Path = "packages/Storyteller.3.0.1/tools",
            Timeout = 300
        });

        Information("Done");
    });

RunTarget(target);