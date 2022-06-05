using UnityEngine;
using TalusFramework.References.Interfaces;

namespace TalusFramework.References
{
    [System.Serializable]
    public sealed class SpriteReference : BaseReference<Sprite>
    {
        public static implicit operator Sprite(SpriteReference reference) => reference.Value;
    }
}
