using Sirenix.OdinInspector;

using TalusFramework.Responses.Interfaces;

using UnityEngine;
using UnityEngine.Events;

namespace TalusFramework.Responses
{
    [CreateAssetMenu(fileName = "New Void Response", menuName = "Responses/Void", order = 0)]
    public sealed class VoidResponse : BaseResponse
    {
        [LabelWidth(85)]
        [SerializeField]
        private UnityEvent _Response;

        [GUIColor(0f, 1f, 0f)]
        [Button(ButtonSizes.Large), DisableInEditorMode]
        public override void Send() => _Response?.Invoke();
    }
}