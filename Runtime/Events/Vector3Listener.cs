using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [AddComponentMenu("TalusFramework/Listeners/Vector3 Listener", 4)]
    public class Vector3Listener : BaseGameEventListener<Vector3, Vector3Event>
    { }
}
