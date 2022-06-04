using System.Diagnostics;

using UnityEngine;

using Debug = UnityEngine.Debug;

namespace TalusFramework.Runtime.Utility.Logging
{
    public static class TLog
    {
        [Conditional("ENABLE_LOGS")]
        public static void Log<T>(this T sender, string msg, LogType logType = LogType.Log) where T : Object
        {
            switch (logType)
            {
                case LogType.Log:
                    Debug.Log(msg, sender);
                    break;

                case LogType.Error:
                    Debug.LogError(msg, sender);
                    break;

                case LogType.Warning:
                    Debug.LogWarning(msg, sender);
                    break;

                case LogType.Assert:
                    Debug.LogAssertion(msg, sender);
                    break;

                case LogType.Exception:
                    Debug.LogError(msg, sender);
                    break;

                default:
                    Debug.Log(msg, sender);
                    break;
            }
        }

        public static void LogError<T>(this T sender, string msg) where T : Object
        {
            Log(sender, msg, LogType.Error);
        }

        public static void LogWarning<T>(this T sender, string msg) where T : Object
        {
            Log(sender, msg, LogType.Warning);
        }
    }
}
