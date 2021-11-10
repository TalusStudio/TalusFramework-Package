using Sirenix.OdinInspector;

using TalusFramework.Runtime.References.Interfaces;

using UnityEngine;
using UnityEngine.Events;

namespace TalusFramework.Runtime.Responses.Interfaces
{
	public class ResponseSO<T> : BaseResponseSO<T>
	{
		[FoldoutGroup("Arguments")]
		[ToggleLeft]
		public bool UseDynamicArgument;

		[FoldoutGroup("Arguments")]
		[ShowIf("@UseDynamicArgument == false")]
		[LabelWidth(60)]
		[SerializeField]
		private BaseReference<T> _Argument;

		[SerializeField]
		private UnityEvent<T> _Response;

		public override UnityEvent<T> Response
		{
			get => _Response;
			set => _Response = value;
		}

		[DisableInEditorMode]
		[Button(ButtonSizes.Large, ButtonStyle.FoldoutButton)] [GUIColor(0f, 1f, 0f)]
		public override void Invoke() => Response.Invoke(_Argument.Value);

		[DisableInEditorMode]
		[Button(ButtonSizes.Small, ButtonStyle.CompactBox)] [GUIColor(1f, 1f, 0f)]
		[LabelText("Dynamic Context")]
		public void Invoke(T argument) => Response.Invoke(argument);
	}
}
