using TalusFramework.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Variables
{
    [CreateAssetMenu(fileName = "New Animation Curve Variable", menuName = "Variables/Animation Curve", order = 9)]
    public sealed class AnimationCurveVariable : BaseVariable<AnimationCurve>
    {
        public override void ResetRuntimeValue()
        {
            RuntimeValue = new AnimationCurve(Value?.keys)
            {
                preWrapMode = (WrapMode) (Value?.preWrapMode),
                postWrapMode = (WrapMode) (Value?.postWrapMode)
            };
        }
    }
}