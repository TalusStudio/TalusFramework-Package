using TalusFramework.Runtime.Collections.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Collections
{
    [CreateAssetMenu(fileName = "New GameObject Collection", menuName = "Collections/GameObject", order = 4)]
    public class GameObjectCollection : BaseCollection<GameObject>
    { }
}