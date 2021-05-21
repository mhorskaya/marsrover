namespace MarsRover
{
    public class MoveCommand : ICommand
    {
        public void Execute(Rover rover)
        {
            rover.Move();
        }
    }
}