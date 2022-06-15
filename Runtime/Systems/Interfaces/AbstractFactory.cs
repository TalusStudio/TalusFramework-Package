using UnityEngine;

using TalusFramework.Base;

namespace TalusFramework.Systems.Interfaces
{
    public abstract class AbstractFactory<T> : BaseSO
    {
        [SerializeField]
        private T _Object;
        public T Object => _Object;

        public abstract T Create();
    }
}