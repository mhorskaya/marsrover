namespace MarsRover
{
    public class TurnLeftCommand : ICommand
    {
        public void Execute(Rover rover)
        {
            rover.TurnLeft();
        }
    }
}