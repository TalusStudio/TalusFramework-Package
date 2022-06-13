namespace TalusFramework.Events.Interfaces
{
    public interface IListener
    { }

    public interface IGameEventListener : IListener
    {
        public void Send();
    }

    public interface IGameEventListener<T> : IListener
    {
        public void Send(T param);
    }
}
