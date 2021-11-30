using System;

using TalusFramework.Runtime.References.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.References
{
    [Serializable]
    public sealed class ColorReference : BaseReference<Color>
    {
        public static implicit operator Color(ColorReference reference) => reference.Value;
    }
}
