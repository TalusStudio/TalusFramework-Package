using TalusFramework.Runtime.References.Interfaces;

namespace TalusFramework.Runtime.References
{
    [System.Serializable]
    public sealed class GameObjectReference : BaseReference<UnityEngine.GameObject>
    {
        public static implicit operator UnityEngine.GameObject(GameObjectReference reference) => reference.Value;
    }
}
