using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;

using UnityEngine;
using UnityEngine.UI;

namespace TalusFramework.Runtime.Behaviours
{
    [HideMonoScript]
    public class TextReplacer : MonoBehaviour
    {
        [LabelWidth(80)]
        [Required]
        public Text Text;

        [LabelWidth(65)]
        [AssetSelector, Required]
        public BaseValueSO Value;

        private void Start() => SetText();
        private void OnEnable() => SetText();

        public void SetText()
        {
            var intValue = Value as BaseValueSO<int>;

            if (intValue != null)
            {
                Text.text = intValue.RuntimeValue.ToString();
                return;
            }

            var floatValue = Value as BaseValueSO<float>;

            if (floatValue != null)
            {
                Text.text = floatValue.RuntimeValue.ToString();
                return;
            }

            var stringValue = Value as BaseValueSO<string>;

            if (stringValue != null)
            {
                Text.text = stringValue.RuntimeValue;
            }
        }
    }
}