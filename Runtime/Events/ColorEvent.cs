using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [CreateAssetMenu(fileName = "New Color Event", menuName = "Events/Color", order = 6)]
    public sealed class ColorEvent : BaseGameEvent<Color>
    { }
}
