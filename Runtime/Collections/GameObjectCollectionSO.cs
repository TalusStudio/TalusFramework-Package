using Sirenix.OdinInspector;

using TalusFramework.Runtime.Collections.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Collections
{
    [HideMonoScript]
    [CreateAssetMenu(fileName = "New GameObject Runtime Set", menuName = "Collections/GameObject Runtime Set",
        order = 0)]
    public class GameObjectCollectionSO : BaseCollectionSO<GameObject>
    { }
}
