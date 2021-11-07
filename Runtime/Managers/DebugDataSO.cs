using System;

using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Constants;
using TalusFramework.Runtime.Events;
using TalusFramework.Runtime.References;
using TalusFramework.Runtime.Utility.Logging;

namespace TalusFramework.Runtime.Managers
{
	[CreateAssetMenu]
	[HideMonoScript]
	public class DebugDataSO : BaseSO
	{
		[FoldoutGroup("Debugging")]
		[ToggleLeft]
		[SerializeField]
		private bool _EnableHiddenDebugView;

		[ShowIf("_EnableHiddenDebugView")]
		[FoldoutGroup("Debugging")]
		[LabelWidth(145)]
		[AssetSelector]
		public GameObjectConstantSO DebugView;

		[ShowIf("_EnableHiddenDebugView")]
		[FoldoutGroup("Debugging")]
		[LabelWidth(145)]
		[SerializeField]
		public IntReference RequiredTapCount;

		[ShowIf("_EnableHiddenDebugView")]
		[FoldoutGroup("Debugging")]
		[Required]
		[LabelWidth(145)]
		[AssetSelector]
		public GameEvent ConsoleActivatedEvent;

		public void CreateDebugView()
		{
			if (!_EnableHiddenDebugView)
			{
				TLog.Log("Quantum Console disabled in Build Settings!!!", LogType.Warning);
				return;
			}

			if (GameObject.Find("UI_Canvas_Debug") == null)
			{
				Instantiate(DebugView.Value);
			}
			else
			{
				TLog.Log("Quantum Console binding already in scene!");
			}
		}

		[NonSerialized]
		private int _CurrentTapCount;

		public void CheckConsoleActivity()
		{
			if (++_CurrentTapCount >= RequiredTapCount)
			{
				_CurrentTapCount = 0;

				ConsoleActivatedEvent.Raise();
			}
		}
	}
}
