using UnityEngine;

using TalusFramework.References.Interfaces;
using TalusFramework.Variables;

namespace TalusFramework.References
{
    [System.Serializable]
    public sealed class SpriteReference : BaseReference<Sprite, SpriteVariable>
    {
        public static implicit operator Sprite(SpriteReference reference) => reference.Value;
    }
}
