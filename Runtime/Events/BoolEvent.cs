using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [CreateAssetMenu(fileName = "New Bool Event", menuName = "Events/Bool", order = 0)]
    public sealed class BoolEvent : BaseGameEvent<bool>
    { }
}
