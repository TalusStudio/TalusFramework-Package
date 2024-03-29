﻿using System;

using UnityEngine;

using TalusFramework.References;
using TalusFramework.Variables.Interfaces;

namespace TalusFramework.Variables
{
    [CreateAssetMenu(fileName = "New Float Variable", menuName = "Variables/Float", order = 2)]
    public sealed class FloatVariable : BaseVariable<float>
    {
        public override bool AreValuesEqual(float value) => Mathf.Approximately(RuntimeValue, value);

        public void Add(FloatVariable variable) => SetValue(RuntimeValue + variable.RuntimeValue);
        public void Add(float variable) => SetValue(RuntimeValue + variable);

        public void Subtract(FloatVariable variable) => SetValue(RuntimeValue - variable.RuntimeValue);
        public void Subtract(float variable) => SetValue(RuntimeValue - variable);

        public void Multiply(FloatVariable variable) => SetValue(RuntimeValue * variable.RuntimeValue);
        public void Multiply(float variable) => SetValue(RuntimeValue * variable);

        public void Divide(FloatVariable variable) => SetValue(RuntimeValue / variable.RuntimeValue);
        public void Divide(float variable) => SetValue(RuntimeValue / variable);

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

        public static FloatVariable operator ++(FloatVariable lhs)
        {
            lhs.Add(1.0f);
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

        public static FloatVariable operator --(FloatVariable lhs)
        {
            lhs.Subtract(1.0f);
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