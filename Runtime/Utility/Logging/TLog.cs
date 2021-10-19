using UnityEngine;

namespace TalusFramework.Runtime.Utility.Logging
{
    public static class TLog
    {
        //[System.Diagnostics.Conditional("ENABLE_LOGS")]
        public static void Log(string logMsg, LogType logType = LogType.Log)
        {
            switch (logType)
            {
                case LogType.Log:
                    Debug.Log(logMsg);
                    break;
                case LogType.Error:
                    Debug.LogError(logMsg);
                    break;
                case LogType.Warning:
                    Debug.LogWarning(logMsg);
                    break;
                case LogType.Assert:
                    Debug.LogAssertion(logMsg);
                    break;
                case LogType.Exception:
                    Debug.LogError(logMsg);
                    break;
                default:
                    Debug.Log(logMsg);
                    break;
            }
        }
    }
}
