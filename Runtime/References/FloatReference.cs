using TalusFramework.Runtime.Constants;
using TalusFramework.Runtime.References.Interfaces;
using TalusFramework.Runtime.Variables;

namespace TalusFramework.Runtime.References
{
    [System.Serializable]
    public sealed class FloatReference : BaseReference<float, FloatVariableSO, FloatConstantSO>
    {
        public static implicit operator float(FloatReference reference) => reference.Value;
    }
}
