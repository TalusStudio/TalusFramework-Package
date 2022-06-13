using Sirenix.OdinInspector;

using TalusFramework.Utility.Assertions;

using UnityEngine;
using UnityEngine.Events;

namespace TalusFramework.Events.Interfaces
{
    [HideMonoScript]
    public abstract class BaseGameEventListener : MonoBehaviour, IGameEventListener
    {
        public GameEventPair Pair;

        [DisableInEditorMode]
        [GUIColor(0, 1, 0)]
        public void Send()
        {
            Pair.Response?.Invoke();
        }

        protected virtual void OnEnable()
        {
            this.Assert(Pair.GameEvent != null, "GameEvent reference is null!");

            Pair.GameEvent.AddListener(this);
        }

        protected virtual void OnDisable()
        {
            this.Assert(Pair.GameEvent != null, "GameEvent reference is null!");

            Pair.GameEvent.RemoveListener(this);
        }
    }

    [HideMonoScript]
    public abstract class BaseGameEventListener<T> : MonoBehaviour, IGameEventListener<T>
    {
        public GameEventPair<T> Pair;

        [DisableInEditorMode]
        [GUIColor(0, 1, 0)]
        public void Send(T param)
        {
            Pair.Response?.Invoke(param);
        }

        protected virtual void OnEnable()
        {
            this.Assert(Pair.GameEvent != null, "GameEvent reference is null!");

            var gameEventType = Pair.GameEvent as BaseGameEvent<T>;
            this.Assert(gameEventType != null, "Event type mis-match!");

            gameEventType.AddListener(this);
        }

        protected virtual void OnDisable()
        {
            this.Assert(Pair.GameEvent != null, "GameEvent reference is null!");

            var gameEventType = Pair.GameEvent as BaseGameEvent<T>;
            this.Assert(gameEventType != null, "Event type mis-match!");

            gameEventType.RemoveListener(this);
        }
    }

    [System.Serializable]
    [HideLabel]
    public class GameEventPair
    {
        [Tooltip("Event to register with."), LabelWidth(75)]
        [Required]
        public BaseGameEvent GameEvent;

        [Tooltip("Response to invoke when Event is raised."), PropertySpace]
        public UnityEvent Response;
    }

    [System.Serializable]
    [HideLabel]
    public class GameEventPair<T>
    {
        [Tooltip("Event to register with."), LabelWidth(75)]
        [Required]
        public BaseGameEvent<T> GameEvent;

        [Tooltip("Response to invoke when Event is raised."), PropertySpace]
        public UnityEvent<T> Response;
    }
}