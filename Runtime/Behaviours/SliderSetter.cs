using UnityEngine;
using UnityEngine.UI;

using Sirenix.OdinInspector;

using TalusFramework.References;
using TalusFramework.Behaviours.Interfaces;
using TalusFramework.Utility.Assertions;

namespace TalusFramework.Behaviours
{
    [AddComponentMenu("TalusFramework/Behaviours/Slider Setter", 6)]
    public class SliderSetter : BaseBehaviour
    {
        [Required]
        [LabelWidth(80)]
        public Slider Slider;

        [LabelWidth(100)]
        public FloatReference FloatReference;

        [LabelWidth(100)]
        public FloatReference Smoothing;

        protected override void Start()
        {
            this.Assert(Slider != null, "Invalid Reference!", typeof(Slider), null);
        }

        private void Update()
        {
            if (FloatReference != null)
            {
                Slider.value = Mathf.Lerp(Slider.value, FloatReference, Smoothing);
            }
        }
    }
}
