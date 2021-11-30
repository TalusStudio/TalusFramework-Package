using System;

using TalusFramework.Runtime.References.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.References
{
    [Serializable]
    public sealed class SpriteReference : BaseReference<Sprite>
    {
        public static implicit operator Sprite(SpriteReference reference) => reference.Value;
    }
}
