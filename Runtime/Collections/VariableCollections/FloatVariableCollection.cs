using Sirenix.OdinInspector;

using TalusFramework.Collections.Interfaces;
using TalusFramework.Variables;

using UnityEngine;

namespace TalusFramework.Collections.VariableCollections
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