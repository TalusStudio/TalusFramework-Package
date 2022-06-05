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
    public class BaseValue<TPlainType> : BaseValue, ISerializationCallbackReceiver
    {
        [DisableInPlayMode]
        [OnValueChanged("@RuntimeValue = _Value")]
        [AssetsOnly]
        [SerializeField]
        private TPlainType _Value;

        [DisableInEditorMode]
        [AssetsOnly]
        [SerializeField]
        private TPlainType _RuntimeValue;
        public TPlainType RuntimeValue
        {
            get => _RuntimeValue;
            protected set => _RuntimeValue = value;
        }

        public virtual void OnBeforeSerialize()
        { }

        public virtual void OnAfterDeserialize()
        {
            RuntimeValue = _Value;
        }
    }
}