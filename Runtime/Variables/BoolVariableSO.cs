using Sirenix.OdinInspector;

using TalusFramework.Runtime.Variables.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Variables
{
    [CreateAssetMenu(fileName = "New Bool Variable", menuName = "Variables/Bool", order = 0)]
    [HideMonoScript]
    public sealed class BoolVariableSO : BaseVariableSO<bool>
    { }
}
