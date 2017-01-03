using Cake.Core;
using Shouldly;
using Xunit;
using NSubstitute;

namespace Cake.Storyteller.Tests
{
    public class StorytellerArgumentBuilderTests
    {
        private readonly ICakeContext _context;
        private readonly StorytellerArgumentBuilder _argBuilder;

        public StorytellerArgumentBuilderTests()
        {
            _context = Substitute.For<ICakeContext>();
            _argBuilder = new StorytellerArgumentBuilder();
        }

        [Fact]
        public void BuildsWithNoCustomArguments()
        {
            var str = _argBuilder.BuildArguments(_context.Arguments);
            str.ShouldBe(string.Empty);
        }

        [Fact]
        public void BuildsWithTwoArgumentsFromCmd()
        {
            _context.Arguments.HasArgument("profile").Returns(true);
            _context.Arguments.GetArgument("profile").Returns("Chrome");
            _context.Arguments.HasArgument("timeout").Returns(true);
            _context.Arguments.GetArgument("timeout").Returns("500");

            var str = _argBuilder.BuildArguments(_context.Arguments);
            str.ShouldBe("--profile Chrome --timeout 500");
        }

        [Fact]
        public void BuildsWithStorytellerSettings()
        {
            var str = _argBuilder.BuildArguments(new StorytellerSettings
            {
                Profile = "Chrome",
                Timeout = 700
            });
            str.ShouldBe("--profile Chrome --timeout 700");
        }

        [Fact]
        public void ArugmentListOverridesSettings()
        {
            _context.Arguments.HasArgument("profile").Returns(true);
            _context.Arguments.GetArgument("profile").Returns("Chrome");
            _context.Arguments.HasArgument("timeout").Returns(true);
            _context.Arguments.GetArgument("timeout").Returns("500");

            var str = _argBuilder.BuildArguments(_context.Arguments, new StorytellerSettings
            {
                Profile = "Phantom",
                Timeout = 300
            });

            str.ShouldBe("--profile Chrome --timeout 500");
        }

        [Fact]
        public void ReplacesArgumetOnlyFromSettings()
        {
            _context.Arguments.HasArgument("profile").Returns(true);
            _context.Arguments.GetArgument("profile").Returns("Chrome");

            var str = _argBuilder.BuildArguments(_context.Arguments, new StorytellerSettings
            {
                Profile = "Phantom",
                Timeout = 300
            });

            str.ShouldBe("--profile Chrome --timeout 300");
        }
    }
}
