using TalusFramework.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Variables
{
    [CreateAssetMenu(fileName = "New Bool Variable", menuName = "Variables/Bool", order = 0)]
    public sealed class BoolVariable : BaseVariable<bool>
    {
        public void Toggle() => SetValue(!RuntimeValue);
    }
}
