using Sirenix.OdinInspector;
using TalusFramework.Runtime.References;
using TalusFramework.Runtime.Variables;
using UnityEngine;
using UnityEngine.UI;

namespace TalusFramework.Runtime.Behaviours
{
    [ExecuteInEditMode]
    [HideMonoScript]
    public class SliderSetter : MonoBehaviour
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
                Slider.value = FloatReference.Value;
            }
        }
    }
}
