using UnityEngine;

using TalusFramework.References.Interfaces;
using TalusFramework.Variables;

namespace TalusFramework.References
{
    [System.Serializable]
    public sealed class Vector2Reference : BaseReference<Vector2, Vector2Variable>
    {
        public static implicit operator Vector2(Vector2Reference reference) => reference.Value;
    }
}
