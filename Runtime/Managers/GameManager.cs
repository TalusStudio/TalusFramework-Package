using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Managers.Interfaces;

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
            for (int i = 0; i < _SubManagers.Count; ++i)
            {
                _SubManagers[i].Initialize();
            }
        }
    }
}