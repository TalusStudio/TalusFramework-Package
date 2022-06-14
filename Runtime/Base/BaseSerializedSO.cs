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
        [SuffixLabel("@GetType().Name")]
        public Description Description = default;
#endif
    }
}