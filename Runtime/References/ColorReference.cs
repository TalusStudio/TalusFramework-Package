using UnityEngine;
using TalusFramework.References.Interfaces;
using TalusFramework.Variables;

namespace TalusFramework.References
{
    [System.Serializable]
    public sealed class ColorReference : BaseReference<Color, ColorVariable>
    {
        public static implicit operator Color(ColorReference reference) => reference.Value;
    }
}
