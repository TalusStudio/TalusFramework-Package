using TalusFramework.Runtime.References.Interfaces;

namespace TalusFramework.Runtime.References
{
    [System.Serializable]
    public sealed class Vector2Reference : BaseReference<UnityEngine.Vector2>
    {
        public static implicit operator UnityEngine.Vector2(Vector2Reference reference) => reference.Value;
    }
}
