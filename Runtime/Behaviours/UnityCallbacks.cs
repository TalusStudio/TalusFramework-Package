using UnityEngine;
using UnityEngine.Events;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Behaviours.Interfaces;

namespace TalusFramework.Runtime.Behaviours
{
    [HideMonoScript]
    [AddComponentMenu("TalusFramework/Behaviours/UnityCallbacks", 9)]
    public class UnityCallbacks : BaseBehaviour
    {
        public UnityEvent OnAwakeEvent;
        public UnityEvent OnEnableEvent;
        public UnityEvent OnStartEvent;
        public UnityEvent OnDestroyEvent;

        private void Awake()
        {
            OnAwakeEvent.Invoke();
        }

        private void OnEnable()
        {
            OnEnableEvent.Invoke();
        }

        private void Start()
        {
            OnStartEvent.Invoke();
        }

        private void OnDestroy()
        {
            OnDestroyEvent.Invoke();
        }
    }
}