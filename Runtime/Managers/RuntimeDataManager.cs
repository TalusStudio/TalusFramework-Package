using System.Collections.Generic;
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

namespace TalusFramework.Managers
{
    /// <summary>
    ///     RuntimeData Manager sets next level
    /// </summary>
    [CreateAssetMenu(fileName = "New Runtime Manager", menuName = "Managers/Runtime Manager", order = 1)]
    public class RuntimeDataManager : BaseSO, IInitable
    {
        [FoldoutGroup("Base"), Required] public StringVariable LevelText;
        [FoldoutGroup("Base"), Required] public StringConstant LevelCyclePref;
        [FoldoutGroup("Base"), Required] public StringConstant DisabledLevelCountPref;
        [FoldoutGroup("Base"), Required] public StringConstant DisabledLevelPref;

        [LabelWidth(100), Required] public SceneVariable NextLevel;
        [LabelWidth(100), Required] public SceneCollection LevelCollection;

        public void Initialize()
        {
            RefreshLevelData();
        }

        public void LevelUp()
        {
            PlayerPrefs.SetInt(LevelCyclePref.RuntimeValue, CompletedLevelCount + 1);
            RefreshLevelData();
        }

        public void DisableCurrentLevel()
        {
            string currentScenePath = SceneManager.GetActiveScene().path;
            if (DisabledLevels.Contains(currentScenePath)) { return; }

            PlayerPrefs.SetString(DisabledLevelPref.RuntimeValue + DisabledLevelCount, currentScenePath);
            PlayerPrefs.SetInt(DisabledLevelCountPref.RuntimeValue, DisabledLevelCount + 1);
        }

        private void RefreshLevelData()
        {
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