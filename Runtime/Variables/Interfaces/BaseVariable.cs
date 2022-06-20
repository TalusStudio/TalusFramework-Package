using UnityEngine.Events;

using Sirenix.OdinInspector;

using TalusFramework.Base;
using TalusFramework.Utility.Assertions;

namespace TalusFramework.Variables.Interfaces
{
    public abstract class BaseVariable<TPlainType> : BaseValue<TPlainType>
    {
        [ToggleGroup(nameof(UnityEvents))] public bool UnityEvents;
        [ToggleGroup(nameof(UnityEvents))] public UnityEvent<TPlainType> OnChangeEvent;

        public virtual void SetValue(TPlainType value)
        {
            if (AreValuesEqual(value)) { return; }

            RuntimeValue = value;
            InvokeOnChangeEvents(value);
        }

        public virtual void SetValue(BaseValue value)
        {
            var variable = value as BaseValue<TPlainType>;

            this.Assert(variable != null, $@"Type mismatch in {name}.
                Expected: {typeof(TPlainType)}
                Given: {value.GetType()}"
            );

            SetValue(variable.RuntimeValue);
        }

        protected void InvokeOnChangeEvents(TPlainType value)
        {
            if (!UnityEvents) { return; }

            OnChangeEvent?.Invoke(value);
        }
    }
}