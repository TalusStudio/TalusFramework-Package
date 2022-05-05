using UnityEngine;

using TalusFramework.Runtime.Base;

namespace TalusFramework.Runtime.Utility.Logging
{
    [CreateAssetMenu]
    public class Logger : BaseSO
    {
        [Header("Settings")]
        [SerializeField]
        private bool _ShowLogs;

        [SerializeField]
        private string _Prefix;

        [SerializeField]
        private Color _PrefixColor;

        private string _HexColor;

        private void OnValidate()
        {
            _HexColor = "#" + ColorUtility.ToHtmlStringRGBA(_PrefixColor);
        }

        public void Log(object message, Object sender)
        {
            if (!_ShowLogs) { return; }

            TLog.Log($"<color={_HexColor}>{_Prefix}: {message}</color>", sender);
        }

        public void Log(string message)
        {
            Log(message, this);
        }
    }
}
