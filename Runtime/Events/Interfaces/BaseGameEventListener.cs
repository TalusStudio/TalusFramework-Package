using UnityEngine;
using UnityEngine.Events;

using Sirenix.OdinInspector;

using TalusFramework.Utility.Assertions;

namespace TalusFramework.Events.Interfaces
{
    /// <summary>
    ///     Base: Void Event
    /// </summary>
    [HideMonoScript]
    public abstract class BaseGameEventListener : MonoBehaviour, IGameEventListener
    {
        [LabelWidth(70)]
        [AssetList(AssetNamePrefix = "Event_")]
        [Required]
        public VoidEvent GameEvent;
        public UnityEvent Response;

        [DisableInEditorMode]
        [GUIColor(0, 1, 0)]
        public void Send()
        {
            this.Assert(EventHelper.IsValidEvent(Response) == true, "There is a broken target on event!");

            Response?.Invoke();
        }

        protected virtual void OnEnable()
        {
            this.Assert(GameEvent != null, "Invalid Reference!", typeof(VoidEvent), null);

            GameEvent.AddListener(this);
        }

        protected virtual void OnDisable()
        {
            this.Assert(GameEvent != null, "Invalid Reference!", typeof(VoidEvent), null);

            GameEvent.RemoveListener(this);
        }
    }

    /// <summary>
    ///     Base: Generic Event
    /// </summary>
    [HideMonoScript]
    public abstract class BaseGameEventListener<TPlainType, TEventType> : MonoBehaviour, IGameEventListener<TPlainType>
        where TEventType : IGameEvent<TPlainType>
    {
        [LabelWidth(70)]
        [AssetList(AssetNamePrefix = "Event_")]
        [Required]
        public TEventType GameEvent;

        public UnityEvent<TPlainType> Response;

        [DisableInEditorMode]
        [GUIColor(0, 1, 0)]
        public void Send(TPlainType param)
        {
            this.Assert(EventHelper.IsValidEvent(Response) == true, "There is a broken target on event!");

            Response?.Invoke(param);
        }

        protected virtual void OnEnable()
        {
            this.Assert(GameEvent != null, "Invalid Reference!", typeof(TEventType), null);

            GameEvent.AddListener(this);
        }

        protected virtual void OnDisable()
        {
            this.Assert(GameEvent != null, "Invalid Reference!", typeof(TEventType), null);

            GameEvent.RemoveListener(this);
        }
    }
}