using Sirenix.OdinInspector;

using TalusFramework.Runtime.Responses.Interfaces;

using UnityEngine;
using UnityEngine.Events;

namespace TalusFramework.Runtime.Responses
{
    [CreateAssetMenu(fileName = "New Void Response", menuName = "Responses/Void", order = 10)]
    public sealed class VoidResponse : BaseResponse
    {
        [LabelWidth(85)]
        [SerializeField]
        private UnityEvent _Response;

        [Button, DisableInEditorMode]
        public override void Send() => _Response?.Invoke();
    }
}