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
    [CreateAssetMenu(fileName = "New Game Manager", menuName = "Talus/Framework/Managers/Game Manager", order = 0)]
    public class GameManager : BaseManager
    {
        [Space]
        [ToggleLeft]
        public bool _UseCustomFPS = true;

        [EnableIf(nameof(_UseCustomFPS))]
        [LabelWidth(30)]
        [SerializeField]
        private int _FPS = 60;

        [Space]
        [Required]
        [SerializeField]
        private List<BaseManager> _SubManagers = new List<BaseManager>();

        public override void Initialize()
        {
            if (_UseCustomFPS)
            {
                Application.targetFrameRate = _FPS;
                this.Log($"Target frame rate changed to: {_FPS}");
            }

            if (_SubManagers.Count == 0)
            {
                this.Warning("There are no registered sub managers...");
                return;
            }

            for (int i = _SubManagers.Count - 1; i >= 0; i--)
            {
                _SubManagers[i].Initialize();
            }
        }
    }
}