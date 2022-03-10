﻿using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Utility.Logging;

using UnityEngine;

namespace TalusFramework.Runtime.References.Interfaces
{
    // Can't get property drawer to work with generic arguments
    public abstract class BaseReference
    { }

    [System.Serializable]
    public class BaseReference<TPlainType> : BaseReference
    {
        [SerializeField]
        private bool UseConstant = true;

        [SerializeField]
        private TPlainType ConstantValue;

        [SerializeField]
        private BaseValue Variable;

        public BaseReference()
        { }

        public BaseReference(bool useConst)
        {
            UseConstant = useConst;
        }

        public TPlainType Value
        {
            get
            {
                if (UseConstant)
                {
                    return ConstantValue;
                }

                var value = Variable as BaseValue<TPlainType>;
                if (value != null)
                {
                    return value.RuntimeValue;
                }

                TLog.Log("Type mismatch in " + Variable.name + " reference, expected: " + typeof(TPlainType), Variable, LogType.Error);
                return default;
            }
        }

        public override string ToString() => Value.ToString();
    }
}