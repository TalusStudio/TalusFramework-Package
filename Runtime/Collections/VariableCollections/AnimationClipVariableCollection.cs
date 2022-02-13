using Sirenix.OdinInspector;

using TalusFramework.Runtime.Collections.Interfaces;
using TalusFramework.Runtime.Variables;

using UnityEngine;

namespace TalusFramework.Runtime.Collections.VariableCollections
{
    [CreateAssetMenu(fileName = "New Animation Clip Variable Collection", menuName = "Collections/Variable Collections/Animation Clip", order = 0)]
    public class AnimationClipVariableCollection : BaseCollection<AnimationClipVariable>
    {
        [FoldoutGroup("Actions")]
        [Button]
        public void ResetAllValues(AnimationClip value)
        {
            for (int i = 0; i < Items.Count; ++i)
            {
                Items[i].SetValue(value);
            }
        }
    }
}