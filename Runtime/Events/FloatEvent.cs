using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [CreateAssetMenu(fileName = "New Float Event", menuName = "Events/Float", order = 2)]
    public sealed class FloatEvent : BaseGameEvent<float>
    { }
}
