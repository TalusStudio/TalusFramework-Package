using UnityEngine;

using TalusFramework.Runtime.References.Interfaces;

namespace TalusFramework.Runtime.References
{
    [System.Serializable]
    public sealed class SpriteReference : BaseReference<Sprite>
    {
        public static implicit operator Sprite(SpriteReference reference) => reference.Value;
    }
}
