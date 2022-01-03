using TalusFramework.Runtime.Collections.Interfaces;
using TalusFramework.Runtime.Variables;

using UnityEngine;

namespace TalusFramework.Runtime.Collections
{
    [CreateAssetMenu(fileName = "New Float Variable Collection", menuName = "Collections/Float Variable", order = 4)]
    public class FloatCollectionSO : BaseCollectionSO<FloatVariableSO>
    {
        public void ResetAllValues(float value)
        {
            for (int i = 0; i < Items.Count; ++i)
            {
                Items[i].SetValue(value);
            }
        }
    }
}