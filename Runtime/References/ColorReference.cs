using UnityEngine;

using TalusFramework.Runtime.References.Interfaces;

namespace TalusFramework.Runtime.References
{
    [System.Serializable]
    public sealed class ColorReference : BaseReference<Color>
    {
        public static implicit operator Color(ColorReference reference) => reference.Value;
    }
}
