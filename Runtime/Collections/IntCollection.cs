using UnityEngine;

using TalusFramework.Collections.Interfaces;

namespace TalusFramework.Collections
{
    [CreateAssetMenu(fileName = "New Int Collection", menuName = "Collections/Int", order = 1)]
    public class IntCollection : BaseCollection<int>
    { }
}