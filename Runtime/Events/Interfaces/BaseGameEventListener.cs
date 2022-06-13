using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Utility.Assertions;
using UnityEngine.Events;

namespace TalusFramework.Events.Interfaces
{
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