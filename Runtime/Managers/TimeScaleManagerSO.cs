using UnityEngine;

using QFSW.QC;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;

namespace TalusFramework.Runtime.Managers
{
	[CreateAssetMenu]
	[HideMonoScript]
	[CommandPrefix("talus.")]
	public class TimeScaleManagerSO : BaseSO
	{
		private void OnEnable() => QuantumRegistry.RegisterObject(this);
		private void OnDisable() => QuantumRegistry.DeregisterObject(this);

		[Button(ButtonSizes.Large), EnableIf("@Time.timeScale != 0f"), GUIColor(1f, 1f, 0f)]
		public void PauseGame() => Time.timeScale = 0f;

		[Button(ButtonSizes.Large), EnableIf("@Time.timeScale == 0f"), GUIColor(0f, 1f, 0f)]
		public void UnpauseGame() => Time.timeScale = 1f;
	}
}
