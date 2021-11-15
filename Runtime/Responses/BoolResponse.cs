using Sirenix.OdinInspector;

using TalusFramework.Runtime.Responses.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Responses
{
    [CreateAssetMenu(fileName = "New Bool Response", menuName = "Responses/Bool", order = 0)]
    [HideMonoScript]
    public sealed class BoolResponse : ResponseSO<bool>
    { }
}
