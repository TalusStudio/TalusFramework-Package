using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Base;
using TalusFramework.Events.Interfaces;
using TalusFramework.Responses.Interfaces;
using Logger = TalusFramework.Utility.Logging.Logger;

namespace TalusFramework.Events
{
    [CreateAssetMenu]
    public class GameEvent : BaseSO
    {
        [FoldoutGroup("Responses")]
        [HideLabel]
        public List<BaseResponse> GlobalResponses = new List<BaseResponse>();

        [FoldoutGroup("Debugging")]
        [LabelWidth(50)]
        [SerializeField]
        private Logger _Logger;

        public List<IGameEventListener> Listeners => _Listeners;
        private readonly List<IGameEventListener> _Listeners = new List<IGameEventListener>();

        public void Raise<T>(T arg)
        {
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
            for (int i = GlobalResponses.Count - 1; i >= 0; i--)
            {
                BaseResponse response = GlobalResponses[i];
                response.Send();
            }

            RaiseEvent();
        }

        public void AddListener(IGameEventListener listener)
        {
            if (_Listeners.Contains(listener)) { return; }

            _Listeners.Add(listener);
        }

        public void RemoveListener(IGameEventListener listener)
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

            if (_Logger != null)
            {
                _Logger.Log(name + " raised!", this);
            }
        }
    }
}