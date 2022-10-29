using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [CreateAssetMenu(fileName = "New Vector2 Event", menuName = "Events/Vector2", order = 3)]
    public sealed class Vector2Event : BaseGameEvent<Vector2>
    { }
}
