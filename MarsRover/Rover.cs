using System;
using System.Linq;

namespace MarsRover
{
    public class Rover
    {
        private readonly Plateau _plateau;
        private Position _position;
        private Orientation _orientation;

        public Rover(Plateau plateau, Position position, Orientation orientation)
        {
            _plateau = plateau;
            _position = position;
            _orientation = orientation;
        }

        public void RunCommands(string commands)
        {
            foreach (var command in commands.Select(GetCommand))
            {
                command.Execute(this);
            }
        }

        private static ICommand GetCommand(char command) => command switch
        {
            'L' => new TurnLeftCommand(),
            'R' => new TurnRightCommand(),
            'M' => new MoveCommand(),
            _ => throw new ArgumentOutOfRangeException(nameof(command), command, "Unknown command")
        };

        public void Turn(Direction direction)
        {
            _orientation = (_orientation, direction) switch
            {
                (Orientation.North, Direction.Left) => Orientation.West,
                (Orientation.West, Direction.Left) => Orientation.South,
                (Orientation.South, Direction.Left) => Orientation.East,
                (Orientation.East, Direction.Left) => Orientation.North,
                (Orientation.North, Direction.Right) => Orientation.East,
                (Orientation.East, Direction.Right) => Orientation.South,
                (Orientation.South, Direction.Right) => Orientation.West,
                (Orientation.West, Direction.Right) => Orientation.North,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, "Unknown direction")
            };
        }

        public void Move()
        {
            var position = _position.GetAdjacentPosition(_orientation);
            if (!_plateau.Includes(position))
            {
                throw new IndexOutOfRangeException("Cannot advance position");
            }

            _position = position;
        }

        public string GetLocationInfo()
        {
            return $"{_position.X} {_position.Y} {(char) _orientation}";
        }
    }
}