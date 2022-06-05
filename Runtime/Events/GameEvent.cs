using System.Collections.Generic;

using Sirenix.OdinInspector;

using TalusFramework.Base;
using TalusFramework.Responses.Interfaces;

using UnityEngine;

using Logger = TalusFramework.Utility.Logging.Logger;

namespace TalusFramework.Events
{
    [CreateAssetMenu]
    public class GameEvent : BaseSO
    {
        [ToggleGroup("Responses")]
        public bool Responses;

        [ToggleGroup("Responses")]
        [HideLabel]
        public List<BaseResponse> GlobalResponses = new List<BaseResponse>();

        [ToggleGroup("Debugging")]
        public bool Debugging;

        [ToggleGroup("Debugging"), LabelWidth(60)]
        [SerializeField, AssetSelector]
        private Logger _Logger;

        public List<GameEventListener> Listeners => _Listeners;

        [GUIColor(1f, 1f, 0.5f), HideInEditorMode]
        [SerializeField, ReadOnly]
        private List<GameEventListener> _Listeners = new List<GameEventListener>();

        public void Raise<T>(T arg)
        {
            if (!Responses) { return; }

            for (int i = GlobalResponses.Count - 1; i >= 0; i--)
            {
                BaseResponse response = GlobalResponses[i];
                var dynamicResponse = response as Response<T>;

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

            RaiseEvent();
        }

        [GUIColor(0f, 1f, 0f)]
        [Button(ButtonSizes.Large), DisableInEditorMode]
        public void Raise()
        {
            if (!Responses) { return; }

            for (int i = GlobalResponses.Count - 1; i >= 0; i--)
            {
                BaseResponse response = GlobalResponses[i];
                response.Send();
            }

            RaiseEvent();
        }

        public void AddListener(GameEventListener listener)
        {
            if (_Listeners.Contains(listener)) { return; }

            _Listeners.Add(listener);
        }

        public void RemoveListener(GameEventListener listener)
        {
            if (!_Listeners.Contains(listener)) { return; }

            _Listeners.Remove(listener);
        }

        private void RaiseEvent()
        {
            for (int i = _Listeners.Count - 1; i >= 0; i--)
            {
                _Listeners[i].OnEventRaised();
            }

            if (Debugging && _Logger != null)
            {
                _Logger.Log(name + " raised!", this);
            }
        }
    }
}