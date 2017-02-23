using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Storyteller
{
    /// <summary>
    /// Storyteller runner
    /// </summary>
    public class StorytellerRunner : Tool<StorytellerSettings>
    {
        private readonly ICakeArguments _arguments;

        /// <summary>
        /// Initializes new instance of <see cref="StorytellerRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">Filesystem</param>
        /// <param name="environment">Environment</param>
        /// <param name="processRunner">Process Runner</param>
        /// <param name="toolLocator">Tool Locator</param>
        /// <param name="arguments">Arguments</param>
        public StorytellerRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator toolLocator, ICakeArguments arguments) : base(fileSystem, environment, processRunner, toolLocator)
        {
            _arguments = arguments;
        }

        /// <summary>
        /// Runs Storyteller in the command line
        /// </summary>
        /// <param name="projectPath">Storyteller project path</param>
        /// <param name="settings"><see cref="StorytellerSettings"/> object</param>
        /// <returns></returns>
        public int RunCommand(string projectPath, StorytellerSettings settings)
        {
            var exitCode = StCommand(StorytellerCommand.Run, projectPath, settings);
            if (exitCode != 0)
            {
                throw new StorytellerException("Storyteller tests failed.");
            }
            return exitCode;
        }

        /// <summary>
        /// Opens the Storyteller UI
        /// </summary>
        /// <param name="projectPath">Storyteller project path</param>
        /// <param name="settings"><see cref="StorytellerSettings"/> object</param>
        public void OpenCommand(string projectPath, StorytellerSettings settings)
        {
            StCommand(StorytellerCommand.Open, projectPath, settings);
        }
        private int StCommand(StorytellerCommand storytellerCommand, string projectPath, StorytellerSettings settings)
        {
            var argumentBuilder = new StorytellerArgumentBuilder();
            argumentBuilder.BuildArguments(storytellerCommand, projectPath, _arguments, settings);
            var process = RunProcess(settings, argumentBuilder.BuildArguments(storytellerCommand, projectPath, _arguments, settings));

            process.WaitForExit();
            return process.GetExitCode();
        }

        /// <summary>
        /// Get Storyteller name
        /// </summary>
        /// <returns></returns>
        protected override string GetToolName()
        {
            return "Storyteller";
        }

        /// <summary>
        /// Gets storyteller exe 
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] {"ST.exe"};
        }
    }
}
