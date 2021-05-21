namespace MarsRover
{
    public interface ICommand
    {
        public void Execute(Rover rover);
    }
}