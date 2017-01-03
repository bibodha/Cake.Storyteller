using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Cake.Core;

namespace Cake.Storyteller
{
    public class StorytellerArgumentBuilder
    {
        private readonly List<string> _stArguments;
        public StorytellerArgumentBuilder()
        {
            _stArguments = new List<string>
            {
                 "results-path" ,
                 "workspace" ,
                 "exclude-tags" ,
                 "open" ,
                 "csv" ,
                 "json" ,
                 "dump" ,
                 "build" ,
                 "profile" ,
                 "timeout" ,
                 "lifecycle" ,
                 "teamcity" ,
                 "config" ,
                 "retries" 
            };
        }

        public string BuildArguments(ICakeArguments arguments, StorytellerSettings settings = null)
        {
            var dict = new Dictionary<string, string>();

            if (settings != null)
            {
                //settings
                var props = typeof(StorytellerSettings).GetProperties();
                foreach (var prop in props)
                {
                    var attrs = prop.GetCustomAttributes(false);
                    foreach (var attr in attrs)
                    {
                        var stFlagAttr = attr as StorytellerFlag;
                        if (stFlagAttr != null)
                        {
                            var value = prop.GetValue(settings, null);
                            if (value != null)
                            {
                                dict.Add(stFlagAttr.Flag, value.ToString());
                            }
                        }
                    }
                }
            }

            //arguments
            if (arguments != null)
            {
                _stArguments.ForEach(arg =>
                {
                    if (arguments.HasArgument(arg))
                    {
                        dict[arg] = arguments.GetArgument(arg);
                    }
                });
            }

            var stringBuilder = new StringBuilder();
            foreach (var pair in dict)
            {
                stringBuilder.Append("--" + pair.Key + " " + pair.Value + " ");
            }
            return stringBuilder.ToString().Trim();
        }

        public string BuildArguments(StorytellerSettings settings)
        {
            return BuildArguments(null, settings);
        }
    }
}