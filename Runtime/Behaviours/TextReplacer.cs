using UnityEngine;
using UnityEngine.UI;

using Sirenix.OdinInspector;

using TalusFramework.Base;
using TalusFramework.Behaviours.Interfaces;
using TalusFramework.Utility.Assertions;

namespace TalusFramework.Behaviours
{
    [AddComponentMenu("TalusFramework/Behaviours/Text Replacer", 7)]
    public class TextReplacer : BaseBehaviour
    {
        [LabelWidth(80)]
        [Required]
        public Text Text;

        [LabelWidth(65)]
        [Required]
        public BaseValue Value;

        [GUIColor(0f, 1f, 0f)]
        [Button, DisableInEditorMode]
        public void SetText()
        {
            Text.text = Value.ToString();
        }

        protected override void Awake()
        {
            this.Assert(Text != null, "Invalid Reference!", typeof(Text), null);
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