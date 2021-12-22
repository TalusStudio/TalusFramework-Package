using System;

using TalusFramework.Runtime.References;
using TalusFramework.Runtime.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Variables
{
    [CreateAssetMenu(fileName = "New Int Variable", menuName = "Variables/Int", order = 2)]
    public sealed class IntVariableSO : BaseVariableSO<int>
    {
        public void Add(IntVariableSO variable) => SetValue(RuntimeValue + variable.RuntimeValue);
        public void Add(int variable) => SetValue(RuntimeValue + variable);

        public void Subtract(IntVariableSO variable) => SetValue(RuntimeValue - variable.RuntimeValue);
        public void Subtract(int variable) => SetValue(RuntimeValue - variable);

        public void Multiply(IntVariableSO variable) => SetValue(RuntimeValue * variable.RuntimeValue);
        public void Multiply(int variable) => SetValue(RuntimeValue * variable);

        public void Divide(IntVariableSO variable) => SetValue(RuntimeValue / variable.RuntimeValue);
        public void Divide(int variable) => SetValue(RuntimeValue / variable);

        public static IntVariableSO operator +(IntVariableSO lhs, IntReference rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static IntVariableSO operator +(IntVariableSO lhs, int rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static IntVariableSO operator ++(IntVariableSO lhs)
        {
            lhs.Add(lhs);
            return lhs;
        }

        public static IntVariableSO operator -(IntVariableSO lhs, IntReference rhs)
        {
            lhs.Subtract(rhs);
            return lhs;
        }

        public static IntVariableSO operator -(IntVariableSO lhs, int rhs)
        {
            lhs.Subtract(rhs);
            return lhs;
        }

        public static IntVariableSO operator --(IntVariableSO lhs)
        {
            lhs.Subtract(1);
            return lhs;
        }

        public static IntVariableSO operator *(IntVariableSO lhs, IntReference rhs)
        {
            lhs.Multiply(rhs);
            return lhs;
        }

        public static IntVariableSO operator *(IntVariableSO lhs, int rhs)
        {
            lhs.Multiply(rhs);
            return lhs;
        }

        public static IntVariableSO operator /(IntVariableSO lhs, IntReference rhs)
        {
            if (rhs == 0)
            {
                throw new DivideByZeroException();
            }

            lhs.Divide(rhs);
            return lhs;
        }

        public static IntVariableSO operator /(IntVariableSO lhs, int rhs)
        {
            if (rhs == 0)
            {
                throw new DivideByZeroException();
            }

            lhs.Divide(rhs);
            return lhs;
        }

        public static bool operator <=(IntVariableSO lhs, IntReference rhs) => lhs.RuntimeValue <= rhs.Value;
        public static bool operator <=(IntVariableSO lhs, int rhs) => lhs.RuntimeValue <= rhs;

        public static bool operator >=(IntVariableSO lhs, IntReference rhs) => lhs.RuntimeValue >= rhs.Value;
        public static bool operator >=(IntVariableSO lhs, int rhs) => lhs.RuntimeValue >= rhs;

        public static bool operator <(IntVariableSO lhs, IntReference rhs) => lhs.RuntimeValue < rhs.Value;
        public static bool operator <(IntVariableSO lhs, int rhs) => lhs.RuntimeValue < rhs;

        public static bool operator >(IntVariableSO lhs, IntReference rhs) => lhs.RuntimeValue > rhs.Value;
        public static bool operator >(IntVariableSO lhs, int rhs) => lhs.RuntimeValue > rhs;
    }
}