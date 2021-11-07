using UnityEngine;

#if ENABLE_COMMANDS
using QFSW.QC;
#endif

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;

namespace TalusFramework.Runtime.Managers
{
	[CreateAssetMenu]
	[HideMonoScript]
#if ENABLE_COMMANDS
	[CommandPrefix("talus.")]
#endif
	public class TimeScaleManagerSO : BaseSO
	{
#if ENABLE_COMMANDS
		private void OnEnable() => QuantumRegistry.RegisterObject(this);
		private void OnDisable() => QuantumRegistry.DeregisterObject(this);
#endif

		[Button(ButtonSizes.Large), EnableIf("@Time.timeScale != 0f"), GUIColor(1f, 1f, 0f)]
		public void PauseGame() => Time.timeScale = 0f;

		[Button(ButtonSizes.Large), EnableIf("@Time.timeScale == 0f"), GUIColor(0f, 1f, 0f)]
		public void UnpauseGame() => Time.timeScale = 1f;
	}
}
