using Sirenix.OdinInspector;

using TalusFramework.Runtime.Responses.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Responses
{
	[CreateAssetMenu(fileName = "New Vector3 Response", menuName = "Responses/Vector3", order = 5)]
	[HideMonoScript]
	public sealed class Vector3Response : ResponseSO<Vector3> { }
}
