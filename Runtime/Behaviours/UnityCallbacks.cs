using Sirenix.OdinInspector;

using UnityEngine;
using UnityEngine.Events;

namespace TalusFramework.Runtime.Behaviours
{
    [HideMonoScript]
    public class UnityCallbacks : MonoBehaviour
    {
        public UnityEvent OnAwake;
        public UnityEvent OnStart;

        private void Awake()
        {
            OnAwake.Invoke();
        }

        private void Start()
        {
            OnStart.Invoke();
        }
    }
}