using Cake.Core.Tooling;

namespace Cake.Storyteller
{
    /// <summary>
    /// Settings used by <see cref="StorytellerRunner"/>. Definitions provided in Storyteller Documentation
    /// </summary>
    public class StorytellerSettings : ToolSettings
    {
        /// <summary>
        /// Path to write out the results. Default is stresults.htm
        /// </summary>
        [StorytellerFlag("results-path")]
        public string ResultsPath { get; set; }
        /// <summary>
        /// Optional. Runs only one workspace
        /// </summary>
        [StorytellerFlag("workspace")]
        public string Workspace { get; set; }
        /// <summary>
        /// Optional. Excludes specs with any of the specified tags (comma-delimited)
        /// </summary>
        [StorytellerFlag("exclude-tags")]
        public string ExcludeTags { get; set; }
        /// <summary>
        /// Open the results in a browser after the run. DO NOT DO THIS IN CI!
        /// </summary>
        [StorytellerFlag("open")]
        public bool? Open { get; set; }
        /// <summary>
        /// WriteToText the performance data in CSV format to the specified path
        /// </summary>
        [StorytellerFlag("csv")]
        public string Csv { get; set; }
        /// <summary>
        /// WriteToText the raw result information to JSON format at the specified path
        /// </summary>
        [StorytellerFlag("json")]
        public string Json { get; set; }
        /// <summary>
        /// Dump the raw JSON history of the batch run to the specified path
        /// </summary>
        [StorytellerFlag("dump")]
        public string Dump { get; set; }
        /// <summary>
        /// Specify a build target to force Storyteller to choose that profile. By default, ST will use 'Debug'
        /// </summary>
        [StorytellerFlag("build")]
        public string Build { get; set; }
        /// <summary>
        /// Storyteller test mode profile for systems like Serenity that use this
        /// </summary>
        [StorytellerFlag("profile")]
        public string Profile { get; set; }
        /// <summary>
        /// Optional. Default project timeout in seconds.
        /// </summary>
        [StorytellerFlag("timeout")]
        public int? Timeout { get; set; }
        /// <summary>
        /// Optional. Only runs tests with desired <see cref="Lifecycle"/>
        /// </summary>
        [StorytellerFlag("lifecycle")]
        public string Lifecycle { get; set; }
        /// <summary>
        /// Optional. Applies extra logging to see progress within TeamCity during CI runs
        /// </summary>
        [StorytellerFlag("teamcity")]
        public bool? TeamCity { get; set; }
        /// <summary>
        /// Optional. Override the config file selection of the Storyteller test running AppDomain
        /// </summary>
        [StorytellerFlag("config")]
        public string Config { get; set; }
        /// <summary>
        /// Sets a minimum number of retry attempts for this execution
        /// </summary>
        [StorytellerFlag("retries")]
        public int? Retries { get; set; }
    }
}
