using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;

using TMPro;

using UnityEngine;

namespace TalusFramework.Runtime.Behaviours
{
    [HideMonoScript]
    [AddComponentMenu("TalusFramework/Behaviours/TMPTextReplacer", 8)]
    public class TMPTextReplacer : MonoBehaviour
    {
        [LabelWidth(80)]
        [Required]
        public TMP_Text Text;

        [LabelWidth(65)]
        [AssetSelector, Required]
        public BaseValueSO Value;

        private void Start() => SetText();
        private void OnEnable() => SetText();

        [GUIColor(0f, 1f, 0f)]
        [Button, DisableInEditorMode]
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