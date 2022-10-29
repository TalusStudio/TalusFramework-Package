using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [AddComponentMenu("TalusFramework/Listeners/String Listener", 5)]
    public sealed class StringListener : BaseGameEventListener<string, StringEvent>
    { }
}
