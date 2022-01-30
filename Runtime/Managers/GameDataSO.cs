﻿using System.Collections.Generic;

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
        [TitleGroup("Scene Management")]
        public List<SceneReference> Levels;

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

        public void DisableCurrentLevel()
        {
            if (DisabledLevels.Contains(SceneManager.GetActiveScene().path))
            {
                return;
            }

            int disabledLevelCount = PlayerPrefs.GetInt("DISABLED_LEVEL_COUNT") + 1;
            PlayerPrefs.SetString("DISABLE_LEVEL_" + (disabledLevelCount - 1), SceneManager.GetActiveScene().path);
            PlayerPrefs.SetInt("DISABLED_LEVEL_COUNT", disabledLevelCount);
            PlayerPrefs.Save();
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