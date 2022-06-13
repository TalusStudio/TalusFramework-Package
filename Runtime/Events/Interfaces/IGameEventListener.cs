namespace TalusFramework.Events.Interfaces
{
    public interface IGameEventListener
    {
        public void Send();
    }

    public interface IGameEventListener<T>
    {
        public void Send(T param);
    }
}
