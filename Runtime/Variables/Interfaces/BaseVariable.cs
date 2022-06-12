using System.Collections.Generic;

using Sirenix.OdinInspector;

using TalusFramework.Base;
using TalusFramework.Responses.Interfaces;
using TalusFramework.Utility.Assertions;

using UnityEngine.Events;

namespace TalusFramework.Variables.Interfaces
{
    public abstract class BaseVariable<TPlainType> : BaseValue<TPlainType>
    {
        public override TPlainType RuntimeValue
        {
            get => base.RuntimeValue;
            set
            {
                if (base.RuntimeValue != null && base.RuntimeValue.Equals(value)) { return; }

                base.RuntimeValue = value;
                InvokeOnChangeEvents(value);
            }
        }

        [ToggleGroup("UnityEvents")]
        public bool UnityEvents;

        [ToggleGroup("Responses")]
        public bool Responses;

        [ToggleGroup("UnityEvents")]
        public UnityEvent<TPlainType> OnChangeEvent;

        [ToggleGroup("Responses")]
        public List<BaseResponse> OnChangeResponses = new List<BaseResponse>();

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
            if (UnityEvents)
            {
                OnChangeEvent?.Invoke(value);
            }

            if (!Responses) { return; }

            for (int i = OnChangeResponses.Count - 1; i >= 0; i--)
            {
                var responseReference = OnChangeResponses[i];
                this.Assert(responseReference != null, "There is an invalid response reference!");

                // catch -> dynamic response
                var response = responseReference as Response<TPlainType>;
                if (response != null)
                {
                    response.Send(value);
                    continue;
                }

                // catch -> void response
                responseReference.Send();
            }
        }
    }
}