using UnityEngine;
using TalusFramework.References.Interfaces;

namespace TalusFramework.References
{
    [System.Serializable]
    public sealed class GameObjectReference : BaseReference<GameObject>
    {
        public static implicit operator GameObject(GameObjectReference reference) => reference.Value;
    }
}
