using Sirenix.OdinInspector;

using TalusFramework.Runtime.Constants.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Constants
{
	[CreateAssetMenu(fileName = "New Bool Constant", menuName = "Constants/Bool", order = 0)]
	[HideMonoScript]
	public sealed class BoolConstantSO : BaseConstantSO<bool> { }
}
