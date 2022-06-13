namespace TalusFramework.Events.Interfaces
{
    public interface IGameEvent
    {
        public void AddListener(IGameEventListener listener);
        public void RemoveListener(IGameEventListener listener);
        public void Raise();
    }

    public interface IGameEvent<T>
    {
        public void AddListener(IGameEventListener<T> listener);
        public void RemoveListener(IGameEventListener<T> listener);
        public void Raise(T param);
    }
}