using System.Collections.Generic;
using System.Linq;

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
    public class GameDataManager : BaseSO, IInitiable
    {

#if ENABLE_BACKEND
        [FoldoutGroup("Scene Management")]
        public SceneReference ElephantScene;
#endif

        [FoldoutGroup("Scene Management")]
        public SceneReference ForwarderScene;

        [FoldoutGroup("Scene Management")]
        public List<SceneReference> Levels;

#if UNITY_EDITOR
        [FoldoutGroup("Scene Management")]
        [Button(ButtonSizes.Large), GUIColor(0f, 1f, 0f)]
        public void SyncBuildSettings()
        {
            var scenes = new List<EditorBuildSettingsScene>();

#if ENABLE_BACKEND
            scenes.Add(new EditorBuildSettingsScene(ElephantScene.ScenePath, true));
#endif

            scenes.Add(new EditorBuildSettingsScene(ForwarderScene.ScenePath, true));
            scenes.AddRange(Levels.Select(t => new EditorBuildSettingsScene(t.ScenePath, true)));
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

        public void Initialize()
        {
            UpdateGameData();
        }

        public void DisableCurrentLevel()
        {
            if (DisabledLevels.Contains(SceneManager.GetActiveScene().path))
            {
                return;
            }

            PlayerPrefs.SetString("DISABLE_LEVEL_" + DisabledLevelCount, SceneManager.GetActiveScene().path);
            PlayerPrefs.SetInt("DISABLED_LEVEL_COUNT", DisabledLevelCount + 1);
        }

        public void LevelUp()
        {
            PlayerPrefs.SetInt(LevelCyclePref.RuntimeValue, CompletedLevelCount + 1);
            UpdateGameData();
        }

        private int CompletedLevelCount => PlayerPrefs.GetInt(LevelCyclePref.RuntimeValue);
        private int DisabledLevelCount => PlayerPrefs.GetInt("DISABLED_LEVEL_COUNT");

        private List<string> PlayableLevels => (from t in Levels where !DisabledLevels.Contains(t.ScenePath) select t.ScenePath).ToList();
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


        private void UpdateGameData()
        {
            LevelText.SetValue("LEVEL " + (CompletedLevelCount + 1));
            NextLevel.SetValue(PlayableLevels[(CompletedLevelCount - DisabledLevelCount) % PlayableLevels.Count]);
        }
    }
}