﻿using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.SceneManagement;

using Sirenix.OdinInspector;

using TalusFramework.Base;
using TalusFramework.Managers.Interfaces;
using TalusFramework.Constants;
using TalusFramework.Variables;
using TalusFramework.Collections;
using TalusFramework.Utility;
using TalusFramework.Utility.Assertions;

namespace TalusFramework.Managers
{
    /// <summary>
    ///     RuntimeData Manager sets next level
    /// </summary>
    [CreateAssetMenu(fileName = "New Runtime Manager", menuName = "_OTHERS/Managers/Runtime Manager", order = 1)]
    public class RuntimeDataManager : BaseSO, IInitable
    {
        [FoldoutGroup("Base"), Required] public StringConstant LevelCyclePref;
        [FoldoutGroup("Base"), Required] public StringConstant DisabledLevelCountPref;
        [FoldoutGroup("Base"), Required] public StringConstant DisabledLevelPref;

        [LabelWidth(100), Required] public SceneCollection LevelCollection;
        [LabelWidth(100), Required] public SceneVariable NextLevel;
        [LabelWidth(100), Required] public StringVariable LevelText;

        public void Initialize()
        {
            RefreshLevelData();
        }

        public void LevelUp()
        {
            this.Assert(LevelCyclePref != null, "Invalid Reference!", typeof(StringConstant), null);

            PlayerPrefs.SetInt(LevelCyclePref.RuntimeValue, CompletedLevelCount + 1);
            RefreshLevelData();
        }

        public void DisableCurrentLevel()
        {
            this.Assert(DisabledLevelPref != null, "Invalid Reference!", typeof(StringConstant), null);
            this.Assert(DisabledLevelCountPref != null, "Invalid Reference!", typeof(StringConstant), null);

            string currentScenePath = SceneManager.GetActiveScene().path;
            if (DisabledLevels.Contains(currentScenePath)) { return; }

            PlayerPrefs.SetString(DisabledLevelPref.RuntimeValue + DisabledLevelCount, currentScenePath);
            PlayerPrefs.SetInt(DisabledLevelCountPref.RuntimeValue, DisabledLevelCount + 1);
        }

        private void RefreshLevelData()
        {
            this.Assert(LevelCollection != null, "Invalid Reference!", typeof(SceneCollection), null);
            this.Assert(NextLevel != null, "Invalid Reference!", typeof(SceneVariable), null);
            this.Assert(LevelText != null, "Invalid Reference!", typeof(StringVariable), null);

            LevelText.SetValue("LEVEL " + (CompletedLevelCount + 1));
            NextLevel.SetValue(new SceneReference(LevelCollection[
                Mathf.Abs(CompletedLevelCount - DisabledLevelCount) % LevelCollection.Count
            ]));
        }

        private int CompletedLevelCount => PlayerPrefs.GetInt(LevelCyclePref.RuntimeValue);
        private int DisabledLevelCount => PlayerPrefs.GetInt(DisabledLevelCountPref.RuntimeValue);

        private List<string> DisabledLevels =>
            Enumerable.Range(0, DisabledLevelCount)
            .Select(i => PlayerPrefs.GetString(DisabledLevelPref.RuntimeValue + i))
            .ToList();
    }
}