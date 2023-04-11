using UnityEngine;

using TalusFramework.Base;
using TalusFramework.Variables.Interfaces;
using TalusFramework.Utility;

namespace TalusFramework.Variables
{
    [CreateAssetMenu(fileName = "New Scene Variable", menuName = "Variables/Scene", order = 11)]
    public sealed class SceneVariable : BaseVariable<SceneReference>
    {
        public override void ResetRuntimeValue()
        {
            if (Value == null || Value.IsEmpty) { return; }

            base.SetValue(Value.Clone());
        }

        public override void SetValue(SceneReference value)
        {
            base.SetValue(value.Clone());
        }

        public override void SetValue(BaseValue value)
        {
            var variable = value as BaseValue<SceneReference>;
            base.SetValue(variable.RuntimeValue.Clone());
        }
    }
}
