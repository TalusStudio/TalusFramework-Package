using TalusFramework.Constants.Interfaces;

using UnityEngine;

namespace TalusFramework.Constants
{
    [CreateAssetMenu(fileName = "New Animation Curve Constant", menuName = "Constants/Animation Curve", order = 9)]
    public sealed class AnimationCurveConstant : BaseConstant<AnimationCurve>
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