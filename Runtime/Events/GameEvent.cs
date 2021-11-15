using System.Collections.Generic;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Responses;

using UnityEngine;

namespace TalusFramework.Runtime.Events
{
    [HideMonoScript]
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        [PropertyOrder(1)]
        public ToggleableResponses GlobalResponses = new ToggleableResponses();

        [HideInEditorMode]
        [PropertyOrder(2)]
        [PropertySpace]
        [ReadOnly]
        [SerializeField]
        private List<GameEventListener> _GameEventListeners = new List<GameEventListener>();

        public int ListenersCount => _GameEventListeners.Count;

        [PropertySpace]
        [Button(ButtonSizes.Large)] [GUIColor(0, 1, 0)]
        [PropertyOrder(2)]
        [DisableInEditorMode]
        public void Raise()
        {
            if (GlobalResponses.Enabled) { GlobalResponses.SendAll(); }

            for (int i = _GameEventListeners.Count - 1; i >= 0; i--)
            {
                _GameEventListeners[i].OnEventRaised();
            }
        }

        public void AddListener(GameEventListener listener)
        {
            if (!_GameEventListeners.Contains(listener))
            {
                _GameEventListeners.Add(listener);
            }
        }

        public void RemoveListener(GameEventListener listener)
        {
            if (_GameEventListeners.Contains(listener))
            {
                _GameEventListeners.Remove(listener);
            }
        }
    }
}
