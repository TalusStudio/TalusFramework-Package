using System.Collections.Generic;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Responses;
using TalusFramework.Runtime.Utility.Logging;

using UnityEngine;

namespace TalusFramework.Runtime.Events
{
	[CreateAssetMenu]
	[HideMonoScript]
	public class GameEvent : SerializedScriptableObject
	{

		[PropertyOrder(1)]
		public ToggleableResponses GlobalResponses = new ToggleableResponses();

#if ENABLE_LOGS
		[PropertyOrder(999)]
		[Space]
		[ToggleLeft]
		public bool UseDebug;
#endif
		[HideInEditorMode]
		[PropertyOrder(2)]
		[PropertySpace]
		[ReadOnly]
		[SerializeField]
		private List<GameEventListener> _GameEventListeners = new List<GameEventListener>();

		public int ListenersCount => _GameEventListeners.Count;

		[PropertySpace]
		[Button(ButtonSizes.Large)] [GUIColor(0, 1, 0)]
		[PropertyOrder(2)]
		[DisableInEditorMode]
		public void Raise()
		{
#if ENABLE_LOGS
			if (UseDebug) { TLog.Log(name + " invoked!"); }
#endif

			if (GlobalResponses.Enabled)
			{
				GlobalResponses.RaiseAll();
			}

			for (int i = _GameEventListeners.Count - 1; i >= 0; i--)
			{
				_GameEventListeners[i].OnEventRaised();
			}
		}

		public void AddListener(GameEventListener listener)
		{
			if (!_GameEventListeners.Contains(listener))
			{
				_GameEventListeners.Add(listener);
			}
		}

		public void RemoveListener(GameEventListener listener)
		{
			if (_GameEventListeners.Contains(listener))
			{
				_GameEventListeners.Remove(listener);
			}
		}
	}
}
