using TalusFramework.Runtime.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Variables
{
    [CreateAssetMenu(fileName = "New Bool Variable", menuName = "Variables/Bool", order = 0)]
    public sealed class BoolVariable : BaseVariable<bool>
    {
        public void Toggle() => SetValue(!RuntimeValue);
    }
}
