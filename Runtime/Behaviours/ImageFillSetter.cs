using UnityEngine;
using UnityEngine.UI;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.References;
using TalusFramework.Runtime.Behaviours.Interfaces;

namespace TalusFramework.Runtime.Behaviours
{
    [AddComponentMenu("TalusFramework/Behaviours/ImageFillSetter", 4)]
    public class ImageFillSetter : BaseBehaviour
    {
        [Tooltip("Image to set the fill amount on.")] [LabelWidth(65)]
        [Required]
        public Image Image;

        [Tooltip("Value to use as the current ")] [LabelWidth(50)]
        public FloatReference Variable;

        [Tooltip("Min value that Variable to have no fill on Image.")] [LabelWidth(50)]
        public FloatReference Min;

        [Tooltip("Max value that Variable can be to fill Image.")] [LabelWidth(50)]
        public FloatReference Max;

        private void Update()
        {
            Image.fillAmount = Mathf.Clamp01(Mathf.InverseLerp(Min, Max, Variable));
        }
    }
}