using Sirenix.OdinInspector;

using TalusFramework.Runtime.Collections.Interfaces;
using TalusFramework.Runtime.Variables;

using UnityEngine;

namespace TalusFramework.Runtime.Collections.VariableCollections
{
    [CreateAssetMenu(fileName = "New Color Variable Collection", menuName = "Collections/Variable Collections/Color", order = 1)]
    public class ColorVariableCollection : BaseCollection<ColorVariable>
    {
        [FoldoutGroup("Actions")]
        [Button]
        public void ResetAllValues(Color value)
        {
            for (int i = 0; i < Items.Count; ++i)
            {
                Items[i].SetValue(value);
            }
        }
    }
}