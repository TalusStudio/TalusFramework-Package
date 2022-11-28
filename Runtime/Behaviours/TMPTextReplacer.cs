using UnityEngine;
using TMPro;

using Sirenix.OdinInspector;

using TalusFramework.Base;
using TalusFramework.Behaviours.Interfaces;

namespace TalusFramework.Behaviours
{
    [AddComponentMenu("TalusFramework/Behaviours/TMP Text Replacer", 8)]
    public class TMPTextReplacer : BaseBehaviour
    {
        [LabelWidth(80)]
        [Required]
        public TMP_Text Text;

        [LabelWidth(65)]
        [Required]
        public BaseValue Value;

        [GUIColor(0f, 1f, 0f), Button]
        public void SetText()
        {
            Text.text = Value.ToString();
        }

        protected override void OnEnable()
        {
            SetText();
        }

        protected override void Start()
        {
            SetText();
        }
    }
}