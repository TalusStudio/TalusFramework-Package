using Sirenix.OdinInspector;

using TalusFramework.Runtime.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Variables
{
	[CreateAssetMenu(fileName = "New Vector3 Variable", menuName = "Variables/Vector3", order = 5)]
	[HideMonoScript]
	public sealed class Vector3VariableSO : BaseVariableSO<Vector3> { }
}
