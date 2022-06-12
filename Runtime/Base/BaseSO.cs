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
#if UNITY_EDITOR
        public Description Description;
#endif
    }
}
