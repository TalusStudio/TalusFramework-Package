using Sirenix.OdinInspector;
using TalusFramework.Runtime.Base;
using UnityEngine;

namespace TalusFramework.Runtime.Constants.Interfaces
{
    public abstract class BaseConstantSO<TPlainType> : BaseSO
    {
        [PropertyOrder(1), HideLabel, LabelWidth(45)]
        [Title("Value", "@ToString()", bold: false)]
        [SerializeField]
        private TPlainType _Value;

        public TPlainType Value => _Value;
    }
}
