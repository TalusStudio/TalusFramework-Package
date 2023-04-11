using UnityEngine;

using TalusFramework.Collections.Interfaces;

namespace TalusFramework.Collections
{
    [CreateAssetMenu(fileName = "New GameObject Collection", menuName = "Collections/GameObject", order = 10)]
    public class GameObjectCollection : BaseCollection<GameObject>
    { }
}