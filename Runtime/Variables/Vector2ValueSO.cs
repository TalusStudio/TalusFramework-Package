using Sirenix.OdinInspector;
using TalusFramework.Runtime.Variables.Interfaces;
using UnityEngine;

namespace TalusFramework.Runtime.Variables
{
    [CreateAssetMenu(fileName = "New Vector2 Variable", menuName = "Variables/Vector2", order = 4)]
    [HideMonoScript]
    public sealed class Vector2ValueSO : BaseVariableSO<Vector2>
	{ }
}
