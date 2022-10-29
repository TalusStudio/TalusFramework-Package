using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [AddComponentMenu("TalusFramework/Listeners/Animation Clip Listener", 8)]
    public sealed class AnimationClipListener : BaseGameEventListener<AnimationClip, AnimationClipEvent>
    { }
}
