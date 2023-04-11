using TalusFramework.Events.Interfaces;
using TalusFramework.Utility;

using UnityEngine;

namespace TalusFramework.Events
{
    [AddComponentMenu("TalusFramework/Listeners/Scene Listener", 11)]
    public sealed class SceneListener : BaseGameEventListener<SceneReference, SceneEvent>
    { }
}
