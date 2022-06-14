using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.References;
using TalusFramework.Behaviours.Interfaces;
using TalusFramework.Utility.Assertions;

namespace TalusFramework.Behaviours
{
    [AddComponentMenu("TalusFramework/Behaviours/Object Creator", 5)]
    public class ObjectCreator : BaseBehaviour
    {
        [FoldoutGroup("Properties"), LabelWidth(95)]
        [Tooltip("Apply offset to position.")]
        public bool UseOffset;

        [ShowIf("UseOffset")]
        [FoldoutGroup("Properties")]
        [Tooltip("Add offset to position."), LabelWidth(90)]
        public Vector3Reference Offset;

        [FoldoutGroup("Properties")]
        [Tooltip("Create as child of this component."), LabelWidth(95)]
        [ValidateInput(nameof(ValidateDestroyInput), ValidationMessage)]
        public bool CreateAsChild;

        [FoldoutGroup("Properties")]
        [Tooltip("GameObject gonna be persistent between Scenes."), LabelWidth(95)]
        [ValidateInput(nameof(ValidateDestroyInput), ValidationMessage)]
        public bool DontDestroy;

        [Tooltip("Reference for the object to be created.")]
        [LabelWidth(40)]
        public GameObjectReference Object;

        private Transform _CachedTransform;

        [PropertySpace(SpaceBefore = 10)]
        [GUIColor(0f, 1f, 0f)]
        [Button(ButtonSizes.Large), DisableInEditorMode]
        public void Create()
        {
            this.Assert(Object.Value != null, $"Spawner reference is null on {gameObject.name}!");

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

        private void Awake()
        {
            _CachedTransform = GetComponent<Transform>();

            this.Assert(ValidateDestroyInput(), ValidationMessage);
        }

        private void OnEnable()
        { }

        private const string ValidationMessage = "Objects with marked DontDestroy can not be a child object!";
        private bool ValidateDestroyInput() => !(DontDestroy && CreateAsChild);
    }
}