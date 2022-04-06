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

        [Conditional("ENABLE_LOGS")]
        public static void LogError(string logMsg, Object sender = null)
        {
            Debug.LogError(logMsg, sender);
        }

        [Conditional("ENABLE_LOGS")]
        public static void LogWarning(string logMsg, Object sender = null)
        {
            Debug.LogWarning(logMsg, sender);
        }
    }
}
