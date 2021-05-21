using Xunit;

namespace MarsRover.Tests
{
    public class PositionTests
    {
        [Fact]
        public void GetsCorrectAdjacentPositionForOrientation()
        {
            var position = new Position(1, 1);

            Assert.Equal(new Position(1, 2), position.GetAdjacentPosition(Orientation.North));
            Assert.Equal(new Position(2, 1), position.GetAdjacentPosition(Orientation.East));
            Assert.Equal(new Position(1, 0), position.GetAdjacentPosition(Orientation.South));
            Assert.Equal(new Position(0, 1), position.GetAdjacentPosition(Orientation.West));
        }
    }
}