using UnityEngine;

using TalusFramework.Collections.Interfaces;

namespace TalusFramework.Collections
{
    [CreateAssetMenu(fileName = "New Bool Collection", menuName = "Collections/Bool", order = 0)]
    public class BoolCollection : BaseCollection<bool>
    { }
}