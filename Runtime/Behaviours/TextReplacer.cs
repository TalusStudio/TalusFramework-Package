using Sirenix.OdinInspector;
using TalusFramework.Runtime.References;
using UnityEngine;
using UnityEngine.UI;

namespace TalusFramework.Runtime.Behaviours
{
    [HideMonoScript]
    public class TextReplacer : MonoBehaviour
    {
        [Required]
        [LabelWidth(80)]
        public Text Text;

        [Required]
        [LabelWidth(65)]
        public StringReference Reference;

        private void Start()
        {
            Text.text = Reference.Value;
        }

        private void OnEnable()
        {
            Text.text = Reference.Value;
        }
    }
}
