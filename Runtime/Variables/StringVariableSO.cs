using Sirenix.OdinInspector;
using TalusFramework.Runtime.Constants;
using TalusFramework.Runtime.Variables.Interfaces;
using UnityEngine;

namespace TalusFramework.Runtime.Variables
{
    [CreateAssetMenu(fileName = "New String Variable", menuName = "Variables/String", order = 3)]
    [HideMonoScript]
    public sealed class StringVariableSO : BaseVariableSO<string, StringVariableSO, StringConstantSO>
    {
        public override string ToString() => typeof(string).ToString();
    }
}
