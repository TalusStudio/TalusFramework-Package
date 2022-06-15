using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Systems.Interfaces;
using TalusFramework.References;

namespace TalusFramework.Systems
{
    [CreateAssetMenu(menuName = "Factory/Prefab")]
    public class PrefabFactory : AbstractFactory<GameObject>
    {
        [ToggleGroup(nameof(_PositionOffset),  "Apply Offset", CollapseOthersOnExpand = false)]
        [HideLabel, LabelWidth(100)]
        [SerializeField]
        private bool _PositionOffset = default;

        [ToggleGroup(nameof(_PositionOffset), CollapseOthersOnExpand = false)]
        [LabelWidth(50)]
        [SerializeField]
        private Vector3Reference _Position = default;

        [ToggleGroup(nameof(_RotationOffset), "Apply Rotation", CollapseOthersOnExpand = false)]
        [LabelWidth(100)]
        [ToggleLeft]
        [SerializeField]
        private bool _RotationOffset = default;

        [ToggleGroup(nameof(_RotationOffset), CollapseOthersOnExpand = false)]
        [LabelWidth(50)]
        [SerializeField]
        private Vector3Reference _Rotation = default;

        public override GameObject Create()
        {
            var clone = Instantiate(
                Object,
                (_PositionOffset) ? _Position : Vector3.zero,
                (_RotationOffset) ? Quaternion.Euler(_Rotation) : Quaternion.identity
            );

            return clone;
        }

        public void CreateAsChild(Transform parent)
        {
            GameObject createdObject = Create();
            createdObject.transform.SetParent(parent);
            createdObject.transform.localPosition = _Position;
            createdObject.transform.localRotation = Quaternion.Euler(_Rotation);
        }
    }
}