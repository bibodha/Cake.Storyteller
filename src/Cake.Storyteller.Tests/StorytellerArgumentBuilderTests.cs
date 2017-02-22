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
            var builder = _argBuilder.BuildArguments(StorytellerCommand.Open, "src/test", _context.Arguments);
            builder.Render().ShouldBe("open src/test");
        }

        [Fact]
        public void BuildsWithTwoArgumentsFromCmd()
        {
            _context.Arguments.HasArgument("profile").Returns(true);
            _context.Arguments.GetArgument("profile").Returns("Chrome");
            _context.Arguments.HasArgument("timeout").Returns(true);
            _context.Arguments.GetArgument("timeout").Returns("500");

            var builder = _argBuilder.BuildArguments(StorytellerCommand.Open, "src/test", _context.Arguments);
            builder.Render().ShouldBe("open src/test --profile Chrome --timeout 500");
        }

        [Fact]
        public void BuildsWithStorytellerSettings()
        {
            var builder = _argBuilder.BuildArguments(StorytellerCommand.Open, "src/test", null, new StorytellerSettings
            {
                Profile = "Chrome",
                Timeout = 700
            });

            builder.Render().ShouldBe("open src/test --profile Chrome --timeout 700");
        }

        [Fact]
        public void ArugmentListOverridesSettings()
        {
            _context.Arguments.HasArgument("profile").Returns(true);
            _context.Arguments.GetArgument("profile").Returns("Chrome");
            _context.Arguments.HasArgument("timeout").Returns(true);
            _context.Arguments.GetArgument("timeout").Returns("500");

            var builder = _argBuilder.BuildArguments(StorytellerCommand.Open, "src/test", _context.Arguments, new StorytellerSettings
            {
                Profile = "Phantom",
                Timeout = 300
            });

            builder.Render().ShouldBe("open src/test --profile Chrome --timeout 500");
        }

        [Fact]
        public void ReplacesArgumetOnlyFromSettings()
        {
            _context.Arguments.HasArgument("profile").Returns(true);
            _context.Arguments.GetArgument("profile").Returns("Chrome");

            var builder = _argBuilder.BuildArguments(StorytellerCommand.Open, "src/test",_context.Arguments, new StorytellerSettings
            {
                Profile = "Phantom",
                Timeout = 300
            });

            builder.Render().ShouldBe("open src/test --profile Chrome --timeout 300");
        }

        [Fact]
        public void BuildsWithFlagFromArgumentList()
        {
            _context.Arguments.HasArgument("teamcity").Returns(true);

            var builder = _argBuilder.BuildArguments(StorytellerCommand.Open, "src/test", _context.Arguments,
                new StorytellerSettings
                {
                    Profile = "Chrome",
                    Timeout = 300
                });

            builder.Render().ShouldBe("open src/test --profile Chrome --timeout 300 --teamcity");
        }

        [Fact]
        public void BuildsWithFlagFromSettings()
        {
            var builder = _argBuilder.BuildArguments(StorytellerCommand.Open, "src/test", null, new StorytellerSettings
            {
                Profile = "Chrome",
                Timeout = 300,
                TeamCity = true
            });

            builder.Render().ShouldBe("open src/test --profile Chrome --timeout 300 --teamcity");
        }
    }
}
