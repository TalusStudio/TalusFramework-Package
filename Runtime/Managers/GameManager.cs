using System.Collections.Generic;

using Sirenix.OdinInspector;
using Sirenix.Serialization;

using TalusFramework.Runtime.Base;

using UnityEngine;

namespace TalusFramework.Runtime.Managers
{
    [HideMonoScript]
    [CreateAssetMenu(fileName = "New Game Manager", menuName = "Managers/Game Manager", order = 0)]
    public class GameManager : SerializedScriptableObject, IInitiable
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            Application.targetFrameRate = 60;
        }

        [Required]
        [OdinSerialize]
        private List<IInitiable> _Initializables;

        public void Initialize()
        {
            for (int i = 0; i < _Initializables.Count; ++i)
            {
                _Initializables[i].Initialize();
            }
        }
    }
}