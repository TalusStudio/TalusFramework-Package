using Sirenix.OdinInspector;
using TalusFramework.Runtime.References;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TalusFramework.Runtime.Behaviours
{
    [HideMonoScript]
    public class TextReplacer : MonoBehaviour
    {
        [Required]
        [LabelWidth(80)]
        public Text Text;

		[LabelWidth(65)]
        public StringReference StringReference;

        private void Start()
        {
            Text.text = StringReference.Value;
        }

        private void OnEnable()
        {
            Text.text = StringReference.Value;
        }
    }
}
