using TalusFramework.Runtime.References.Interfaces;

namespace TalusFramework.Runtime.References
{
    [System.Serializable]
    public sealed class Vector3Reference : BaseReference<UnityEngine.Vector3>
    {
        public static implicit operator UnityEngine.Vector3(Vector3Reference reference) => reference.Value;
    }
}
