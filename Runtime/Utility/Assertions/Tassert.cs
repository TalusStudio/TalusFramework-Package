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
        public static void Assert(bool condition, string message, Object context = null)
        {
            Debug.Assert(condition, $"Assertion Failed: {message}", context);
        }

        public static void Assert(bool condition, string message, System.Type expected, System.Type given, Object context = null)
        {
            string givenType = (given == null) ? "Null" : given.Name;
            Assert(condition, @$"<b><color=yellow>{message}</color></b>
                    Expected: <b><color=green>{expected.Name}</color></b>
                    Given: <b><color=red>{givenType}</color></b>"
            );
        }

        public static void Assert<T>(this T sender, bool condition, string message, System.Type expected, System.Type given)
            where T : Object
        {
            string givenType = (given == null) ? "Null" : given.Name;
            Assert(sender, condition, @$"<b><color=yellow>{message}</color></b> (<b><color=cyan>{sender.name}</color></b>)
                    Expected: <b><color=green>{expected.Name}</color></b>
                    Given: <b><color=red>{givenType}</color></b>"
            );
        }

        public static void Assert<T>(this T sender, bool condition, string message) where T : Object
        {
            Assert(condition, message, sender);

#if UNITY_EDITOR
            if (condition) { return; }

            bool pauseEditor = !Application.isBatchMode && Application.isPlaying && Application.isEditor;
            UnityEditor.EditorApplication.isPaused = pauseEditor;
#endif
        }
    }
}
