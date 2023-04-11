using System.Collections.Generic;

using UnityEngine.Events;

using TalusFramework.Utility.Logging;

namespace TalusFramework.Events
{
    /// <summary>
    ///     Helper class to populate listeners
    /// </summary>
    public static class EventHelper
    {
        public static void AddListener<TContainer, TListener>(TContainer container, TListener listener)
            where TContainer : ICollection<TListener>
        {
            if (!container.Contains(listener))
            {
                container.Add(listener);
            }
        }

        public static void RemoveListener<TContainer, TListener>(TContainer container, TListener listener)
            where TContainer : ICollection<TListener>
        {
            if (container.Contains(listener))
            {
                container.Remove(listener);
            }
        }

        public static void LogEvent<T>(T logger, string message) where T : Logger
        {
            if (logger != null)
            {
                logger.Log(message);
            }
        }

        // To inform the developer when broken event target exists.
        public static bool IsValidEvent<T>(T response) where T : UnityEventBase
        {
            int badReferenceCount = 0;
            for (int i = 0; i < response.GetPersistentEventCount(); i++)
            {
                if (response.GetPersistentTarget(i) != null) { continue; }
                ++badReferenceCount;
            }

            return badReferenceCount == 0;
        }
    }
}
