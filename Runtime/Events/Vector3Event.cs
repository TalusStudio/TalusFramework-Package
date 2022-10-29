using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [CreateAssetMenu(fileName = "New Vector3 Event", menuName = "Events/Vector3", order = 4)]
    public sealed class Vector3Event : BaseGameEvent<Vector3>
    { }
}
