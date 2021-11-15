using Sirenix.OdinInspector;

using TalusFramework.Runtime.References.Interfaces;

using UnityEngine;
using UnityEngine.Events;

namespace TalusFramework.Runtime.Responses.Interfaces
{
    public class ResponseSO<T> : BaseResponseSO<T>
    {
#if UNITY_EDITOR
        [FoldoutGroup("Arguments")]
        [ToggleLeft]
        public bool UseDynamicArgument;
#endif

        /// <summary>
        /// </summary>
        [FoldoutGroup("Arguments")]
        [ShowIf("@UseDynamicArgument == false")]
        [LabelWidth(60)]
        [SerializeField]
        private BaseReference<T> _Argument;

        /// <summary>
        /// </summary>
        [SerializeField]
        private UnityEvent<T> _Response;

        protected override BaseReference<T> Argument => _Argument;

        /// <summary>
        /// </summary>
        /// <param name="argument"></param>
        public override void Send(T argument) => _Response.Invoke(argument);

        /// <summary>
        /// </summary>
        [DisableInEditorMode]
        [Button(ButtonSizes.Small, ButtonStyle.CompactBox)] [GUIColor(1f, 1f, 0f)]
        [LabelText("Dynamic Context")]
        public override void Send() => Send(Argument.Value);
    }
}
