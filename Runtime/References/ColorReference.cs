using UnityEngine;
using TalusFramework.References.Interfaces;

namespace TalusFramework.References
{
    [System.Serializable]
    public sealed class ColorReference : BaseReference<Color>
    {
        public static implicit operator Color(ColorReference reference) => reference.Value;
    }
}
