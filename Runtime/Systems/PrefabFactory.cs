using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Systems.Interfaces;
using TalusFramework.References;

namespace TalusFramework.Systems
{
    [CreateAssetMenu]
    public class PrefabFactory : AbstractFactory<GameObject>
    {
        [LabelWidth(100)]
        [ToggleLeft]
        [SerializeField]
        private bool _CustomTransform = default;

        [ShowIf(nameof(_CustomTransform))]
        [LabelWidth(100)]
        public Vector3Reference Position;

        [ShowIf(nameof(_CustomTransform))]
        [LabelWidth(100)]
        public Vector3Reference Rotation;

        [ShowIf(nameof(_CustomTransform))]
        [LabelWidth(100)]
        public Vector3Reference Scale;

        public override GameObject Create()
        {
            var clone = _CustomTransform
                ? Instantiate(Object, Position.Value, Quaternion.Euler(Rotation))
                : Instantiate(Object);

            if (_CustomTransform)
            {
                clone.transform.localScale = Scale;
            }

            return clone;
        }
    }
}