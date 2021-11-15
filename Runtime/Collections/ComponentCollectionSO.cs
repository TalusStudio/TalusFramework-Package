using Sirenix.OdinInspector;

using TalusFramework.Runtime.Collections.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Collections
{
    [HideMonoScript]
    [CreateAssetMenu(fileName = "New Component Runtime Set", menuName = "Collections/Component Runtime Set", order = 2)]
    public class ComponentCollectionSO : BaseCollectionSO<Component>
    { }
}
