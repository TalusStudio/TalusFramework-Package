using UnityEngine;

using TalusFramework.Utility.Logging;

namespace TalusFramework.Base
{
    public class BaseScriptableSingleton<T> : ScriptableObject where T : ScriptableObject
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                _instance = NullableInstance;

                if (_instance == null)
                {
                    Tlog.Warning($"Type of Singleton_{typeof(T).Name} can not found in resources folder, so creating temporarily in memory!");
                    _instance = CreateInstance<T>();
                }

                return _instance;
            }
        }

        public static T NullableInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load($"Singleton_{typeof(T).Name}") as T;
                }

                return _instance;
            }
        }
    }
}
