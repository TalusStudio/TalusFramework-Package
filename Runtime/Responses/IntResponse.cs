using Sirenix.OdinInspector;

using TalusFramework.Runtime.Responses.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Responses
{
    [CreateAssetMenu(fileName = "New Int Response", menuName = "Responses/Int", order = 2)]
    [HideMonoScript]
    public sealed class IntResponse : ResponseSO<int>
    { }
}
