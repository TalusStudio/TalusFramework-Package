namespace TalusFramework.Systems.Interfaces
{
    public interface ICommand
    {
        public void Execute();
        public void Undo();
    }
}