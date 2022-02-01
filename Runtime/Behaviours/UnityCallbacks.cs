using UnityEngine;
using UnityEngine.Events;

using Sirenix.OdinInspector;

namespace TalusFramework.Runtime.Behaviours
{
    [HideMonoScript]
    public class UnityCallbacks : MonoBehaviour
    {
        public UnityEvent OnAwakeEvent;
        public UnityEvent OnStartEvent;
        public UnityEvent OnDestroyEvent;

        private void Awake()
        {
            OnAwakeEvent.Invoke();
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