using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Managers.Interfaces;
using TalusFramework.Variables;
using TalusFramework.Utility.Assertions;
using TalusFramework.Constants;

namespace TalusFramework.Managers
{
    [CreateAssetMenu(fileName = "New Ui Manager", menuName = "_OTHERS/Managers/Ui Manager", order = 4)]
    public class UiManager : BaseManager
    {
        [LabelWidth(100)]
        [Required]
        public StringVariable LevelText;

        [Required] public StringConstant LevelCyclePref;

        private int CompletedLevelCount => PlayerPrefs.GetInt(LevelCyclePref.RuntimeValue);

        public override void Initialize()
        {
            this.Assert(LevelText != null, "Invalid Reference!", typeof(StringVariable), null);

            LevelText.SetValue($"LEVEL {CompletedLevelCount + 1}");
        }
    }
}