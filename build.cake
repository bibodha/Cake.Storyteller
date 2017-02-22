#tool "nuget:?package=xunit.runner.console"

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

Task("Test")
    .Does(() => {
        XUnit2(GetFiles("./src/**/bin/Debug/*.Tests.dll"));
    });

RunTarget(target);