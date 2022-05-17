﻿using System.Collections.Generic;
using System.Linq;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Managers.Interfaces;
using TalusFramework.Runtime.Constants;
using TalusFramework.Runtime.Variables;

using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TalusFramework.Runtime.Managers
{
    [CreateAssetMenu(fileName = "New Runtime Manager", menuName = "Managers/Runtime Manager", order = 1)]
    public class RuntimeDataManager : BaseSO, IInitializable
    {
#if UNITY_EDITOR
        [Button(ButtonSizes.Large), GUIColor(0f, 1f, 0f)]
        public void SyncBuildSettings()
        {
            var scenes = new List<EditorBuildSettingsScene>();

            if (IsBackendActivated())
            {
                scenes.Add(new EditorBuildSettingsScene(ElephantScene.ScenePath, true));
            }

            scenes.Add(new EditorBuildSettingsScene(ForwarderScene.ScenePath, true));
            scenes.AddRange(Levels.Select(t => new EditorBuildSettingsScene(t.ScenePath, true)));
            EditorBuildSettings.scenes = scenes.ToArray();
        }

        private bool IsBackendActivated()
        {
            #if ENABLE_BACKEND
            return true;
            #else
            return false;
            #endif
        }
#endif
        [ShowIf("@IsBackendActivated() == true")]
        [FoldoutGroup("Scene Management")]
        public SceneReference ElephantScene;

        [FoldoutGroup("Scene Management")]
        public SceneReference ForwarderScene;

        public List<SceneReference> Levels;

        [FoldoutGroup("Variables")]
        [AssetSelector, Required]
        public StringVariable NextLevel;

        [FoldoutGroup("Variables")]
        [AssetSelector, Required]
        public StringVariable LevelText;

        [FoldoutGroup("Variables - Player Prefs")]
        [AssetSelector, Required]
        public StringConstant LevelCyclePref;

        [FoldoutGroup("Variables - Player Prefs")]
        [AssetSelector, Required]
        public StringConstant DisabledLevelCountPref;

        [FoldoutGroup("Variables - Player Prefs")]
        [AssetSelector, Required]
        public StringConstant DisabledLevelPref;

        public void Initialize()
        {
            UpdateGameData();
        }

        public void LevelUp()
        {
            PlayerPrefs.SetInt(LevelCyclePref.RuntimeValue, CompletedLevelCount + 1);
            UpdateGameData();
        }

        public void DisableCurrentLevel()
        {
            if (DisabledLevels.Contains(SceneManager.GetActiveScene().path))
            {
                return;
            }

            PlayerPrefs.SetString(DisabledLevelPref.RuntimeValue + DisabledLevelCount, SceneManager.GetActiveScene().path);
            PlayerPrefs.SetInt(DisabledLevelCountPref.RuntimeValue, DisabledLevelCount + 1);
        }

        private void UpdateGameData()
        {
            LevelText.SetValue("LEVEL " + (CompletedLevelCount + 1));
            NextLevel.SetValue(PlayableLevels[Mathf.Abs(CompletedLevelCount - DisabledLevelCount) % PlayableLevels.Count]);
        }

        private int CompletedLevelCount => PlayerPrefs.GetInt(LevelCyclePref.RuntimeValue);
        private int DisabledLevelCount => PlayerPrefs.GetInt(DisabledLevelCountPref.RuntimeValue);

        private List<string> PlayableLevels => (from t in Levels where !DisabledLevels.Contains(t.ScenePath) select t.ScenePath).ToList();
        private List<string> DisabledLevels => Enumerable.Range(0, DisabledLevelCount)
            .Select(i => PlayerPrefs.GetString(DisabledLevelPref.RuntimeValue + i))
            .ToList();
    }
}