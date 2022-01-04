using System;

using TalusFramework.Runtime.References.Interfaces;

namespace TalusFramework.Runtime.References
{
    [Serializable]
    public sealed class AnimationClipReference : BaseReference<UnityEngine.AnimationClip>
    {
        public static implicit operator UnityEngine.AnimationClip(AnimationClipReference reference) => reference.Value;
    }
}