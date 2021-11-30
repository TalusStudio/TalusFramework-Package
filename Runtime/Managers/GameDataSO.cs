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
        [TitleGroup("Variables - Scene Management"), LabelWidth(100)]
        [AssetSelector, Required]
        public IntVariableSO NextLevelIndex;

        [TitleGroup("Variables - In Game"), LabelWidth(100)]
        [AssetSelector, Required]
        public StringVariableSO LevelText;

        [TitleGroup("Variables - Scene Management"), LabelWidth(100)]
        [AssetSelector, Required]
        public StringConstantSO LevelCyclePref;

        /// <summary>
        ///     To reference playable levels.
        /// </summary>
        public static List<int> Levels
        {
            get
            {
                var levelIndexes = new List<int>();

#if ENABLE_BACKEND
                // scene at buildIndex 0 -> elephant
                // scene at buildIndex 1 -> forwarder scene
                for (int i = 2; i < SceneManager.sceneCountInBuildSettings; ++i)
                {
                    levelIndexes.Add(i);
                }
#else
                // scene at buildIndex 0 -> forwarder scene
                for (int i = 1; i < SceneManager.sceneCountInBuildSettings; ++i)
                {
                    levelIndexes.Add(i);
                }
#endif
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

        public void UpdateNextLevelVariable() => NextLevelIndex.SetValue(Levels[CompletedLevelCount % Levels.Count]);
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
