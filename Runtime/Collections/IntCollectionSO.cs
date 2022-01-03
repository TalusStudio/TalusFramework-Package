using TalusFramework.Runtime.Collections.Interfaces;
using TalusFramework.Runtime.Variables;

using UnityEngine;

namespace TalusFramework.Runtime.Collections
{
    [CreateAssetMenu(fileName = "New Int Variable Collection", menuName = "Collections/Int Variable", order = 3)]
    public class IntCollectionSO : BaseCollectionSO<IntVariableSO>
    { }
}