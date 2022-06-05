using TalusFramework.Responses.Interfaces;

using UnityEngine;

namespace TalusFramework.Responses
{
    [CreateAssetMenu(fileName = "New GameObject Response", menuName = "Responses/GameObject", order = 6)]
    public sealed class GameObjectResponse : Response<GameObject>
    { }
}
