using TalusFramework.Base;
using TalusFramework.Utility.Assertions;
using TalusFramework.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Variables
{
    [CreateAssetMenu(fileName = "New GameObject Variable", menuName = "Variables/GameObject", order = 9)]
    public sealed class GameObjectVariable : BaseVariable<GameObject>
    {
        public override void SetValue(GameObject value)
        {
            if (ReferenceEquals(RuntimeValue, value)) { return; }

            RuntimeValue = value;
            InvokeOnChangeEvents(value);
        }

        public override void SetValue(BaseValue value)
        {
            if (ReferenceEquals(this, value)) { return; }

            var variable = value as BaseValue<GameObject>;

            this.Assert(variable != null, $@"Type mismatch in {name}.
                Expected: {typeof(GameObject)}
                Given: {value.GetType()}"
            );

            RuntimeValue = variable.RuntimeValue;
            InvokeOnChangeEvents(variable.RuntimeValue);
        }
    }
}
