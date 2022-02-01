using Sirenix.OdinInspector;

using TalusFramework.Runtime.Base;

using UnityEngine;

namespace TalusFramework.Runtime.Managers
{
    [CreateAssetMenu(fileName = "New TimeScale Manager", menuName = "Managers/TimeScale Manager", order = 3)]
    public class TimeScaleManager : BaseSO
    {
        [Button]
        public void SetTimeScale(float timeScale)
        {
            Time.timeScale = timeScale;
        }
    }
}