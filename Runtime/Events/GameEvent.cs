using System.Collections.Generic;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Responses.Interfaces;

using UnityEngine;

using Logger = TalusFramework.Runtime.Utility.Logging.Logger;

namespace TalusFramework.Runtime.Events
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
            if (Responses)
            {
                for (int i = GlobalResponses.Count - 1; i >= 0; i--)
                {
                    BaseResponse response = GlobalResponses[i];
                    var dynamicResponse = response as Response<T>;

                    if (dynamicResponse != null) // capture dynamic responses.
                    {
                        dynamicResponse.Send(arg);
                    }
                    else // capture void responses.
                    {
                        response.Send();
                    }
                }
            }

            for (int i = _Listeners.Count - 1; i >= 0; i--)
            {
                _Listeners[i].OnEventRaised();
            }

            if (Debugging && _Logger != null)
            {
                _Logger.Log(name + " raised!", this);
            }
        }

        [GUIColor(0f, 1f, 0f)]
        [Button(ButtonSizes.Large), DisableInEditorMode]
        public void Raise()
        {
            if (Responses)
            {
                for (int i = GlobalResponses.Count - 1; i >= 0; i--)
                {
                    BaseResponse response = GlobalResponses[i];
                    response.Send();
                }
            }

            for (int i = _Listeners.Count - 1; i >= 0; i--)
            {
                _Listeners[i].OnEventRaised();
            }

            if (Debugging && _Logger != null)
            {
                _Logger.Log(name + " raised!", this);
            }
        }

        public void AddListener(GameEventListener listener)
        {
            if (_Listeners.Contains(listener))
            {
                return;
            }

            _Listeners.Add(listener);
        }

        public void RemoveListener(GameEventListener listener)
        {
            if (!_Listeners.Contains(listener))
            {
                return;
            }

            _Listeners.Remove(listener);
        }
    }
}