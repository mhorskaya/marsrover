using System;
using System.Collections.Generic;
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

        private readonly Dictionary<char, ICommand> _commands = new()
        {
            ['L'] = new TurnLeftCommand(),
            ['R'] = new TurnRightCommand(),
            ['M'] = new MoveCommand()
        };

        private readonly Dictionary<Orientation, Orientation> _leftOrientationMap = new()
        {
            [Orientation.North] = Orientation.West,
            [Orientation.West] = Orientation.South,
            [Orientation.South] = Orientation.East,
            [Orientation.East] = Orientation.North
        };

        private readonly Dictionary<Orientation, Orientation> _rightOrientationMap = new()
        {
            [Orientation.North] = Orientation.East,
            [Orientation.East] = Orientation.South,
            [Orientation.South] = Orientation.West,
            [Orientation.West] = Orientation.North
        };


        public void Run(string commands)
        {
            foreach (var command in commands.Select(GetCommand))
            {
                command.Execute(this);
            }
        }

        private ICommand GetCommand(char commandChar)
        {
            if (_commands.TryGetValue(commandChar, out var command))
            {
                return command;
            }

            throw new ArgumentOutOfRangeException(nameof(commandChar), commandChar, "Unrecognized command character");
        }

        public void TurnLeft()
        {
            _orientation = _leftOrientationMap[_orientation];
        }

        public void TurnRight()
        {
            _orientation = _rightOrientationMap[_orientation];
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