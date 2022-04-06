using Sirenix.OdinInspector;

using TalusFramework.Runtime.Events;

using UnityEngine;
using UnityEngine.SceneManagement;

using Logger = TalusFramework.Runtime.Utility.Logging.Logger;

namespace TalusFramework.Runtime.SceneManagement
{
    [HideMonoScript]
    public class SceneLoadListener : MonoBehaviour
    {
        [LabelWidth(100)]
        [AssetSelector, Required]
        [SerializeField]
        public GameEvent LevelLoadEvent;

        [FoldoutGroup("Debugging")]
        [LabelWidth(45)]
        [AssetSelector, Required]
        [SerializeField]
        private Logger _Logger;

        private void OnEnable() => SceneManager.sceneLoaded += HandleSceneLoad;
        private void OnDisable() => SceneManager.sceneLoaded -= HandleSceneLoad;

        private void HandleSceneLoad(Scene scene, LoadSceneMode loadSceneMode)
        {
            _Logger.Log(scene.name + " loaded!", this);

            LevelLoadEvent.Raise(scene.name);
        }
    }
}