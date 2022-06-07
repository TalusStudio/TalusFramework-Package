using TalusFramework.Collections.Interfaces;

using UnityEngine;

namespace TalusFramework.Collections
{
    [CreateAssetMenu(fileName = "New GameObject Collection", menuName = "Collections/GameObject", order = 9)]
    public class GameObjectCollection : BaseCollection<GameObject>
    { }
}