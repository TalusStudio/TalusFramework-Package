using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.References;
using TalusFramework.Behaviours.Interfaces;

namespace TalusFramework.Behaviours
{
    [AddComponentMenu("TalusFramework/Behaviours/Object Creator", 5)]
    public class ObjectCreator : BaseBehaviour
    {
        [Tooltip("Reference for the object to be created."), LabelWidth(60)]
        public GameObjectReference Object;

        [FoldoutGroup("Properties"), LabelWidth(95)]
        [Tooltip("Apply offset to position.")]
        public bool UseOffset;

        [ShowIf("UseOffset")]
        [FoldoutGroup("Properties")]
        [Tooltip("Add offset to position."), LabelWidth(90)]
        public Vector3Reference Offset;

        [FoldoutGroup("Properties")]
        [Tooltip("Create as child of this component."), LabelWidth(95)]
        [ValidateInput(nameof(ValidateDestroyInput), "Objects with marked DontDestroy can not be a child object!")]
        public bool CreateAsChild;

        [FoldoutGroup("Properties")]
        [Tooltip("GameObject gonna marked as DontDestroyOnLoad"), LabelWidth(95)]
        [ValidateInput(nameof(ValidateDestroyInput), "Objects with marked DontDestroy can not be a child object!")]
        public bool DontDestroy;

        private Transform _CachedTransform;

        private void Awake()
        {
            _CachedTransform = GetComponent<Transform>();
        }

        [GUIColor(0f, 1f, 0f)]
        [Button, DisableInEditorMode]
        public void Create()
        {
            GameObject obj = Instantiate(Object.Value,
                _CachedTransform.position,
                _CachedTransform.rotation,
                CreateAsChild ? _CachedTransform : null);

            if (UseOffset)
            {
                obj.transform.localPosition = Offset;
            }

            if (!ValidateDestroyInput())
            {
                DontDestroyOnLoad(obj);
            }
        }

        private bool ValidateDestroyInput() => !(DontDestroy && CreateAsChild);
    }
}