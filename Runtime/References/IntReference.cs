using TalusFramework.Runtime.Constants;
using TalusFramework.Runtime.References.Interfaces;
using TalusFramework.Runtime.Variables;

namespace TalusFramework.Runtime.References
{
    [System.Serializable]
    public sealed class IntReference : BaseReference<int, IntVariableSO, IntConstantSO>
    {
        public static implicit operator int(IntReference reference) => reference.Value;
    }
}
