using Sirenix.OdinInspector;

using TalusFramework.Runtime.Collections.Interfaces;
using TalusFramework.Runtime.Variables;

using UnityEngine;

namespace TalusFramework.Runtime.Collections.VariableCollections
{
    [CreateAssetMenu(fileName = "New Vector3 Variable Collection", menuName = "Collections/Variable Collections/Vector3", order = 7)]
    public class Vector3VariableCollection : BaseCollection<Vector3Variable>
    {
        [FoldoutGroup("Actions")]
        [Button]
        public void ResetAllValues(Vector3 value)
        {
            for (int i = 0; i < Items.Count; ++i)
            {
                Items[i].SetValue(value);
            }
        }
    }
}