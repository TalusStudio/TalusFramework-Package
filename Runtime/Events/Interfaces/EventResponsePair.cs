using UnityEngine.Events;
using UnityEngine;

using Sirenix.OdinInspector;

namespace TalusFramework.Events.Interfaces
{
    [HideLabel]
    [System.Serializable]
    public class EventResponsePair
    {
        [LabelWidth(75)]
        [Required]
        public BaseGameEvent GameEvent;

        [PropertySpace]
        public UnityEvent Response;
    }

    [HideLabel]
    [System.Serializable]
    public class EventResponsePair<T>
    {
        [Tooltip("Event to register with."), LabelWidth(75)]
        [Required]
        public BaseGameEvent<T> GameEvent;

        [Tooltip("Response to invoke when Event is raised."), PropertySpace]
        public UnityEvent<T> Response;
    }
}