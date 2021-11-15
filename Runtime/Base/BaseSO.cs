using Sirenix.OdinInspector;

using UnityEngine;
using UnityEngine.Serialization;

// (disable "assigned but never used" warning)
#pragma warning disable 414

namespace TalusFramework.Runtime.Base
{
    /// <summary>
    ///     Base class for Scriptable Objects in Talus Framework.
    /// </summary>
    public abstract class BaseSO : ScriptableObject
    {
        [PropertyOrder(0), FoldoutGroup("Developer Description")]
        [HideLabel]
        [TextArea(5, 10)]
        [FormerlySerializedAs("DeveloperDescription")]
        [SerializeField]
        private string _DeveloperDescription = "";
    }
}
