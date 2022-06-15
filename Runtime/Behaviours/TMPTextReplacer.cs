using UnityEngine;
using TMPro;

using Sirenix.OdinInspector;

using TalusFramework.Base;
using TalusFramework.Behaviours.Interfaces;
using TalusFramework.Utility.Assertions;

namespace TalusFramework.Behaviours
{
    [AddComponentMenu("TalusFramework/Behaviours/TMP Text Replacer", 8)]
    public class TMPTextReplacer : BaseBehaviour
    {
        [LabelWidth(80)]
        [Required]
        public TMP_Text Text;

        [LabelWidth(65)]
        [AssetSelector, Required]
        public BaseValue Value;

        [GUIColor(0f, 1f, 0f)]
        [Button, DisableInEditorMode]
        public void SetText()
        {
            var intValue = Value as BaseValue<int>;
            if (intValue != null)
            {
                Text.text = intValue.RuntimeValue.ToString();
                return;
            }

            var floatValue = Value as BaseValue<float>;
            if (floatValue != null)
            {
                Text.text = floatValue.RuntimeValue.ToString();
                return;
            }

            var stringValue = Value as BaseValue<string>;
            if (stringValue != null)
            {
                Text.text = stringValue.RuntimeValue;
            }
        }

        private void Awake()
        {
            this.Assert(Text != null, "Invalid Reference!", typeof(TMP_Text), null);
        }

        protected override void OnEnable()
        {
            SetText();
        }

        private void Start()
        {
            SetText();
        }
    }
}