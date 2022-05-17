﻿using System.Collections.Generic;

using Sirenix.OdinInspector;
using Sirenix.Serialization;

using TalusFramework.Runtime.Base;
using TalusFramework.Runtime.Managers.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Managers
{
    [CreateAssetMenu(fileName = "New Game Manager", menuName = "Managers/Game Manager", order = 0)]
    public class GameManager : BaseSerializedSO, IInitializable
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            Application.targetFrameRate = 60;
        }

        [Required]
        [OdinSerialize]
        private readonly List<IInitializable> _Initializables = new List<IInitializable>();

        public void Initialize()
        {
            for (int i = 0; i < _Initializables.Count; ++i)
            {
                _Initializables[i].Initialize();
            }
        }
    }
}