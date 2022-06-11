using UnityEngine;

using Sirenix.OdinInspector;

namespace TalusFramework.Behaviours.Interfaces
{
    [HideMonoScript]
    public class BaseBehaviour : MonoBehaviour
    {
#pragma warning disable 0414
        [FoldoutGroup("Developer Description")]
        [TextArea(5, 10)]
        [SerializeField]
        [HideLabel]
        private string _DeveloperDescription = default;
#pragma warning restore 0414
    }
}
