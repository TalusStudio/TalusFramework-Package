using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [AddComponentMenu("TalusFramework/Listeners/Animation Curve Listener", 9)]
    public sealed class AnimationCurveListener : BaseGameEventListener<AnimationCurve, AnimationCurveEvent>
    { }
}
