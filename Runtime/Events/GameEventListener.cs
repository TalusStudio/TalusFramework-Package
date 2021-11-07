using Sirenix.OdinInspector;

using TalusFramework.Runtime.Utility.Logging;

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
			if (GameEvent != null)
			{
				GameEvent.AddListener(this);
			}
			else
			{
				TLog.Log("GameEvent reference is null!", LogType.Error);
			}
		}

		private void OnDisable()
		{
			if (GameEvent != null)
			{
				GameEvent.RemoveListener(this);
			}
			else
			{
				TLog.Log("GameEvent reference is null!", LogType.Error);
			}
		}

		[DisableInEditorMode]
		[Button("Invoke Response", ButtonSizes.Large)] [GUIColor(0, 1, 0)]
		public void OnEventRaised()
		{
			Response?.Invoke();
		}
	}
}
