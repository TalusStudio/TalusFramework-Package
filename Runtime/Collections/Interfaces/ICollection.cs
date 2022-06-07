namespace TalusFramework.Collections.Interfaces
{
    public interface ICollection
    {
        int Count { get; }
    }

    public interface ICollection<T> : ICollection
    {
        T this[int index] { get; set; }

        bool Add(T thing);
        bool Remove(T thing);
        bool Contains(T thing);
        void ForEach(System.Action<T> action);
        void Clear();
    }
}