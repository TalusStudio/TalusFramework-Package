using TalusFramework.References.Interfaces;
using TalusFramework.Variables;

namespace TalusFramework.References
{
    [System.Serializable]
    public sealed class FloatReference : BaseReference<float, FloatVariable>
    {
        public static implicit operator float(FloatReference reference) => reference.Value;
    }
}
