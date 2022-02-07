using System.Collections.Generic;

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
    }
}