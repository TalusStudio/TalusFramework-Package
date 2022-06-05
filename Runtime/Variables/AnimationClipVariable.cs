﻿using TalusFramework.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Variables
{
    [CreateAssetMenu(fileName = "New Animation Clip Variable", menuName = "Variables/Animation Clip", order = 9)]
    public sealed class AnimationClipVariable : BaseVariable<AnimationClip>
    { }
}