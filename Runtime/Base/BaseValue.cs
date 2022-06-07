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
        [AssetsOnly]
        [SerializeField]
        [LabelWidth(90)]
        private TPlainType _Value;
        public TPlainType Value => _Value;

        [DisableInEditorMode]
        [AssetsOnly]
        [SerializeField]
        [LabelWidth(90)]
        private TPlainType _RuntimeValue;
        public TPlainType RuntimeValue
        {
            get => _RuntimeValue;
            protected set => _RuntimeValue = value;
        }

        protected virtual void OnEnable()
        {
            ResetValueAfterDeserialize();
        }

        public virtual void ResetValueAfterDeserialize()
        {
            RuntimeValue = _Value;
        }
    }
}