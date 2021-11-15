using Sirenix.OdinInspector;

using TalusFramework.Runtime.Events;
using TalusFramework.Runtime.References;
using TalusFramework.Runtime.Responses;
using TalusFramework.Runtime.Utility.Logging;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace TalusFramework.Runtime.SceneManagement
{
    /// <summary>
    ///     Send Level Load Response to Update Current Level Index() and Raise Level Load Event.
    /// </summary>
    [HideMonoScript]
    public class SceneLoadListener : MonoBehaviour
    {
        [LabelWidth(130)]
        [AssetSelector]
        [Required]
        [SerializeField]
        private IntResponse _LevelLoadResponse;

        [LabelWidth(130)]
        [AssetSelector]
        [Required]
        [SerializeField]
        private GameEvent _LevelLoadEvent;

        [LabelWidth(128)]
        public BoolReference Debug;

        private void OnEnable() => SceneManager.sceneLoaded += HandleSceneLoad;
        private void OnDisable() => SceneManager.sceneLoaded -= HandleSceneLoad;

        private void HandleSceneLoad(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (Debug)
            {
                TLog.Log("<color=yellow>SceneListener: " + scene.name + " loaded!</color>");
            }

            _LevelLoadResponse.Send(scene.buildIndex);
            _LevelLoadEvent.Raise();
        }
    }
}
