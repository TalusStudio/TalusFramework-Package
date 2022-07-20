using UnityEngine;

using TalusFramework.Utility.Logging;

namespace TalusFramework.Base
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
                    _Instance = FindObjectOfType<T>();

                    if (_Instance == null)
                    {
                        IsTemporaryInstance = true;
                        _Instance = new GameObject("Temp Instance of " + typeof(T), typeof(T)).GetComponent<T>();
                        _Instance.Warning("No instance of " + typeof(T) + ", a temporary one is created.");
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

        /// <summary>
        ///     This function is called when the instance is used the first time
        ///     Put all the initializations you need here, as you would do in Awake.
        /// </summary>
        public virtual void Init(bool dontDestroy = true)
        {
            if (dontDestroy)
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        private static T _Instance;
        private static bool _IsInitialized;

        private void Awake()
        {
            if (_Instance == null)
            {
                _Instance = this as T;
            }
            else if (_Instance != this)
            {
                this.Error(GetType() + " singleton is already exist! Destroying self...");
                DestroyImmediate(this);
                return;
            }

            if (!_IsInitialized)
            {
                _IsInitialized = true;
                _Instance.Init();
            }
        }
    }
}