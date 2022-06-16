using UnityEngine;
using UnityEngine.Events;

using TalusFramework.Behaviours.Interfaces;

namespace TalusFramework.Behaviours
{
    [AddComponentMenu("TalusFramework/Behaviours/Unity Callbacks", 9)]
    public class UnityCallbacks : BaseBehaviour
    {
        public UnityEvent OnAwakeEvent;
        public UnityEvent OnEnableEvent;
        public UnityEvent OnStartEvent;
        public UnityEvent OnDestroyEvent;

        protected override void Awake()
        {
            OnAwakeEvent.Invoke();
        }

        protected override void OnEnable()
        {
            OnEnableEvent.Invoke();
        }

        protected override void Start()
        {
            OnStartEvent.Invoke();
        }

        private void OnDestroy()
        {
            OnDestroyEvent.Invoke();
        }
    }
}