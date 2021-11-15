using Sirenix.OdinInspector;

using TalusFramework.Runtime.Responses.Interfaces;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace TalusFramework.Runtime.Responses
{
    [CreateAssetMenu(fileName = "New Void Response", menuName = "Responses/Void", order = 10)]
    [HideMonoScript]
    public sealed class VoidResponse : BaseResponseSO
    {
        [FormerlySerializedAs("Response")]
        [LabelWidth(85)]
        [SerializeField]
        private UnityEvent _Response;

        [Button(ButtonSizes.Large)] [GUIColor(0f, 1f, 0f)]
        public override void Send() { _Response.Invoke(); }
    }
}
