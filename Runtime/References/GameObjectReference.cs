using System;

using TalusFramework.Runtime.References.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.References
{
    [Serializable]
    public sealed class GameObjectReference : BaseReference<GameObject>
    {
        public static implicit operator GameObject(GameObjectReference reference) => reference.Value;
    }
}
