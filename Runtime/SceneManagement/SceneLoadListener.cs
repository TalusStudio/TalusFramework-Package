using Sirenix.OdinInspector;

using TalusFramework.Runtime.Events;
using TalusFramework.Runtime.Utility.Logging;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace TalusFramework.Runtime.SceneManagement
{
    [HideMonoScript]
    public class SceneLoadListener : MonoBehaviour
    {
        [LabelWidth(100)]
        [AssetSelector, Required]
        [SerializeField]
        public GameEvent LevelLoadEvent;

        private void OnEnable() => SceneManager.sceneLoaded += HandleSceneLoad;
        private void OnDisable() => SceneManager.sceneLoaded -= HandleSceneLoad;

        private void HandleSceneLoad(Scene scene, LoadSceneMode loadSceneMode)
        {
            TLog.Log("<color=yellow>SceneListener: " + scene.name + " loaded!</color>");
            LevelLoadEvent.Raise(scene.name);
        }
    }
}