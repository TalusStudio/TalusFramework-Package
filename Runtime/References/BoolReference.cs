using TalusFramework.References.Interfaces;

namespace TalusFramework.References
{
    [System.Serializable]
    public sealed class BoolReference : BaseReference<bool>
    {
        public static implicit operator bool(BoolReference reference) => reference.Value;
    }
}
