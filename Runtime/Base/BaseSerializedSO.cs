using Sirenix.OdinInspector;

using UnityEngine;

namespace TalusFramework.Runtime.Base
{
    /// <summary>
    ///     Base class for Odin Serialized Scriptable Objects in Talus Framework.
    /// </summary>
    [HideMonoScript]
    public abstract class BaseSerializedSO : SerializedScriptableObject
    {
#pragma warning disable 0414
        [HideLabel, PropertyOrder(0), FoldoutGroup("Developer Description")]
        [TextArea(5, 10)]
        [SerializeField]
        private string _DeveloperDescription = "";
#pragma warning restore 0414
    }
}