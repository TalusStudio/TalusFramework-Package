using Sirenix.OdinInspector;

using TalusFramework.Behaviours.Interfaces;
using TalusFramework.Events;
using TalusFramework.Utility.Assertions;

using UnityEngine.SceneManagement;

namespace TalusFramework.SceneManagement
{
    public class SceneLoadListener : BaseBehaviour
    {
        [LabelWidth(100)]
        [AssetSelector, Required]
        public GameEvent LevelLoadEvent;

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
            this.Assert(LevelLoadEvent != null, "Level Load Event is null!");

            LevelLoadEvent.Raise(scene.name);
        }
    }
}