using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace TalusFramework.Runtime.Events
{
    [DefaultExecutionOrder(-9999)]
    [HideMonoScript]
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        [Required]
        [AssetSelector(DropdownTitle = "Events")]
        [LabelWidth(75)]
        public GameEvent GameEvent;

        [Tooltip("Response to invoke when Event is raised.")]
        [PropertySpace]
        public UnityEvent Response;

        private void OnEnable()
        {
            GameEvent.AddListener(this);
        }

        private void OnDisable()
        {
            GameEvent.RemoveListener(this);
        }

        [DisableInEditorMode]
        [Button("Invoke Response", ButtonSizes.Large), GUIColor(0, 1, 0)]
        public void OnEventRaised()
        {
            Response?.Invoke();
        }
    }
}
