using TalusFramework.References.Interfaces;

namespace TalusFramework.References
{
    [System.Serializable]
    public sealed class FloatReference : BaseReference<float>
    {
        public static implicit operator float(FloatReference reference) => reference.Value;
    }
}
