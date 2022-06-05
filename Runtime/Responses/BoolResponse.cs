﻿using TalusFramework.Responses.Interfaces;

using UnityEngine;

namespace TalusFramework.Responses
{
    [CreateAssetMenu(fileName = "New Bool Response", menuName = "Responses/Bool", order = 0)]
    public sealed class BoolResponse : Response<bool>
    { }
}
