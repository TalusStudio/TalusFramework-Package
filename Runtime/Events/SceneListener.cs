using TalusFramework.Events.Interfaces;
using TalusFramework.Utility;

using UnityEngine;

namespace TalusFramework.Events
{
    [AddComponentMenu("TalusFramework/Listeners/Scene Listener", 10)]
    public class SceneListener : BaseGameEventListener<SceneReference, SceneEvent>
    { }
}
