using Sirenix.OdinInspector;

using TalusFramework.Runtime.Collections.Interfaces;
using TalusFramework.Runtime.Variables;

using UnityEngine;

namespace TalusFramework.Runtime.Collections.VariableCollections
{
    [CreateAssetMenu(fileName = "New GameObject Variable Collection", menuName = "Collections/Variable Collections/GameObject", order = 3)]
    public class GameObjectVariableCollection : BaseCollection<GameObjectVariable>
    {
        [FoldoutGroup("Actions")]
        [Button]
        public void ResetAllValues(GameObject value)
        {
            for (int i = 0; i < Items.Count; ++i)
            {
                Items[i].SetValue(value);
            }
        }
    }
}