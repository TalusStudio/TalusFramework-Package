using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;

using UnityEngine;

namespace TalusFramework.Runtime.Managers
{
    [CreateAssetMenu(fileName = "New TimeScale Manager", menuName = "Managers/TimeScale Manager", order = 2)]
    public class TimeScaleManager : BaseSO
    {
        [Button(ButtonSizes.Large), GUIColor(1f, 1f, 0f)]
        [EnableIf("@Time.timeScale != 0f")]
        public void PauseGame() => Time.timeScale = 0f;

        [Button(ButtonSizes.Large), GUIColor(0f, 1f, 0f)]
        [EnableIf("@Time.timeScale == 0f")]
        public void UnpauseGame() => Time.timeScale = 1f;
    }
}