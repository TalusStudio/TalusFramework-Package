using Sirenix.OdinInspector;
using TalusFramework.Runtime.Constants;
using TalusFramework.Runtime.Variables.Interfaces;
using UnityEngine;

namespace TalusFramework.Runtime.Variables
{
    [CreateAssetMenu(fileName = "New GameObject Variable", menuName = "Variables/GameObject", order = 6)]
    [HideMonoScript]
    public sealed class GameObjectVariableSO : BaseVariableSO<GameObject, GameObjectVariableSO, GameObjectConstantSO>
    { }
}
