using TalusFramework.Responses.Interfaces;

using UnityEngine;

namespace TalusFramework.Responses
{
    [CreateAssetMenu(fileName = "New String Response", menuName = "Responses/String", order = 6)]
    public sealed class StringResponse : Response<string>
    { }
}
