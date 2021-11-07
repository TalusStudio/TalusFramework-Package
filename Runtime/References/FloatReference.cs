using TalusFramework.Runtime.References.Interfaces;

namespace TalusFramework.Runtime.References
{
    [System.Serializable]
    public sealed class FloatReference : BaseReference<float>
    {
        public static implicit operator float(FloatReference reference) => reference.Value;
    }
}
