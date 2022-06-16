using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Managers.Interfaces;
using TalusFramework.Utility.Logging;

namespace TalusFramework.Managers
{
    /// <summary>
    ///     Game Manager inits other managers
    /// </summary>
    [CreateAssetMenu(fileName = "New Game Manager", menuName = "_OTHERS/Managers/Game Manager", order = 0)]
    public class GameManager : BaseManager
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            Application.targetFrameRate = 60;
        }

        [Required]
        [SerializeField]
        private List<BaseManager> _SubManagers = new List<BaseManager>();

        public override void Initialize()
        {
            if (_SubManagers.Count == 0)
            {
                this.LogWarning("There are no registered sub managers...");
                return;
            }

            for (int i = _SubManagers.Count - 1; i >= 0; i--)
            {
                _SubManagers[i].Initialize();
            }
        }
    }
}