using Sirenix.OdinInspector;

using TalusFramework.Runtime.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Variables
{
	[CreateAssetMenu(fileName = "New Float Variable", menuName = "Variables/Float", order = 1)]
	[HideMonoScript]
	public sealed class FloatVariableSO : BaseVariableSO<float> { }
}
