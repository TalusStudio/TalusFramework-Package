using System.Collections.Generic;
using Sirenix.OdinInspector;
using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Utility;
using UnityEngine;

namespace TalusFramework.Runtime.Events
{
    [CreateAssetMenu]
    [HideMonoScript]
    public class GameEvent : BaseSO
    {
        [ReadOnly]
        [HideInEditorMode]
        [SerializeField]
        [PropertyOrder(2)]
        [PropertySpace]
        private List<GameEventListener> _gameEventListeners = new List<GameEventListener>();
        
        [PropertyOrder(1)]
        public ToggleableEvent GlobalCallback;

        [PropertySpace]
        [Button(ButtonSizes.Large), GUIColor(0, 1, 0)]
        [PropertyOrder(2)]
        [DisableInEditorMode]
        public void Raise()
        {
            for (int i = _gameEventListeners.Count - 1; i >= 0; i--)
            {
                _gameEventListeners[i].OnEventRaised();
            }

            if (GlobalCallback.Enabled)
            {
                GlobalCallback.Response?.Invoke();
            }
        }

        public void AddListener(GameEventListener gameEventListener)
        {
            if (!_gameEventListeners.Contains(gameEventListener))
            {
                _gameEventListeners.Add(gameEventListener);
            }
        }

        public void RemoveListener(GameEventListener gameEventListener)
        {
            if (_gameEventListeners.Contains(gameEventListener))
            {
                _gameEventListeners.Remove(gameEventListener);
            }
        }
    }
}
