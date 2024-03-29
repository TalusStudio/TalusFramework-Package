﻿using System;

using UnityEngine;

using TalusFramework.References;
using TalusFramework.Variables.Interfaces;

namespace TalusFramework.Variables
{
    [CreateAssetMenu(fileName = "New Vector2 Variable", menuName = "Variables/Vector2", order = 3)]
    public sealed class Vector2Variable : BaseVariable<Vector2>
    {
        public void Add(Vector2Variable variable) => SetValue(RuntimeValue + variable.RuntimeValue);
        public void Add(Vector2 variable) => SetValue(RuntimeValue + variable);

        public void Subtract(Vector2Variable variable) => SetValue(RuntimeValue - variable.RuntimeValue);
        public void Subtract(Vector2 variable) => SetValue(RuntimeValue - variable);

        public void Multiply(FloatVariable variable) => SetValue(RuntimeValue * variable.RuntimeValue);
        public void Multiply(float variable) => SetValue(RuntimeValue * variable);

        public void Divide(FloatVariable variable) => SetValue(RuntimeValue / variable.RuntimeValue);
        public void Divide(float variable) => SetValue(RuntimeValue / variable);

        public static Vector2Variable operator +(Vector2Variable lhs, Vector2Reference rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static Vector2Variable operator +(Vector2Variable lhs, Vector2 rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static Vector2Variable operator -(Vector2Variable lhs, Vector2Reference rhs)
        {
            lhs.Subtract(rhs);
            return lhs;
        }

        public static Vector2Variable operator -(Vector2Variable lhs, Vector2 rhs)
        {
            lhs.Subtract(rhs);
            return lhs;
        }

        public static Vector2Variable operator *(Vector2Variable lhs, float rhs)
        {
            lhs.Multiply(rhs);
            return lhs;
        }

        public static Vector2Variable operator /(Vector2Variable lhs, float rhs)
        {
            if (rhs == 0f)
            {
                throw new DivideByZeroException();
            }

            lhs.Divide(rhs);
            return lhs;
        }
    }
}