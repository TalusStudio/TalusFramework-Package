using System.Collections.Generic;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Responses.Interfaces;

using UnityEngine;

using Logger = TalusFramework.Runtime.Utility.Logging.Logger;

namespace TalusFramework.Runtime.Events
{
    /// <summary>
    ///     Be careful about execution.
    /// </summary>
    [CreateAssetMenu]
    public class GameEvent : BaseSO
    {
#if UNITY_EDITOR
        [ToggleGroup("Responses")]
        public bool Responses;
#endif

        [ToggleGroup("Responses")]
        [PropertyOrder(1)]
        public List<BaseResponse> GlobalResponses = new List<BaseResponse>();

        [HideInEditorMode]
        [PropertyOrder(2)]
        [PropertySpace]
        [ReadOnly]
        [SerializeField]
        private List<GameEventListener> _Listeners = new List<GameEventListener>();
        public List<GameEventListener> Listeners => _Listeners;

        [FoldoutGroup("Debugging")]
        [SerializeField]
        private Logger _Logger;
        
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
                else
                {
                    // capture void responses.
                    response.Send(); 
                }
            }

            for (int i = _Listeners.Count - 1; i >= 0; i--)
            {
                _Listeners[i].OnEventRaised();
            }

            if (_Logger != null)
            {
                _Logger.Log(name + " raised!", this);
            }
        }

        [Button, DisableInEditorMode]
        public void Raise()
        {
            for (int i = GlobalResponses.Count - 1; i >= 0; i--)
            {
                BaseResponse response = GlobalResponses[i];
                response.Send();
            }

            for (int i = _Listeners.Count - 1; i >= 0; i--)
            {
                _Listeners[i].OnEventRaised();
            }

            if (_Logger != null)
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