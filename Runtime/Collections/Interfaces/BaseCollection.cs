using System.Collections;
using System.Collections.Generic;

using Sirenix.OdinInspector;

using TalusFramework.Base;

namespace TalusFramework.Collections.Interfaces
{
    public abstract class BaseCollection<T> : BaseSO, ICollection<T>, IEnumerable<T>
    {
        [LabelWidth(45)]
        [LabelText("@this.ToString()")]
        [ListDrawerSettings(DraggableItems = true,
            Expanded = true,
            ShowIndexLabels = true,
            ShowPaging = true,
            ShowItemCount = true,
            NumberOfItemsPerPage = 10
        )]
        public List<T> Items = new List<T>();

        public T this[int index]
        {
            get => Items[index];
            set => Items[index] = value;
        }

        public int Count => Items.Count;

        public bool Add(T thing)
        {
            if (Items.Contains(thing)) { return false; }

            Items.Add(thing);
            return true;
        }

        public bool Remove(T thing)
        {
            if (!Items.Contains(thing)) { return false; }

            Items.Remove(thing);
            return true;
        }

        public bool Contains(T thing)
        {
            return Items.Contains(thing);
        }

        public void ForEach(System.Action<T> action)
        {
            for (int i = Items.Count - 1; i >= 0; i--)
            {
                action(Items[i]);
            }
        }

        public void Clear()
        {
            Items.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return $"{typeof(T).Name} Collection";
        }
    }
}