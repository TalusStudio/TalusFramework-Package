using UnityEngine;

using Sirenix.OdinInspector;

namespace TalusFramework.Runtime.Behaviours.Interfaces
{
    [HideMonoScript]
    public class BaseBehaviour : MonoBehaviour
    {
#pragma warning disable 0414
        [FoldoutGroup("Developer Description")]
        [TextArea(5, 10)]
        [SerializeField]
        private string _DeveloperDescription = "";
#pragma warning restore 0414
    }
}
