using Sirenix.OdinInspector;
using TalusFramework.Runtime.Constants;
using TalusFramework.Runtime.Variables.Interfaces;
using UnityEngine;

namespace TalusFramework.Runtime.Variables
{
    [CreateAssetMenu(fileName = "New Vector2 Variable", menuName = "Variables/Vector2", order = 4)]
    [HideMonoScript]
    public sealed class Vector2VariableSO : BaseVariableSO<Vector2, Vector2VariableSO, Vector2ConstantSO>
    { }
}
