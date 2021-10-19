using Sirenix.OdinInspector;
using TalusFramework.Runtime.Sets;
using UnityEngine;

namespace TalusFramework.Runtime.Behaviours
{
    [HideMonoScript]
    public class Thing : MonoBehaviour
    {
        [Required]
        [LabelWidth(75)]
        public ThingRuntimeSet RuntimeSet;

        private void OnEnable()
        {
            RuntimeSet.Add(this);
        }

        private void OnDisable()
        {
            RuntimeSet.Remove(this);
        }
    }
}
