using Sirenix.OdinInspector;

using TalusFramework.Runtime.Responses.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Responses
{
    [CreateAssetMenu(fileName = "New GameObject Response", menuName = "Responses/GameObject", order = 6)]
    [HideMonoScript]
    public sealed class GameObjectResponse : ResponseSO<GameObject>
    { }
}
