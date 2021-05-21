using Xunit;

namespace MarsRover.Tests
{
    public class CommandTests
    {
        [Fact]
        public void MoveCommand_Moves_Rover()
        {
            var rover = InitRover(0, 0, 'N');
            new MoveCommand().Execute(rover);
            Assert.Equal("0 1 N", rover.GetLocationInfo());
        }

        [Fact]
        public void TurnLeftCommand_TurnsRoverLeft()
        {
            var rover = InitRover(0, 0, 'N');
            new TurnLeftCommand().Execute(rover);
            Assert.Equal("0 0 W", rover.GetLocationInfo());
        }

        [Fact]
        public void TurnRightCommand_TurnsRoverRight()
        {
            var rover = InitRover(0, 0, 'N');
            new TurnRightCommand().Execute(rover);
            Assert.Equal("0 0 E", rover.GetLocationInfo());
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