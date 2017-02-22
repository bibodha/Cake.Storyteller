using Cake.Common.Tests.Fixtures;

namespace Cake.Storyteller.Tests
{
    public sealed class StorytellerFixture : ToolFixture<StorytellerSettings>
    {
        public StorytellerFixture() : base("ST.exe")
        {
            Settings.Timeout = 500;
            Settings.Build = "Debug";
        }

        protected override void RunTool()
        {
            var tool = new StorytellerRunner(FileSystem, Environment, ProcessRunner, ToolLocator, Arguments);
            tool.RunCommand("src/test", Settings);
        }
    }
}
