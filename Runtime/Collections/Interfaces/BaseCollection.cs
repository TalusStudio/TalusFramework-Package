using System;
using System.Collections;
using System.Collections.Generic;

using Sirenix.OdinInspector;

using TalusFramework.Base;

using UnityEngine;

namespace TalusFramework.Collections.Interfaces
{
    /// <summary>
    ///     To work with UnityEditor.
    /// </summary>
    public abstract class BaseCollection : BaseSO
    { }

    public abstract class BaseCollection<T> : BaseCollection, ICollection<T>
    {
        [LabelWidth(45)]
        [LabelText("@this.ToString()")]
        [ListDrawerSettings(DraggableItems = true,
            Expanded = true,
            ShowIndexLabels = false,
            ShowPaging = true,
            ShowItemCount = true,
            NumberOfItemsPerPage = 10
        )]
        [SerializeField]
        private List<T> _Items = default;
        public List<T> Items => _Items;

        public T this[int index]
        {
            get => Items[index];
            set => Items[index] = value;
        }

        public int Count => Items.Count;

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void ForEach(System.Action<T> action)
        {
            for (int i = Items.Count - 1; i >= 0; i--)
            {
                action(Items[i]);
            }
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

        bool ICollection<T>.Contains(T item)
        {
            return Items.Contains(item);
        }

        public void Add(T item)
        {
            if (!Items.Contains(item))
            {
                Items.Add(item);
            }
        }

        public bool Remove(T item)
        {
            if (!Items.Contains(item)) { return false; }

            Items.Remove(item);
            return true;
        }

        public void Clear()
        {
            Items.Clear();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("The array cannot be null.");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            }

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("The destination array has fewer elements than the collection.");
            }

            for (int i = 0; i < Count; i++)
            {
                array[i + arrayIndex] = Items[i];
            }
        }
    }
}