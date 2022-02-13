using Sirenix.OdinInspector;

using TalusFramework.Runtime.Collections.Interfaces;
using TalusFramework.Runtime.Variables;

using UnityEngine;

namespace TalusFramework.Runtime.Collections.VariableCollections
{
    [CreateAssetMenu(fileName = "New Float Variable Collection", menuName = "Collections/Variable Collections/Float", order = 2)]
    public class FloatVariableCollection : BaseCollection<FloatVariable>
    {
        [FoldoutGroup("Actions")]
        [Button]
        public void ResetAllValues(float value)
        {
            for (int i = 0; i < Items.Count; ++i)
            {
                Items[i].SetValue(value);
            }
        }
    }
}