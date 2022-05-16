using Sirenix.OdinInspector;

using TalusFramework.Runtime.Utility.Logging;

using UnityEngine;
using UnityEngine.Events;

namespace TalusFramework.Runtime.Events
{
    [HideMonoScript]
    [AddComponentMenu("TalusFramework/Events/GameEventListener", 0)]
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with."), LabelWidth(75)]
        [AssetSelector(DropdownTitle = "Events")]
        [Required]
        public GameEvent GameEvent;

        [Tooltip("Response to invoke when Event is raised."), PropertySpace]
        [ValidateInput("ValidateResponseInput", "Response required!")]
        public UnityEvent Response;

#if UNITY_EDITOR
        private bool ValidateResponseInput => Response.GetPersistentEventCount() > 0 && Response.GetPersistentTarget(0) != null;
#endif

        private void OnEnable()
        {
            if (GameEvent == null)
            {
                this.LogError("GameEvent reference is null!");
                return;
            }

            GameEvent.AddListener(this);
        }

        private void OnDisable()
        {
            if (GameEvent == null)
            {
                this.LogError("GameEvent reference is null!");
                return;
            }

            GameEvent.RemoveListener(this);
        }

        [DisableInEditorMode]
        [GUIColor(0, 1, 0)]
        public void OnEventRaised() => Response?.Invoke();
    }
}