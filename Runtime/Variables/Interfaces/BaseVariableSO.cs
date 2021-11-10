﻿using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Responses;
using TalusFramework.Runtime.Utility.Logging;

using UnityEngine;

namespace TalusFramework.Runtime.Variables.Interfaces
{
	public abstract class BaseVariableSO<TPlainType> : BaseValueSO<TPlainType>
	{
		[PropertySpace]
		[PropertyOrder(2)]
		[HorizontalGroup(1f)]
		public ToggleableResponses OnChangeEvent = new ToggleableResponses();

		public virtual void SetValue(TPlainType value)
		{
			if (RuntimeValue.Equals(value)) { return; }

			RuntimeValue = value;

			if (OnChangeEvent.Enabled)
			{
				OnChangeEvent.RaiseAll();
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
				OnChangeEvent.RaiseAll();
			}
		}
	}
}
