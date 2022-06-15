using Sirenix.OdinInspector;

using TalusFramework.Behaviours.Interfaces;
using TalusFramework.Events;
using TalusFramework.Utility;
using TalusFramework.Utility.Assertions;

using UnityEngine.SceneManagement;

namespace TalusFramework.SceneManagement
{
    public class LevelLoadEventInvoker : BaseBehaviour
    {
        [LabelWidth(100)]
        [AssetSelector, Required]
        public SceneEvent LevelLoadEvent;

        protected override void OnEnable()
        {
            SceneManager.sceneLoaded += HandleSceneLoad;
        }

        protected override void OnDisable()
        {
            SceneManager.sceneLoaded -= HandleSceneLoad;
        }

        private void HandleSceneLoad(Scene scene, LoadSceneMode loadSceneMode)
        {
            this.Assert(LevelLoadEvent != null, "Invalid Reference!", typeof(SceneEvent), null);

            LevelLoadEvent.Raise(new SceneReference(scene.path));
        }
    }
}