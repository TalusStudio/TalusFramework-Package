using Sirenix.OdinInspector;

using TalusFramework.Collections.Interfaces;
using TalusFramework.Variables;

using UnityEngine;

namespace TalusFramework.Collections.VariableCollections
{
    [CreateAssetMenu(fileName = "New Int Variable Collection", menuName = "Collections/Variable Collections/Int", order = 4)]
    public class IntVariableCollection : BaseCollection<IntVariable>
    {
        [FoldoutGroup("Actions")]
        [Button]
        public void ResetAllValues(int value)
        {
            for (int i = 0; i < Items.Count; ++i)
            {
                Items[i].SetValue(value);
            }
        }
    }
}