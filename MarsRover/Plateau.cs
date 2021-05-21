using System;

namespace MarsRover
{
    public class Plateau
    {
        public Position BottomLeft { get; }
        public Position TopRight { get; }

        public Plateau(int x, int y)
        {
            if (x < 0) throw new ArgumentOutOfRangeException(nameof(x), x, "Invalid top right position");
            if (y < 0) throw new ArgumentOutOfRangeException(nameof(y), y, "Invalid top right position");

            BottomLeft = new Position(0, 0);
            TopRight = new Position(x, y);
        }

        public bool Includes(Position position)
        {
            return BottomLeft.X <= position.X && position.X <= TopRight.X &&
                   BottomLeft.Y <= position.Y && position.Y <= TopRight.Y;
        }
    }
}