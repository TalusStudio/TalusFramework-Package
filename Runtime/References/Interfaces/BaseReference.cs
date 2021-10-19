using TalusFramework.Runtime.Constants.Interfaces;
using TalusFramework.Runtime.Variables.Interfaces;
using UnityEngine;

namespace TalusFramework.Runtime.References.Interfaces
{
    // Can't get property drawer to work with generic arguments
    public abstract class BaseReference
    { }

    // priority order
    // PlainReference > ConstantReference > VariableReference
    [System.Serializable]
    public class BaseReference<TPlainType, TVariableType, TConstantType> : BaseReference
        where TVariableType : BaseVariableSO<TPlainType, TVariableType, TConstantType>
        where TConstantType : BaseConstantSO<TPlainType>
    {
        [SerializeField]
        private bool UsePlain;

        [SerializeField]
        private bool UseConstant;

        [SerializeField]
        private TPlainType PlainValue;
        
        [SerializeField]
        private TConstantType ConstantValue;

        [SerializeField]
        private TVariableType Variable;
        
        public BaseReference()
        { }

        public BaseReference(bool useConst)
        {
            UseConstant = useConst;
        }

        public TPlainType Value => UsePlain ? PlainValue : UseConstant ? ConstantValue.Value : Variable.Value;
    }
}
