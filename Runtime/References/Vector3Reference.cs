using UnityEngine;
using TalusFramework.References.Interfaces;

namespace TalusFramework.References
{
    [System.Serializable]
    public sealed class Vector3Reference : BaseReference<Vector3>
    {
        public static implicit operator Vector3(Vector3Reference reference) => reference.Value;
    }
}
