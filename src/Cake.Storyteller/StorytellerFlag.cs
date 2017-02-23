using System;

namespace Cake.Storyteller
{
    /// <summary>
    /// Flag for Storyteller settings
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class StorytellerFlag : Attribute
    {
        public StorytellerFlag(string flag)
        {
            Flag = flag;
        }
        /// <summary>
        /// Flag that identifies the Storyteller argument
        /// </summary>
        public string Flag { get; private set; }
    }
}
