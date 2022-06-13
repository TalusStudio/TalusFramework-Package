using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [AddComponentMenu("TalusFramework/Listeners/Int Listener", 1)]
    public class IntListener : BaseGameEventListener<int, IntEvent>
    { }
}
