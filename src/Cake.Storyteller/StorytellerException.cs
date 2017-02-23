using System;

namespace Cake.Storyteller
{
    /// <summary>
    /// Exception fro Storyteller
    /// </summary>
    public class StorytellerException : Exception
    {
        /// <summary>
        /// Exception that is thrown when a Storyteller test fails.
        /// </summary>
        /// <param name="message"></param>
        public StorytellerException(string message) : base(message)
        {
            
        }
    }
}