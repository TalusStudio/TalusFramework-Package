﻿using System.Collections.Generic;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Responses.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Events
{
    [CreateAssetMenu]
    public class GameEvent : BaseSO
    {
        [ToggleGroup("Responses")]
        public bool Responses;

        [ToggleGroup("Responses")]
        [PropertyOrder(1)]
        public List<BaseResponseSO> GlobalResponses = new List<BaseResponseSO>();

        [HideInEditorMode]
        [PropertyOrder(2)]
        [PropertySpace]
        [ReadOnly]
        [SerializeField]
        private List<GameEventListener> _GameEventListeners = new List<GameEventListener>();

        public int ListenersCount => _GameEventListeners.Count;

        public void Raise<T>(T arg)
        {
            for (int i = GlobalResponses.Count - 1; i >= 0; i--)
            {
                BaseResponseSO response = GlobalResponses[i];
                var dynamicResponse = response as ResponseSO<T>;

                // capture dynamic responses.
                if (dynamicResponse != null)
                {
                    dynamicResponse.Send(arg);
                }
                else // capture void responses.
                {
                    response.Send();
                }
            }

            for (int i = _GameEventListeners.Count - 1; i >= 0; i--)
            {
                _GameEventListeners[i].OnEventRaised();
            }
        }

        public void Raise()
        {
            for (int i = GlobalResponses.Count - 1; i >= 0; i--)
            {
                BaseResponseSO response = GlobalResponses[i];
                response.Send();
            }

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
