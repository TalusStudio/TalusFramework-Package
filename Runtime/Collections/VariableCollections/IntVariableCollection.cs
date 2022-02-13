using Sirenix.OdinInspector;

using TalusFramework.Runtime.Collections.Interfaces;
using TalusFramework.Runtime.Variables;

using UnityEngine;

namespace TalusFramework.Runtime.Collections.VariableCollections
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