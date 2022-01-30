using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;

using UnityEngine;

namespace TalusFramework.Runtime.Managers
{
    [CreateAssetMenu(fileName = "New TimeScale Manager", menuName = "Managers/TimeScale Manager", order = 2)]
    public class TimeScaleManagerSO : BaseSO
    {
        [Button(ButtonSizes.Large)] [EnableIf("@Time.timeScale != 0f")] [GUIColor(1f, 1f, 0f)]
        public void PauseGame() => Time.timeScale = 0f;

        [Button(ButtonSizes.Large)] [EnableIf("@Time.timeScale == 0f")] [GUIColor(0f, 1f, 0f)]
        public void UnpauseGame() => Time.timeScale = 1f;
    }
}