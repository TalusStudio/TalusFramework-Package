using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [AddComponentMenu("TalusFramework/Listeners/Game Object Listener", 9)]
    public sealed class GameObjectListener : BaseGameEventListener<GameObject, GameObjectEvent>
    { }
}
