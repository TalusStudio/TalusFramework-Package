using TalusFramework.References.Interfaces;
using TalusFramework.Variables;

namespace TalusFramework.References
{
    [System.Serializable]
    public sealed class BoolReference : BaseReference<bool, BoolVariable>
    {
        public static implicit operator bool(BoolReference reference) => reference.Value;
    }
}
