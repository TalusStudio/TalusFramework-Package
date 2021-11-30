using System;

using TalusFramework.Runtime.References;
using TalusFramework.Runtime.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Variables
{
    [CreateAssetMenu(fileName = "New Float Variable", menuName = "Variables/Float", order = 1)]
    public sealed class FloatVariableSO : BaseVariableSO<float>
    {
        public void Add(FloatVariableSO variable) => SetValue(RuntimeValue + variable.RuntimeValue);
        public void Add(float variable) => SetValue(RuntimeValue + variable);

        public void Subtract(FloatVariableSO variable) => SetValue(RuntimeValue - variable.RuntimeValue);
        public void Subtract(float variable) => SetValue(RuntimeValue - variable);

        public void Multiply(FloatVariableSO variable) => SetValue(RuntimeValue * variable.RuntimeValue);
        public void Multiply(float variable) => SetValue(RuntimeValue * variable);

        public void Divide(FloatVariableSO variable) => SetValue(RuntimeValue / variable.RuntimeValue);
        public void Divide(float variable) => SetValue(RuntimeValue / variable);

        public static FloatVariableSO operator +(FloatVariableSO lhs, FloatReference rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static FloatVariableSO operator +(FloatVariableSO lhs, float rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static FloatVariableSO operator -(FloatVariableSO lhs, FloatReference rhs)
        {
            lhs.Subtract(rhs);
            return lhs;
        }

        public static FloatVariableSO operator -(FloatVariableSO lhs, float rhs)
        {
            lhs.Subtract(rhs);
            return lhs;
        }

        public static FloatVariableSO operator *(FloatVariableSO lhs, FloatReference rhs)
        {
            lhs.Multiply(rhs);
            return lhs;
        }

        public static FloatVariableSO operator *(FloatVariableSO lhs, float rhs)
        {
            lhs.Multiply(rhs);
            return lhs;
        }

        public static FloatVariableSO operator /(FloatVariableSO lhs, FloatReference rhs)
        {
            if (rhs == 0f)
            {
                throw new DivideByZeroException();
            }

            lhs.Divide(rhs);
            return lhs;
        }

        public static FloatVariableSO operator /(FloatVariableSO lhs, float rhs)
        {
            if (rhs == 0f)
            {
                throw new DivideByZeroException();
            }

            lhs.Divide(rhs);
            return lhs;
        }

        public static bool operator <=(FloatVariableSO lhs, FloatReference rhs) => lhs.RuntimeValue <= rhs.Value;
        public static bool operator <=(FloatVariableSO lhs, float rhs) => lhs.RuntimeValue <= rhs;

        public static bool operator >=(FloatVariableSO lhs, FloatReference rhs) => lhs.RuntimeValue >= rhs.Value;
        public static bool operator >=(FloatVariableSO lhs, float rhs) => lhs.RuntimeValue >= rhs;

        public static bool operator <(FloatVariableSO lhs, FloatReference rhs) => lhs.RuntimeValue < rhs.Value;
        public static bool operator <(FloatVariableSO lhs, float rhs) => lhs.RuntimeValue < rhs;

        public static bool operator >(FloatVariableSO lhs, FloatReference rhs) => lhs.RuntimeValue > rhs.Value;
        public static bool operator >(FloatVariableSO lhs, float rhs) => lhs.RuntimeValue > rhs;
    }
}
