using Sirenix.OdinInspector;

using TalusFramework.Collections.Interfaces;
using TalusFramework.Variables;

using UnityEngine;

namespace TalusFramework.Collections.VariableCollections
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