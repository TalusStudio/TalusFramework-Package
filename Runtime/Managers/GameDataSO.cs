using Sirenix.OdinInspector;
using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Variables;
using UnityEngine;

namespace TalusFramework.Runtime.Managers
{
    [CreateAssetMenu]
    public class GameDataSO : BaseSO
    {
        [Required]
        [SerializeField]
        [AssetSelector(DropdownTitle = "Build Data Scriptables")]
        [LabelWidth(70)]
        private BuildDataSO _BuildData;

        [Required]
        [SerializeField]
        [AssetSelector(DropdownTitle = "String Variables")]
        [LabelWidth(70)]
        private StringVariableSO _LevelText;

        public void UpdateLevelTextVariable()
        {
            _LevelText.SetValue("LEVEL " + (_BuildData.GetLevelPlayerPrefValue() + 1));
        }

        public int GetNextLevelIndex()
        {
            int completedLevel = _BuildData.GetLevelPlayerPrefValue();
            return BuildDataSO.LevelIndexes[completedLevel % BuildDataSO.LevelCount];
        }
    }
}
