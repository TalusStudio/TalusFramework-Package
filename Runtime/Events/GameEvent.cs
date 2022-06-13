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
    public class GameEvent : BaseSO, IGameEvent
    {
        [FoldoutGroup("Responses")]
        [HideLabel]
        public List<BaseResponse> GlobalResponses = new List<BaseResponse>();

        [FoldoutGroup("Debugging")]
        [LabelWidth(50)]
        [SerializeField]
        private Logger _Logger;

        public List<IListener> Listeners => _Listeners;
        private readonly List<IListener> _Listeners = new List<IListener>();

        public void Raise<T>(T arg)
        {
            for (int i = GlobalResponses.Count - 1; i >= 0; i--)
            {
                BaseResponse voidResponse = GlobalResponses[i];

                // send dynamics
                var dynamicResponse = voidResponse as Response<T>;
                if (dynamicResponse != null)
                {
                    dynamicResponse.Send(arg);
                    continue;
                }

                // send voids
                voidResponse.Send();
            }

            RaiseEvent();
        }

        [GUIColor(0f, 1f, 0f)]
        [Button(ButtonSizes.Large), DisableInEditorMode]
        public void Raise()
        {
            for (int i = GlobalResponses.Count - 1; i >= 0; i--)
            {
                BaseResponse voidResponse = GlobalResponses[i];
                voidResponse.Send();
            }

            RaiseEvent();
        }

        public void AddListener(IListener listener)
        {
            if (_Listeners.Contains(listener))
            {
                return;
            }

            _Listeners.Add(listener);
        }

        public void RemoveListener(IListener listener)
        {
            if (!_Listeners.Contains(listener))
            {
                return;
            }

            _Listeners.Remove(listener);
        }

        private void RaiseEvent()
        {
            for (int i = _Listeners.Count - 1; i >= 0; i--)
            {
                var listener = _Listeners[i] as IGameEventListener;
                listener.Send();
            }

            if (_Logger != null)
            {
                _Logger.Log(name + " raised!", this);
            }
        }
    }
}