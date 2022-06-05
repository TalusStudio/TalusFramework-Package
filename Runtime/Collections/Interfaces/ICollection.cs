namespace TalusFramework.Collections.Interfaces
{
    public interface ICollection
    {
        int Count { get; }
    }

    public interface ICollection<T> : ICollection
    {
        bool Add(T thing);
        bool Remove(T thing);
        void ForEach(System.Action<T> action);
    }
}