using Sirenix.OdinInspector;
using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Constants.Interfaces;
using TalusFramework.Runtime.Utility;
using UnityEngine;

namespace TalusFramework.Runtime.Variables.Interfaces
{
    public abstract class BaseVariableSO<TPlainType, TVariableType, TConstantType> : BaseSO, ISerializationCallbackReceiver
        where TVariableType : BaseVariableSO<TPlainType, TVariableType, TConstantType>
        where TConstantType : BaseConstantSO<TPlainType>
    {
        [HideInPlayMode]
        [PropertyOrder(1)]
        [LabelWidth(45)]
        [Title("Value", "@ToString()", bold: false)]
        [HideLabel]
        [SerializeField]
        private TPlainType _Value;

        [HideInEditorMode]
        [PropertyOrder(1)]
        [LabelWidth(45)]
        [Title("Value", "@ToString()", bold: false)]
        [HideLabel]
        [SerializeField]
        private TPlainType _RuntimeValue;

        public TPlainType Value => _RuntimeValue;

        [PropertySpace]
        [PropertyOrder(2)]
        [HorizontalGroup(1f)]
        public ToggleableEvent OnChangeEvent = new ToggleableEvent();

        public void SetValue(TPlainType value)
        {
            if (_RuntimeValue.Equals(value)) { return; }

            _RuntimeValue = value;

            if (OnChangeEvent.Enabled)
            {
                OnChangeEvent.Response.Invoke();
            }
        }

        public void SetValue(TVariableType value)
        {
            if (_RuntimeValue.Equals(value.Value)) { return; }

            _RuntimeValue = value.Value;

            if (OnChangeEvent.Enabled)
            {
                OnChangeEvent.Response.Invoke();
            }
        }

        public void SetValue(TConstantType value)
        {
            if (_RuntimeValue.Equals(value.Value)) { return; }

            _RuntimeValue = value.Value;

            if (OnChangeEvent.Enabled)
            {
                OnChangeEvent.Response.Invoke();
            }
        }

        public void OnBeforeSerialize()
        { }

        public void OnAfterDeserialize()
        {
            _RuntimeValue = _Value;
        }

        public override string ToString() => typeof(TPlainType).ToString();
    }
}
