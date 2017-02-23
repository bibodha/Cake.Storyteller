#tool "nuget:?package=xunit.runner.console"

var target = Argument("Target", "Default");

var solutionPath = "src/Cake.Storyteller.sln";

Task("Default")
    .IsDependentOn("Build");

var VERSION_NUMBER = AppVeyor.IsRunningOnAppVeyor ? EnvironmentVariable("APPVEYOR_BUILD_VERSION") : "0.0.0";

Task("Build")
    .Does(() => {
        NuGetRestore(solutionPath);
        DotNetBuild(solutionPath, settings => settings.Configuration = "Release");
    });

Task("NuGetPack")
    .Does(() => {
        NuGetPack("./src/Cake.Storyteller.nuspec", new NuGetPackSettings {
            OutputDirectory = "./",
            Verbosity = NuGetVerbosity.Detailed,
            Version = VERSION_NUMBER
        });
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

Task("Ci")
    .IsDependentOn("Default")
    .IsDependentOn("NuGetPack");

RunTarget(target);