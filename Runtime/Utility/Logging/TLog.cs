using System.Diagnostics;

using UnityEngine;

using Debug = UnityEngine.Debug;

namespace TalusFramework.Runtime.Utility.Logging
{
    public static class TLog
    {
        [Conditional("ENABLE_LOGS")]
        public static void Log(string logMsg, Object sender = null, LogType logType = LogType.Log)
        {
            switch (logType)
            {
                case LogType.Log:
                    Debug.Log(logMsg, sender);
                    break;

                case LogType.Error:
                    Debug.LogError(logMsg, sender);
                    break;

                case LogType.Warning:
                    Debug.LogWarning(logMsg, sender);
                    break;

                case LogType.Assert:
                    Debug.LogAssertion(logMsg, sender);
                    break;

                case LogType.Exception:
                    Debug.LogError(logMsg, sender);
                    break;

                default:
                    Debug.Log(logMsg, sender);
                    break;
            }
        }

        public static void Log(this GameObject obj, string logMsg)
        {
            Log(logMsg, obj);
        }

        public static void Log(this ScriptableObject obj, string logMsg)
        {
            Log(logMsg, obj);
        }

        [Conditional("ENABLE_LOGS")]
        public static void LogError(string logMsg, Object sender = null)
        {
            Debug.LogError(logMsg, sender);
        }

        public static void LogError(this GameObject obj, string logMsg)
        {
            LogError(logMsg, obj);
        }

        public static void LogError(this ScriptableObject obj, string logMsg)
        {
            LogError(logMsg, obj);
        }

        [Conditional("ENABLE_LOGS")]
        public static void LogWarning(string logMsg, Object sender = null)
        {
            Debug.LogWarning(logMsg, sender);
        }

        public static void LogWarning(this GameObject obj, string logMsg)
        {
            LogWarning(logMsg, obj);
        }

        public static void LogWarning(this ScriptableObject obj, string logMsg)
        {
            LogWarning(logMsg, obj);
        }
    }
}
