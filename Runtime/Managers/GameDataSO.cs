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

namespace TalusFramework.Runtime.Managers
{
    [CreateAssetMenu(fileName = "New Game Data", menuName = "Managers/Game Data", order = 1)]
#if ENABLE_COMMANDS
    [CommandPrefix("talus.")]
#endif
    public class GameDataSO : BaseSO
    {
        [FoldoutGroup("Levels")]
        public List<SceneReference> LevelsInBuild;

        [FoldoutGroup("Levels")]
        [Button(ButtonSizes.Large)]
        public void DisableLevel(SceneReference scene)
        {
            int disabledLevelCount = PlayerPrefs.GetInt("DISABLED_LEVEL_COUNT");
            PlayerPrefs.SetString("DISABLE_LEVEL_" + disabledLevelCount, scene.ScenePath);
            PlayerPrefs.SetInt("DISABLED_LEVEL_COUNT", ++disabledLevelCount);
        }

        [TitleGroup("Variables - Scene Management"), LabelWidth(100)]
        [AssetSelector, Required]
        public StringVariableSO NextLevel;

        [TitleGroup("Variables - In Game"), LabelWidth(100)]
        [AssetSelector, Required]
        public StringVariableSO LevelText;

        [TitleGroup("Variables - Scene Management"), LabelWidth(100)]
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

                for (int i = 0; i < LevelsInBuild.Count; ++i)
                {
                    if (DisabledLevels.Contains(LevelsInBuild[i].ScenePath))
                    {
                        continue;
                    }

                    levelIndexes.Add(LevelsInBuild[i].ScenePath);
                }

                return levelIndexes;
            }
        }

        private List<string> DisabledLevels
        {
            get
            {
                var disabledLevels = new List<string>();

                for (int i = 0; i < PlayerPrefs.GetInt("DISABLED_LEVEL_COUNT"); ++i)
                {
                    disabledLevels.Add(PlayerPrefs.GetString("DISABLE_LEVEL_" + i));
                }

                return disabledLevels;
            }
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