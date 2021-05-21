using System;
using Xunit;

namespace MarsRover.Tests
{
    public class PlateauTests
    {
        [Theory]
        [InlineData(5, 5, 0, 0)]
        [InlineData(5, 5, 2, 3)]
        [InlineData(5, 5, 5, 5)]
        public void Plateau_Includes_ValidPosition(int plaX, int plaY, int posX, int posY)
        {
            var plateau = new Plateau(plaX, plaY);
            var position = new Position(posX, posY);
            Assert.True(plateau.Includes(position));
        }

        [Theory]
        [InlineData(5, 5, -1, 0)]
        [InlineData(5, 5, -1, 6)]
        [InlineData(5, 5, 2, 6)]
        [InlineData(5, 5, 5, 6)]
        public void Plateau_DoesNotInclude_InvalidPosition(int plaX, int plaY, int posX, int posY)
        {
            var plateau = new Plateau(plaX, plaY);
            var position = new Position(posX, posY);
            Assert.False(plateau.Includes(position));
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(-1, 1)]
        [InlineData(1, -1)]
        public void Plateau_DoesNotInstantiate_InvalidTopRightPosition(int x, int y)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Plateau(x, y));
        }

        [Fact]
        public void Plateau_Instantiates_ValidBottomLeftPosition()
        {
            var plateau = new Plateau(5, 5);
            Assert.Equal(plateau.BottomLeft, new Position(0, 0));
        }

        [Fact]
        public void Plateau_Instantiates_ValidTopRightPosition()
        {
            var plateau = new Plateau(5, 5);
            Assert.Equal(plateau.TopRight, new Position(5, 5));
        }
    }
}