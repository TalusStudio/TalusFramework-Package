using System.Collections.Generic;

using Sirenix.OdinInspector;

using TalusFramework.Base;

namespace TalusFramework.Events.Interfaces
{
    /// <summary>
    ///     Base Void GameEvent
    /// </summary>
    public abstract class BaseGameEvent : BaseSO, IGameEvent
    {
        private readonly List<IGameEventListener> _Listeners = new List<IGameEventListener>();

        [Button]
        public void Raise()
        {
            for (int i = _Listeners.Count - 1; i >= 0; i--)
            {
                _Listeners[i].Send();
            }
        }

        public void AddListener(IGameEventListener listener) => EventUtility.AddListener(_Listeners, listener);
        public void RemoveListener(IGameEventListener listener) => EventUtility.RemoveListener(_Listeners, listener);
    }

    /// <summary>
    ///     Base Typed GameEvent
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public abstract class BaseGameEvent<T> : BaseSO, IGameEvent<T>
    {
        private readonly List<IGameEventListener<T>> _Listeners = new List<IGameEventListener<T>>();

        [Button]
        public void Raise(T parameter)
        {
            for (int i = _Listeners.Count - 1; i >= 0; i--)
            {
                _Listeners[i].Send(parameter);
            }
        }

        public void AddListener(IGameEventListener<T> listener) => EventUtility.AddListener(_Listeners, listener);
        public void RemoveListener(IGameEventListener<T> listener) => EventUtility.RemoveListener(_Listeners, listener);
    }

    /// <summary>
    ///     Helper class to populate listeners
    /// </summary>
    public class EventUtility
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
    }
}