using Sirenix.OdinInspector;

using TalusFramework.Collections.Interfaces;
using TalusFramework.Variables;

using UnityEngine;

namespace TalusFramework.Collections.VariableCollections
{
    [CreateAssetMenu(fileName = "New Sprite Variable Collection", menuName = "Collections/Variable Collections/Sprite", order = 5)]
    public class SpriteVariableCollection : BaseCollection<SpriteVariable>
    {
        [FoldoutGroup("Actions")]
        [Button]
        public void ResetAllValues(Sprite value)
        {
            for (int i = 0; i < Items.Count; ++i)
            {
                Items[i].SetValue(value);
            }
        }
    }
}