using Sirenix.OdinInspector;

using TalusFramework.Runtime.Responses.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Responses
{
	[CreateAssetMenu(fileName = "New String Response", menuName = "Responses/String", order = 3)]
	[HideMonoScript]
	public sealed class StringResponse : ResponseSO<string> { }
}
