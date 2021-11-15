using Sirenix.OdinInspector;

using TalusFramework.Runtime.Responses.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Responses
{
    [CreateAssetMenu(fileName = "New Float Response", menuName = "Responses/float", order = 1)]
    [HideMonoScript]
    public sealed class FloatResponse : ResponseSO<float>
    { }
}
