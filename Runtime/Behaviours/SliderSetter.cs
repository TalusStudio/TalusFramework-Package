using UnityEngine;
using UnityEngine.UI;

using Sirenix.OdinInspector;

using TalusFramework.References;
using TalusFramework.Behaviours.Interfaces;

namespace TalusFramework.Behaviours
{
    [AddComponentMenu("TalusFramework/Behaviours/SliderSetter", 6)]
    [ExecuteInEditMode]
    public class SliderSetter : BaseBehaviour
    {
        [Required]
        [LabelWidth(80)]
        public Slider Slider;

        [LabelWidth(100)]
        public FloatReference FloatReference;

        private void Update()
        {
            if (Slider != null && FloatReference != null)
            {
                Slider.value = FloatReference;
            }
        }
    }
}