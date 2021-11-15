using Sirenix.OdinInspector;

using TalusFramework.Runtime.Constants;
using TalusFramework.Runtime.References;

using UnityEngine;

namespace TalusFramework.Runtime.Behaviours
{
    [HideMonoScript]
    public class ObjectCreator : MonoBehaviour
    {
        [Required]
        [LabelWidth(60)]
        [AssetSelector]
        [Tooltip("Reference for the object to be created.")]
        public GameObjectConstantSO ObjectSO;

        [FoldoutGroup("Properties")]
        [LabelWidth(95)]
        [Tooltip("Apply offset to position.")]
        public bool UseOffset;

        [ShowIf("UseOffset")]
        [FoldoutGroup("Properties")]
        [LabelWidth(90)]
        [Tooltip("Add offset to position.")]
        public Vector3Reference Offset;

        [FoldoutGroup("Properties")]
        [LabelWidth(95)]
        [ValidateInput("ValidateDestroyInput", "Objects with marked DontDestroy can not be a child object!")]
        [Tooltip("Create as child of this component.")]
        public bool CreateAsChild;

        [FoldoutGroup("Properties")]
        [LabelWidth(95)]
        [ValidateInput("ValidateDestroyInput", "Objects with marked DontDestroy can not be a child object!")]
        [Tooltip("GameObject gonna marked as DontDestroyOnLoad")]
        public bool DontDestroy;

        private Transform _CachedTransform;

        private void Awake()
        {
            _CachedTransform = GetComponent<Transform>();
        }

        public void Create()
        {
            GameObject obj = Instantiate(ObjectSO.RuntimeValue,
                _CachedTransform.position,
                _CachedTransform.rotation,
                CreateAsChild ? _CachedTransform : null);


            if (UseOffset)
            {
                obj.transform.localPosition = Offset;
            }

            if (DontDestroy && !CreateAsChild)
            {
                DontDestroyOnLoad(obj);
            }
        }

#if UNITY_EDITOR
        private bool ValidateDestroyInput() => !(DontDestroy && CreateAsChild);
#endif
    }
}
