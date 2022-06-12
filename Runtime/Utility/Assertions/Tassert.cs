using System.Diagnostics;

using UnityEngine;

using Object = UnityEngine.Object;
using Debug = UnityEngine.Debug;

namespace TalusFramework.Utility.Assertions
{
    public static class Tassert
    {
        [Conditional("DEVELOPMENT_BUILD")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("TALUS_ASSERTS")]
        public static void Assert(bool condition, string message, Object context = null)
        {
            Debug.Assert(condition, message, context);
        }

        public static void Assert<T>(this T sender, bool condition, string message) where T : Object
        {
            Assert(condition, message, sender);

#if UNITY_EDITOR
            if (!condition)
            {
                UnityEditor.EditorApplication.isPaused = Application.isEditor && !Application.isBatchMode;
            }
#endif
        }
    }
}
