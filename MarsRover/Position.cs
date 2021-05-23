using System.Collections.Generic;

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

        private static readonly Dictionary<Orientation, Position> TransformMap = new()
        {
            [Orientation.North] = new Position(0, 1),
            [Orientation.East] = new Position(1, 0),
            [Orientation.South] = new Position(0, -1),
            [Orientation.West] = new Position(-1, 0)
        };

        public Position GetAdjacentPosition(Orientation orientation)
        {
            return this + TransformMap[orientation];
        }

        public static Position operator +(Position a, Position b) => new(a.X + b.X, a.Y + b.Y);

        public override string ToString() => $"({X}, {Y})";
    }
}