using UnityEngine;
using TMPro;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;

namespace TalusFramework.Runtime.Behaviours
{
    [HideMonoScript]
    public class TMPTextReplacer : MonoBehaviour
    {
        [Required]
        [LabelWidth(80)]
        public TMP_Text Text;

        [LabelWidth(65)]
        [AssetSelector]
        public BaseValueSO Value;

        private void Start() => SetText();
        private void OnEnable() => SetText();

        private void SetText()
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
                return;
            }
        }
    }
}
