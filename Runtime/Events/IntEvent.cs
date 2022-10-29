using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [CreateAssetMenu(fileName = "New Int Event", menuName = "Events/Int", order = 1)]
    public sealed class IntEvent : BaseGameEvent<int>
    { }
}
