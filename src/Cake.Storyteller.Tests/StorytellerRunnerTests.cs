using System.IO;
using Cake.Core;
using NSubstitute;
using Shouldly;
using Xunit;

namespace Cake.Storyteller.Tests
{
    public class StorytellerRunnerTests
    {
        private readonly ICakeContext _context;
        private readonly StorytellerRunner _runner;

        public StorytellerRunnerTests()
        {
            _context = Substitute.For<ICakeContext>();
            _runner = new StorytellerRunner(_context);
        }

        [Fact]
        public void ThrowsExceptionWhenTestFails()
        {
            
        }


    }
}