using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Utility.Assertions;

namespace TalusFramework.Events.Interfaces
{
    [HideMonoScript]
    public abstract class BaseGameEventListener : MonoBehaviour, IGameEventListener
    {
        public EventResponsePair Pair;

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
        public EventResponsePair<T> Pair;

        [DisableInEditorMode]
        [GUIColor(0, 1, 0)]
        public void Send(T param)
        {
            Pair.Response?.Invoke(param);
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
}