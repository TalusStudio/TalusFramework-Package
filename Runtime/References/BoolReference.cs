using TalusFramework.Runtime.Constants;
using TalusFramework.Runtime.References.Interfaces;
using TalusFramework.Runtime.Variables;

namespace TalusFramework.Runtime.References
{
    [System.Serializable]
    public sealed class BoolReference : BaseReference<bool, BoolVariableSO, BoolConstantSO>
    {
        public static implicit operator bool(BoolReference reference) => reference.Value;
    }
}
