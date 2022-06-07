using System.Collections.Generic;
using System.Linq;

using Sirenix.OdinInspector;
using TalusFramework.Constants;
using TalusFramework.Variables;

using UnityEngine;
using UnityEngine.SceneManagement;
using TalusFramework.Base;
using TalusFramework.Collections;
using TalusFramework.Managers.Interfaces;

namespace TalusFramework.Managers
{
    [CreateAssetMenu(fileName = "New Runtime Manager", menuName = "Managers/Runtime Manager", order = 1)]
    public class RuntimeDataManager : BaseSO, IInitializable
    {
        [FoldoutGroup("Initialization")]
        [AssetSelector, Required]
        public StringVariable NextLevel;

        [FoldoutGroup("Initialization")]
        [AssetSelector, Required]
        public StringVariable LevelText;

        [FoldoutGroup("Initialization")]
        [AssetSelector, Required]
        public StringConstant LevelCyclePref;

        [FoldoutGroup("Initialization")]
        [AssetSelector, Required]
        public StringConstant DisabledLevelCountPref;

        [FoldoutGroup("Initialization")]
        [AssetSelector, Required]
        public StringConstant DisabledLevelPref;

        [LabelWidth(100)]
        [AssetSelector, Required]
        public SceneCollection LevelCollection;

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

        private List<string> PlayableLevels => (from t in LevelCollection.Items where !DisabledLevels.Contains(t.ScenePath) select t.ScenePath).ToList();
        private List<string> DisabledLevels => Enumerable.Range(0, DisabledLevelCount)
            .Select(i => PlayerPrefs.GetString(DisabledLevelPref.RuntimeValue + i))
            .ToList();
    }
}