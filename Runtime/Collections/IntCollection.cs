using TalusFramework.Runtime.Collections.Interfaces;
using TalusFramework.Runtime.Variables;

using UnityEngine;

namespace TalusFramework.Runtime.Collections
{
    [CreateAssetMenu(fileName = "New Int Variable Collection", menuName = "Collections/Int Variable", order = 3)]
    public class IntCollection : BaseCollection<IntVariable>
    {
        public void ResetAllValues(int value)
        {
            for (int i = 0; i < Items.Count; ++i)
            {
                Items[i].SetValue(value);
            }
        }
    }
}