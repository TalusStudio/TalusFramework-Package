using UnityEngine;
using UnityEngine.UI;

using Sirenix.OdinInspector;

using TalusFramework.References;
using TalusFramework.Behaviours.Interfaces;
using TalusFramework.Utility.Assertions;

namespace TalusFramework.Behaviours
{
    [AddComponentMenu("TalusFramework/Behaviours/Slider Setter", 6)]
    [ExecuteInEditMode]
    public class SliderSetter : BaseBehaviour
    {
        [Required]
        [LabelWidth(80)]
        public Slider Slider;

        [LabelWidth(100)]
        public FloatReference FloatReference;

        protected override void Start()
        {
            this.Assert(Slider != null, "Invalid Reference!", typeof(Slider), null);
        }

        private void Update()
        {
            if (FloatReference != null)
            {
                Slider.value = FloatReference;
            }
        }
    }
}