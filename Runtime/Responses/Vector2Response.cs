using Sirenix.OdinInspector;

using TalusFramework.Runtime.Responses.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Responses
{
    [CreateAssetMenu(fileName = "New Vector2 Response", menuName = "Responses/Vector2", order = 4)]
    [HideMonoScript]
    public sealed class Vector2Response : ResponseSO<Vector2>
    { }
}
