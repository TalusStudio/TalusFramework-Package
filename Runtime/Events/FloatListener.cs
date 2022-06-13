using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [AddComponentMenu("TalusFramework/Listeners/Float Listener", 2)]
    public class FloatListener : BaseGameEventListener<float, FloatEvent>
    { }
}
