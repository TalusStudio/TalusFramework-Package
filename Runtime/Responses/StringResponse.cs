using TalusFramework.Runtime.Responses.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Responses
{
    [CreateAssetMenu(fileName = "New String Response", menuName = "Responses/String", order = 3)]
    public sealed class StringResponse : Response<string>
    { }
}
