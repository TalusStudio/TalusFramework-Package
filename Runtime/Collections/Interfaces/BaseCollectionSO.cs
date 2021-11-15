using System.Collections.Generic;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;

using UnityEngine;

namespace TalusFramework.Runtime.Collections.Interfaces
{
    public abstract class BaseCollectionSO<T> : BaseSO
    {
        [LabelWidth(45)]
        [Title("Collection", bold: true)]
        [HideLabel]
        [SerializeField]
        public List<T> Items = new List<T>();

        public void Add(T thing)
        {
            if (!Items.Contains(thing))
            {
                Items.Add(thing);
            }
        }

        public void Remove(T thing)
        {
            if (Items.Contains(thing))
            {
                Items.Remove(thing);
            }
        }
    }
}
