using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Tooling;

namespace Cake.Storyteller
{
    public class StorytellerRunner : Tool<StorytellerSettings>
    {
        private readonly ICakeArguments _arguments;

        public StorytellerRunner(ICakeContext context) : base(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools)
        {
            _arguments = context.Arguments;
        }

        public int RunCommand(string projectPath, StorytellerSettings settings)
        {
            var exitCode = StCommand(StorytellerCommand.Run, projectPath, settings);
            if (exitCode != 0)
            {
                throw new CakeException("Storyteller tests failed.");
            }
            return exitCode;
        }

        public void OpenCommand(string projectPath, StorytellerSettings settings)
        {
            StCommand(StorytellerCommand.Open, projectPath, settings);
        }
        private int StCommand(StorytellerCommand storytellerCommand, string projectPath, StorytellerSettings settings)
        {
            var argumentBuilder = new StorytellerArgumentBuilder();
            var process = RunProcess(settings, argumentBuilder.BuildArguments(storytellerCommand, projectPath, _arguments, settings));

            process.WaitForExit();
            return process.GetExitCode();
        }

        protected override string GetToolName()
        {
            return "Storyteller";
        }

        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] {"ST.exe"};
        }
    }
}
