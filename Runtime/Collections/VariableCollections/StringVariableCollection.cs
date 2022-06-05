using Sirenix.OdinInspector;

using TalusFramework.Collections.Interfaces;
using TalusFramework.Variables;

using UnityEngine;

namespace TalusFramework.Collections.VariableCollections
{
    [CreateAssetMenu(fileName = "New String Variable Collection", menuName = "Collections/Variable Collections/String", order = 6)]
    public class StringVariableCollection : BaseCollection<StringVariable>
    {
        [FoldoutGroup("Actions")]
        [Button]
        public void ResetAllValues(string value)
        {
            for (int i = 0; i < Items.Count; ++i)
            {
                Items[i].SetValue(value);
            }
        }
    }
}