using TalusFramework.Runtime.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Variables
{
    [CreateAssetMenu(fileName = "New Animation Clip Variable", menuName = "Variables/Animation Clip", order = 9)]
    public sealed class AnimationClipVariableSO : BaseVariableSO<AnimationClip>
    { }
}