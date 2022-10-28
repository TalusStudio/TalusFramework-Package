using UnityEngine;

using TalusFramework.References.Interfaces;
using TalusFramework.Variables;

namespace TalusFramework.References
{
    [System.Serializable]
    public sealed class GameObjectReference : BaseReference<GameObject, GameObjectVariable>
    {
        public static implicit operator GameObject(GameObjectReference reference) => reference.Value;
    }
}
