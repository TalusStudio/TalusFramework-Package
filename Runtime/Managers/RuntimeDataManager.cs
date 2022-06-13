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
    [CreateAssetMenu(fileName = "New Runtime Manager", menuName = "Managers/Runtime Manager", order = 1)]
    public class RuntimeDataManager : BaseSO, IInitializable
    {
        [Required]
        public SceneVariable NextLevel;

        [FoldoutGroup("Initialization")]
        [Required]
        public StringVariable LevelText;

        [FoldoutGroup("Initialization")]
        [Required]
        public StringConstant LevelCyclePref;

        [FoldoutGroup("Initialization")]
        [Required]
        public StringConstant DisabledLevelCountPref;

        [FoldoutGroup("Initialization")]
        [Required]
        public StringConstant DisabledLevelPref;

        [LabelWidth(100)]
        [Required]
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
            NextLevel.SetValue(new SceneReference(PlayableLevels[Mathf.Abs(CompletedLevelCount - DisabledLevelCount) % PlayableLevels.Count]));
        }

        private int CompletedLevelCount => PlayerPrefs.GetInt(LevelCyclePref.RuntimeValue);
        private int DisabledLevelCount => PlayerPrefs.GetInt(DisabledLevelCountPref.RuntimeValue);

        private List<string> PlayableLevels => (
            from scene in LevelCollection
            where !DisabledLevels.Contains(scene.ScenePath)
            select scene.ScenePath
        ).ToList();

        private List<string> DisabledLevels => Enumerable.Range(0, DisabledLevelCount)
            .Select(i => PlayerPrefs.GetString(DisabledLevelPref.RuntimeValue + i))
            .ToList();
    }
}