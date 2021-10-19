using Sirenix.OdinInspector;
using TalusFramework.Runtime.Events;
using TalusFramework.Runtime.Utility.Logging;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TalusFramework.Runtime.SceneManagement
{
    /// <summary>
    /// invokes LevelLoadEvent
    /// </summary>
    [HideMonoScript]
    public class SceneLoadListener : MonoBehaviour
    {
        [Required]
        [AssetSelector(DropdownTitle = "Game Events")]
        [LabelWidth(100)]
        [SerializeField]
        private GameEvent _LevelLoadEvent;

        private void OnEnable()
        {
            SceneManager.sceneLoaded += HandleSceneLoad;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= HandleSceneLoad;
        }

        private void HandleSceneLoad(Scene scene, LoadSceneMode loadSceneMode)
        {
            TLog.Log("<color=yellow>SceneListener: " + scene.name + " loaded!</color>");

            _LevelLoadEvent.Raise();
        }
    }
}
