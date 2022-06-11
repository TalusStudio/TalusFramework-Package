using System;

using TalusFramework.References;
using TalusFramework.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Variables
{
    [CreateAssetMenu(fileName = "New Vector3 Variable", menuName = "Variables/Vector3", order = 4)]
    public sealed class Vector3Variable : BaseVariable<Vector3>
    {
        public void Add(Vector3Variable variable) => RuntimeValue += variable.RuntimeValue;
        public void Add(Vector3 variable) => RuntimeValue += variable;

        public void Subtract(Vector3Variable variable) => RuntimeValue -= variable.RuntimeValue;
        public void Subtract(Vector3 variable) => RuntimeValue -= variable;

        public void Multiply(FloatVariable variable) => RuntimeValue *= variable.RuntimeValue;
        public void Multiply(float variable) => RuntimeValue *= variable;

        public void Divide(FloatVariable variable) => RuntimeValue /= variable.RuntimeValue;
        public void Divide(float variable) => RuntimeValue /= variable;

        public static Vector3Variable operator +(Vector3Variable lhs, Vector3Reference rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static Vector3Variable operator +(Vector3Variable lhs, Vector3 rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static Vector3Variable operator -(Vector3Variable lhs, Vector3Reference rhs)
        {
            lhs.Subtract(rhs);
            return lhs;
        }

        public static Vector3Variable operator -(Vector3Variable lhs, Vector3 rhs)
        {
            lhs.Subtract(rhs);
            return lhs;
        }

        public static Vector3Variable operator *(Vector3Variable lhs, int rhs)
        {
            lhs.Multiply(rhs);
            return lhs;
        }

        public static Vector3Variable operator /(Vector3Variable lhs, int rhs)
        {
            if (rhs == 0)
            {
                throw new DivideByZeroException();
            }

            lhs.Multiply(rhs);
            return lhs;
        }
    }
}