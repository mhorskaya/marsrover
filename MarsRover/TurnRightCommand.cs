namespace MarsRover
{
    public class TurnRightCommand : ICommand
    {
        public void Execute(Rover rover)
        {
            rover.TurnRight();
        }
    }
}