﻿using Sirenix.OdinInspector;

using TalusFramework.Behaviours.Interfaces;
using TalusFramework.Events;

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
            LevelLoadEvent.Raise(scene.name);
        }
    }
}