using System.Collections.Generic;
using System.Text;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Storyteller
{
    public class StorytellerRunner : Tool<StorytellerSettings>
    {
        private readonly IProcessRunner _runner;
        private readonly ICakeLog _log;
        private readonly IToolLocator _tool;
        private readonly ICakeArguments _arguments;

        public StorytellerRunner(ICakeContext context) : base(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools)
        {
            _runner = context.ProcessRunner;
            _log = context.Log;
            _tool = context.Tools;
            _arguments = context.Arguments;
        }

        public int RunCommand(string projectPath, StorytellerSettings settings)
        {
            var exitCode = StCommand(StorytellerCommand.Run, projectPath, settings);
            if (exitCode != 0)
            {
                throw new CakeException("Storyteller tests failed.");
            }
            else
            {
                return exitCode;
            }
        }

        public void OpenCommand(string projectPath, StorytellerSettings settings)
        {
            StCommand(StorytellerCommand.Open, projectPath, settings);
        }
        private int StCommand(StorytellerCommand storytellerCommand, string projectPath, StorytellerSettings settings)
        {
            var toolPath = _tool.Resolve("ST.exe");

            var argumentBuilder = new StorytellerArgumentBuilder();
            var str = argumentBuilder.BuildArguments(_arguments);
            var process = _runner.Start(toolPath, new ProcessSettings
            {
                Arguments = string.Join(" ",
                    storytellerCommand,
                    projectPath,
                    str
                )
            });

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
