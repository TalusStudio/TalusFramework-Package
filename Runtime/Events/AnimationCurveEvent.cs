using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [CreateAssetMenu(fileName = "New Animation Curve Event", menuName = "Events/Animation Curve", order = 9)]
    public sealed class AnimationCurveEvent : BaseGameEvent<AnimationCurve>
    { }
}
