using UnityEngine;

using TalusFramework.References;
using TalusFramework.Variables.Interfaces;

namespace TalusFramework.Variables
{
    [CreateAssetMenu(fileName = "New String Variable", menuName = "Variables/String", order = 5)]
    public sealed class StringVariable : BaseVariable<string>
    {
        public void Add(StringVariable variable) => SetValue(RuntimeValue + variable.RuntimeValue);
        public void Add(string variable) => SetValue(RuntimeValue + variable);

        public static StringVariable operator +(StringVariable lhs, StringReference rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static StringVariable operator +(StringVariable lhs, string rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }
    }
}