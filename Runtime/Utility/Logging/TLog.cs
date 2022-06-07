using UnityEngine;

namespace TalusFramework.Utility.Logging
{
    public static class TLog
    {
        [System.Diagnostics.Conditional("DEVELOPMENT_BUILD")]
        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        public static void Log<T>(this T sender, string message, LogType type = LogType.Log) where T : Object
        {
            switch (type)
            {
                case LogType.Log:
                    Debug.Log(message, sender);
                break;

                case LogType.Error:
                    Debug.LogError(message, sender);
                break;

                case LogType.Warning:
                    Debug.LogWarning(message, sender);
                break;

                case LogType.Assert:
                    Debug.LogAssertion(message, sender);
                break;

                case LogType.Exception:
                    Debug.LogError(message, sender);
                break;

                default:
                    Debug.Log(message, sender);
                break;
            }
        }

        public static void LogError<T>(this T sender, string message) where T : Object
        {
            sender.Log(message, LogType.Error);
        }

        public static void LogWarning<T>(this T sender, string message) where T : Object
        {
            sender.Log(message, LogType.Warning);
        }

        public static void LogAssert<T>(this T sender, string message) where T : Object
        {
            sender.Log(message, LogType.Assert);
        }
    }
}
