using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Managers.Interfaces;
using TalusFramework.Variables;
using TalusFramework.Utility.Assertions;
using TalusFramework.Constants;

namespace TalusFramework.Managers
{
    [CreateAssetMenu(fileName = "New Ui Manager", menuName = "Talus/Framework/Managers/Ui Manager", order = 4)]
    public class UiManager : BaseManager
    {
        [LabelWidth(100)]
        [Required] public StringVariable LevelText;

        [LabelWidth(100)]
        [Required] public StringConstant LevelCyclePref;

        public override void Initialize()
        {
            this.Assert(LevelText != null, "Invalid Reference!", typeof(StringVariable), null);

            int completedLevelCount = PlayerPrefs.GetInt(LevelCyclePref.RuntimeValue);
            LevelText.SetValue($"LEVEL {completedLevelCount + 1}");
        }
    }
}