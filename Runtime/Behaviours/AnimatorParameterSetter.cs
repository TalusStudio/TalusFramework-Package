using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.References;
using TalusFramework.Runtime.Behaviours.Interfaces;

namespace TalusFramework.Runtime.Behaviours
{
    /// <summary>
    ///     Takes a Float Reference and sends its value to an Animator parameter
    ///     every frame on Update.
    /// </summary>
    [AddComponentMenu("TalusFramework/Behaviours/AnimatorParameterSetter", 0)]
    public class AnimatorParameterSetter : BaseBehaviour
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
        public BoolReference BoolValue;

        [Tooltip("Variable to read from and send to the Animator as the specified parameter."), LabelWidth(95)]
        [ShowIf("@ParameterType == AnimatorParameterType.Float")]
        [SerializeField]
        public FloatReference FloatValue;

        [Tooltip("Variable to read from and send to the Animator as the specified parameter."), LabelWidth(95)]
        [ShowIf("@ParameterType == AnimatorParameterType.Int")]
        [SerializeField]
        public IntReference IntValue;

        private int _ParameterHash;

        private void Awake()
        {
            _ParameterHash = Animator.StringToHash(ParameterName);
        }

        private void Update()
        {
            switch (ParameterType)
            {
                case AnimatorParameterType.Float:
                    Animator.SetFloat(_ParameterHash, FloatValue);
                    break;

                case AnimatorParameterType.Int:
                    Animator.SetInteger(_ParameterHash, IntValue);
                    break;

                case AnimatorParameterType.Bool:
                    Animator.SetBool(_ParameterHash, BoolValue);
                    break;

                case AnimatorParameterType.Trigger:
                    Animator.SetTrigger(_ParameterHash);
                    break;
            }
        }
    }
}