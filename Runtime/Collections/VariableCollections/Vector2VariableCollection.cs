using Sirenix.OdinInspector;

using TalusFramework.Runtime.Collections.Interfaces;
using TalusFramework.Runtime.Variables;

using UnityEngine;

namespace TalusFramework.Runtime.Collections.VariableCollections
{
    [CreateAssetMenu(fileName = "New Vector2 Variable Collection", menuName = "Collections/Variable Collections/Vector2", order = 7)]
    public class Vector2VariableCollection : BaseCollection<Vector2Variable>
    {
        [FoldoutGroup("Actions")]
        [Button]
        public void ResetAllValues(Vector2 value)
        {
            for (int i = 0; i < Items.Count; ++i)
            {
                Items[i].SetValue(value);
            }
        }
    }
}