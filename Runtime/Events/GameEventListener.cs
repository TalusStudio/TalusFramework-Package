using Sirenix.OdinInspector;

using TalusFramework.Utility.Assertions;

using UnityEngine;
using UnityEngine.Events;

namespace TalusFramework.Events
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
        [ValidateInput(nameof(ValidateResponseInput), "Response required!")]
        public UnityEvent Response;

        [DisableInEditorMode]
        [GUIColor(0, 1, 0)]
        public void OnEventRaised() => Response?.Invoke();

        private void OnEnable()
        {
            this.Assert(GameEvent != null, "GameEvent reference is null!");

            GameEvent.AddListener(this);
        }

        private void OnDisable()
        {
            this.Assert(GameEvent != null, "GameEvent reference is null!");

            GameEvent.RemoveListener(this);
        }

        private bool ValidateResponseInput => Response.GetPersistentEventCount() > 0 && Response.GetPersistentTarget(0) != null;
    }
}