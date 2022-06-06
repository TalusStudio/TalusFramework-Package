namespace TalusFramework.Collections.Interfaces
{
    public interface ICollection
    {
        int Count { get; }

        void Clear();
    }

    public interface ICollection<T> : ICollection
    {
        T this[int index] { get; set; }

        bool Add(T thing);
        bool Remove(T thing);
        void ForEach(System.Action<T> action);
    }
}