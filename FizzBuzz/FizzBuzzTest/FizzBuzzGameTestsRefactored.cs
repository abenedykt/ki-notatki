using FluentAssertions;
using Xunit;

namespace FizzBuzzTest
{
    public class FizzBuzzGameTestsRefactored
    {
        [Theory,
            InlineData(1, "1"),
            InlineData(2, "2"),
            InlineData(3, "Fizz"),
            InlineData(5, "Buzz"),
            InlineData(15, "FizzBuzz")
            ]
        public void FizzBuzzGame(int input, string expected)
        {
            var game = new FizzBuzzGame();
            var result = game.Play(input);

            result.Should().Be(expected);
        }


        [Fact]
        public void Sumowanie()
        {
            var a = 10;
            var b = 20;
            var c = 0;

            var result = (a + b)/c;

            result.Should().Be(15);
        }
    }
}