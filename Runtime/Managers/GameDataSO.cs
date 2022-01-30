using System.Collections.Generic;

using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Constants;
using TalusFramework.Runtime.Variables;

using UnityEngine;
using UnityEngine.SceneManagement;

#if ENABLE_COMMANDS
using QFSW.QC;
#endif

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TalusFramework.Runtime.Managers
{
    [CreateAssetMenu(fileName = "New Game Data", menuName = "Managers/Game Data", order = 1)]
#if ENABLE_COMMANDS
    [CommandPrefix("talus.")]
#endif
    public class GameDataSO : BaseSO
    {

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
        [Button(ButtonSizes.Large)]
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


        /// <summary>
        ///     To reference playable levels.
        /// </summary>
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

        private int DisabledLevelCount => PlayerPrefs.GetInt("DISABLED_LEVEL_COUNT");

        private List<string> DisabledLevels
        {
            get
            {
                var disabledLevels = new List<string>();

                for (int i = 0; i < DisabledLevelCount; ++i)
                {
                    disabledLevels.Add(PlayerPrefs.GetString("DISABLE_LEVEL_" + (i - 1)));
                }

                return disabledLevels;
            }
        }

        public void DisableCurrentLevel()
        {
            if (DisabledLevels.Contains(SceneManager.GetActiveScene().path))
            {
                return;
            }

            PlayerPrefs.SetInt("DISABLED_LEVEL_COUNT", DisabledLevelCount + 1);
            PlayerPrefs.SetString("DISABLE_LEVEL_" + DisabledLevelCount, SceneManager.GetActiveScene().path);
        }

#if ENABLE_COMMANDS
        [Command("get-level-pref", MonoTargetType.Registry)]
#endif
        private int CompletedLevelCount => PlayerPrefs.GetInt(LevelCyclePref.RuntimeValue);

#if ENABLE_COMMANDS
        [Command("increment-completed-level", MonoTargetType.Registry)]
#endif
        public void IncrementCompletedLevel() => PlayerPrefs.SetInt(LevelCyclePref.RuntimeValue, CompletedLevelCount + 1);

        public void UpdateNextLevelVariable() => NextLevel.SetValue(PlayableLevels[CompletedLevelCount % PlayableLevels.Count]);
        public void UpdateLevelTextVariable() => LevelText.SetValue("LEVEL " + (CompletedLevelCount + 1));

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            Application.targetFrameRate = 60;
        }

#if ENABLE_COMMANDS
        private void OnEnable() => QuantumRegistry.RegisterObject(this);
        private void OnDisable() => QuantumRegistry.DeregisterObject(this);
#endif
    }
}