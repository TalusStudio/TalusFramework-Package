using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [AddComponentMenu("TalusFramework/Listeners/Bool Listener", 0)]
    public sealed class BoolListener : BaseGameEventListener<bool, BoolEvent>
    { }
}
