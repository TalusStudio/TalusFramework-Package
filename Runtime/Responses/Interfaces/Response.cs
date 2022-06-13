using Sirenix.OdinInspector;

using UnityEngine;
using UnityEngine.Events;

namespace TalusFramework.Responses.Interfaces
{
    public abstract class Response<T> : BaseResponse<T>
    {
        [SerializeField]
        private UnityEvent<T> _Response;

        [DisableInEditorMode]
        [Button("Send")]
        public override void Send(T argument)
        {
            _Response?.Invoke(argument);
        }
    }
}