using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [CreateAssetMenu(fileName = "New Sprite Event", menuName = "Events/Sprite", order = 7)]
    public sealed class SpriteEvent : BaseGameEvent<Sprite>
    { }
}
