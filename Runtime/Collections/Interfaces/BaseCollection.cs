using System.Collections.Generic;
using System.Runtime.InteropServices;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;

using UnityEngine;

namespace TalusFramework.Runtime.Collections.Interfaces
{
    public abstract class BaseCollection<T> : BaseSO
    {
        [HideLabel, Title("Collection", bold: true), LabelWidth(45)]
        [SerializeField]
        public List<T> Items = new List<T>();

        public bool Add(T thing)
        {
            if (Items.Contains(thing))
            {
                return false;
            }

            Items.Add(thing);
            return true;
        }

        public bool Remove(T thing)
        {
            if (!Items.Contains(thing))
            {
                return false;
            }

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
            for (int i = 0; i < Items.Count; ++i)
            {
                Items[i] = value;
            }
        }

        [FoldoutGroup("Actions")]
        [Button(ButtonSizes.Large), GUIColor(1f, 1f, 0f)]
        public void ResetAllValuesToDefault()
        {
            for (int i = 0; i < Items.Count; ++i)
            {
                Items[i] = default;
            }
        }

        [FoldoutGroup("Actions")]
        [Button(ButtonSizes.Large), GUIColor(1f, 1f, 0f)]
        public void Clear()
        {
            Items.Clear();
            Items = null;
        }
    }
}