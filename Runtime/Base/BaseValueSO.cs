using Sirenix.OdinInspector;

using UnityEngine;

namespace TalusFramework.Runtime.Base
{
    /// <summary>
    ///     To work with UnityEditor & UnityEvent.
    /// </summary>
    public abstract class BaseValueSO : BaseSO
    { }

    /// <summary>
    ///     Base Variable Class, use RunTimeValue property if u need reference.
    /// </summary>
    /// <typeparam name="TPlainType">Serializable type.</typeparam>
    public class BaseValueSO<TPlainType> : BaseValueSO, ISerializationCallbackReceiver
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