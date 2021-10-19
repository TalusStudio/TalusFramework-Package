﻿using Sirenix.OdinInspector;
using TalusFramework.Runtime.Constants.Interfaces;
using UnityEngine;

namespace TalusFramework.Runtime.Constants
{
    [CreateAssetMenu(fileName = "New GameObject Constant", menuName = "Constants/GameObject", order = 6)]
    [HideMonoScript]
    public sealed class GameObjectConstantSO : BaseConstantSO<GameObject>
    {
    }
}
