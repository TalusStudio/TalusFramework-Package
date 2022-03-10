using TalusFramework.Runtime.Utility.Logging;

using UnityEngine;

namespace TalusFramework.Runtime.Base
{
    /// <summary>
    ///     Generic Singleton for MonoBehaviours.
    /// </summary>
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        public static bool IsTemporaryInstance { private set; get; }

        public static T Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = FindObjectOfType(typeof(T)) as T;

                    if (_Instance == null)
                    {
                        IsTemporaryInstance = true;
                        _Instance = new GameObject("Temp Instance of " + typeof(T), typeof(T)).GetComponent<T>();
                        TLog.Log("No instance of " + typeof(T) + ", a temporary one is created.", _Instance, LogType.Warning);

                        // Problem during the creation, this should not happen
                        if (_Instance == null)
                        {
                            TLog.Log("Problem during the creation of " + typeof(T), null, LogType.Error);
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

        private static T _Instance;

        private static bool _IsInitialized;


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
                TLog.Log("Another instance of " + GetType() + " is already exist! Destroying self...", this, LogType.Error);
                DestroyImmediate(this);
                return;
            }

            if (!_IsInitialized)
            {
                _IsInitialized = true;
                _Instance.Init();
            }
        }

        private void OnApplicationQuit()
        {
            _Instance = null;
        }


        /// <summary>
        ///     This function is called when the instance is used the first time
        ///     Put all the initializations you need here, as you would do in Awake
        /// </summary>
        public virtual void Init(bool dontDestroy = true)
        {
            if (dontDestroy)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}