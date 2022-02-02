using TalusFramework.Runtime.Collections.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Collections
{
    [CreateAssetMenu(fileName = "New Transform Collection", menuName = "Collections/Transform", order = 1)]
    public class TransformCollection : BaseCollection<Transform>
    { }
}