using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [AddComponentMenu("TalusFramework/Listeners/Sprite Listener", 7)]
    public class SpriteListener : BaseGameEventListener<Sprite, SpriteEvent>
    { }
}
