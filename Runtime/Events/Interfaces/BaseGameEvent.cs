using System.Collections.Generic;

using Sirenix.OdinInspector;

using TalusFramework.Base;
using Logger = TalusFramework.Utility.Logging.Logger;

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

            EventUtility.LogEvent(Logger, $"{name} raised!");
        }

        public void AddListener(IGameEventListener listener) => EventUtility.AddListener(_Listeners, listener);
        public void RemoveListener(IGameEventListener listener) => EventUtility.RemoveListener(_Listeners, listener);
    }

    /// <summary>
    ///     Base Typed GameEvent
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
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

            EventUtility.LogEvent(Logger, $"{name} raised!");
        }

        public void AddListener(IGameEventListener<T> listener) => EventUtility.AddListener(_Listeners, listener);
        public void RemoveListener(IGameEventListener<T> listener) => EventUtility.RemoveListener(_Listeners, listener);
    }

    /// <summary>
    ///     Helper class to populate listeners
    /// </summary>
    internal class EventUtility
    {
        public static void AddListener<TContainer, TListener>(TContainer container, TListener listener)
            where TContainer : ICollection<TListener>
        {
            if (container.Contains(listener))
            {
                return;
            }

            container.Add(listener);
        }

        public static void RemoveListener<TContainer, TListener>(TContainer container, TListener listener)
            where TContainer : ICollection<TListener>
        {
            if (!container.Contains(listener))
            {
                return;
            }

            container.Remove(listener);
        }

        public static void LogEvent<T>(T logger, string message) where T : Logger
        {
            if (logger == null)
            {
                return;
            }

            logger.Log(message);
        }
    }
}