using TalusFramework.Runtime.Responses.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Responses
{
    [CreateAssetMenu(fileName = "New Int Response", menuName = "Responses/Int", order = 2)]
    public sealed class IntResponse : Response<int>
    { }
}
