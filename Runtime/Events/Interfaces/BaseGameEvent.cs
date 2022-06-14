using System.Collections.Generic;

using Sirenix.OdinInspector;

using TalusFramework.Base;

namespace TalusFramework.Events.Interfaces
{
    /// <summary>
    ///     Base Void GameEvent
    /// </summary>
    public abstract class BaseGameEvent : BaseEvent, IGameEvent
    {
        private readonly List<IGameEventListener> _Listeners = new List<IGameEventListener>();

        [GUIColor(0f, 1f, 0f)]
        [Button(ButtonSizes.Large), DisableInEditorMode]
        public void Raise()
        {
            for (int i = _Listeners.Count - 1; i >= 0; i--)
            {
                _Listeners[i].Send();
            }

            EventHelper.LogEvent(Logger, $"{name} raised! (Type: Void)");
        }

        public void AddListener(IGameEventListener listener) => EventHelper.AddListener(_Listeners, listener);
        public void RemoveListener(IGameEventListener listener) => EventHelper.RemoveListener(_Listeners, listener);
    }

    /// <summary>
    ///     Base Typed GameEvent
    /// </summary>
    public abstract class BaseGameEvent<T> : BaseEvent, IGameEvent<T>
    {
        private readonly List<IGameEventListener<T>> _Listeners = new List<IGameEventListener<T>>();

        [GUIColor(0f, 1f, 0f)]
        [Button, DisableInEditorMode]
        public void Raise(T parameter)
        {
            for (int i = _Listeners.Count - 1; i >= 0; i--)
            {
                _Listeners[i].Send(parameter);
            }

            EventHelper.LogEvent(Logger, $"{name} raised! (Type: {typeof(T).Name}, Parameter: {parameter})");
        }

        public void AddListener(IGameEventListener<T> listener) => EventHelper.AddListener(_Listeners, listener);
        public void RemoveListener(IGameEventListener<T> listener) => EventHelper.RemoveListener(_Listeners, listener);
    }
}