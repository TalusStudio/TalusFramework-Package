using Sirenix.OdinInspector;

using TalusFramework.Runtime.Constants.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Constants
{
	[CreateAssetMenu(fileName = "New String Constant", menuName = "Constants/String", order = 3)]
	[HideMonoScript]
	public sealed class StringConstantSO : BaseConstantSO<string> { }
}
