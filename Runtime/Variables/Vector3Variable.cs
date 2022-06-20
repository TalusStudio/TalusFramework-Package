using System;

using UnityEngine;

using TalusFramework.References;
using TalusFramework.Variables.Interfaces;

namespace TalusFramework.Variables
{
    [CreateAssetMenu(fileName = "New Vector3 Variable", menuName = "Variables/Vector3", order = 4)]
    public sealed class Vector3Variable : BaseVariable<Vector3>
    {
        public void Add(Vector3Variable variable) => SetValue(RuntimeValue + variable.RuntimeValue);
        public void Add(Vector3 variable) => SetValue(RuntimeValue + variable);

        public void Subtract(Vector3Variable variable) => SetValue(RuntimeValue - variable.RuntimeValue);
        public void Subtract(Vector3 variable) => SetValue(RuntimeValue - variable);

        public void Multiply(FloatVariable variable) => SetValue(RuntimeValue * variable.RuntimeValue);
        public void Multiply(float variable) => SetValue(RuntimeValue * variable);

        public void Divide(FloatVariable variable) => SetValue(RuntimeValue / variable.RuntimeValue);
        public void Divide(float variable) => SetValue(RuntimeValue / variable);

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

        public static Vector3Variable operator *(Vector3Variable lhs, float rhs)
        {
            lhs.Multiply(rhs);
            return lhs;
        }

        public static Vector3Variable operator /(Vector3Variable lhs, float rhs)
        {
            if (rhs == 0f)
            {
                throw new DivideByZeroException();
            }

            lhs.Multiply(rhs);
            return lhs;
        }
    }
}