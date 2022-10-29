using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [CreateAssetMenu(fileName = "New GameObject Event", menuName = "Events/GameObject", order = 9)]
    public sealed class GameObjectEvent : BaseGameEvent<GameObject>
    { }
}
