using TalusFramework.Events.Interfaces;

using UnityEngine;

namespace TalusFramework.Events
{
    [CreateAssetMenu(fileName = "New String Event", menuName = "Events/String", order = 5)]
    public class StringEvent : BaseGameEvent<string>
    { }
}
