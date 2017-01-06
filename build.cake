#r "src/Cake.Storyteller/bin/Debug/Cake.Storyteller.dll"
#tool "nuget:?package=storyteller"

var target = Argument("Target", "Default");

var solutionPath = "src/Cake.Storyteller.sln";

Task("Default")
    .IsDependentOn("Build");

Task("Build")
    .Does(() => {
        NuGetRestore(solutionPath);
        DotNetBuild(solutionPath);
    });

Task("Clean")
    .Does(() => {
        CleanDirectories("./src/build");
        CleanDirectories("./src/**/bin");
        CleanDirectories("./src/**/obj");
        CreateDirectory("./src/build");
    });

Task("StOpen")
    .Does(() => {
        StorytellerOpen("src/ApplicationManager.StoryTeller.Integration", new StorytellerSettings{
            Timeout = 300,
            Profile = "Phantom"
        });
    });

Task("StRun")
    .Does(() => {
        StorytellerRun("src/ApplicationManager.StoryTeller.Integration", new StorytellerSettings{
            Timeout = 300,
            Profile = "Phantom",
            Retries = 1
        });
    });

RunTarget(target);