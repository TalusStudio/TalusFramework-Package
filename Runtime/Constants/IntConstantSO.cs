using Sirenix.OdinInspector;
using TalusFramework.Runtime.Constants.Interfaces;
using UnityEngine;

namespace TalusFramework.Runtime.Constants
{
    [CreateAssetMenu(fileName = "New Int Constant", menuName = "Constants/Int", order = 2)]
    [HideMonoScript]
    public sealed class IntConstantSO : BaseConstantSO<int>
    {
        public override string ToString() => "Const Int";
    }
}
