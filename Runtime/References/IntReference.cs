using TalusFramework.References.Interfaces;
using TalusFramework.Variables;

namespace TalusFramework.References
{
    [System.Serializable]
    public sealed class IntReference : BaseReference<int, IntVariable>
    {
        public static implicit operator int(IntReference reference) => reference.Value;
    }
}
