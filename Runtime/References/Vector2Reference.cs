using TalusFramework.Runtime.Constants;
using TalusFramework.Runtime.References.Interfaces;
using TalusFramework.Runtime.Variables;

namespace TalusFramework.Runtime.References
{
    [System.Serializable]
    public sealed class Vector2Reference : BaseReference<UnityEngine.Vector2, Vector2VariableSO, Vector2ConstantSO>
    {
        public static implicit operator UnityEngine.Vector2(Vector2Reference reference) => reference.Value;
    }
}
