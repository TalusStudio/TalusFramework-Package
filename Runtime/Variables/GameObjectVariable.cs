using UnityEngine;

using TalusFramework.Base;
using TalusFramework.Variables.Interfaces;

namespace TalusFramework.Variables
{
    [CreateAssetMenu(fileName = "New GameObject Variable", menuName = "Variables/GameObject", order = 9)]
    public sealed class GameObjectVariable : BaseVariable<GameObject>
    {
        public override bool AreValuesEqual(GameObject value) => ReferenceEquals(RuntimeValue, value);

        public override void SetValue(GameObject value)
        {
            base.SetValue(value);
        }

        public override void SetValue(BaseValue value)
        {
            var variable = value as BaseValue<GameObject>;
            base.SetValue(variable.RuntimeValue);
        }
    }
}
