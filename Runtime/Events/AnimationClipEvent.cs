using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [CreateAssetMenu(fileName = "New Animation Clip Event", menuName = "Events/Animation Clip", order = 8)]
    public sealed class AnimationClipEvent : BaseGameEvent<AnimationClip>
    { }
}
