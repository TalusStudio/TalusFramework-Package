using UnityEngine;

using TalusFramework.Events.Interfaces;
using TalusFramework.Utility;

namespace TalusFramework.Events
{
    [CreateAssetMenu(fileName = "New Scene Event", menuName = "Events/Scene", order = 11)]
    public sealed class SceneEvent : BaseGameEvent<SceneReference>
    { }
}
