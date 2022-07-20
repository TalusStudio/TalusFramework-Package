using System.Diagnostics;

using LogType = UnityEngine.LogType;
using Object = UnityEngine.Object;
using Debug = UnityEngine.Debug;

namespace TalusFramework.Utility.Logging
{
    public static class Tlog
    {
        [Conditional("DEVELOPMENT_BUILD")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("TALUS_LOGS")]
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

        public static void Error<T>(this T sender, string message) where T : Object
        {
            sender.Log(message, LogType.Error);
        }

        public static void Warning<T>(this T sender, string message) where T : Object
        {
            sender.Log(message, LogType.Warning);
        }

        public static void Assert<T>(this T sender, string message) where T : Object
        {
            sender.Log(message, LogType.Assert);
        }

        public static void Error(string message) => Debug.LogError(message);
        public static void Warning(string message) => Debug.LogWarning(message);
        public static void Assert(string message) => Debug.LogAssertion(message);
    }
}
