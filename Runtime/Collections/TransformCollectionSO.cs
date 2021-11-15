using Sirenix.OdinInspector;

using TalusFramework.Runtime.Collections.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Collections
{
    [HideMonoScript]
    [CreateAssetMenu(fileName = "New Transform Runtime Set", menuName = "Collections/Transform Runtime Set", order = 1)]
    public class TransformCollectionSO : BaseCollectionSO<Transform>
    { }
}
