using TalusFramework.Runtime.Utility.Logging;

using UnityEngine;

namespace TalusFramework.Runtime.Base
{
    /// <summary>
    ///     Generic Singleton for MonoBehaviours.
    /// </summary>
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _Instance;

        private static bool _IsInitialized;

        public static T Instance
        {
            get
            {
                // Instance required for the first time, we look for it
                if (_Instance == null)
                {
                    _Instance = FindObjectOfType(typeof(T)) as T;

                    // Object not found, we create a temporary one
                    if (_Instance == null)
                    {
                        TLog.Log("No instance of " + typeof(T) + ", a temporary one is created.", LogType.Warning);

                        IsTemporaryInstance = true;
                        _Instance = new GameObject("Temp Instance of " + typeof(T), typeof(T)).GetComponent<T>();

                        // Problem during the creation, this should not happen
                        if (_Instance == null)
                        {
                            TLog.Log("Problem during the creation of " + typeof(T), LogType.Error);
                        }
                    }

                    if (!_IsInitialized)
                    {
                        _IsInitialized = true;
                        _Instance.Init();
                    }
                }

                return _Instance;
            }
        }

        public static bool IsTemporaryInstance { private set; get; }

        // If no other monobehaviour request the instance in an awake function
        // executing before this one, no need to search the object.
        private void Awake()
        {
            if (_Instance == null)
            {
                _Instance = this as T;
            }
            else if (_Instance != this)
            {
                TLog.Log("Another instance of " + GetType() + " is already exist! Destroying self...", LogType.Error);
                DestroyImmediate(this);
                return;
            }

            if (!_IsInitialized)
            {
                DontDestroyOnLoad(gameObject);
                _IsInitialized = true;
                _Instance.Init();
            }
        }

        /// Make sure the instance isn't referenced anymore when the user quit, just in case.
        private void OnApplicationQuit()
        {
            _Instance = null;
        }


        /// <summary>
        ///     This function is called when the instance is used the first time
        ///     Put all the initializations you need here, as you would do in Awake
        /// </summary>
        public virtual void Init() { }
    }
}
