using TalusFramework.Runtime.Collections.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Collections
{
    [CreateAssetMenu(fileName = "New Transform Collection", menuName = "Collections/Transform", order = 7)]
    public class TransformCollection : BaseCollection<Transform>
    { }
}