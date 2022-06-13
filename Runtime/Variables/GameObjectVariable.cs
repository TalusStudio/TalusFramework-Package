using TalusFramework.Base;
using TalusFramework.Utility.Assertions;
using TalusFramework.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Variables
{
    [CreateAssetMenu(fileName = "New GameObject Variable", menuName = "Variables/GameObject", order = 9)]
    public sealed class GameObjectVariable : BaseVariable<GameObject>
    {
        public override GameObject RuntimeValue
        {
            get => base.RuntimeValue;
            protected set
            {
                if (!ReferenceEquals(RuntimeValue, value))
                {
                    base.RuntimeValue = value;
                    InvokeOnChangeEvents(value);
                }
            }
        }

        public override void SetValue(GameObject value)
        {
            base.RuntimeValue = value;
        }

        public override void SetValue(BaseValue value)
        {
            var variable = value as BaseValue<GameObject>;

            this.Assert(variable != null, $@"Type mismatch in {name}.
                Expected: {typeof(GameObject)}
                Given: {value.GetType()}"
            );

            base.RuntimeValue = variable.RuntimeValue;
        }
    }
}
