using UnityEngine.Events;

using Sirenix.OdinInspector;

using TalusFramework.Base;
using TalusFramework.Utility.Assertions;

namespace TalusFramework.Variables.Interfaces
{
    public abstract class BaseVariable<TPlainType> : BaseValue<TPlainType>
    {
        public override TPlainType RuntimeValue
        {
            get => base.RuntimeValue;
            protected set
            {
                if (base.RuntimeValue != null && base.RuntimeValue.Equals(value)) { return; }

                base.RuntimeValue = value;
                InvokeOnChangeEvents(value);
            }
        }

        [ToggleGroup(nameof(UnityEvents))]
        public bool UnityEvents;

        [ToggleGroup(nameof(UnityEvents))]
        public UnityEvent<TPlainType> OnChangeEvent;

        public virtual void SetValue(TPlainType value)
        {
            RuntimeValue = value;
        }

        public virtual void SetValue(BaseValue value)
        {
            var variable = value as BaseValue<TPlainType>;

            this.Assert(variable != null, $@"Type mismatch in {name}.
                Expected: {typeof(TPlainType)}
                Given: {value.GetType()}"
            );

            RuntimeValue = variable.RuntimeValue;
        }

        protected void InvokeOnChangeEvents(TPlainType value)
        {
            if (!UnityEvents)
            {
                return;
            }

            OnChangeEvent?.Invoke(value);
        }
    }
}