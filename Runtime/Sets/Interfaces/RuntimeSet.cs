using System.Collections.Generic;
using Sirenix.OdinInspector;
using TalusFramework.Runtime.Base;
using UnityEngine;

namespace TalusFramework.Runtime.Sets.Interfaces
{
    public abstract class RuntimeSet<T> : BaseSO
    {
        [SerializeField]
        [LabelWidth(45)]
        [Title("Collection", bold: true)]
        [HideLabel]
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
