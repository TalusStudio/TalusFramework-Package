using TalusFramework.Runtime.References;
using TalusFramework.Runtime.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Variables
{
    [CreateAssetMenu(fileName = "New String Variable", menuName = "Variables/String", order = 3)]
    public sealed class StringVariableSO : BaseVariableSO<string>
    {
        public void Add(StringVariableSO variable) => SetValue(RuntimeValue + variable.RuntimeValue);
        public void Add(string variable) => SetValue(RuntimeValue + variable);

        public static StringVariableSO operator +(StringVariableSO lhs, StringReference rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static StringVariableSO operator +(StringVariableSO lhs, string rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }
    }
}
