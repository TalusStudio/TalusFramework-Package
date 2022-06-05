using System.Collections.Generic;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;

namespace TalusFramework.Runtime.Collections.Interfaces
{
    public abstract class BaseCollection<T> : BaseSO
    {
        [HideLabel, LabelWidth(45)]
        [Title("Collection:", bold: true)]
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

        public void ForEach(System.Action<T> action)
        {
            for (int i = Items.Count - 1; i >= 0; i--)
            {
                action(Items[i]);
            }
        }

        [FoldoutGroup("Actions")]
        [Button]
        public void ResetAllValues(T value)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                Items[i] = value;
            }
        }

        [FoldoutGroup("Actions")]
        [Button(ButtonSizes.Large), GUIColor(1f, 1f, 0f)]
        public void ResetAllValuesToDefault()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                Items[i] = default;
            }
        }

        [FoldoutGroup("Actions")]
        [Button(ButtonSizes.Large), GUIColor(1f, 1f, 0f)]
        public void Clear()
        {
            Items.Clear();
        }
    }
}