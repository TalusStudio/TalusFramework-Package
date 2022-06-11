using UnityEngine;

using Sirenix.OdinInspector;

namespace TalusFramework.Base
{
    /// <summary>
    ///     To work with UnityEditor & UnityEvent.
    /// </summary>
    public abstract class BaseValue : BaseSO
    { }

    /// <summary>
    ///     Base Variable Class, use RunTimeValue property if u need reference.
    /// </summary>
    /// <typeparam name="TPlainType">Serializable type.</typeparam>
    public abstract class BaseValue<TPlainType> : BaseValue
    {
        [LabelWidth(90), DisableInPlayMode]
        [AssetsOnly]
        [SerializeField]
        private TPlainType _Value;
        public TPlainType Value => _Value;

        [LabelWidth(90), DisableInEditorMode]
        [AssetsOnly]
        [SerializeField]
        private TPlainType _RuntimeValue;
        public virtual TPlainType RuntimeValue
        {
            get => _RuntimeValue;
            set => _RuntimeValue = value;
        }

        protected virtual void OnEnable()
        {
            ResetRuntimeValue();
        }

        public virtual void ResetRuntimeValue()
        {
            RuntimeValue = _Value;
        }
    }
}