using System;

using TalusFramework.Runtime.References.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.References
{
    [Serializable]
    public sealed class Vector3Reference : BaseReference<Vector3>
    {
        public static implicit operator Vector3(Vector3Reference reference) => reference.Value;
    }
}
