using TalusFramework.Runtime.Collections.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Collections
{
    [CreateAssetMenu(fileName = "New Transform Collection", menuName = "Collections/Transform", order = 9)]
    public class TransformCollection : BaseCollection<Transform>
    { }
}