using UnityEngine;

using Sirenix.OdinInspector;

namespace TalusFramework.Base
{
    [FoldoutGroup("Developer Description")]
    [HideLabel]
    [System.Serializable]
    public class Description
    {
#pragma warning disable 0414
        [PropertyOrder(0)]
        [TextArea(5, 10)]
        [HideLabel]
        public string Text;
#pragma warning restore 0414
    }
}
