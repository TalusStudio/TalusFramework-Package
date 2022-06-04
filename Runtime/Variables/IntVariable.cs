using System;

using TalusFramework.Runtime.References;
using TalusFramework.Runtime.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Variables
{
    [CreateAssetMenu(fileName = "New Int Variable", menuName = "Variables/Int", order = 2)]
    public sealed class IntVariable : BaseVariable<int>
    {
        public void Add(IntVariable variable) => SetValue(RuntimeValue + variable.RuntimeValue);
        public void Add(int variable) => SetValue(RuntimeValue + variable);

        public void Subtract(IntVariable variable) => SetValue(RuntimeValue - variable.RuntimeValue);
        public void Subtract(int variable) => SetValue(RuntimeValue - variable);

        public void Multiply(IntVariable variable) => SetValue(RuntimeValue * variable.RuntimeValue);
        public void Multiply(int variable) => SetValue(RuntimeValue * variable);

        public void Divide(IntVariable variable) => SetValue(RuntimeValue / variable.RuntimeValue);
        public void Divide(int variable) => SetValue(RuntimeValue / variable);

        public static IntVariable operator +(IntVariable lhs, IntReference rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static IntVariable operator +(IntVariable lhs, int rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static IntVariable operator ++(IntVariable lhs)
        {
            lhs.Add(1);
            return lhs;
        }

        public static IntVariable operator -(IntVariable lhs, IntReference rhs)
        {
            lhs.Subtract(rhs);
            return lhs;
        }

        public static IntVariable operator -(IntVariable lhs, int rhs)
        {
            lhs.Subtract(rhs);
            return lhs;
        }

        public static IntVariable operator --(IntVariable lhs)
        {
            lhs.Subtract(1);
            return lhs;
        }

        public static IntVariable operator *(IntVariable lhs, IntReference rhs)
        {
            lhs.Multiply(rhs);
            return lhs;
        }

        public static IntVariable operator *(IntVariable lhs, int rhs)
        {
            lhs.Multiply(rhs);
            return lhs;
        }

        public static IntVariable operator /(IntVariable lhs, IntReference rhs)
        {
            if (rhs == 0)
            {
                throw new DivideByZeroException();
            }

            lhs.Divide(rhs);
            return lhs;
        }

        public static IntVariable operator /(IntVariable lhs, int rhs)
        {
            if (rhs == 0)
            {
                throw new DivideByZeroException();
            }

            lhs.Divide(rhs);
            return lhs;
        }

        public static bool operator <=(IntVariable lhs, IntReference rhs) => lhs.RuntimeValue <= rhs.Value;
        public static bool operator <=(IntVariable lhs, int rhs) => lhs.RuntimeValue <= rhs;

        public static bool operator >=(IntVariable lhs, IntReference rhs) => lhs.RuntimeValue >= rhs.Value;
        public static bool operator >=(IntVariable lhs, int rhs) => lhs.RuntimeValue >= rhs;

        public static bool operator <(IntVariable lhs, IntReference rhs) => lhs.RuntimeValue < rhs.Value;
        public static bool operator <(IntVariable lhs, int rhs) => lhs.RuntimeValue < rhs;

        public static bool operator >(IntVariable lhs, IntReference rhs) => lhs.RuntimeValue > rhs.Value;
        public static bool operator >(IntVariable lhs, int rhs) => lhs.RuntimeValue > rhs;
    }
}