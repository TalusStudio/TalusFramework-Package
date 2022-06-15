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

                Tassert.Assert(Variable != null, $"Invalid Variable Reference on {GetType().Name}!", typeof(BaseValue), null);

                var value = Variable as BaseValue<TPlainType>;
                Tassert.Assert(value != null, $"Type mismatch on Variable Reference! (Current Reference: {Variable.name})",
                    typeof(TPlainType),
                    Variable.GetType());

                return value.RuntimeValue;
            }
        }
    }
}