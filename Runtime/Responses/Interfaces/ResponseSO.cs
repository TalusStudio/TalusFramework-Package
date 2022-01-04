using Sirenix.OdinInspector;

using TalusFramework.Runtime.References.Interfaces;

using UnityEngine;
using UnityEngine.Events;

namespace TalusFramework.Runtime.Responses.Interfaces
{
    public abstract class ResponseSO<T> : BaseResponseSO<T>
    {
        [LabelWidth(90)]
        [SerializeField]
        private BaseReference<T> _StaticArgument;

        [SerializeField]
        private UnityEvent<T> _Response;

        protected override BaseReference<T> Argument => _StaticArgument;

        [FoldoutGroup("Debugging")]
        [BoxGroup("Debugging/Invoke with Dynamic Parameter(function parameter)")]
        [Button, DisableInEditorMode]
        public override void Send(T argument)
        {
            _Response?.Invoke(argument);
        }

        [FoldoutGroup("Debugging")]
        [BoxGroup("Debugging/Invoke with Static Parameter")]
        [Button, DisableInEditorMode]
        public override void Send()
        {
            Send(Argument.Value);
        }
    }
}