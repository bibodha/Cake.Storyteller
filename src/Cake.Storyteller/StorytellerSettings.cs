using Cake.Core.Tooling;
using StoryTeller.Model;

namespace Cake.Storyteller
{
    public class StorytellerSettings : ToolSettings
    {
        public string Path { get; set; }
        public string Build { get; set; }
        public string Profile { get; set; }
        public int? Timeout { get; set; }
        public string Lifecycle { get; set; }
        public bool TeamCity { get; set; }
        public string Config { get; set; }
        public int Retries { get; set; }
    }
}
