using UnityEngine;

using TalusFramework.Runtime.References.Interfaces;

namespace TalusFramework.Runtime.References
{
    [System.Serializable]
    public sealed class GameObjectReference : BaseReference<GameObject>
    {
        public static implicit operator GameObject(GameObjectReference reference) => reference.Value;
    }
}
