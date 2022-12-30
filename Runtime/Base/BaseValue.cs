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
        [DisableInPlayMode]
        [LabelWidth(90)]
        [SerializeField]
        [OnValueChanged(nameof(ResetRuntimeValue))]
        private TPlainType _Value = default;
        public TPlainType Value => _Value;

        [LabelWidth(90)]
        [SerializeField]
        [HideDuplicateReferenceBox]
        private TPlainType _RuntimeValue = default;
        public virtual TPlainType RuntimeValue
        {
            get => _RuntimeValue;
            protected set => _RuntimeValue = value;
        }

        protected virtual void OnEnable()
        {
            ResetRuntimeValue();
        }

        public virtual void ResetRuntimeValue()
        {
            RuntimeValue = Value;
        }

        public virtual bool AreValuesEqual(TPlainType value) => RuntimeValue.Equals(value);

        public override string ToString()
        {
            return RuntimeValue.ToString();
        }
    }
}