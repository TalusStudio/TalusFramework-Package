using TalusFramework.References.Interfaces;

namespace TalusFramework.References
{
    [System.Serializable]
    public sealed class AnimationClipReference : BaseReference<UnityEngine.AnimationClip>
    {
        public static implicit operator UnityEngine.AnimationClip(AnimationClipReference reference) => reference.Value;
    }
}