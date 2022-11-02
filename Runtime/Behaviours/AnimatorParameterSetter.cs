using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.References;
using TalusFramework.Behaviours.Interfaces;
using TalusFramework.Utility.Assertions;

namespace TalusFramework.Behaviours
{
    /// <summary>
    ///     Takes a reference and sends its value to an Animator parameter
    ///     every frame on Update.
    /// </summary>
    [AddComponentMenu("TalusFramework/Behaviours/Animator Parameter Setter", 0)]
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
        public BoolReference BoolValue;

        [Tooltip("Variable to read from and send to the Animator as the specified parameter."), LabelWidth(95)]
        [ShowIf("@ParameterType == AnimatorParameterType.Float")]
        public FloatReference FloatValue;

        [Tooltip("Variable to read from and send to the Animator as the specified parameter."), LabelWidth(95)]
        [ShowIf("@ParameterType == AnimatorParameterType.Int")]
        public IntReference IntValue;

        private int _ParameterHash;

        protected override void Awake()
        {
            _ParameterHash = Animator.StringToHash(ParameterName.Value);
        }
        
        private void Update()
        {
            switch (ParameterType)
            {
                case AnimatorParameterType.Float:
                    Animator.SetFloat(_ParameterHash, FloatValue.Value);
                break;

                case AnimatorParameterType.Int:
                    Animator.SetInteger(_ParameterHash, IntValue.Value);
                break;

                case AnimatorParameterType.Bool:
                    Animator.SetBool(_ParameterHash, BoolValue.Value);
                break;

                case AnimatorParameterType.Trigger:
                    Animator.SetTrigger(_ParameterHash);
                break;
            }
        }
    }
}