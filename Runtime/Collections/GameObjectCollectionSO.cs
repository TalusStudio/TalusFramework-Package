using TalusFramework.Runtime.Collections.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Collections
{
    [CreateAssetMenu(fileName = "New GameObject Collection", menuName = "Collections/GameObject", order = 2)]
    public class GameObjectCollectionSO : BaseCollectionSO<GameObject>
    { }
}