using Sirenix.OdinInspector;

using TalusFramework.Runtime.References;

using UnityEngine;

namespace TalusFramework.Runtime.Behaviours
{
    /// <summary>
    ///     Takes a Float Reference and sends its value to an Animator parameter
    ///     every frame on Update.
    /// </summary>
    [HideMonoScript]
    [AddComponentMenu("TalusFramework/Behaviours/AnimatorParameterSetter", 0)]
    public class AnimatorParameterSetter : MonoBehaviour
    {
        public enum AnimatorParameterType
        {
            Bool,
            Float,
            Int,
            Trigger
        }

        [Tooltip("Animator to set parameters on."), LabelWidth(110)]
        [Required]
        public Animator Animator;

        [Tooltip("Name of the parameter to set with the value of Variable."), LabelWidth(95)]
        public StringReference ParameterName;

        [Tooltip("Parameter type."), LabelWidth(100)]
        [EnumToggleButtons]
        [Required]
        public AnimatorParameterType ParameterType = AnimatorParameterType.Float;

        [Tooltip("Variable to read from and send to the Animator as the specified parameter."), LabelWidth(95)]
        [ShowIf("@ParameterType == AnimatorParameterType.Bool")]
        [SerializeField]
        private BoolReference BoolReference;

        [Tooltip("Variable to read from and send to the Animator as the specified parameter."), LabelWidth(95)]
        [ShowIf("@ParameterType == AnimatorParameterType.Float")]
        [SerializeField]
        private FloatReference FloatReference;

        [Tooltip("Variable to read from and send to the Animator as the specified parameter."), LabelWidth(95)]
        [ShowIf("@ParameterType == AnimatorParameterType.Int")]
        [SerializeField]
        private IntReference IntReference;

        /// <summary>
        ///     Animator Hash of ParameterName, automatically generated.
        /// </summary>
        private int parameterHash;

        private void Awake()
        {
            parameterHash = Animator.StringToHash(ParameterName);
        }

        private void Update()
        {
            switch (ParameterType)
            {
                case AnimatorParameterType.Float:
                    Animator.SetFloat(parameterHash, FloatReference.Value);
                    break;

                case AnimatorParameterType.Int:
                    Animator.SetInteger(parameterHash, IntReference.Value);
                    break;

                case AnimatorParameterType.Bool:
                    Animator.SetBool(parameterHash, BoolReference.Value);
                    break;

                case AnimatorParameterType.Trigger:
                    Animator.SetTrigger(parameterHash);
                    break;
            }
        }
    }
}