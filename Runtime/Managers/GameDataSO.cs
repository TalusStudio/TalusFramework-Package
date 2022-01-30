using System.Collections.Generic;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Constants;
using TalusFramework.Runtime.Variables;

using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TalusFramework.Runtime.Managers
{
    [CreateAssetMenu(fileName = "New Game Data", menuName = "Managers/Game Data", order = 1)]
    public class GameDataSO : BaseSO
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            Application.targetFrameRate = 60;
        }

#if ENABLE_BACKEND
        [TitleGroup("Scene Management")]
        public SceneReference ElephantScene;
#endif

        [TitleGroup("Scene Management")]
        public SceneReference ForwarderScene;

        [TitleGroup("Scene Management")]
        public List<SceneReference> Levels;

#if UNITY_EDITOR
        [TitleGroup("Scene Management")]
        [Button(ButtonSizes.Large), GUIColor(0f, 1f, 0f)]
        public void SyncBuildSettings()
        {
            var scenes = new List<EditorBuildSettingsScene>();

#if ENABLE_BACKEND
            scenes.Add(new EditorBuildSettingsScene(ElephantScene.ScenePath, true));
#endif
            scenes.Add(new EditorBuildSettingsScene(ForwarderScene.ScenePath, true));

            for (int i = 0; i < Levels.Count; ++i)
            {
                scenes.Add(new EditorBuildSettingsScene(Levels[i].ScenePath, true));
            }

            EditorBuildSettings.scenes = scenes.ToArray();
        }
#endif

        [FoldoutGroup("Variables")]
        [AssetSelector, Required]
        public StringVariableSO NextLevel;

        [FoldoutGroup("Variables")]
        [AssetSelector, Required]
        public StringVariableSO LevelText;

        [FoldoutGroup("Variables")]
        [AssetSelector, Required]
        public StringConstantSO LevelCyclePref;

        public void DisableCurrentLevel()
        {
            if (DisabledLevels.Contains(SceneManager.GetActiveScene().path))
            {
                return;
            }

            PlayerPrefs.SetString("DISABLE_LEVEL_" + DisabledLevelCount, SceneManager.GetActiveScene().path);
            PlayerPrefs.SetInt("DISABLED_LEVEL_COUNT", DisabledLevelCount + 1);
        }

        public void IncrementCompletedLevel() => PlayerPrefs.SetInt(LevelCyclePref.RuntimeValue, CompletedLevelCount + 1);
        public void UpdateNextLevelVariable() => NextLevel.SetValue(PlayableLevels[(CompletedLevelCount - DisabledLevelCount) % PlayableLevels.Count]);
        public void UpdateLevelTextVariable() => LevelText.SetValue("LEVEL " + (CompletedLevelCount + 1));

        private int CompletedLevelCount => PlayerPrefs.GetInt(LevelCyclePref.RuntimeValue);
        private int DisabledLevelCount => PlayerPrefs.GetInt("DISABLED_LEVEL_COUNT");


        private List<string> PlayableLevels
        {
            get
            {
                var levelIndexes = new List<string>();

                for (int i = 0; i < Levels.Count; ++i)
                {
                    if (DisabledLevels.Contains(Levels[i].ScenePath))
                    {
                        continue;
                    }

                    levelIndexes.Add(Levels[i].ScenePath);
                }

                return levelIndexes;
            }
        }


        private List<string> DisabledLevels
        {
            get
            {
                var disabledLevels = new List<string>();

                for (int i = 0; i < DisabledLevelCount; ++i)
                {
                    disabledLevels.Add(PlayerPrefs.GetString("DISABLE_LEVEL_" + i));
                }

                return disabledLevels;
            }
        }

    }
}