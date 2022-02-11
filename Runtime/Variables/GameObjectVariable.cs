﻿using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Utility.Logging;
using TalusFramework.Runtime.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Variables
{
    [CreateAssetMenu(fileName = "New GameObject Variable", menuName = "Variables/GameObject", order = 6)]
    public sealed class GameObjectVariable : BaseVariable<GameObject>
    {
        public override void SetValue(GameObject value)
        {
            if (ReferenceEquals(RuntimeValue, value))
            {
                return;
            }

            RuntimeValue = value;
            InvokeOnChangeEvents(value);
        }

        public override void SetValue(BaseValue value)
        {
            if (ReferenceEquals(this, value))
            {
                return;
            }

            var variable = value as BaseValue<GameObject>;

            if (variable == null)
            {
                TLog.Log("Type mismatch in " + name + ". Expected type:" + typeof(GameObject), LogType.Error);
                return;
            }

            RuntimeValue = variable.RuntimeValue;
            InvokeOnChangeEvents(variable.RuntimeValue);
        }
    }
}