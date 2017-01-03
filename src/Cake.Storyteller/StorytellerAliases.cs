using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Storyteller
{
    [CakeAliasCategory("Storyteller")]
    public static class StorytellerAliases
    {
        [CakeMethodAlias]
        public static void StorytellerOpen(this ICakeContext context, string projectPath, StorytellerSettings settings = null)
        {
            var runner = new StorytellerRunner(context);
            runner.OpenCommand(projectPath, settings);
        }

        [CakeMethodAlias]
        public static void StorytellerRun(this ICakeContext context, string projectPath,
            StorytellerSettings settings = null)
        {
            var runner = new StorytellerRunner(context);
            runner.RunCommand(projectPath, settings);
        }
    }
}
