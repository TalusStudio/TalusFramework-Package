using TalusFramework.Runtime.Constants;
using TalusFramework.Runtime.References.Interfaces;
using TalusFramework.Runtime.Variables;
using UnityEngine;

namespace TalusFramework.Runtime.References
{
    [System.Serializable]
    public sealed class GameObjectReference : BaseReference<GameObject, GameObjectVariableSO, GameObjectConstantSO>
    {
        public static implicit operator GameObject(GameObjectReference reference) => reference.Value;
    }
}
