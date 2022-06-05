using TalusFramework.References.Interfaces;

namespace TalusFramework.References
{
    [System.Serializable]
    public sealed class IntReference : BaseReference<int>
    {
        public static implicit operator int(IntReference reference) => reference.Value;
    }
}
