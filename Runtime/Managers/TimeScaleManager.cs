using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Base;
using TalusFramework.Managers.Interfaces;

namespace TalusFramework.Managers
{
    [CreateAssetMenu(fileName = "New TimeScale Manager", menuName = "Managers/TimeScale Manager", order = 3)]
    public class TimeScaleManager : BaseSO, IInitable
    {
        public void Initialize()
        { }

        [Button, GUIColor(0f, 1f, 0f)]
        public void SetTimeScale(float timeScale)
        {
            Time.timeScale = timeScale;
        }
    }
}