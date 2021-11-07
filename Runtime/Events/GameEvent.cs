using System.Collections.Generic;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Utility;
using TalusFramework.Runtime.Utility.Logging;

using UnityEngine;
using UnityEngine.Serialization;

namespace TalusFramework.Runtime.Events
{
	[CreateAssetMenu]
	[HideMonoScript]
	public class GameEvent : BaseSO
	{
		[ReadOnly]
		[HideInEditorMode]
		[SerializeField]
		[PropertyOrder(2)]
		[PropertySpace]
		[FormerlySerializedAs("_gameEventListeners")]
		private List<GameEventListener> _GameEventListeners = new List<GameEventListener>();

		[PropertyOrder(1)]
		public ToggleableEvent GlobalCallback = new ToggleableEvent();

#if ENABLE_LOGS
		[PropertyOrder(3)]
		[Space]
		[ToggleLeft]
		public bool ConsoleDebug;
#endif

		public int ListenersCount => _GameEventListeners.Count;

		[PropertySpace]
		[Button(ButtonSizes.Large)] [GUIColor(0, 1, 0)]
		[PropertyOrder(2)]
		[DisableInEditorMode]
		public void Raise()
		{
#if ENABLE_LOGS
			if (ConsoleDebug) { TLog.Log(name + " invoked!"); }
#endif

			if (GlobalCallback.Enabled)
			{
				GlobalCallback.Response?.Invoke();
			}

			for (int i = _GameEventListeners.Count - 1; i >= 0; i--)
			{
				_GameEventListeners[i].OnEventRaised();
			}
		}

		public void AddListener(GameEventListener gameEventListener)
		{
			if (!_GameEventListeners.Contains(gameEventListener))
			{
				_GameEventListeners.Add(gameEventListener);
			}
		}

		public void RemoveListener(GameEventListener gameEventListener)
		{
			if (_GameEventListeners.Contains(gameEventListener))
			{
				_GameEventListeners.Remove(gameEventListener);
			}
		}
	}
}
