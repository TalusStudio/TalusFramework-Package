using Sirenix.OdinInspector;

using TalusFramework.Base;
using TalusFramework.Managers.Interfaces;

using UnityEngine;

namespace TalusFramework.Managers
{
    [CreateAssetMenu(fileName = "New TimeScale Manager", menuName = "Managers/TimeScale Manager", order = 3)]
    public class TimeScaleManager : BaseSO, IInitializable
    {
        public void Initialize()
        { }

        [Button]
        public void SetTimeScale(float timeScale)
        {
            Time.timeScale = timeScale;
        }
    }
}