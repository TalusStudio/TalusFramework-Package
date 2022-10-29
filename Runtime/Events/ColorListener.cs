using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [AddComponentMenu("TalusFramework/Listeners/Color Listener", 6)]
    public sealed class ColorListener : BaseGameEventListener<Color, ColorEvent>
    { }
}
