using Cake.Core.Tooling;
using StoryTeller.Model;

namespace Cake.Storyteller
{
    public class StorytellerSettings : ToolSettings
    {
        [StorytellerFlag("results-path")]
        public string ResultsPath { get; set; }
        [StorytellerFlag("workspace")]
        public string Workspace { get; set; }
        [StorytellerFlag("exclude-tags")]
        public string ExcludeTags { get; set; }
        [StorytellerFlag("open")]
        public bool? Open { get; set; }
        [StorytellerFlag("csv")]
        public string Csv { get; set; }
        [StorytellerFlag("json")]
        public string Json { get; set; }
        [StorytellerFlag("dump")]
        public string Dump { get; set; }
        [StorytellerFlag("build")]
        public string Build { get; set; }
        [StorytellerFlag("profile")]
        public string Profile { get; set; }
        [StorytellerFlag("timeout")]
        public int? Timeout { get; set; }
        [StorytellerFlag("lifecycle")]
        public string Lifecycle { get; set; }
        [StorytellerFlag("teamcity")]
        public bool? TeamCity { get; set; }
        [StorytellerFlag("config")]
        public string Config { get; set; }
        [StorytellerFlag("retries")]
        public int? Retries { get; set; }
    }
}
