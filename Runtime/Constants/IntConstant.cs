﻿using TalusFramework.Runtime.Constants.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Constants
{
    [CreateAssetMenu(fileName = "New Int Constant", menuName = "Constants/Int", order = 2)]
    public sealed class IntConstant : BaseConstant<int>
    { }
}