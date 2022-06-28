using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [AddComponentMenu("TalusFramework/Listeners/Bool Listener", 0)]
    public class BoolListener : BaseGameEventListener<bool, BoolEvent>
    { }
}
