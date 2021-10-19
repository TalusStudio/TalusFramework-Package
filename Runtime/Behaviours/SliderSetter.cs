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

        [Required]
        [LabelWidth(65)]
        public FloatReference Reference;

        private void Update()
        {
            if (Slider != null && Reference != null)
            {
                Slider.value = Reference.Value;
            }
        }
    }
}
