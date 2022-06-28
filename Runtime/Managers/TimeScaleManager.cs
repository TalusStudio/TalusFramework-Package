using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Managers.Interfaces;

namespace TalusFramework.Managers
{
    [CreateAssetMenu(fileName = "New TimeScale Manager", menuName = "_OTHERS/Managers/TimeScale Manager", order = 3)]
    public class TimeScaleManager : BaseManager
    {
        public override void Initialize()
        { }

        [Button, GUIColor(0f, 1f, 0f)]
        public void SetTimeScale(float timeScale)
        {
            Time.timeScale = timeScale;
        }
    }
}