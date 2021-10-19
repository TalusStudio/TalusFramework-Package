using Sirenix.OdinInspector;
using UnityEngine;

#pragma warning disable 414 // (disable "assigned but never used" warning)

namespace TalusFramework.Runtime.Base
{
    public abstract class BaseSO : ScriptableObject
    {
        [PropertyOrder(0), HideLabel]
        [TextArea(5, 10), FoldoutGroup("Developer Description")]
        [SerializeField]
        private string DeveloperDescription = "";
    }
}
