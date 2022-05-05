using System.Collections.Generic;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Responses.Interfaces;
using TalusFramework.Runtime.Utility.Logging;

using UnityEngine.Events;

namespace TalusFramework.Runtime.Variables.Interfaces
{
    public abstract class BaseVariable<TPlainType> : BaseValue<TPlainType>
    {
        [ToggleGroup("UnityEvents")]
        public bool UnityEvents;

        [ToggleGroup("Responses")]
        public bool Responses;

        [ToggleGroup("UnityEvents")]
        public UnityEvent<TPlainType> OnChangeEvent;

        [ToggleGroup("Responses")]
        [AssetSelector]
        public List<BaseResponse> OnChangeResponses = new List<BaseResponse>();

        public virtual void SetValue(TPlainType value)
        {
            if (RuntimeValue.Equals(value))
            {
                return;
            }

            RuntimeValue = value;
            InvokeOnChangeEvents(value);
        }

        public virtual void SetValue(BaseValue value)
        {
            var variable = value as BaseValue<TPlainType>;

            if (variable == null)
            {
                this.LogError("Type mismatch in " + name + ". Expected type:" + typeof(TPlainType));
                return;
            }

            if (RuntimeValue.Equals(variable.RuntimeValue))
            {
                return;
            }

            RuntimeValue = variable.RuntimeValue;
            InvokeOnChangeEvents(RuntimeValue);
        }

        protected void InvokeOnChangeEvents(TPlainType value)
        {
            if (UnityEvents)
            {
                OnChangeEvent?.Invoke(value);
            }

            if (Responses)
            {
                for (int i = OnChangeResponses.Count - 1; i >= 0; i--)
                {
                    // catch dynamic response
                    var response = OnChangeResponses[i] as Response<TPlainType>;

                    if (response != null)
                    {
                        response.Send(value);
                    }
                    else // catch void responses.
                    {
                        OnChangeResponses[i].Send();
                    }
                }
            }
        }
    }
}