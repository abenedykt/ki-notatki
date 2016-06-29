using System;
using FluentAssertions;
using Xunit;

namespace FizzBuzzTest
{
    public class FizzBuzzGameTests
    {
        private readonly FizzBuzzGame _game;

        public FizzBuzzGameTests()
        {
            _game = new FizzBuzzGame();
        }

        [Fact]
        public void When_play_one_should_return_one()
        {
            // act
            var result = _game.Play(1);

            //assert
            result.Should().Be("1");
        }

        [Fact]
        public void When_play_two_should_return_two()
        {
            var result = _game.Play(2);
            result.Should().Be("2");
        }

        [Fact]
        public void When_play_three_should_return_Fizz()
        {
            var result = _game.Play(3);
            result.Should().Be("Fizz");
        }

        [Fact]
        public void When_play_five_should_return_Buzz()
        {
            var result = _game.Play(5);
            result.Should().Be("Buzz");
        }
        [Fact]
        public void When_play_15_should_return_FizzBuzz()
        {
            var result = _game.Play(15);
            result.Should().Be("FizzBuzz");
        }
    }

    public class FizzBuzzGame
    {
        public string Play(int value)
        {
            var result = string.Empty;

            if (value % 3 == 0)
                result += "Fizz";

            if (value % 5 == 0)
                result += "Buzz";

            if (string.IsNullOrEmpty(result))
                result += value.ToString();
            return result;
        }
    }
}
