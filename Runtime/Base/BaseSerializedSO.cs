using Sirenix.OdinInspector;

namespace TalusFramework.Base
{
    /// <summary>
    ///     Base class for Odin Serialized Scriptable Objects in Talus Framework.
    /// </summary>
    [HideMonoScript]
    public abstract class BaseSerializedSO : SerializedScriptableObject
    {
#if UNITY_EDITOR
        public Description Description = default;
#endif
    }
}