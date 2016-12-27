using System.Text;
using Cake.Core.Diagnostics;
using Cake.Core.IO;

namespace Cake.Storyteller
{
    public class StorytellerRunner
    {
        private readonly IProcessRunner _runner;
        private readonly ICakeLog _log;

        public StorytellerRunner(IProcessRunner runner, ICakeLog log)
        {
            _runner = runner;
            _log = log;
        }

        public void Run(string projectPath, StorytellerSettings settings)
        {
            StCommand("run", projectPath, settings);
        }

        public void Open(string projectPath, StorytellerSettings settings)
        {
            StCommand("open", projectPath, settings);
        }
        private void StCommand(string command, string projectPath, StorytellerSettings settings)
        {
            var path = string.IsNullOrEmpty(settings.Path) ? settings.Path : "packages/Storyteller.3.0.1/tools/";
            var toolPath = path + "ST.exe";
            _log.Verbose("Found ST at: " + toolPath);

            var str = new StringBuilder();

            str.Append(settings.Build != null ? " --build " + settings.Build : "");
            str.Append(settings.Profile != null ? " --profile " + settings.Profile: "" );
            str.Append(settings.Timeout != 0 ? " --timeout " + settings.Timeout : "");
            str.Append(settings.Lifecycle != null ? " --Lifecycle " + settings.Lifecycle : "" );
            str.Append(settings.TeamCity ? " --teamcity " : "");
            str.Append(settings.Config != null ? " --config " + settings.Config : "");
            str.Append(" --retries " + settings.Retries);

            _runner.Start(toolPath, new ProcessSettings
            {
                Arguments = string.Join(" ",
                    command,
                    projectPath,
                    str
                )
            });
        }
    }
}
