using UnityEngine;

using Sirenix.OdinInspector;

namespace TalusFramework.Base
{
    /// <summary>
    ///     Base class for Scriptable Objects in Talus Framework.
    /// </summary>
    [HideMonoScript]
    public abstract class BaseSO : ScriptableObject
    {
#pragma warning disable 0414
        [HideLabel, PropertyOrder(0), FoldoutGroup("Developer Description")]
        [TextArea(5, 10)]
        [SerializeField]
        private string _DeveloperDescription = default;
#pragma warning restore 0414
    }
}
