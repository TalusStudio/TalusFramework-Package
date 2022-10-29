using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [AddComponentMenu("TalusFramework/Listeners/Vector2 Listener", 3)]
    public sealed class Vector2Listener : BaseGameEventListener<Vector2, Vector2Event>
    { }
}
