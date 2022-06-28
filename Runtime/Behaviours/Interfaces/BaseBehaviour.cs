using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Base;

namespace TalusFramework.Behaviours.Interfaces
{
    [HideMonoScript]
    public class BaseBehaviour : MonoBehaviour
    {
#if UNITY_EDITOR
        public Description Description = default;
#endif

        protected virtual void Awake()
        { }

        protected virtual void Start()
        { }

        protected virtual void OnEnable()
        { }

        protected virtual void OnDisable()
        { }
    }
}
