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
        public List<SceneReference> PlayableLevels;

        [FoldoutGroup("Levels")]
        public List<SceneReference> TutorialLevels;

        [FoldoutGroup("Levels")]
        [Button(ButtonSizes.Large)]
        public void DisableTutorialLevels()
        {
            PlayerPrefs.SetInt("DISABLE_TUTORIAL_LEVELS", 1);
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
        public List<string> Levels
        {
            get
            {
                var levelIndexes = new List<string>();

                if (!PlayerPrefs.HasKey("DISABLE_TUTORIAL_LEVELS"))
                {
                    for (int i = 0; i < TutorialLevels.Count; ++i)
                    {
                        levelIndexes.Add(TutorialLevels[i].ScenePath);
                    }
                }

                for (int i = 0; i < PlayableLevels.Count; ++i)
                {
                    levelIndexes.Add(PlayableLevels[i].ScenePath);
                }

                return levelIndexes;
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

        public void UpdateNextLevelVariable() => NextLevel.SetValue(Levels[CompletedLevelCount % Levels.Count]);
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