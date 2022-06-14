using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;
using Sirenix.Serialization;

using TalusFramework.Base;
using TalusFramework.Managers.Interfaces;

namespace TalusFramework.Managers
{
    /// <summary>
    ///     Game Manager inits other managers
    /// </summary>
    [CreateAssetMenu(fileName = "New Game Manager", menuName = "Managers/Game Manager", order = 0)]
    public class GameManager : BaseSerializedSO, IInitable
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            Application.targetFrameRate = 60;
        }

        [Required]
        [OdinSerialize]
        private readonly List<IInitable> _Initializables = new List<IInitable>();

        public void Initialize()
        {
            for (int i = 0; i < _Initializables.Count; ++i)
            {
                _Initializables[i].Initialize();
            }
        }
    }
}