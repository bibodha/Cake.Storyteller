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
        private string _path;
        private StorytellerRunner _runner;

        public StorytellerRunnerTests()
        {
            _context = Substitute.For<ICakeContext>();
            _runner = new StorytellerRunner(_context);
        }

        [Fact]
        public void RunsProcessSuccessfully()
        {
            var exitCode = _runner.RunCommand("test", new StorytellerSettings
            {
                Timeout = 700,
                Profile = "Phatom"
            });
            exitCode.ShouldBe(0);
        }

        [Fact]
        public void ThrowsExceptionWhenTestFails()
        {
            
        }


    }
}