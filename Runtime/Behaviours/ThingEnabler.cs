using Sirenix.OdinInspector;
using UnityEngine;

namespace TalusFramework.Runtime.Behaviours
{
    [HideMonoScript]
    public class ThingEnabler : MonoBehaviour
    {
        [Required]
        [LabelWidth(45)]
        public Thing Thing;

        public void Enable()
        {
            Thing.gameObject.SetActive(true);
        }
    }
}
