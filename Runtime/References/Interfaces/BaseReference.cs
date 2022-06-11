using UnityEngine;

using TalusFramework.Base;
using TalusFramework.Utility.Assertions;

namespace TalusFramework.References.Interfaces
{
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

                Variable.Assert(Variable != null, $"{GetType()} value is null!");

                var value = Variable as BaseValue<TPlainType>;
                Variable.Assert(value != null, $@"Type mismatch in {Variable.name} reference.
                    Expected: {typeof(TPlainType)}
                    Given: {Variable.GetType()}"
                );

                return value.RuntimeValue;
            }
        }
    }
}