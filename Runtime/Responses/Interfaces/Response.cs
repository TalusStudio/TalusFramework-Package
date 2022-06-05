using Sirenix.OdinInspector;

using TalusFramework.References.Interfaces;

using UnityEngine;
using UnityEngine.Events;

namespace TalusFramework.Responses.Interfaces
{
    public abstract class Response<T> : BaseResponse<T>
    {
        [BoxGroup]
        [LabelWidth(90)]
        [SerializeField]
        private BaseReference<T> _StaticArgument;

        [SerializeField]
        private UnityEvent<T> _Response;

        protected override BaseReference<T> Argument => _StaticArgument;

        [FoldoutGroup("Debugging")]
        [Button("Send (dynamic parameter)"), DisableInEditorMode]
        public override void Send(T argument)
        {
            _Response?.Invoke(argument);
        }

        [FoldoutGroup("Debugging")]
        [Button("Send (static parameter)"), DisableInEditorMode]
        public override void Send()
        {
            Send(Argument.Value);
        }
    }
}