using TalusFramework.Runtime.Collections.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Collections
{
    [CreateAssetMenu(fileName = "New Component Collection", menuName = "Collections/Component", order = 2)]
    public class ComponentCollection : BaseCollection<Component>
    { }
}