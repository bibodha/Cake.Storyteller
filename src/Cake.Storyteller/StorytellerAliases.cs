using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Storyteller
{
    /// <summary>
    /// Alias for Cake Storyteller
    /// </summary>
    [CakeAliasCategory("Storyteller")]
    public static class StorytellerAliases
    {
        /// <summary>
        /// Opens Storyteller UI
        /// </summary>
        /// <param name="context">Cake context</param>
        /// <param name="projectPath">Path of the Storyteller project</param>
        /// <param name="settings"><see cref="StorytellerSettings"/> object</param>
        [CakeMethodAlias]
        public static void StorytellerOpen(this ICakeContext context, string projectPath, StorytellerSettings settings = null)
        {
            var runner = new StorytellerRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Arguments);
            runner.OpenCommand(projectPath, settings);
        }

        /// <summary>
        /// Runs Storyteller in the command line
        /// </summary>
        /// <param name="context">Cake context</param>
        /// <param name="projectPath">Path of the Storyteller project</param>
        /// <param name="settings"><see cref="StorytellerSettings"/> object</param>
        [CakeMethodAlias]
        public static void StorytellerRun(this ICakeContext context, string projectPath,
            StorytellerSettings settings = null)
        {
            var runner = new StorytellerRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Arguments);
            runner.RunCommand(projectPath, settings);
        }
    }
}
