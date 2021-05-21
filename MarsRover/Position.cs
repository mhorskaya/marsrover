using System;

namespace MarsRover
{
    public readonly struct Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position GetAdjacentPosition(Orientation orientation) => orientation switch
        {
            Orientation.North => new Position(X, Y + 1),
            Orientation.East => new Position(X + 1, Y),
            Orientation.South => new Position(X, Y - 1),
            Orientation.West => new Position(X - 1, Y),
            _ => throw new ArgumentOutOfRangeException(nameof(orientation), orientation, "Unknown orientation")
        };

        public override string ToString() => $"({X}, {Y})";
    }
}