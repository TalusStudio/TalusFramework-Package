using Sirenix.OdinInspector;
using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Utility;
using TalusFramework.Runtime.Utility.Logging;
using UnityEngine;

namespace TalusFramework.Runtime.Variables.Interfaces
{
	public abstract class BaseVariableSO<TPlainType> : BaseValueSO<TPlainType>
	{
		[PropertySpace]
		[PropertyOrder(2)]
		[HorizontalGroup(1f)]
		public ToggleableEvent OnChangeEvent = new ToggleableEvent();

		public virtual void SetValue(TPlainType value)
		{
			if (RuntimeValue.Equals(value)) { return; }

			RuntimeValue = value;

			if (OnChangeEvent.Enabled)
			{
				OnChangeEvent.Response.Invoke();
			}
		}

		public virtual void SetValue(BaseValueSO value)
		{
			BaseValueSO<TPlainType> variable = value as BaseValueSO<TPlainType>;
			if (variable == null)
			{
				TLog.Log("Type mismatch in " + name + ". Expected type:" + typeof(TPlainType), LogType.Error);
				return;
			}

			if (RuntimeValue.Equals(variable.RuntimeValue)) { return; }

			RuntimeValue = variable.RuntimeValue;

			if (OnChangeEvent.Enabled)
			{
				OnChangeEvent.Response.Invoke();
			}
		}
	}
}
