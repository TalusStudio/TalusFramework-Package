using UnityEngine;

using TalusFramework.References.Interfaces;
using TalusFramework.Variables;

namespace TalusFramework.References
{
    [System.Serializable]
    public sealed class Vector3Reference : BaseReference<Vector3, Vector3Variable>
    {
        public static implicit operator Vector3(Vector3Reference reference) => reference.Value;
    }
}
