using Sirenix.OdinInspector;
using TalusFramework.Runtime.Constants;
using TalusFramework.Runtime.Variables.Interfaces;
using UnityEngine;

namespace TalusFramework.Runtime.Variables
{
    [CreateAssetMenu(fileName = "New Int Variable", menuName = "Variables/Int", order = 2)]
    [HideMonoScript]
    public sealed class IntVariableSO : BaseVariableSO<int, IntVariableSO, IntConstantSO>
    { }
}
