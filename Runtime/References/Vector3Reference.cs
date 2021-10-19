using TalusFramework.Runtime.Constants;
using TalusFramework.Runtime.References.Interfaces;
using TalusFramework.Runtime.Variables;

namespace TalusFramework.Runtime.References
{
    [System.Serializable]
    public sealed class Vector3Reference : BaseReference<UnityEngine.Vector3, Vector3VariableSO, Vector3ConstantSO>
    {
        public static implicit operator UnityEngine.Vector3(Vector3Reference reference) => reference.Value;
    }
}
