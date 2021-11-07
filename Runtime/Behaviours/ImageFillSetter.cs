using Sirenix.OdinInspector;

using TalusFramework.Runtime.References;

using UnityEngine;
using UnityEngine.UI;

namespace TalusFramework.Runtime.Behaviours
{
	[HideMonoScript]
	public class ImageFillSetter : MonoBehaviour
	{
		[Tooltip("Image to set the fill amount on.")]
		[Required]
		[LabelWidth(65)]
		public Image Image;

		[Tooltip("Value to use as the current ")]
		[LabelWidth(50)]
		public FloatReference Variable;

		[Tooltip("Min value that Variable to have no fill on Image.")]
		[LabelWidth(50)]
		public FloatReference Min;

		[Tooltip("Max value that Variable can be to fill Image.")]
		[LabelWidth(50)]
		public FloatReference Max;

		private void Update()
		{
			Image.fillAmount = Mathf.Clamp01(Mathf.InverseLerp(Min.Value, Max.Value, Variable.Value));
		}
	}
}
