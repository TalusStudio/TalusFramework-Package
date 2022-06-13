using UnityEngine;

using TalusFramework.Utility;
using TalusFramework.Variables.Interfaces;
using TalusFramework.Base;
using TalusFramework.Utility.Assertions;

namespace TalusFramework.Variables
{
    [CreateAssetMenu(fileName = "New Scene Variable", menuName = "Variables/Scene", order = 10)]
    public sealed class SceneVariable : BaseVariable<SceneReference>
    {
        public override SceneReference RuntimeValue
        {
            get => base.RuntimeValue;
            protected set
            {
                if (!base.RuntimeValue.IsEmpty && !base.RuntimeValue.Equals(value))
                {
                    base.RuntimeValue = new SceneReference(value);
                    InvokeOnChangeEvents(base.RuntimeValue);
                }
            }
        }

        public override void ResetRuntimeValue()
        {
            if (Value == null || Value.IsEmpty)
            {
                return;
            }

            base.RuntimeValue = new SceneReference(Value);
            InvokeOnChangeEvents(base.RuntimeValue);
        }

        public override void SetValue(SceneReference value)
        {
            RuntimeValue = new SceneReference(value);
        }

        public override void SetValue(BaseValue value)
        {
            var variable = value as BaseValue<SceneReference>;

            this.Assert(variable != null, $@"Type mismatch in {name}.
                Expected: {typeof(SceneReference)}
                Given: {value.GetType()}"
            );

            RuntimeValue = new SceneReference(variable.RuntimeValue);
        }
    }
}
