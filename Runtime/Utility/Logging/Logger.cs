using UnityEngine;

using TalusFramework.Base;

namespace TalusFramework.Utility.Logging
{
    [CreateAssetMenu(fileName = "New Logger", menuName = "Talus/Framework/Logger", order = 0)]
    public class Logger : BaseSO
    {
        [Header("Settings")]
        [SerializeField] private bool _ShowLogs;
        [SerializeField] private string _Prefix;
        [SerializeField] private Color _PrefixColor;

        private string _HexColor;

        private void OnValidate()
        {
            _HexColor = "#" + ColorUtility.ToHtmlStringRGBA(_PrefixColor);
        }

        public void Log(object message, Object sender)
        {
            if (!_ShowLogs) { return; }

            sender.Log($"<color={_HexColor}>{_Prefix}:</color> {message}");
        }

        public void Log(string message)
        {
            Log(message, this);
        }
    }
}
