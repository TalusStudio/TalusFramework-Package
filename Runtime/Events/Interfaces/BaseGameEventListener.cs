using Sirenix.OdinInspector;

using TalusFramework.Utility.Assertions;

using UnityEngine;
using UnityEngine.Events;

namespace TalusFramework.Events.Interfaces
{
    [HideMonoScript]
    public abstract class BaseGameEventListener : MonoBehaviour, IGameEventListener
    {
        [Tooltip("Event to register with."), LabelWidth(75)]
        [AssetSelector(DropdownTitle = "Events")]
        [Required]
        public GameEvent GameEvent;

        [Tooltip("Response to invoke when Event is raised."), PropertySpace]
        public UnityEvent Response;

        [DisableInEditorMode]
        [GUIColor(0, 1, 0)]
        public void Send()
        {
            Response?.Invoke();
        }

        protected virtual void OnEnable()
        {
            this.Assert(GameEvent != null, "GameEvent reference is null!");

            GameEvent.AddListener(this);
        }

        protected virtual void OnDisable()
        {
            this.Assert(GameEvent != null, "GameEvent reference is null!");

            GameEvent.RemoveListener(this);
        }
    }

    [HideMonoScript]
    public abstract class BaseGameEventListener<T> : MonoBehaviour, IGameEventListener<T>
    {
        [Tooltip("Event to register with."), LabelWidth(75)]
        [AssetSelector(DropdownTitle = "Events")]
        [Required]
        public GameEvent GameEvent;

        [Tooltip("Response to invoke when Event is raised."), PropertySpace]
        public UnityEvent<T> Response;

        [DisableInEditorMode]
        [GUIColor(0, 1, 0)]
        public void Send(T param)
        {
            Response?.Invoke(param);
        }

        protected virtual void OnEnable()
        {
            this.Assert(GameEvent != null, "GameEvent reference is null!");

            GameEvent.AddListener(this);
        }

        protected virtual void OnDisable()
        {
            this.Assert(GameEvent != null, "GameEvent reference is null!");

            GameEvent.RemoveListener(this);
        }
    }
}