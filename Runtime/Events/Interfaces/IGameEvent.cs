namespace TalusFramework.Events.Interfaces
{
    public interface IGameEvent
    {
        public void AddListener(IListener listener);
        public void RemoveListener(IListener listener);
    }
}