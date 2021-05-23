using System;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverTests
    {
        [Theory]
        [InlineData("1 2 N", "LMLMLMLMM", "1 3 N")]
        [InlineData("3 3 E", "MMRMMRMRRM", "5 1 E")]
        [InlineData("0 0 N", "MMMMMRMMMMML", "5 5 N")]
        [InlineData("0 0 N", "RLRLRLRLRLRL", "0 0 N")]
        public void Rover_Moves_Correctly(string input, string commands, string output)
        {
            var inputs = input.Split(" ");
            var x = int.Parse(inputs[0]);
            var y = int.Parse(inputs[1]);
            var o = char.Parse(inputs[2]);

            var plateau = new Plateau(5, 5);
            var position = new Position(x, y);
            var orientation = (Orientation) o;
            var rover = new Rover(plateau, position, orientation);

            rover.Run(commands);

            Assert.Equal(output, rover.GetLocationInfo());
        }

        [Fact]
        public void Rover_CannotLeavePlateau()
        {
            var rover = InitRover(0, 0, 'W');
            Assert.Throws<IndexOutOfRangeException>(() => rover.Move());
        }

        [Fact]
        public void Rover_CannotRunUnrecognizedCommand()
        {
            var rover = InitRover(0, 0, 'N');
            Assert.Throws<ArgumentOutOfRangeException>(() => rover.Run("?"));
        }

        private static Rover InitRover(int x, int y, char o)
        {
            var plateau = new Plateau(5, 5);
            var position = new Position(x, y);
            var orientation = (Orientation) o;
            return new Rover(plateau, position, orientation);
        }
    }
}