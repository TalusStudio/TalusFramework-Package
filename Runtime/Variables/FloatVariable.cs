using System;

using TalusFramework.Runtime.References;
using TalusFramework.Runtime.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Variables
{
    [CreateAssetMenu(fileName = "New Float Variable", menuName = "Variables/Float", order = 1)]
    public sealed class FloatVariable : BaseVariable<float>
    {
        public void Add(FloatVariable variable) => RuntimeValue += variable.RuntimeValue;
        public void Add(float variable) => RuntimeValue += variable;

        public void Subtract(FloatVariable variable) => RuntimeValue -= variable.RuntimeValue;
        public void Subtract(float variable) => RuntimeValue -= variable;

        public void Multiply(FloatVariable variable) => RuntimeValue *= variable.RuntimeValue;
        public void Multiply(float variable) => RuntimeValue *= variable;

        public void Divide(FloatVariable variable) => RuntimeValue /= variable.RuntimeValue;
        public void Divide(float variable) => RuntimeValue /= variable;

        public static FloatVariable operator +(FloatVariable lhs, FloatReference rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static FloatVariable operator +(FloatVariable lhs, float rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static FloatVariable operator -(FloatVariable lhs, FloatReference rhs)
        {
            lhs.Subtract(rhs);
            return lhs;
        }

        public static FloatVariable operator -(FloatVariable lhs, float rhs)
        {
            lhs.Subtract(rhs);
            return lhs;
        }

        public static FloatVariable operator *(FloatVariable lhs, FloatReference rhs)
        {
            lhs.Multiply(rhs);
            return lhs;
        }

        public static FloatVariable operator *(FloatVariable lhs, float rhs)
        {
            lhs.Multiply(rhs);
            return lhs;
        }

        public static FloatVariable operator /(FloatVariable lhs, FloatReference rhs)
        {
            if (rhs == 0f)
            {
                throw new DivideByZeroException();
            }

            lhs.Divide(rhs);
            return lhs;
        }

        public static FloatVariable operator /(FloatVariable lhs, float rhs)
        {
            if (rhs == 0f)
            {
                throw new DivideByZeroException();
            }

            lhs.Divide(rhs);
            return lhs;
        }

        public static bool operator <=(FloatVariable lhs, FloatReference rhs) => lhs.RuntimeValue <= rhs.Value;
        public static bool operator <=(FloatVariable lhs, float rhs) => lhs.RuntimeValue <= rhs;

        public static bool operator >=(FloatVariable lhs, FloatReference rhs) => lhs.RuntimeValue >= rhs.Value;
        public static bool operator >=(FloatVariable lhs, float rhs) => lhs.RuntimeValue >= rhs;

        public static bool operator <(FloatVariable lhs, FloatReference rhs) => lhs.RuntimeValue < rhs.Value;
        public static bool operator <(FloatVariable lhs, float rhs) => lhs.RuntimeValue < rhs;

        public static bool operator >(FloatVariable lhs, FloatReference rhs) => lhs.RuntimeValue > rhs.Value;
        public static bool operator >(FloatVariable lhs, float rhs) => lhs.RuntimeValue > rhs;
    }
}