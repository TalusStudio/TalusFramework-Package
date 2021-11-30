using TalusFramework.Runtime.Responses.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Responses
{
    [CreateAssetMenu(fileName = "New Bool Response", menuName = "Responses/Bool", order = 0)]
    public sealed class BoolResponse : ResponseSO<bool>
    { }
}
