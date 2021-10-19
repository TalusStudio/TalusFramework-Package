using TalusFramework.Runtime.Constants;
using TalusFramework.Runtime.References.Interfaces;
using TalusFramework.Runtime.Variables;

namespace TalusFramework.Runtime.References
{
    [System.Serializable]
    public sealed class StringReference : BaseReference<string, StringVariableSO, StringConstantSO>
    {
        public static implicit operator string(StringReference reference) => reference.Value;
    }
}
