using TalusFramework.References.Interfaces;
using TalusFramework.Variables;

namespace TalusFramework.References
{
    [System.Serializable]
    public sealed class AnimationClipReference : BaseReference<UnityEngine.AnimationClip, AnimationClipVariable>
    {
        public static implicit operator UnityEngine.AnimationClip(AnimationClipReference reference) => reference.Value;
    }
}