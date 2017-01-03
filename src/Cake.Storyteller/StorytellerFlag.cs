using System;

namespace Cake.Storyteller
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StorytellerFlag : Attribute
    {
        public StorytellerFlag(string flag)
        {
            Flag = flag;
        }
        public string Flag { get; private set; }
    }
}
