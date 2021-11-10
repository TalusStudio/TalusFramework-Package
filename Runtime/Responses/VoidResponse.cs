using Sirenix.OdinInspector;

using TalusFramework.Runtime.Responses.Interfaces;

using UnityEngine;
using UnityEngine.Events;

namespace TalusFramework.Runtime.Responses
{
	[CreateAssetMenu(fileName = "New Void Response", menuName = "Responses/Void", order = 10)]
	[HideMonoScript]
	public sealed class VoidResponse : BaseResponseSO
	{
		[LabelWidth(85)]
		public UnityEvent Response;

		[Button(ButtonSizes.Large)] [GUIColor(0f, 1f, 0f)]
		public override void Invoke() { Response.Invoke(); }
	}
}
