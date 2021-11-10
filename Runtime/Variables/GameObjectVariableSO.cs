using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Utility.Logging;
using TalusFramework.Runtime.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Variables
{
	[CreateAssetMenu(fileName = "New GameObject Variable", menuName = "Variables/GameObject", order = 6)]
	[HideMonoScript]
	public sealed class GameObjectVariableSO : BaseVariableSO<GameObject>
	{
		public override void SetValue(GameObject value)
		{
			if (ReferenceEquals(RuntimeValue, value)) { return; }

			RuntimeValue = value;

			if (OnChangeEvent.Enabled)
			{
				OnChangeEvent.RaiseAll();
			}
		}

		public override void SetValue(BaseValueSO value)
		{
			if (ReferenceEquals(this, value)) { return; }

			BaseValueSO<GameObject> variable = value as BaseValueSO<GameObject>;

			if (variable == null)
			{
				TLog.Log("Type mismatch in " + name + ". Expected type:" + typeof(GameObject), LogType.Error);
				return;
			}

			RuntimeValue = variable.Value;

			if (OnChangeEvent.Enabled)
			{
				OnChangeEvent.RaiseAll();
			}
		}
	}
}
