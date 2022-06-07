using TalusFramework.Base;
using TalusFramework.Utility.Logging;
using TalusFramework.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Variables
{
    [CreateAssetMenu(fileName = "New GameObject Variable", menuName = "Variables/GameObject", order = 9)]
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
                this.LogError("Type mismatch in " + name + ". Expected type:" + typeof(GameObject));
                return;
            }

            RuntimeValue = variable.RuntimeValue;
            InvokeOnChangeEvents(variable.RuntimeValue);
        }
    }
}
