using UnityEngine;

using TalusFramework.Variables.Interfaces;

namespace TalusFramework.References.Interfaces
{
    public abstract class BaseReference
    { }

    [System.Serializable]
    public class BaseReference<TPlainType, TVariableType> : BaseReference
        where TVariableType : BaseVariable<TPlainType>
    {
        [SerializeField]
        private bool UseConstant = true;

        [SerializeField]
        private TPlainType ConstantValue;

        [SerializeField]
        private TVariableType Variable;

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

                return Variable.RuntimeValue;
            }
        }

        public static implicit operator TPlainType(BaseReference<TPlainType, TVariableType> reference)
        {
            return reference.Value;
        }
    }
}